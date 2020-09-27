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
            this.FreqMaxLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ErpLabel = new System.Windows.Forms.Label();
            this.KLabel = new System.Windows.Forms.Label();
            this.RpLabel = new System.Windows.Forms.Label();
            this.RzLabel = new System.Windows.Forms.Label();
            this.Zc1Label = new System.Windows.Forms.Label();
            this.ErcLabel = new System.Windows.Forms.Label();
            this.RcLabel = new System.Windows.Forms.Label();
            this.Zp2Label = new System.Windows.Forms.Label();
            this.Z0Label = new System.Windows.Forms.Label();
            this.Zp1Label = new System.Windows.Forms.Label();
            this.Zc2Label = new System.Windows.Forms.Label();
            this.ZoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GraphControl
            // 
            this.GraphControl.Location = new System.Drawing.Point(265, 189);
            this.GraphControl.Name = "GraphControl";
            this.GraphControl.ScrollGrace = 0D;
            this.GraphControl.ScrollMaxX = 0D;
            this.GraphControl.ScrollMaxY = 0D;
            this.GraphControl.ScrollMaxY2 = 0D;
            this.GraphControl.ScrollMinX = 0D;
            this.GraphControl.ScrollMinY = 0D;
            this.GraphControl.ScrollMinY2 = 0D;
            this.GraphControl.Size = new System.Drawing.Size(675, 307);
            this.GraphControl.TabIndex = 0;
            this.GraphControl.UseExtendedPrintDialog = true;
            // 
            // FreqMinLabel
            // 
            this.FreqMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FreqMinLabel.AutoSize = true;
            this.FreqMinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FreqMinLabel.Location = new System.Drawing.Point(258, 9);
            this.FreqMinLabel.Name = "FreqMinLabel";
            this.FreqMinLabel.Size = new System.Drawing.Size(128, 16);
            this.FreqMinLabel.TabIndex = 11;
            this.FreqMinLabel.Text = "Frequency min, GHz";
            // 
            // FreqMaxLabel
            // 
            this.FreqMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FreqMaxLabel.AutoSize = true;
            this.FreqMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FreqMaxLabel.Location = new System.Drawing.Point(258, 35);
            this.FreqMaxLabel.Name = "FreqMaxLabel";
            this.FreqMaxLabel.Size = new System.Drawing.Size(132, 16);
            this.FreqMaxLabel.TabIndex = 12;
            this.FreqMaxLabel.Text = "Frequency max, GHz";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(396, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 20);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(396, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 20);
            this.textBox2.TabIndex = 14;
            // 
            // LengthLabel
            // 
            this.LengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LengthLabel.Location = new System.Drawing.Point(258, 61);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(76, 16);
            this.LengthLabel.TabIndex = 15;
            this.LengthLabel.Text = "Length, mm";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(396, 57);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(45, 20);
            this.textBox3.TabIndex = 16;
            // 
            // ErpLabel
            // 
            this.ErpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErpLabel.AutoSize = true;
            this.ErpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ErpLabel.Location = new System.Drawing.Point(447, 35);
            this.ErpLabel.Name = "ErpLabel";
            this.ErpLabel.Size = new System.Drawing.Size(128, 16);
            this.ErpLabel.TabIndex = 17;
            this.ErpLabel.Text = "Frequency min, GHz";
            // 
            // KLabel
            // 
            this.KLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.KLabel.AutoSize = true;
            this.KLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.KLabel.Location = new System.Drawing.Point(447, 61);
            this.KLabel.Name = "KLabel";
            this.KLabel.Size = new System.Drawing.Size(128, 16);
            this.KLabel.TabIndex = 18;
            this.KLabel.Text = "Frequency min, GHz";
            // 
            // RpLabel
            // 
            this.RpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RpLabel.AutoSize = true;
            this.RpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RpLabel.Location = new System.Drawing.Point(581, 35);
            this.RpLabel.Name = "RpLabel";
            this.RpLabel.Size = new System.Drawing.Size(128, 16);
            this.RpLabel.TabIndex = 19;
            this.RpLabel.Text = "Frequency min, GHz";
            // 
            // RzLabel
            // 
            this.RzLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RzLabel.AutoSize = true;
            this.RzLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RzLabel.Location = new System.Drawing.Point(581, 61);
            this.RzLabel.Name = "RzLabel";
            this.RzLabel.Size = new System.Drawing.Size(128, 16);
            this.RzLabel.TabIndex = 20;
            this.RzLabel.Text = "Frequency min, GHz";
            // 
            // Zc1Label
            // 
            this.Zc1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zc1Label.AutoSize = true;
            this.Zc1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Zc1Label.Location = new System.Drawing.Point(715, 9);
            this.Zc1Label.Name = "Zc1Label";
            this.Zc1Label.Size = new System.Drawing.Size(128, 16);
            this.Zc1Label.TabIndex = 21;
            this.Zc1Label.Text = "Frequency min, GHz";
            // 
            // ErcLabel
            // 
            this.ErcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErcLabel.AutoSize = true;
            this.ErcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ErcLabel.Location = new System.Drawing.Point(447, 9);
            this.ErcLabel.Name = "ErcLabel";
            this.ErcLabel.Size = new System.Drawing.Size(128, 16);
            this.ErcLabel.TabIndex = 22;
            this.ErcLabel.Text = "Frequency min, GHz";
            // 
            // RcLabel
            // 
            this.RcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RcLabel.AutoSize = true;
            this.RcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.RcLabel.Location = new System.Drawing.Point(581, 9);
            this.RcLabel.Name = "RcLabel";
            this.RcLabel.Size = new System.Drawing.Size(128, 16);
            this.RcLabel.TabIndex = 23;
            this.RcLabel.Text = "Frequency min, GHz";
            // 
            // Zp2Label
            // 
            this.Zp2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zp2Label.AutoSize = true;
            this.Zp2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Zp2Label.Location = new System.Drawing.Point(715, 35);
            this.Zp2Label.Name = "Zp2Label";
            this.Zp2Label.Size = new System.Drawing.Size(128, 16);
            this.Zp2Label.TabIndex = 24;
            this.Zp2Label.Text = "Frequency min, GHz";
            // 
            // Z0Label
            // 
            this.Z0Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Z0Label.AutoSize = true;
            this.Z0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Z0Label.Location = new System.Drawing.Point(715, 61);
            this.Z0Label.Name = "Z0Label";
            this.Z0Label.Size = new System.Drawing.Size(72, 16);
            this.Z0Label.TabIndex = 25;
            this.Z0Label.Text = "Frequency";
            // 
            // Zp1Label
            // 
            this.Zp1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zp1Label.AutoSize = true;
            this.Zp1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Zp1Label.Location = new System.Drawing.Point(849, 9);
            this.Zp1Label.Name = "Zp1Label";
            this.Zp1Label.Size = new System.Drawing.Size(72, 16);
            this.Zp1Label.TabIndex = 26;
            this.Zp1Label.Text = "Frequency";
            // 
            // Zc2Label
            // 
            this.Zc2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zc2Label.AutoSize = true;
            this.Zc2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Zc2Label.Location = new System.Drawing.Point(849, 35);
            this.Zc2Label.Name = "Zc2Label";
            this.Zc2Label.Size = new System.Drawing.Size(72, 16);
            this.Zc2Label.TabIndex = 27;
            this.Zc2Label.Text = "Frequency";
            // 
            // ZoLabel
            // 
            this.ZoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoLabel.AutoSize = true;
            this.ZoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ZoLabel.Location = new System.Drawing.Point(849, 58);
            this.ZoLabel.Name = "ZoLabel";
            this.ZoLabel.Size = new System.Drawing.Size(72, 16);
            this.ZoLabel.TabIndex = 28;
            this.ZoLabel.Text = "Frequency";
            // 
            // FormForGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 508);
            this.Controls.Add(this.ZoLabel);
            this.Controls.Add(this.Zc2Label);
            this.Controls.Add(this.Zp1Label);
            this.Controls.Add(this.Z0Label);
            this.Controls.Add(this.Zp2Label);
            this.Controls.Add(this.RcLabel);
            this.Controls.Add(this.ErcLabel);
            this.Controls.Add(this.Zc1Label);
            this.Controls.Add(this.RzLabel);
            this.Controls.Add(this.RpLabel);
            this.Controls.Add(this.KLabel);
            this.Controls.Add(this.ErpLabel);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FreqMaxLabel);
            this.Controls.Add(this.FreqMinLabel);
            this.Controls.Add(this.GraphControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(968, 547);
            this.MinimumSize = new System.Drawing.Size(968, 547);
            this.Name = "FormForGraph";
            this.Text = "FormForGraph";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl GraphControl;
        private System.Windows.Forms.Label FreqMinLabel;
        private System.Windows.Forms.Label FreqMaxLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label ErpLabel;
        private System.Windows.Forms.Label KLabel;
        private System.Windows.Forms.Label RpLabel;
        private System.Windows.Forms.Label RzLabel;
        private System.Windows.Forms.Label Zc1Label;
        private System.Windows.Forms.Label ErcLabel;
        private System.Windows.Forms.Label RcLabel;
        private System.Windows.Forms.Label Zp2Label;
        private System.Windows.Forms.Label Z0Label;
        private System.Windows.Forms.Label Zp1Label;
        private System.Windows.Forms.Label Zc2Label;
        private System.Windows.Forms.Label ZoLabel;
    }
}