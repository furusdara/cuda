namespace CudaForms
{
    partial class MainWIndow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWIndow));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenButton = new System.Windows.Forms.Button();
            this.inPictureBox1 = new System.Windows.Forms.PictureBox();
            this.outPictureBox2 = new System.Windows.Forms.PictureBox();
            this.ExcecuteButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morfologicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.Button();
            this.iterNumberTextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.EroderadioButton1 = new System.Windows.Forms.RadioButton();
            this.Erode3x3radioButton2 = new System.Windows.Forms.RadioButton();
            this.DilateradioButton3 = new System.Windows.Forms.RadioButton();
            this.Dilate3x3radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outPictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.jpg,*.png|";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(3, 54);
            this.OpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(138, 28);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // inPictureBox1
            // 
            this.inPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inPictureBox1.Location = new System.Drawing.Point(150, 54);
            this.inPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.inPictureBox1.MaximumSize = new System.Drawing.Size(512, 512);
            this.inPictureBox1.Name = "inPictureBox1";
            this.inPictureBox1.Size = new System.Drawing.Size(512, 512);
            this.inPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inPictureBox1.TabIndex = 1;
            this.inPictureBox1.TabStop = false;
            this.inPictureBox1.Click += new System.EventHandler(this.inPictureBox1_Click);
            // 
            // outPictureBox2
            // 
            this.outPictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outPictureBox2.Location = new System.Drawing.Point(700, 54);
            this.outPictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.outPictureBox2.MaximumSize = new System.Drawing.Size(512, 512);
            this.outPictureBox2.Name = "outPictureBox2";
            this.outPictureBox2.Size = new System.Drawing.Size(512, 512);
            this.outPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outPictureBox2.TabIndex = 2;
            this.outPictureBox2.TabStop = false;
            this.outPictureBox2.Click += new System.EventHandler(this.outPictureBox2_Click);
            // 
            // ExcecuteButton
            // 
            this.ExcecuteButton.Location = new System.Drawing.Point(3, 89);
            this.ExcecuteButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExcecuteButton.Name = "ExcecuteButton";
            this.ExcecuteButton.Size = new System.Drawing.Size(138, 28);
            this.ExcecuteButton.TabIndex = 3;
            this.ExcecuteButton.Text = "Execute";
            this.ExcecuteButton.UseVisualStyleBackColor = true;
            this.ExcecuteButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1242, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.excecuteToolStripMenuItem,
            this.morfologicToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(58, 24);
            this.openToolStripMenuItem1.Text = "Menu";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // excecuteToolStripMenuItem
            // 
            this.excecuteToolStripMenuItem.Name = "excecuteToolStripMenuItem";
            this.excecuteToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.excecuteToolStripMenuItem.Text = "Excecute";
            this.excecuteToolStripMenuItem.Click += new System.EventHandler(this.excecuteToolStripMenuItem_Click);
            // 
            // morfologicToolStripMenuItem
            // 
            this.morfologicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erodeToolStripMenuItem,
            this.erodeBorderToolStripMenuItem,
            this.dilateToolStripMenuItem,
            this.dilateBorderToolStripMenuItem});
            this.morfologicToolStripMenuItem.Name = "morfologicToolStripMenuItem";
            this.morfologicToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.morfologicToolStripMenuItem.Text = "Morfologic";
            // 
            // erodeToolStripMenuItem
            // 
            this.erodeToolStripMenuItem.Name = "erodeToolStripMenuItem";
            this.erodeToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.erodeToolStripMenuItem.Text = "Erode";
            this.erodeToolStripMenuItem.Click += new System.EventHandler(this.erodeToolStripMenuItem_Click);
            // 
            // erodeBorderToolStripMenuItem
            // 
            this.erodeBorderToolStripMenuItem.Name = "erodeBorderToolStripMenuItem";
            this.erodeBorderToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.erodeBorderToolStripMenuItem.Text = "Erode3x3Border";
            this.erodeBorderToolStripMenuItem.Click += new System.EventHandler(this.erodeBorderToolStripMenuItem_Click);
            // 
            // dilateToolStripMenuItem
            // 
            this.dilateToolStripMenuItem.Name = "dilateToolStripMenuItem";
            this.dilateToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.dilateToolStripMenuItem.Text = "Dilate";
            this.dilateToolStripMenuItem.Click += new System.EventHandler(this.dilateToolStripMenuItem_Click);
            // 
            // dilateBorderToolStripMenuItem
            // 
            this.dilateBorderToolStripMenuItem.Name = "dilateBorderToolStripMenuItem";
            this.dilateBorderToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.dilateBorderToolStripMenuItem.Text = "Dilate3x3Border";
            this.dilateBorderToolStripMenuItem.Click += new System.EventHandler(this.dilateBorderToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 124);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(138, 28);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // iterNumberTextBox
            // 
            this.iterNumberTextBox.Location = new System.Drawing.Point(3, 158);
            this.iterNumberTextBox.Name = "iterNumberTextBox";
            this.iterNumberTextBox.Size = new System.Drawing.Size(138, 22);
            this.iterNumberTextBox.TabIndex = 11;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(27, 183);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(91, 17);
            this.label.TabIndex = 16;
            this.label.Text = "Set Iterations";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // EroderadioButton1
            // 
            this.EroderadioButton1.AutoSize = true;
            this.EroderadioButton1.Location = new System.Drawing.Point(3, 3);
            this.EroderadioButton1.Name = "EroderadioButton1";
            this.EroderadioButton1.Size = new System.Drawing.Size(67, 21);
            this.EroderadioButton1.TabIndex = 18;
            this.EroderadioButton1.TabStop = true;
            this.EroderadioButton1.Text = "Erode";
            this.EroderadioButton1.UseVisualStyleBackColor = true;
            // 
            // Erode3x3radioButton2
            // 
            this.Erode3x3radioButton2.AutoSize = true;
            this.Erode3x3radioButton2.Location = new System.Drawing.Point(3, 30);
            this.Erode3x3radioButton2.Name = "Erode3x3radioButton2";
            this.Erode3x3radioButton2.Size = new System.Drawing.Size(132, 21);
            this.Erode3x3radioButton2.TabIndex = 19;
            this.Erode3x3radioButton2.TabStop = true;
            this.Erode3x3radioButton2.Text = "Erode3x3Border";
            this.Erode3x3radioButton2.UseVisualStyleBackColor = true;
            // 
            // DilateradioButton3
            // 
            this.DilateradioButton3.AutoSize = true;
            this.DilateradioButton3.Location = new System.Drawing.Point(3, 57);
            this.DilateradioButton3.Name = "DilateradioButton3";
            this.DilateradioButton3.Size = new System.Drawing.Size(65, 21);
            this.DilateradioButton3.TabIndex = 20;
            this.DilateradioButton3.TabStop = true;
            this.DilateradioButton3.Text = "Dilate";
            this.DilateradioButton3.UseVisualStyleBackColor = true;
            // 
            // Dilate3x3radioButton4
            // 
            this.Dilate3x3radioButton4.AutoSize = true;
            this.Dilate3x3radioButton4.Location = new System.Drawing.Point(3, 84);
            this.Dilate3x3radioButton4.Name = "Dilate3x3radioButton4";
            this.Dilate3x3radioButton4.Size = new System.Drawing.Size(130, 21);
            this.Dilate3x3radioButton4.TabIndex = 21;
            this.Dilate3x3radioButton4.TabStop = true;
            this.Dilate3x3radioButton4.Text = "Dilate3x3Border";
            this.Dilate3x3radioButton4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.EroderadioButton1);
            this.panel1.Controls.Add(this.Erode3x3radioButton2);
            this.panel1.Controls.Add(this.Dilate3x3radioButton4);
            this.panel1.Controls.Add(this.DilateradioButton3);
            this.panel1.Location = new System.Drawing.Point(3, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 112);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(294, 570);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "0 xx 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(844, 570);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "0 xx 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Image WIdth x Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 570);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Image WIdth x Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Set Operation";
            // 
            // MainWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1242, 596);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.iterNumberTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ExcecuteButton);
            this.Controls.Add(this.outPictureBox2);
            this.Controls.Add(this.inPictureBox1);
            this.Controls.Add(this.OpenButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWIndow";
            this.Text = "MorfologicalCUDA";
            ((System.ComponentModel.ISupportInitialize)(this.inPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outPictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.PictureBox inPictureBox1;
        private System.Windows.Forms.PictureBox outPictureBox2;
        private System.Windows.Forms.Button ExcecuteButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox iterNumberTextBox;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morfologicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilateBorderToolStripMenuItem;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RadioButton EroderadioButton1;
        private System.Windows.Forms.RadioButton Erode3x3radioButton2;
        private System.Windows.Forms.RadioButton DilateradioButton3;
        private System.Windows.Forms.RadioButton Dilate3x3radioButton4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem excecuteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

