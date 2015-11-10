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
            this.morfologicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MorfListBox = new System.Windows.Forms.CheckedListBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.iterNumberTextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.OpenButton.Location = new System.Drawing.Point(25, 54);
            this.OpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(116, 28);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // inPictureBox1
            // 
            this.inPictureBox1.Location = new System.Drawing.Point(150, 54);
            this.inPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.inPictureBox1.MaximumSize = new System.Drawing.Size(512, 512);
            this.inPictureBox1.Name = "inPictureBox1";
            this.inPictureBox1.Size = new System.Drawing.Size(512, 422);
            this.inPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.inPictureBox1.TabIndex = 1;
            this.inPictureBox1.TabStop = false;
            this.inPictureBox1.Click += new System.EventHandler(this.inPictureBox1_Click);
            // 
            // outPictureBox2
            // 
            this.outPictureBox2.Location = new System.Drawing.Point(700, 54);
            this.outPictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.outPictureBox2.MaximumSize = new System.Drawing.Size(512, 512);
            this.outPictureBox2.Name = "outPictureBox2";
            this.outPictureBox2.Size = new System.Drawing.Size(512, 422);
            this.outPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outPictureBox2.TabIndex = 2;
            this.outPictureBox2.TabStop = false;
            this.outPictureBox2.Click += new System.EventHandler(this.outPictureBox2_Click);
            // 
            // ExcecuteButton
            // 
            this.ExcecuteButton.Location = new System.Drawing.Point(25, 89);
            this.ExcecuteButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExcecuteButton.Name = "ExcecuteButton";
            this.ExcecuteButton.Size = new System.Drawing.Size(116, 28);
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
            this.menuStrip1.Size = new System.Drawing.Size(1259, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
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
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.closeToolStripMenuItem.Text = "Close";
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
            this.erodeToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.erodeToolStripMenuItem.Text = "Erode";
            // 
            // erodeBorderToolStripMenuItem
            // 
            this.erodeBorderToolStripMenuItem.Name = "erodeBorderToolStripMenuItem";
            this.erodeBorderToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.erodeBorderToolStripMenuItem.Text = "ErodeBorder";
            // 
            // dilateToolStripMenuItem
            // 
            this.dilateToolStripMenuItem.Name = "dilateToolStripMenuItem";
            this.dilateToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.dilateToolStripMenuItem.Text = "Dilate";
            // 
            // dilateBorderToolStripMenuItem
            // 
            this.dilateBorderToolStripMenuItem.Name = "dilateBorderToolStripMenuItem";
            this.dilateBorderToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.dilateBorderToolStripMenuItem.Text = "DilateBorder";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MorfListBox
            // 
            this.MorfListBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MorfListBox.FormattingEnabled = true;
            this.MorfListBox.Items.AddRange(new object[] {
            "Erode",
            "ErodeBorder",
            "Dilate",
            "DIlateBorder"});
            this.MorfListBox.Location = new System.Drawing.Point(25, 122);
            this.MorfListBox.Name = "MorfListBox";
            this.MorfListBox.Size = new System.Drawing.Size(117, 106);
            this.MorfListBox.TabIndex = 7;
            this.MorfListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(25, 234);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(116, 28);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // iterNumberTextBox
            // 
            this.iterNumberTextBox.Location = new System.Drawing.Point(25, 268);
            this.iterNumberTextBox.Name = "iterNumberTextBox";
            this.iterNumberTextBox.Size = new System.Drawing.Size(116, 22);
            this.iterNumberTextBox.TabIndex = 11;
            this.iterNumberTextBox.TextChanged += new System.EventHandler(this.iterNumberTextBox1_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(38, 293);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(91, 17);
            this.label.TabIndex = 16;
            this.label.Text = "Set Iterations";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 21);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "None";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 21);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Constant";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 57);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 21);
            this.radioButton3.TabIndex = 20;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Replicate";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(3, 84);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(63, 21);
            this.radioButton4.TabIndex = 21;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Wrap";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(3, 111);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(66, 21);
            this.radioButton5.TabIndex = 22;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Mirror";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Location = new System.Drawing.Point(25, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 137);
            this.panel1.TabIndex = 23;
            // 
            // MainWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1259, 649);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.iterNumberTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MorfListBox);
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
        private System.Windows.Forms.CheckedListBox MorfListBox;
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
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Panel panel1;
    }
}

