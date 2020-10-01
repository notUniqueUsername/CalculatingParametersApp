﻿namespace ParametersApp
{
    partial class FormForGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForGraph));
            this.GraphControl = new ZedGraph.ZedGraphControl();
            this.FreqMinLabel = new System.Windows.Forms.Label();
            this.DotDotLabel = new System.Windows.Forms.Label();
            this.FreqMinTextBox = new System.Windows.Forms.TextBox();
            this.FreqMaxTextBox = new System.Windows.Forms.TextBox();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.NfTextBox = new System.Windows.Forms.TextBox();
            this.ErpLabel = new System.Windows.Forms.Label();
            this.KLabel = new System.Windows.Forms.Label();
            this.RpLabel = new System.Windows.Forms.Label();
            this.RzLabel = new System.Windows.Forms.Label();
            this.Z1Label = new System.Windows.Forms.Label();
            this.ErcLabel = new System.Windows.Forms.Label();
            this.RcLabel = new System.Windows.Forms.Label();
            this.Z2Label = new System.Windows.Forms.Label();
            this.Z1outTextBox = new System.Windows.Forms.TextBox();
            this.Z1outLabel = new System.Windows.Forms.Label();
            this.Z2inTextBox = new System.Windows.Forms.TextBox();
            this.Z1inTextBox = new System.Windows.Forms.TextBox();
            this.Z2inLabel = new System.Windows.Forms.Label();
            this.Z1inLabel = new System.Windows.Forms.Label();
            this.Z2outTextBox = new System.Windows.Forms.TextBox();
            this.Z2outLabel = new System.Windows.Forms.Label();
            this.SParamListBox = new System.Windows.Forms.CheckedListBox();
            this.MagnitudeRadioButton = new System.Windows.Forms.RadioButton();
            this.PhaseRadioButton = new System.Windows.Forms.RadioButton();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ZInOutFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NfLabel = new System.Windows.Forms.Label();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.InputFlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.EEELabel = new System.Windows.Forms.Label();
            this.Z0Label = new System.Windows.Forms.Label();
            this.Z2cLabel = new System.Windows.Forms.Label();
            this.Z1pLabel = new System.Windows.Forms.Label();
            this.MLabel = new System.Windows.Forms.Label();
            this.Z1pToEEEFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Z1pToEEEColumn1FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Z1pToEEEColumn2FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Z0ToRpFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Z0ToRpColumn1FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Z0ToRpColumn2FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NLabel = new System.Windows.Forms.Label();
            this.Z0ToRpColumn3FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.S21Label = new System.Windows.Forms.Label();
            this.ShematicGroupBox = new System.Windows.Forms.GroupBox();
            this.LineToLineRadioButton = new System.Windows.Forms.RadioButton();
            this.GeneralRadioButton = new System.Windows.Forms.RadioButton();
            this.Z01Z02FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Z01Label = new System.Windows.Forms.Label();
            this.Z01TextBox = new System.Windows.Forms.TextBox();
            this.Z02Label = new System.Windows.Forms.Label();
            this.Z02TextBox = new System.Windows.Forms.TextBox();
            this.ShematicPictureBox = new System.Windows.Forms.PictureBox();
            this.ImageNameLabel = new System.Windows.Forms.Label();
            this.GraphNameLabel = new System.Windows.Forms.Label();
            this.ZInOutFlowLayoutPanel.SuspendLayout();
            this.InputFlowLayoutPanel1.SuspendLayout();
            this.Z1pToEEEFlowLayoutPanel.SuspendLayout();
            this.Z1pToEEEColumn1FlowLayoutPanel.SuspendLayout();
            this.Z1pToEEEColumn2FlowLayoutPanel.SuspendLayout();
            this.Z0ToRpFlowLayoutPanel.SuspendLayout();
            this.Z0ToRpColumn1FlowLayoutPanel.SuspendLayout();
            this.Z0ToRpColumn2FlowLayoutPanel.SuspendLayout();
            this.Z0ToRpColumn3FlowLayoutPanel.SuspendLayout();
            this.ShematicGroupBox.SuspendLayout();
            this.Z01Z02FlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShematicPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphControl
            // 
            this.GraphControl.Location = new System.Drawing.Point(246, 107);
            this.GraphControl.Name = "GraphControl";
            this.GraphControl.ScrollGrace = 0D;
            this.GraphControl.ScrollMaxX = 0D;
            this.GraphControl.ScrollMaxY = 0D;
            this.GraphControl.ScrollMaxY2 = 0D;
            this.GraphControl.ScrollMinX = 0D;
            this.GraphControl.ScrollMinY = 0D;
            this.GraphControl.ScrollMinY2 = 0D;
            this.GraphControl.Size = new System.Drawing.Size(562, 304);
            this.GraphControl.TabIndex = 0;
            this.GraphControl.UseExtendedPrintDialog = true;
            // 
            // FreqMinLabel
            // 
            this.FreqMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FreqMinLabel.AutoSize = true;
            this.FreqMinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FreqMinLabel.Location = new System.Drawing.Point(2, 13);
            this.FreqMinLabel.Margin = new System.Windows.Forms.Padding(2);
            this.FreqMinLabel.Name = "FreqMinLabel";
            this.FreqMinLabel.Size = new System.Drawing.Size(68, 16);
            this.FreqMinLabel.TabIndex = 11;
            this.FreqMinLabel.Text = "Freq, GHz";
            // 
            // DotDotLabel
            // 
            this.DotDotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DotDotLabel.AutoSize = true;
            this.DotDotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DotDotLabel.Location = new System.Drawing.Point(125, 6);
            this.DotDotLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DotDotLabel.Name = "DotDotLabel";
            this.DotDotLabel.Size = new System.Drawing.Size(24, 25);
            this.DotDotLabel.TabIndex = 12;
            this.DotDotLabel.Text = "..";
            // 
            // FreqMinTextBox
            // 
            this.FreqMinTextBox.Location = new System.Drawing.Point(76, 7);
            this.FreqMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqMinTextBox.Name = "FreqMinTextBox";
            this.FreqMinTextBox.Size = new System.Drawing.Size(45, 20);
            this.FreqMinTextBox.TabIndex = 13;
            this.FreqMinTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // FreqMaxTextBox
            // 
            this.FreqMaxTextBox.Location = new System.Drawing.Point(153, 7);
            this.FreqMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqMaxTextBox.Name = "FreqMaxTextBox";
            this.FreqMaxTextBox.Size = new System.Drawing.Size(45, 20);
            this.FreqMaxTextBox.TabIndex = 14;
            this.FreqMaxTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // LengthLabel
            // 
            this.LengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LengthLabel.Location = new System.Drawing.Point(2, 39);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(2);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(69, 16);
            this.LengthLabel.TabIndex = 15;
            this.LengthLabel.Text = "Leng., mm";
            // 
            // NfTextBox
            // 
            this.NfTextBox.Location = new System.Drawing.Point(154, 34);
            this.NfTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.NfTextBox.Name = "NfTextBox";
            this.NfTextBox.Size = new System.Drawing.Size(45, 20);
            this.NfTextBox.TabIndex = 16;
            this.NfTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForInt);
            // 
            // ErpLabel
            // 
            this.ErpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErpLabel.AutoSize = true;
            this.ErpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ErpLabel.Location = new System.Drawing.Point(0, 25);
            this.ErpLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.ErpLabel.Name = "ErpLabel";
            this.ErpLabel.Size = new System.Drawing.Size(73, 16);
            this.ErpLabel.TabIndex = 17;
            this.ErpLabel.Text = "Erп = 22,22";
            // 
            // KLabel
            // 
            this.KLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.KLabel.AutoSize = true;
            this.KLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.KLabel.Location = new System.Drawing.Point(0, 5);
            this.KLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.KLabel.Name = "KLabel";
            this.KLabel.Size = new System.Drawing.Size(59, 16);
            this.KLabel.TabIndex = 18;
            this.KLabel.Text = "k = 22.22";
            // 
            // RpLabel
            // 
            this.RpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RpLabel.AutoSize = true;
            this.RpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RpLabel.Location = new System.Drawing.Point(0, 45);
            this.RpLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.RpLabel.Name = "RpLabel";
            this.RpLabel.Size = new System.Drawing.Size(70, 16);
            this.RpLabel.TabIndex = 19;
            this.RpLabel.Text = "Rп = 22.22";
            // 
            // RzLabel
            // 
            this.RzLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RzLabel.AutoSize = true;
            this.RzLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RzLabel.Location = new System.Drawing.Point(0, 45);
            this.RzLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.RzLabel.Name = "RzLabel";
            this.RzLabel.Size = new System.Drawing.Size(68, 16);
            this.RzLabel.TabIndex = 20;
            this.RzLabel.Text = "Rz = 22.22";
            // 
            // Z1Label
            // 
            this.Z1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z1Label.AutoSize = true;
            this.Z1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z1Label.Location = new System.Drawing.Point(0, 25);
            this.Z1Label.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.Z1Label.Name = "Z1Label";
            this.Z1Label.Size = new System.Drawing.Size(83, 16);
            this.Z1Label.TabIndex = 21;
            this.Z1Label.Text = "Z1, Ω = 222.2";
            // 
            // ErcLabel
            // 
            this.ErcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErcLabel.AutoSize = true;
            this.ErcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ErcLabel.Location = new System.Drawing.Point(0, 5);
            this.ErcLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.ErcLabel.Name = "ErcLabel";
            this.ErcLabel.Size = new System.Drawing.Size(72, 16);
            this.ErcLabel.TabIndex = 22;
            this.ErcLabel.Text = "Erc = 22,22";
            // 
            // RcLabel
            // 
            this.RcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RcLabel.AutoSize = true;
            this.RcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RcLabel.Location = new System.Drawing.Point(0, 25);
            this.RcLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.RcLabel.Name = "RcLabel";
            this.RcLabel.Size = new System.Drawing.Size(69, 16);
            this.RcLabel.TabIndex = 23;
            this.RcLabel.Text = "Rc = 22.22";
            // 
            // Z2Label
            // 
            this.Z2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z2Label.AutoSize = true;
            this.Z2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z2Label.Location = new System.Drawing.Point(0, 45);
            this.Z2Label.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.Z2Label.Name = "Z2Label";
            this.Z2Label.Size = new System.Drawing.Size(83, 16);
            this.Z2Label.TabIndex = 24;
            this.Z2Label.Text = "Z2, Ω = 222.2";
            // 
            // Z1outTextBox
            // 
            this.Z1outTextBox.Location = new System.Drawing.Point(172, 3);
            this.Z1outTextBox.Name = "Z1outTextBox";
            this.Z1outTextBox.Size = new System.Drawing.Size(45, 20);
            this.Z1outTextBox.TabIndex = 34;
            this.Z1outTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // Z1outLabel
            // 
            this.Z1outLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z1outLabel.AutoSize = true;
            this.Z1outLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z1outLabel.Location = new System.Drawing.Point(109, 10);
            this.Z1outLabel.Name = "Z1outLabel";
            this.Z1outLabel.Size = new System.Drawing.Size(57, 16);
            this.Z1outLabel.TabIndex = 33;
            this.Z1outLabel.Text = "Z1out, Ω";
            // 
            // Z2inTextBox
            // 
            this.Z2inTextBox.Location = new System.Drawing.Point(58, 29);
            this.Z2inTextBox.Name = "Z2inTextBox";
            this.Z2inTextBox.Size = new System.Drawing.Size(45, 20);
            this.Z2inTextBox.TabIndex = 32;
            this.Z2inTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // Z1inTextBox
            // 
            this.Z1inTextBox.Location = new System.Drawing.Point(58, 3);
            this.Z1inTextBox.Name = "Z1inTextBox";
            this.Z1inTextBox.Size = new System.Drawing.Size(45, 20);
            this.Z1inTextBox.TabIndex = 31;
            this.Z1inTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // Z2inLabel
            // 
            this.Z2inLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z2inLabel.AutoSize = true;
            this.Z2inLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z2inLabel.Location = new System.Drawing.Point(3, 36);
            this.Z2inLabel.Name = "Z2inLabel";
            this.Z2inLabel.Size = new System.Drawing.Size(49, 16);
            this.Z2inLabel.TabIndex = 30;
            this.Z2inLabel.Text = "Z2in, Ω";
            // 
            // Z1inLabel
            // 
            this.Z1inLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z1inLabel.AutoSize = true;
            this.Z1inLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z1inLabel.Location = new System.Drawing.Point(3, 10);
            this.Z1inLabel.Name = "Z1inLabel";
            this.Z1inLabel.Size = new System.Drawing.Size(49, 16);
            this.Z1inLabel.TabIndex = 29;
            this.Z1inLabel.Text = "Z1in, Ω";
            // 
            // Z2outTextBox
            // 
            this.Z2outTextBox.Location = new System.Drawing.Point(172, 29);
            this.Z2outTextBox.Name = "Z2outTextBox";
            this.Z2outTextBox.Size = new System.Drawing.Size(45, 20);
            this.Z2outTextBox.TabIndex = 36;
            this.Z2outTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // Z2outLabel
            // 
            this.Z2outLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z2outLabel.AutoSize = true;
            this.Z2outLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z2outLabel.Location = new System.Drawing.Point(109, 36);
            this.Z2outLabel.Name = "Z2outLabel";
            this.Z2outLabel.Size = new System.Drawing.Size(57, 16);
            this.Z2outLabel.TabIndex = 35;
            this.Z2outLabel.Text = "Z2out, Ω";
            // 
            // SParamListBox
            // 
            this.SParamListBox.BackColor = System.Drawing.SystemColors.Control;
            this.SParamListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SParamListBox.CheckOnClick = true;
            this.SParamListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.SParamListBox.FormattingEnabled = true;
            this.SParamListBox.Items.AddRange(new object[] {
            "All",
            "S11",
            "S12",
            "S13",
            "S14",
            "S22",
            "S23",
            "S24",
            "S33",
            "S34",
            "S44"});
            this.SParamListBox.Location = new System.Drawing.Point(814, 136);
            this.SParamListBox.MultiColumn = true;
            this.SParamListBox.Name = "SParamListBox";
            this.SParamListBox.Size = new System.Drawing.Size(46, 176);
            this.SParamListBox.TabIndex = 37;
            this.SParamListBox.SelectedIndexChanged += new System.EventHandler(this.SParamListBox_SelectedIndexChanged);
            // 
            // MagnitudeRadioButton
            // 
            this.MagnitudeRadioButton.AutoSize = true;
            this.MagnitudeRadioButton.Checked = true;
            this.MagnitudeRadioButton.Location = new System.Drawing.Point(246, 85);
            this.MagnitudeRadioButton.Name = "MagnitudeRadioButton";
            this.MagnitudeRadioButton.Size = new System.Drawing.Size(97, 17);
            this.MagnitudeRadioButton.TabIndex = 38;
            this.MagnitudeRadioButton.TabStop = true;
            this.MagnitudeRadioButton.Text = "Magnitude (dB)";
            this.MagnitudeRadioButton.UseVisualStyleBackColor = true;
            this.MagnitudeRadioButton.CheckedChanged += new System.EventHandler(this.MagnitudeRadioButton_CheckedChanged);
            // 
            // PhaseRadioButton
            // 
            this.PhaseRadioButton.AutoSize = true;
            this.PhaseRadioButton.Location = new System.Drawing.Point(349, 85);
            this.PhaseRadioButton.Name = "PhaseRadioButton";
            this.PhaseRadioButton.Size = new System.Drawing.Size(82, 17);
            this.PhaseRadioButton.TabIndex = 39;
            this.PhaseRadioButton.Text = "Phase (deg)";
            this.PhaseRadioButton.UseVisualStyleBackColor = true;
            this.PhaseRadioButton.CheckedChanged += new System.EventHandler(this.PhaseRadioButton_CheckedChanged);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(814, 107);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(46, 23);
            this.DrawButton.TabIndex = 40;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ZInOutFlowLayoutPanel
            // 
            this.ZInOutFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z1inLabel);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z1inTextBox);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z1outLabel);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z1outTextBox);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z2inLabel);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z2inTextBox);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z2outLabel);
            this.ZInOutFlowLayoutPanel.Controls.Add(this.Z2outTextBox);
            this.ZInOutFlowLayoutPanel.Location = new System.Drawing.Point(12, 280);
            this.ZInOutFlowLayoutPanel.Name = "ZInOutFlowLayoutPanel";
            this.ZInOutFlowLayoutPanel.Size = new System.Drawing.Size(228, 63);
            this.ZInOutFlowLayoutPanel.TabIndex = 42;
            // 
            // NfLabel
            // 
            this.NfLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NfLabel.AutoSize = true;
            this.NfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.NfLabel.Location = new System.Drawing.Point(126, 39);
            this.NfLabel.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.NfLabel.Name = "NfLabel";
            this.NfLabel.Size = new System.Drawing.Size(28, 16);
            this.NfLabel.TabIndex = 43;
            this.NfLabel.Text = "N =";
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(76, 34);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(45, 20);
            this.LengthTextBox.TabIndex = 44;
            this.LengthTextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForInt);
            // 
            // InputFlowLayoutPanel1
            // 
            this.InputFlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputFlowLayoutPanel1.Controls.Add(this.FreqMinLabel);
            this.InputFlowLayoutPanel1.Controls.Add(this.FreqMinTextBox);
            this.InputFlowLayoutPanel1.Controls.Add(this.DotDotLabel);
            this.InputFlowLayoutPanel1.Controls.Add(this.FreqMaxTextBox);
            this.InputFlowLayoutPanel1.Controls.Add(this.LengthLabel);
            this.InputFlowLayoutPanel1.Controls.Add(this.LengthTextBox);
            this.InputFlowLayoutPanel1.Controls.Add(this.NfLabel);
            this.InputFlowLayoutPanel1.Controls.Add(this.NfTextBox);
            this.InputFlowLayoutPanel1.Location = new System.Drawing.Point(657, 13);
            this.InputFlowLayoutPanel1.Name = "InputFlowLayoutPanel1";
            this.InputFlowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.InputFlowLayoutPanel1.Size = new System.Drawing.Size(207, 66);
            this.InputFlowLayoutPanel1.TabIndex = 45;
            // 
            // EEELabel
            // 
            this.EEELabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EEELabel.AutoSize = true;
            this.EEELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.EEELabel.Location = new System.Drawing.Point(0, 45);
            this.EEELabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.EEELabel.Name = "EEELabel";
            this.EEELabel.Size = new System.Drawing.Size(90, 16);
            this.EEELabel.TabIndex = 46;
            this.EEELabel.Text = "Erп/Erc = 22,2";
            // 
            // Z0Label
            // 
            this.Z0Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z0Label.AutoSize = true;
            this.Z0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z0Label.Location = new System.Drawing.Point(0, 5);
            this.Z0Label.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.Z0Label.Name = "Z0Label";
            this.Z0Label.Size = new System.Drawing.Size(83, 16);
            this.Z0Label.TabIndex = 49;
            this.Z0Label.Text = "Z0, Ω = 222.2";
            // 
            // Z2cLabel
            // 
            this.Z2cLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z2cLabel.AutoSize = true;
            this.Z2cLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z2cLabel.Location = new System.Drawing.Point(0, 25);
            this.Z2cLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.Z2cLabel.Name = "Z2cLabel";
            this.Z2cLabel.Size = new System.Drawing.Size(90, 16);
            this.Z2cLabel.TabIndex = 48;
            this.Z2cLabel.Text = "Z2c, Ω = 22,22";
            // 
            // Z1pLabel
            // 
            this.Z1pLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z1pLabel.AutoSize = true;
            this.Z1pLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z1pLabel.Location = new System.Drawing.Point(0, 5);
            this.Z1pLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.Z1pLabel.Name = "Z1pLabel";
            this.Z1pLabel.Size = new System.Drawing.Size(91, 16);
            this.Z1pLabel.TabIndex = 47;
            this.Z1pLabel.Text = "Z1п, Ω = 22,22";
            // 
            // MLabel
            // 
            this.MLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MLabel.AutoSize = true;
            this.MLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.MLabel.Location = new System.Drawing.Point(0, 45);
            this.MLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.MLabel.Name = "MLabel";
            this.MLabel.Size = new System.Drawing.Size(88, 16);
            this.MLabel.TabIndex = 50;
            this.MLabel.Text = "Mmax = 22,22";
            // 
            // Z1pToEEEFlowLayoutPanel
            // 
            this.Z1pToEEEFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z1pToEEEFlowLayoutPanel.Controls.Add(this.Z1pToEEEColumn1FlowLayoutPanel);
            this.Z1pToEEEFlowLayoutPanel.Controls.Add(this.Z1pToEEEColumn2FlowLayoutPanel);
            this.Z1pToEEEFlowLayoutPanel.Location = new System.Drawing.Point(452, 13);
            this.Z1pToEEEFlowLayoutPanel.Name = "Z1pToEEEFlowLayoutPanel";
            this.Z1pToEEEFlowLayoutPanel.Size = new System.Drawing.Size(204, 66);
            this.Z1pToEEEFlowLayoutPanel.TabIndex = 51;
            // 
            // Z1pToEEEColumn1FlowLayoutPanel
            // 
            this.Z1pToEEEColumn1FlowLayoutPanel.Controls.Add(this.Z1pLabel);
            this.Z1pToEEEColumn1FlowLayoutPanel.Controls.Add(this.Z2cLabel);
            this.Z1pToEEEColumn1FlowLayoutPanel.Controls.Add(this.MLabel);
            this.Z1pToEEEColumn1FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Z1pToEEEColumn1FlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Z1pToEEEColumn1FlowLayoutPanel.Name = "Z1pToEEEColumn1FlowLayoutPanel";
            this.Z1pToEEEColumn1FlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Z1pToEEEColumn1FlowLayoutPanel.Size = new System.Drawing.Size(104, 61);
            this.Z1pToEEEColumn1FlowLayoutPanel.TabIndex = 57;
            // 
            // Z1pToEEEColumn2FlowLayoutPanel
            // 
            this.Z1pToEEEColumn2FlowLayoutPanel.Controls.Add(this.ErcLabel);
            this.Z1pToEEEColumn2FlowLayoutPanel.Controls.Add(this.ErpLabel);
            this.Z1pToEEEColumn2FlowLayoutPanel.Controls.Add(this.EEELabel);
            this.Z1pToEEEColumn2FlowLayoutPanel.Location = new System.Drawing.Point(104, 0);
            this.Z1pToEEEColumn2FlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Z1pToEEEColumn2FlowLayoutPanel.Name = "Z1pToEEEColumn2FlowLayoutPanel";
            this.Z1pToEEEColumn2FlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Z1pToEEEColumn2FlowLayoutPanel.Size = new System.Drawing.Size(95, 61);
            this.Z1pToEEEColumn2FlowLayoutPanel.TabIndex = 58;
            // 
            // Z0ToRpFlowLayoutPanel
            // 
            this.Z0ToRpFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z0ToRpFlowLayoutPanel.Controls.Add(this.Z0ToRpColumn1FlowLayoutPanel);
            this.Z0ToRpFlowLayoutPanel.Controls.Add(this.Z0ToRpColumn2FlowLayoutPanel);
            this.Z0ToRpFlowLayoutPanel.Controls.Add(this.Z0ToRpColumn3FlowLayoutPanel);
            this.Z0ToRpFlowLayoutPanel.Location = new System.Drawing.Point(165, 13);
            this.Z0ToRpFlowLayoutPanel.Name = "Z0ToRpFlowLayoutPanel";
            this.Z0ToRpFlowLayoutPanel.Size = new System.Drawing.Size(286, 66);
            this.Z0ToRpFlowLayoutPanel.TabIndex = 52;
            // 
            // Z0ToRpColumn1FlowLayoutPanel
            // 
            this.Z0ToRpColumn1FlowLayoutPanel.Controls.Add(this.Z0Label);
            this.Z0ToRpColumn1FlowLayoutPanel.Controls.Add(this.Z1Label);
            this.Z0ToRpColumn1FlowLayoutPanel.Controls.Add(this.Z2Label);
            this.Z0ToRpColumn1FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Z0ToRpColumn1FlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Z0ToRpColumn1FlowLayoutPanel.Name = "Z0ToRpColumn1FlowLayoutPanel";
            this.Z0ToRpColumn1FlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Z0ToRpColumn1FlowLayoutPanel.Size = new System.Drawing.Size(92, 64);
            this.Z0ToRpColumn1FlowLayoutPanel.TabIndex = 58;
            // 
            // Z0ToRpColumn2FlowLayoutPanel
            // 
            this.Z0ToRpColumn2FlowLayoutPanel.Controls.Add(this.KLabel);
            this.Z0ToRpColumn2FlowLayoutPanel.Controls.Add(this.NLabel);
            this.Z0ToRpColumn2FlowLayoutPanel.Controls.Add(this.RzLabel);
            this.Z0ToRpColumn2FlowLayoutPanel.Location = new System.Drawing.Point(92, 0);
            this.Z0ToRpColumn2FlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Z0ToRpColumn2FlowLayoutPanel.Name = "Z0ToRpColumn2FlowLayoutPanel";
            this.Z0ToRpColumn2FlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Z0ToRpColumn2FlowLayoutPanel.Size = new System.Drawing.Size(84, 64);
            this.Z0ToRpColumn2FlowLayoutPanel.TabIndex = 58;
            // 
            // NLabel
            // 
            this.NLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NLabel.AutoSize = true;
            this.NLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.NLabel.Location = new System.Drawing.Point(0, 25);
            this.NLabel.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.NLabel.Name = "NLabel";
            this.NLabel.Size = new System.Drawing.Size(59, 16);
            this.NLabel.TabIndex = 25;
            this.NLabel.Text = "n = 22.22";
            // 
            // Z0ToRpColumn3FlowLayoutPanel
            // 
            this.Z0ToRpColumn3FlowLayoutPanel.Controls.Add(this.S21Label);
            this.Z0ToRpColumn3FlowLayoutPanel.Controls.Add(this.RcLabel);
            this.Z0ToRpColumn3FlowLayoutPanel.Controls.Add(this.RpLabel);
            this.Z0ToRpColumn3FlowLayoutPanel.Location = new System.Drawing.Point(176, 0);
            this.Z0ToRpColumn3FlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Z0ToRpColumn3FlowLayoutPanel.Name = "Z0ToRpColumn3FlowLayoutPanel";
            this.Z0ToRpColumn3FlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Z0ToRpColumn3FlowLayoutPanel.Size = new System.Drawing.Size(103, 64);
            this.Z0ToRpColumn3FlowLayoutPanel.TabIndex = 57;
            // 
            // S21Label
            // 
            this.S21Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.S21Label.AutoSize = true;
            this.S21Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.S21Label.Location = new System.Drawing.Point(0, 5);
            this.S21Label.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.S21Label.Name = "S21Label";
            this.S21Label.Size = new System.Drawing.Size(91, 16);
            this.S21Label.TabIndex = 53;
            this.S21Label.Text = "S21, dB = 22,2";
            // 
            // ShematicGroupBox
            // 
            this.ShematicGroupBox.Controls.Add(this.LineToLineRadioButton);
            this.ShematicGroupBox.Controls.Add(this.GeneralRadioButton);
            this.ShematicGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ShematicGroupBox.Location = new System.Drawing.Point(11, 13);
            this.ShematicGroupBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.ShematicGroupBox.Name = "ShematicGroupBox";
            this.ShematicGroupBox.Size = new System.Drawing.Size(153, 66);
            this.ShematicGroupBox.TabIndex = 53;
            this.ShematicGroupBox.TabStop = false;
            this.ShematicGroupBox.Text = "Select shematic";
            // 
            // LineToLineRadioButton
            // 
            this.LineToLineRadioButton.AutoSize = true;
            this.LineToLineRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LineToLineRadioButton.Location = new System.Drawing.Point(1, 41);
            this.LineToLineRadioButton.Name = "LineToLineRadioButton";
            this.LineToLineRadioButton.Size = new System.Drawing.Size(149, 20);
            this.LineToLineRadioButton.TabIndex = 1;
            this.LineToLineRadioButton.Text = "Line-to-line transform";
            this.LineToLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // GeneralRadioButton
            // 
            this.GeneralRadioButton.AutoSize = true;
            this.GeneralRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.GeneralRadioButton.Location = new System.Drawing.Point(1, 18);
            this.GeneralRadioButton.Name = "GeneralRadioButton";
            this.GeneralRadioButton.Size = new System.Drawing.Size(142, 20);
            this.GeneralRadioButton.TabIndex = 0;
            this.GeneralRadioButton.Text = "General termination";
            this.GeneralRadioButton.UseVisualStyleBackColor = true;
            this.GeneralRadioButton.CheckedChanged += new System.EventHandler(this.GeneralRadioButton_CheckedChanged);
            // 
            // Z01Z02FlowLayoutPanel
            // 
            this.Z01Z02FlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z01Z02FlowLayoutPanel.Controls.Add(this.Z01Label);
            this.Z01Z02FlowLayoutPanel.Controls.Add(this.Z01TextBox);
            this.Z01Z02FlowLayoutPanel.Controls.Add(this.Z02Label);
            this.Z01Z02FlowLayoutPanel.Controls.Add(this.Z02TextBox);
            this.Z01Z02FlowLayoutPanel.Location = new System.Drawing.Point(12, 349);
            this.Z01Z02FlowLayoutPanel.Name = "Z01Z02FlowLayoutPanel";
            this.Z01Z02FlowLayoutPanel.Size = new System.Drawing.Size(110, 63);
            this.Z01Z02FlowLayoutPanel.TabIndex = 54;
            // 
            // Z01Label
            // 
            this.Z01Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z01Label.AutoSize = true;
            this.Z01Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z01Label.Location = new System.Drawing.Point(3, 10);
            this.Z01Label.Name = "Z01Label";
            this.Z01Label.Size = new System.Drawing.Size(46, 16);
            this.Z01Label.TabIndex = 55;
            this.Z01Label.Text = "Z01, Ω";
            // 
            // Z01TextBox
            // 
            this.Z01TextBox.Location = new System.Drawing.Point(55, 3);
            this.Z01TextBox.Name = "Z01TextBox";
            this.Z01TextBox.Size = new System.Drawing.Size(45, 20);
            this.Z01TextBox.TabIndex = 56;
            this.Z01TextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // Z02Label
            // 
            this.Z02Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z02Label.AutoSize = true;
            this.Z02Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z02Label.Location = new System.Drawing.Point(3, 36);
            this.Z02Label.Name = "Z02Label";
            this.Z02Label.Size = new System.Drawing.Size(46, 16);
            this.Z02Label.TabIndex = 55;
            this.Z02Label.Text = "Z02, Ω";
            // 
            // Z02TextBox
            // 
            this.Z02TextBox.Location = new System.Drawing.Point(55, 29);
            this.Z02TextBox.Name = "Z02TextBox";
            this.Z02TextBox.Size = new System.Drawing.Size(45, 20);
            this.Z02TextBox.TabIndex = 56;
            this.Z02TextBox.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            // 
            // ShematicPictureBox
            // 
            this.ShematicPictureBox.Image = global::ParametersApp.Properties.Resources.String_low_Midl;
            this.ShematicPictureBox.Location = new System.Drawing.Point(12, 97);
            this.ShematicPictureBox.Name = "ShematicPictureBox";
            this.ShematicPictureBox.Size = new System.Drawing.Size(228, 177);
            this.ShematicPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShematicPictureBox.TabIndex = 55;
            this.ShematicPictureBox.TabStop = false;
            // 
            // ImageNameLabel
            // 
            this.ImageNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageNameLabel.AutoSize = true;
            this.ImageNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ImageNameLabel.Location = new System.Drawing.Point(81, 97);
            this.ImageNameLabel.Name = "ImageNameLabel";
            this.ImageNameLabel.Size = new System.Drawing.Size(90, 16);
            this.ImageNameLabel.TabIndex = 56;
            this.ImageNameLabel.Text = "Coupled lines";
            // 
            // GraphNameLabel
            // 
            this.GraphNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphNameLabel.AutoSize = true;
            this.GraphNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.GraphNameLabel.Location = new System.Drawing.Point(484, 86);
            this.GraphNameLabel.Name = "GraphNameLabel";
            this.GraphNameLabel.Size = new System.Drawing.Size(96, 16);
            this.GraphNameLabel.TabIndex = 57;
            this.GraphNameLabel.Text = "S - parameters";
            // 
            // FormForGraph
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(866, 423);
            this.Controls.Add(this.GraphNameLabel);
            this.Controls.Add(this.ImageNameLabel);
            this.Controls.Add(this.ShematicPictureBox);
            this.Controls.Add(this.Z01Z02FlowLayoutPanel);
            this.Controls.Add(this.ShematicGroupBox);
            this.Controls.Add(this.Z0ToRpFlowLayoutPanel);
            this.Controls.Add(this.Z1pToEEEFlowLayoutPanel);
            this.Controls.Add(this.InputFlowLayoutPanel1);
            this.Controls.Add(this.ZInOutFlowLayoutPanel);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.PhaseRadioButton);
            this.Controls.Add(this.MagnitudeRadioButton);
            this.Controls.Add(this.SParamListBox);
            this.Controls.Add(this.GraphControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(882, 462);
            this.MinimumSize = new System.Drawing.Size(882, 462);
            this.Name = "FormForGraph";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormForGraph";
            this.Load += new System.EventHandler(this.DrawButton_Click);
            this.TextChanged += new System.EventHandler(this.textBox_TextChangedForDouble);
            this.ZInOutFlowLayoutPanel.ResumeLayout(false);
            this.ZInOutFlowLayoutPanel.PerformLayout();
            this.InputFlowLayoutPanel1.ResumeLayout(false);
            this.InputFlowLayoutPanel1.PerformLayout();
            this.Z1pToEEEFlowLayoutPanel.ResumeLayout(false);
            this.Z1pToEEEColumn1FlowLayoutPanel.ResumeLayout(false);
            this.Z1pToEEEColumn1FlowLayoutPanel.PerformLayout();
            this.Z1pToEEEColumn2FlowLayoutPanel.ResumeLayout(false);
            this.Z1pToEEEColumn2FlowLayoutPanel.PerformLayout();
            this.Z0ToRpFlowLayoutPanel.ResumeLayout(false);
            this.Z0ToRpColumn1FlowLayoutPanel.ResumeLayout(false);
            this.Z0ToRpColumn1FlowLayoutPanel.PerformLayout();
            this.Z0ToRpColumn2FlowLayoutPanel.ResumeLayout(false);
            this.Z0ToRpColumn2FlowLayoutPanel.PerformLayout();
            this.Z0ToRpColumn3FlowLayoutPanel.ResumeLayout(false);
            this.Z0ToRpColumn3FlowLayoutPanel.PerformLayout();
            this.ShematicGroupBox.ResumeLayout(false);
            this.ShematicGroupBox.PerformLayout();
            this.Z01Z02FlowLayoutPanel.ResumeLayout(false);
            this.Z01Z02FlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShematicPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl GraphControl;
        private System.Windows.Forms.Label FreqMinLabel;
        private System.Windows.Forms.Label DotDotLabel;
        private System.Windows.Forms.TextBox FreqMinTextBox;
        private System.Windows.Forms.TextBox FreqMaxTextBox;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.TextBox NfTextBox;
        private System.Windows.Forms.Label ErpLabel;
        private System.Windows.Forms.Label KLabel;
        private System.Windows.Forms.Label RpLabel;
        private System.Windows.Forms.Label RzLabel;
        private System.Windows.Forms.Label Z1Label;
        private System.Windows.Forms.Label ErcLabel;
        private System.Windows.Forms.Label RcLabel;
        private System.Windows.Forms.Label Z2Label;
        private System.Windows.Forms.TextBox Z1outTextBox;
        private System.Windows.Forms.Label Z1outLabel;
        private System.Windows.Forms.TextBox Z2inTextBox;
        private System.Windows.Forms.TextBox Z1inTextBox;
        private System.Windows.Forms.Label Z2inLabel;
        private System.Windows.Forms.Label Z1inLabel;
        private System.Windows.Forms.TextBox Z2outTextBox;
        private System.Windows.Forms.Label Z2outLabel;
        private System.Windows.Forms.CheckedListBox SParamListBox;
        private System.Windows.Forms.RadioButton MagnitudeRadioButton;
        private System.Windows.Forms.RadioButton PhaseRadioButton;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.FlowLayoutPanel ZInOutFlowLayoutPanel;
        private System.Windows.Forms.Label NfLabel;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.FlowLayoutPanel InputFlowLayoutPanel1;
        private System.Windows.Forms.Label EEELabel;
        private System.Windows.Forms.Label Z0Label;
        private System.Windows.Forms.Label Z2cLabel;
        private System.Windows.Forms.Label Z1pLabel;
        private System.Windows.Forms.Label MLabel;
        private System.Windows.Forms.FlowLayoutPanel Z1pToEEEFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel Z0ToRpFlowLayoutPanel;
        private System.Windows.Forms.Label S21Label;
        private System.Windows.Forms.Label NLabel;
        private System.Windows.Forms.GroupBox ShematicGroupBox;
        private System.Windows.Forms.RadioButton LineToLineRadioButton;
        private System.Windows.Forms.RadioButton GeneralRadioButton;
        private System.Windows.Forms.FlowLayoutPanel Z01Z02FlowLayoutPanel;
        private System.Windows.Forms.Label Z01Label;
        private System.Windows.Forms.TextBox Z01TextBox;
        private System.Windows.Forms.Label Z02Label;
        private System.Windows.Forms.TextBox Z02TextBox;
        private System.Windows.Forms.PictureBox ShematicPictureBox;
        private System.Windows.Forms.Label ImageNameLabel;
        private System.Windows.Forms.FlowLayoutPanel Z0ToRpColumn1FlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel Z0ToRpColumn2FlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel Z0ToRpColumn3FlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel Z1pToEEEColumn1FlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel Z1pToEEEColumn2FlowLayoutPanel;
        private System.Windows.Forms.Label GraphNameLabel;
    }
}