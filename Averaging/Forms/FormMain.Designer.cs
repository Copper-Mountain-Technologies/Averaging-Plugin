namespace Averaging
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.readyTimer = new System.Windows.Forms.Timer(this.components);
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelVnaInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxAveraging = new System.Windows.Forms.GroupBox();
            this.buttonRestartAveraging = new System.Windows.Forms.Button();
            this.labelAveragingFactor = new System.Windows.Forms.Label();
            this.numericUpDownAveragingFactor = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAveraging = new System.Windows.Forms.CheckBox();
            this.dropDownListActiveChannel = new System.Windows.Forms.ComboBox();
            this.labelDropDownListActiveChannel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxAveraging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAveragingFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // readyTimer
            // 
            this.readyTimer.Interval = 1000;
            this.readyTimer.Tick += new System.EventHandler(this.readyTimer_Tick);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVnaInfo,
            this.toolStripStatusLabelSpacer,
            this.toolStripStatusLabelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 143);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 28;
            // 
            // toolStripStatusLabelVnaInfo
            // 
            this.toolStripStatusLabelVnaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVnaInfo.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVnaInfo.Name = "toolStripStatusLabelVnaInfo";
            this.toolStripStatusLabelVnaInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripStatusLabelVnaInfo.Size = new System.Drawing.Size(27, 17);
            this.toolStripStatusLabelVnaInfo.Text = "     ";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(206, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabelVersion.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelVersion.Text = "v ---";
            this.toolStripStatusLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxAveraging);
            this.panelMain.Controls.Add(this.dropDownListActiveChannel);
            this.panelMain.Controls.Add(this.labelDropDownListActiveChannel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(284, 165);
            this.panelMain.TabIndex = 36;
            // 
            // groupBoxAveraging
            // 
            this.groupBoxAveraging.Controls.Add(this.buttonRestartAveraging);
            this.groupBoxAveraging.Controls.Add(this.labelAveragingFactor);
            this.groupBoxAveraging.Controls.Add(this.numericUpDownAveragingFactor);
            this.groupBoxAveraging.Controls.Add(this.checkBoxAveraging);
            this.groupBoxAveraging.Location = new System.Drawing.Point(12, 49);
            this.groupBoxAveraging.Name = "groupBoxAveraging";
            this.groupBoxAveraging.Size = new System.Drawing.Size(260, 85);
            this.groupBoxAveraging.TabIndex = 1;
            this.groupBoxAveraging.TabStop = false;
            // 
            // buttonRestartAveraging
            // 
            this.buttonRestartAveraging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestartAveraging.Location = new System.Drawing.Point(131, 17);
            this.buttonRestartAveraging.Name = "buttonRestartAveraging";
            this.buttonRestartAveraging.Size = new System.Drawing.Size(118, 58);
            this.buttonRestartAveraging.TabIndex = 35;
            this.buttonRestartAveraging.Text = "&Restart Averaging";
            this.buttonRestartAveraging.UseVisualStyleBackColor = true;
            this.buttonRestartAveraging.Click += new System.EventHandler(this.buttonRestartAveraging_Click);
            // 
            // labelAveragingFactor
            // 
            this.labelAveragingFactor.AutoSize = true;
            this.labelAveragingFactor.Location = new System.Drawing.Point(7, 38);
            this.labelAveragingFactor.Name = "labelAveragingFactor";
            this.labelAveragingFactor.Size = new System.Drawing.Size(91, 13);
            this.labelAveragingFactor.TabIndex = 2;
            this.labelAveragingFactor.Text = "Averaging &Factor:";
            // 
            // numericUpDownAveragingFactor
            // 
            this.numericUpDownAveragingFactor.Location = new System.Drawing.Point(10, 54);
            this.numericUpDownAveragingFactor.Name = "numericUpDownAveragingFactor";
            this.numericUpDownAveragingFactor.Size = new System.Drawing.Size(115, 20);
            this.numericUpDownAveragingFactor.TabIndex = 2;
            this.numericUpDownAveragingFactor.ValueChanged += new System.EventHandler(this.numericUpDownAveragingFactor_ValueChanged);
            // 
            // checkBoxAveraging
            // 
            this.checkBoxAveraging.AutoSize = true;
            this.checkBoxAveraging.Location = new System.Drawing.Point(11, 18);
            this.checkBoxAveraging.Name = "checkBoxAveraging";
            this.checkBoxAveraging.Size = new System.Drawing.Size(74, 17);
            this.checkBoxAveraging.TabIndex = 1;
            this.checkBoxAveraging.Text = "&Averaging";
            this.checkBoxAveraging.UseVisualStyleBackColor = true;
            this.checkBoxAveraging.CheckedChanged += new System.EventHandler(this.checkBoxAveraging_CheckedChanged);
            // 
            // dropDownListActiveChannel
            // 
            this.dropDownListActiveChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownListActiveChannel.FormattingEnabled = true;
            this.dropDownListActiveChannel.Location = new System.Drawing.Point(12, 25);
            this.dropDownListActiveChannel.Name = "dropDownListActiveChannel";
            this.dropDownListActiveChannel.Size = new System.Drawing.Size(260, 21);
            this.dropDownListActiveChannel.TabIndex = 0;
            this.dropDownListActiveChannel.SelectedIndexChanged += new System.EventHandler(this.dropDownListActiveChannel_SelectedIndexChanged);
            // 
            // labelDropDownListActiveChannel
            // 
            this.labelDropDownListActiveChannel.AutoSize = true;
            this.labelDropDownListActiveChannel.Location = new System.Drawing.Point(11, 9);
            this.labelDropDownListActiveChannel.Name = "labelDropDownListActiveChannel";
            this.labelDropDownListActiveChannel.Size = new System.Drawing.Size(82, 13);
            this.labelDropDownListActiveChannel.TabIndex = 0;
            this.labelDropDownListActiveChannel.Text = "Active &Channel:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMain";
            this.Text = "< application title goes here >";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxAveraging.ResumeLayout(false);
            this.groupBoxAveraging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAveragingFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer readyTimer;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVnaInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox dropDownListActiveChannel;
        private System.Windows.Forms.Label labelDropDownListActiveChannel;
        private System.Windows.Forms.GroupBox groupBoxAveraging;
        private System.Windows.Forms.Label labelAveragingFactor;
        private System.Windows.Forms.NumericUpDown numericUpDownAveragingFactor;
        private System.Windows.Forms.CheckBox checkBoxAveraging;
        private System.Windows.Forms.Button buttonRestartAveraging;
    }
}

