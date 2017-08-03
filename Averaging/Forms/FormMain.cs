// Copyright ©2016-2017 Copper Mountain Technologies
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
// ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Averaging
{
    public partial class FormMain : Form
    {
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private enum ComConnectionStateEnum
        {
            INITIALIZED,
            NOT_CONNECTED,
            CONNECTED_VNA_NOT_READY,
            CONNECTED_VNA_READY
        }

        private ComConnectionStateEnum previousComConnectionState = ComConnectionStateEnum.INITIALIZED;
        private ComConnectionStateEnum comConnectionState = ComConnectionStateEnum.NOT_CONNECTED;

        private int selectedChannel = -1;

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        public FormMain()
        {
            InitializeComponent();

            // --------------------------------------------------------------------------------------------------------

            // set form icon
            Icon = Properties.Resources.app_icon;

            // set form title
            Text = Program.programName;

            // disable resizing the window
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;

            // position the plug-in in the lower right corner of the screen
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width - 130,
                                 workingArea.Bottom - Size.Height - 50);

            // always display on top
            TopMost = true;

            // --------------------------------------------------------------------------------------------------------

            // disable ui
            panelMain.Enabled = false;

            // set version label text
            toolStripStatusLabelVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            // init averaging factor numeric up down
            numericUpDownAveragingFactor.Minimum = 1;
            numericUpDownAveragingFactor.Maximum = 999;
            numericUpDownAveragingFactor.DecimalPlaces = 0;
            numericUpDownAveragingFactor.Value = 10;

            labelAveragingFactor.Enabled = false;
            numericUpDownAveragingFactor.Enabled = false;
            buttonRestartAveraging.Enabled = false;

            // --------------------------------------------------------------------------------------------------------

            // start the ready timer
            readyTimer.Interval = 250; // 250 ms interval
            readyTimer.Enabled = true;
            readyTimer.Start();

            // start the update timer
            updateTimer.Interval = 250; // 250 ms interval
            updateTimer.Enabled = true;
            updateTimer.Start();

            // --------------------------------------------------------------------------------------------------------
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Timers
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void readyTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // is vna ready?
                if (Program.vna.app.Ready)
                {
                    // yes... vna is ready
                    comConnectionState = ComConnectionStateEnum.CONNECTED_VNA_READY;
                }
                else
                {
                    // no... vna is not ready
                    comConnectionState = ComConnectionStateEnum.CONNECTED_VNA_NOT_READY;
                }
            }
            catch (COMException)
            {
                // com connection has been lost
                comConnectionState = ComConnectionStateEnum.NOT_CONNECTED;
                Application.Exit();
                return;
            }

            if (comConnectionState != previousComConnectionState)
            {
                previousComConnectionState = comConnectionState;

                switch (comConnectionState)
                {
                    default:
                    case ComConnectionStateEnum.NOT_CONNECTED:

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = Color.White;
                        toolStripStatusLabelVnaInfo.BackColor = Color.Red;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = "VNA NOT CONNECTED";

                        // disable ui
                        panelMain.Enabled = false;

                        break;

                    case ComConnectionStateEnum.CONNECTED_VNA_NOT_READY:

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = Color.White;
                        toolStripStatusLabelVnaInfo.BackColor = Color.Red;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = "VNA NOT READY";

                        // disable ui
                        panelMain.Enabled = false;

                        break;

                    case ComConnectionStateEnum.CONNECTED_VNA_READY:

                        // get vna info
                        Program.vna.PopulateInfo(Program.vna.app.NAME);

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = SystemColors.ControlText;
                        toolStripStatusLabelVnaInfo.BackColor = SystemColors.Control;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = Program.vna.modelString + "   " + "SN:" + Program.vna.serialNumberString + "   " + Program.vna.versionString;

                        // enable ui
                        panelMain.Enabled = true;

                        break;
                }
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (comConnectionState == ComConnectionStateEnum.CONNECTED_VNA_READY)
            {
                // update the channel combo box
                if (dropDownListActiveChannel.DroppedDown == false)
                {
                    updateDropDownListActiveChannel();
                }

                // update the averaging check box
                updateCheckBoxAveraging();

                // update the averaging factor numeric up down
                updateNumericUpDownAveragingFactor();

                // update averaging ui enabled state
                updateAveragingUiEnabledState();
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Channel
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void updateDropDownListActiveChannel()
        {
            // save previously selected channel index
            int selectedChannelIndex = dropDownListActiveChannel.SelectedIndex;

            // prevent combo box from flickering when update occurs
            dropDownListActiveChannel.BeginUpdate();

            // clear channel selection combo box
            dropDownListActiveChannel.Items.Clear();

            long splitIndex = 0;
            long activeChannel = 0;
            try
            {
                // get the split index (needed to determine number of channels)
                splitIndex = Program.vna.app.SCPI.DISPlay.SPLit;

                // determine the active channel
                activeChannel = Program.vna.app.SCPI.SERVice.CHANnel.ACTive;
            }
            catch (COMException)
            {
            }

            // determine number of channels from the split index
            int numOfChannels = Program.vna.DetermineNumberOfChannels(splitIndex);

            // populate the channel number combo box
            for (int ch = 1; ch < numOfChannels + 1; ch++)
            {
                dropDownListActiveChannel.Items.Add(ch.ToString());
            }

            // init channel selection to the active channel
            dropDownListActiveChannel.Text = activeChannel.ToString();

            // prevent combo box from flickering when update occurs
            dropDownListActiveChannel.EndUpdate();
        }

        // ------------------------------------------------------------------------------------------------------------

        private void dropDownListActiveChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has channel selection changed?
            if (selectedChannel != dropDownListActiveChannel.SelectedIndex + 1)
            {
                {
                    // yes... update selected channel
                    selectedChannel = dropDownListActiveChannel.SelectedIndex + 1;

                    long activeTrace = 0;
                    try
                    {
                        if (selectedChannel > -1)
                        {
                            object err;

                            // determine the active trace for this channel
                            activeTrace = Program.vna.app.SCPI.SERVice.CHANnel[selectedChannel].TRACe.ACTive;

                            // set the active channel
                            err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[activeTrace].SELect;
                        }
                    }
                    catch (COMException ex)
                    {
                        // display error message
                        showMessageBoxForComException(ex);
                        return;
                    }
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void updateCheckBoxAveraging()
        {
            try
            {
                if (selectedChannel > -1)
                {
                    // read the averaging on/off state
                    checkBoxAveraging.Checked = Program.vna.app.SCPI.SENSe[selectedChannel].AVERage.STATe;
                }
            }
            catch (COMException)
            {
            }
        }

        private void checkBoxAveraging_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectedChannel > -1)
                {
                    // set the averaging on/off state
                    Program.vna.app.SCPI.SENSe[selectedChannel].AVERage.STATe = checkBoxAveraging.Checked;
                }
            }
            catch (COMException ex)
            {
                // display error message
                showMessageBoxForComException(ex);
                return;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void updateNumericUpDownAveragingFactor()
        {
            try
            {
                if (selectedChannel > -1)
                {
                    // read the averaging factor
                    long factor = Program.vna.app.SCPI.SENSe[selectedChannel].AVERage.COUNt;
                    numericUpDownAveragingFactor.Value = Convert.ToDecimal(factor);
                }
            }
            catch (COMException)
            {
            }
        }

        private void numericUpDownAveragingFactor_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectedChannel > -1)
                {
                    // set the averaging factor
                    long factor = Convert.ToInt64(numericUpDownAveragingFactor.Value);
                    Program.vna.app.SCPI.SENSe[selectedChannel].AVERage.COUNt = factor;
                }
            }
            catch (COMException ex)
            {
                // display error message
                showMessageBoxForComException(ex);
                return;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void buttonRestartAveraging_Click(object sender, EventArgs e)
        {
            if (comConnectionState == ComConnectionStateEnum.CONNECTED_VNA_READY)
            {
                try
                {
                    if (selectedChannel > -1)
                    {
                        object err;

                        // restart the averaging process
                        err = Program.vna.app.SCPI.SENSe[selectedChannel].AVERage.CLEar;
                    }
                }
                catch (COMException ex)
                {
                    // display error message
                    showMessageBoxForComException(ex);
                    return;
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void updateAveragingUiEnabledState()
        {
            labelAveragingFactor.Enabled = checkBoxAveraging.Checked;
            numericUpDownAveragingFactor.Enabled = checkBoxAveraging.Checked;
            buttonRestartAveraging.Enabled = checkBoxAveraging.Checked;
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void showMessageBoxForComException(COMException e)
        {
            MessageBox.Show(Program.vna.GetUserMessageForComException(e),
                Program.programName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    }
}