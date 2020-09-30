namespace ParametersApp
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
            this.NTextBox = new System.Windows.Forms.TextBox();
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.EEELabel = new System.Windows.Forms.Label();
            this.Z0Label = new System.Windows.Forms.Label();
            this.Zc2Label = new System.Windows.Forms.Label();
            this.Zp1Label = new System.Windows.Forms.Label();
            this.MLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GeneralRadioButton = new System.Windows.Forms.RadioButton();
            this.LineToLineRadioButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.Z01Label = new System.Windows.Forms.Label();
            this.Z01TextBox = new System.Windows.Forms.TextBox();
            this.Z02Label = new System.Windows.Forms.Label();
            this.Z02TextBox = new System.Windows.Forms.TextBox();
            this.ZInOutFlowLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphControl
            // 
            this.GraphControl.Location = new System.Drawing.Point(358, 128);
            this.GraphControl.Name = "GraphControl";
            this.GraphControl.ScrollGrace = 0D;
            this.GraphControl.ScrollMaxX = 0D;
            this.GraphControl.ScrollMaxY = 0D;
            this.GraphControl.ScrollMaxY2 = 0D;
            this.GraphControl.ScrollMinX = 0D;
            this.GraphControl.ScrollMinY = 0D;
            this.GraphControl.ScrollMinY2 = 0D;
            this.GraphControl.Size = new System.Drawing.Size(530, 304);
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
            this.FreqMinLabel.Size = new System.Drawing.Size(104, 16);
            this.FreqMinLabel.TabIndex = 11;
            this.FreqMinLabel.Text = "Frequency, GHz";
            // 
            // DotDotLabel
            // 
            this.DotDotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DotDotLabel.AutoSize = true;
            this.DotDotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DotDotLabel.Location = new System.Drawing.Point(161, 6);
            this.DotDotLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DotDotLabel.Name = "DotDotLabel";
            this.DotDotLabel.Size = new System.Drawing.Size(24, 25);
            this.DotDotLabel.TabIndex = 12;
            this.DotDotLabel.Text = "..";
            // 
            // FreqMinTextBox
            // 
            this.FreqMinTextBox.Location = new System.Drawing.Point(112, 7);
            this.FreqMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqMinTextBox.Name = "FreqMinTextBox";
            this.FreqMinTextBox.Size = new System.Drawing.Size(45, 20);
            this.FreqMinTextBox.TabIndex = 13;
            // 
            // FreqMaxTextBox
            // 
            this.FreqMaxTextBox.Location = new System.Drawing.Point(189, 7);
            this.FreqMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqMaxTextBox.Name = "FreqMaxTextBox";
            this.FreqMaxTextBox.Size = new System.Drawing.Size(45, 20);
            this.FreqMaxTextBox.TabIndex = 14;
            // 
            // LengthLabel
            // 
            this.LengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LengthLabel.Location = new System.Drawing.Point(2, 8);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(2);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(76, 16);
            this.LengthLabel.TabIndex = 15;
            this.LengthLabel.Text = "Length, mm";
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(25, 29);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(45, 20);
            this.NTextBox.TabIndex = 16;
            // 
            // ErpLabel
            // 
            this.ErpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErpLabel.AutoSize = true;
            this.ErpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ErpLabel.Location = new System.Drawing.Point(96, 25);
            this.ErpLabel.Margin = new System.Windows.Forms.Padding(2);
            this.ErpLabel.Name = "ErpLabel";
            this.ErpLabel.Size = new System.Drawing.Size(76, 16);
            this.ErpLabel.TabIndex = 17;
            this.ErpLabel.Text = "Erp =  22,22";
            // 
            // KLabel
            // 
            this.KLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.KLabel.AutoSize = true;
            this.KLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.KLabel.Location = new System.Drawing.Point(92, 3);
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
            this.RpLabel.Location = new System.Drawing.Point(77, 51);
            this.RpLabel.Name = "RpLabel";
            this.RpLabel.Size = new System.Drawing.Size(70, 16);
            this.RpLabel.TabIndex = 19;
            this.RpLabel.Text = "Rp = 22.22";
            // 
            // RzLabel
            // 
            this.RzLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RzLabel.AutoSize = true;
            this.RzLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RzLabel.Location = new System.Drawing.Point(3, 51);
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
            this.Z1Label.Location = new System.Drawing.Point(107, 19);
            this.Z1Label.Name = "Z1Label";
            this.Z1Label.Size = new System.Drawing.Size(83, 16);
            this.Z1Label.TabIndex = 21;
            this.Z1Label.Text = "Z1, Ω = 22.22";
            // 
            // ErcLabel
            // 
            this.ErcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErcLabel.AutoSize = true;
            this.ErcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ErcLabel.Location = new System.Drawing.Point(97, 5);
            this.ErcLabel.Margin = new System.Windows.Forms.Padding(2);
            this.ErcLabel.Name = "ErcLabel";
            this.ErcLabel.Size = new System.Drawing.Size(75, 16);
            this.ErcLabel.TabIndex = 22;
            this.ErcLabel.Text = "Erc =  22,22";
            // 
            // RcLabel
            // 
            this.RcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RcLabel.AutoSize = true;
            this.RcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RcLabel.Location = new System.Drawing.Point(68, 35);
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
            this.Z2Label.Location = new System.Drawing.Point(143, 35);
            this.Z2Label.Name = "Z2Label";
            this.Z2Label.Size = new System.Drawing.Size(83, 16);
            this.Z2Label.TabIndex = 24;
            this.Z2Label.Text = "Z2, Ω = 22.22";
            // 
            // Z1outTextBox
            // 
            this.Z1outTextBox.Location = new System.Drawing.Point(172, 3);
            this.Z1outTextBox.Name = "Z1outTextBox";
            this.Z1outTextBox.Size = new System.Drawing.Size(45, 20);
            this.Z1outTextBox.TabIndex = 34;
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
            // 
            // Z1inTextBox
            // 
            this.Z1inTextBox.Location = new System.Drawing.Point(58, 3);
            this.Z1inTextBox.Name = "Z1inTextBox";
            this.Z1inTextBox.Size = new System.Drawing.Size(45, 20);
            this.Z1inTextBox.TabIndex = 31;
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
            this.SParamListBox.FormattingEnabled = true;
            this.SParamListBox.Items.AddRange(new object[] {
            "S11",
            "S12",
            "S13",
            "S14",
            "S22",
            "S24",
            "All"});
            this.SParamListBox.Location = new System.Drawing.Point(894, 105);
            this.SParamListBox.MultiColumn = true;
            this.SParamListBox.Name = "SParamListBox";
            this.SParamListBox.Size = new System.Drawing.Size(46, 105);
            this.SParamListBox.TabIndex = 37;
            this.SParamListBox.SelectedIndexChanged += new System.EventHandler(this.SParamListBox_SelectedIndexChanged);
            // 
            // MagnitudeRadioButton
            // 
            this.MagnitudeRadioButton.AutoSize = true;
            this.MagnitudeRadioButton.Checked = true;
            this.MagnitudeRadioButton.Location = new System.Drawing.Point(358, 105);
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
            this.PhaseRadioButton.Location = new System.Drawing.Point(461, 105);
            this.PhaseRadioButton.Name = "PhaseRadioButton";
            this.PhaseRadioButton.Size = new System.Drawing.Size(82, 17);
            this.PhaseRadioButton.TabIndex = 39;
            this.PhaseRadioButton.Text = "Phase (deg)";
            this.PhaseRadioButton.UseVisualStyleBackColor = true;
            this.PhaseRadioButton.CheckedChanged += new System.EventHandler(this.PhaseRadioButton_CheckedChanged);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(897, 216);
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
            this.ZInOutFlowLayoutPanel.Location = new System.Drawing.Point(8, 369);
            this.ZInOutFlowLayoutPanel.Name = "ZInOutFlowLayoutPanel";
            this.ZInOutFlowLayoutPanel.Size = new System.Drawing.Size(228, 63);
            this.ZInOutFlowLayoutPanel.TabIndex = 42;
            // 
            // NfLabel
            // 
            this.NfLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NfLabel.AutoSize = true;
            this.NfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.NfLabel.Location = new System.Drawing.Point(2, 34);
            this.NfLabel.Margin = new System.Windows.Forms.Padding(2);
            this.NfLabel.Name = "NfLabel";
            this.NfLabel.Size = new System.Drawing.Size(18, 16);
            this.NfLabel.TabIndex = 43;
            this.NfLabel.Text = "N";
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(83, 3);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(45, 20);
            this.LengthTextBox.TabIndex = 44;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.FreqMinLabel);
            this.flowLayoutPanel1.Controls.Add(this.FreqMinTextBox);
            this.flowLayoutPanel1.Controls.Add(this.DotDotLabel);
            this.flowLayoutPanel1.Controls.Add(this.FreqMaxTextBox);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(696, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 87);
            this.flowLayoutPanel1.TabIndex = 45;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.LengthLabel);
            this.flowLayoutPanel2.Controls.Add(this.LengthTextBox);
            this.flowLayoutPanel2.Controls.Add(this.NfLabel);
            this.flowLayoutPanel2.Controls.Add(this.NTextBox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 31);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(131, 51);
            this.flowLayoutPanel2.TabIndex = 46;
            // 
            // EEELabel
            // 
            this.EEELabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EEELabel.AutoSize = true;
            this.EEELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.EEELabel.Location = new System.Drawing.Point(96, 45);
            this.EEELabel.Margin = new System.Windows.Forms.Padding(2);
            this.EEELabel.Name = "EEELabel";
            this.EEELabel.Size = new System.Drawing.Size(100, 16);
            this.EEELabel.TabIndex = 46;
            this.EEELabel.Text = "Erp/Erc =  22,22";
            // 
            // Z0Label
            // 
            this.Z0Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z0Label.AutoSize = true;
            this.Z0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z0Label.Location = new System.Drawing.Point(3, 3);
            this.Z0Label.Name = "Z0Label";
            this.Z0Label.Size = new System.Drawing.Size(83, 16);
            this.Z0Label.TabIndex = 49;
            this.Z0Label.Text = "Z0, Ω = 22.22";
            // 
            // Zc2Label
            // 
            this.Zc2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zc2Label.AutoSize = true;
            this.Zc2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Zc2Label.Location = new System.Drawing.Point(2, 25);
            this.Zc2Label.Margin = new System.Windows.Forms.Padding(2);
            this.Zc2Label.Name = "Zc2Label";
            this.Zc2Label.Size = new System.Drawing.Size(90, 16);
            this.Zc2Label.TabIndex = 48;
            this.Zc2Label.Text = "Z2c, Ω = 22,22";
            // 
            // Zp1Label
            // 
            this.Zp1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zp1Label.AutoSize = true;
            this.Zp1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Zp1Label.Location = new System.Drawing.Point(2, 5);
            this.Zp1Label.Margin = new System.Windows.Forms.Padding(2);
            this.Zp1Label.Name = "Zp1Label";
            this.Zp1Label.Size = new System.Drawing.Size(91, 16);
            this.Zp1Label.TabIndex = 47;
            this.Zp1Label.Text = "Z1p, Ω = 22,22";
            // 
            // MLabel
            // 
            this.MLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MLabel.AutoSize = true;
            this.MLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.MLabel.Location = new System.Drawing.Point(2, 45);
            this.MLabel.Margin = new System.Windows.Forms.Padding(2);
            this.MLabel.Name = "MLabel";
            this.MLabel.Size = new System.Drawing.Size(90, 16);
            this.MLabel.TabIndex = 50;
            this.MLabel.Text = "Z1p, S = 22,22";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel3.Controls.Add(this.Zp1Label);
            this.flowLayoutPanel3.Controls.Add(this.ErcLabel);
            this.flowLayoutPanel3.Controls.Add(this.Zc2Label);
            this.flowLayoutPanel3.Controls.Add(this.ErpLabel);
            this.flowLayoutPanel3.Controls.Add(this.MLabel);
            this.flowLayoutPanel3.Controls.Add(this.EEELabel);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(478, 12);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(212, 87);
            this.flowLayoutPanel3.TabIndex = 51;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel4.Controls.Add(this.Z0Label);
            this.flowLayoutPanel4.Controls.Add(this.KLabel);
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.Z1Label);
            this.flowLayoutPanel4.Controls.Add(this.NLabel);
            this.flowLayoutPanel4.Controls.Add(this.RcLabel);
            this.flowLayoutPanel4.Controls.Add(this.Z2Label);
            this.flowLayoutPanel4.Controls.Add(this.RzLabel);
            this.flowLayoutPanel4.Controls.Add(this.RpLabel);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(234, 12);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(238, 87);
            this.flowLayoutPanel4.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "S21, dB = 22,22";
            // 
            // NLabel
            // 
            this.NLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NLabel.AutoSize = true;
            this.NLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.NLabel.Location = new System.Drawing.Point(3, 35);
            this.NLabel.Name = "NLabel";
            this.NLabel.Size = new System.Drawing.Size(59, 16);
            this.NLabel.TabIndex = 25;
            this.NLabel.Text = "n = 22.22";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LineToLineRadioButton);
            this.groupBox1.Controls.Add(this.GeneralRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 81);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select shematic";
            // 
            // GeneralRadioButton
            // 
            this.GeneralRadioButton.AutoSize = true;
            this.GeneralRadioButton.Checked = true;
            this.GeneralRadioButton.Location = new System.Drawing.Point(6, 19);
            this.GeneralRadioButton.Name = "GeneralRadioButton";
            this.GeneralRadioButton.Size = new System.Drawing.Size(116, 17);
            this.GeneralRadioButton.TabIndex = 0;
            this.GeneralRadioButton.TabStop = true;
            this.GeneralRadioButton.Text = "General termination";
            this.GeneralRadioButton.UseVisualStyleBackColor = true;
            // 
            // LineToLineRadioButton
            // 
            this.LineToLineRadioButton.AutoSize = true;
            this.LineToLineRadioButton.Location = new System.Drawing.Point(6, 42);
            this.LineToLineRadioButton.Name = "LineToLineRadioButton";
            this.LineToLineRadioButton.Size = new System.Drawing.Size(131, 17);
            this.LineToLineRadioButton.TabIndex = 1;
            this.LineToLineRadioButton.Text = "Line-to-line transformer";
            this.LineToLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel5.Controls.Add(this.Z01Label);
            this.flowLayoutPanel5.Controls.Add(this.Z01TextBox);
            this.flowLayoutPanel5.Controls.Add(this.Z02Label);
            this.flowLayoutPanel5.Controls.Add(this.Z02TextBox);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(242, 369);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(110, 63);
            this.flowLayoutPanel5.TabIndex = 54;
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
            // 
            // FormForGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 444);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ZInOutFlowLayoutPanel);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.PhaseRadioButton);
            this.Controls.Add(this.MagnitudeRadioButton);
            this.Controls.Add(this.SParamListBox);
            this.Controls.Add(this.GraphControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(968, 547);
            this.Name = "FormForGraph";
            this.Text = "FormForGraph";
            this.ZInOutFlowLayoutPanel.ResumeLayout(false);
            this.ZInOutFlowLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
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
        private System.Windows.Forms.TextBox NTextBox;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label EEELabel;
        private System.Windows.Forms.Label Z0Label;
        private System.Windows.Forms.Label Zc2Label;
        private System.Windows.Forms.Label Zp1Label;
        private System.Windows.Forms.Label MLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LineToLineRadioButton;
        private System.Windows.Forms.RadioButton GeneralRadioButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label Z01Label;
        private System.Windows.Forms.TextBox Z01TextBox;
        private System.Windows.Forms.Label Z02Label;
        private System.Windows.Forms.TextBox Z02TextBox;
    }
}