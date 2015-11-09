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
            this.OpenButton1 = new System.Windows.Forms.Button();
            this.inPictureBox1 = new System.Windows.Forms.PictureBox();
            this.outPictureBox2 = new System.Windows.Forms.PictureBox();
            this.Excecutebutton2 = new System.Windows.Forms.Button();
            this.morfComboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.inComboBox1 = new System.Windows.Forms.ComboBox();
            this.outComboBox2 = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.iterNumberTextBox1 = new System.Windows.Forms.TextBox();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morfologicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inPicturevScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.inPicturehScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.outPicturevScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.outPicturehScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outPictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.jpg,*.png|";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // OpenButton1
            // 
            this.OpenButton1.Location = new System.Drawing.Point(25, 54);
            this.OpenButton1.Margin = new System.Windows.Forms.Padding(4);
            this.OpenButton1.Name = "OpenButton1";
            this.OpenButton1.Size = new System.Drawing.Size(116, 28);
            this.OpenButton1.TabIndex = 0;
            this.OpenButton1.Text = "Open";
            this.OpenButton1.UseVisualStyleBackColor = true;
            this.OpenButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inPictureBox1
            // 
            this.inPictureBox1.Location = new System.Drawing.Point(149, 54);
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
            this.outPictureBox2.Location = new System.Drawing.Point(697, 54);
            this.outPictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.outPictureBox2.MaximumSize = new System.Drawing.Size(512, 512);
            this.outPictureBox2.Name = "outPictureBox2";
            this.outPictureBox2.Size = new System.Drawing.Size(512, 422);
            this.outPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outPictureBox2.TabIndex = 2;
            this.outPictureBox2.TabStop = false;
            this.outPictureBox2.Click += new System.EventHandler(this.outPictureBox2_Click);
            // 
            // Excecutebutton2
            // 
            this.Excecutebutton2.Location = new System.Drawing.Point(25, 89);
            this.Excecutebutton2.Margin = new System.Windows.Forms.Padding(4);
            this.Excecutebutton2.Name = "Excecutebutton2";
            this.Excecutebutton2.Size = new System.Drawing.Size(116, 28);
            this.Excecutebutton2.TabIndex = 3;
            this.Excecutebutton2.Text = "Execute";
            this.Excecutebutton2.UseVisualStyleBackColor = true;
            this.Excecutebutton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // morfComboBox1
            // 
            this.morfComboBox1.FormattingEnabled = true;
            this.morfComboBox1.Items.AddRange(new object[] {
            "Erode",
            "ErodeBorder",
            "Dilate",
            "DIlateBorder"});
            this.morfComboBox1.Location = new System.Drawing.Point(25, 125);
            this.morfComboBox1.Name = "morfComboBox1";
            this.morfComboBox1.Size = new System.Drawing.Size(116, 24);
            this.morfComboBox1.TabIndex = 4;
            this.morfComboBox1.Text = "NONE";
            this.morfComboBox1.SelectedIndexChanged += new System.EventHandler(this.morfComboBox1_SelectedIndexChanged);
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
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Erode",
            "ErodeBorder",
            "Dilate",
            "DIlateBorder"});
            this.checkedListBox1.Location = new System.Drawing.Point(25, 156);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(117, 72);
            this.checkedListBox1.TabIndex = 7;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // inComboBox1
            // 
            this.inComboBox1.FormattingEnabled = true;
            this.inComboBox1.Location = new System.Drawing.Point(452, 534);
            this.inComboBox1.Name = "inComboBox1";
            this.inComboBox1.Size = new System.Drawing.Size(209, 24);
            this.inComboBox1.TabIndex = 8;
            this.inComboBox1.SelectedIndexChanged += new System.EventHandler(this.inComboBox1_SelectedIndexChanged);
            // 
            // outComboBox2
            // 
            this.outComboBox2.FormattingEnabled = true;
            this.outComboBox2.Location = new System.Drawing.Point(1000, 534);
            this.outComboBox2.Name = "outComboBox2";
            this.outComboBox2.Size = new System.Drawing.Size(209, 24);
            this.outComboBox2.TabIndex = 9;
            this.outComboBox2.SelectedIndexChanged += new System.EventHandler(this.outComboBox2_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(25, 234);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(116, 28);
            this.Save.TabIndex = 10;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // iterNumberTextBox1
            // 
            this.iterNumberTextBox1.Location = new System.Drawing.Point(25, 268);
            this.iterNumberTextBox1.Name = "iterNumberTextBox1";
            this.iterNumberTextBox1.Size = new System.Drawing.Size(116, 22);
            this.iterNumberTextBox1.TabIndex = 11;
            this.iterNumberTextBox1.TextChanged += new System.EventHandler(this.iterNumberTextBox1_TextChanged);
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
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // erodeToolStripMenuItem
            // 
            this.erodeToolStripMenuItem.Name = "erodeToolStripMenuItem";
            this.erodeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.erodeToolStripMenuItem.Text = "Erode";
            // 
            // dilateToolStripMenuItem
            // 
            this.dilateToolStripMenuItem.Name = "dilateToolStripMenuItem";
            this.dilateToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.dilateToolStripMenuItem.Text = "Dilate";
            // 
            // erodeBorderToolStripMenuItem
            // 
            this.erodeBorderToolStripMenuItem.Name = "erodeBorderToolStripMenuItem";
            this.erodeBorderToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.erodeBorderToolStripMenuItem.Text = "ErodeBorder";
            // 
            // dilateBorderToolStripMenuItem
            // 
            this.dilateBorderToolStripMenuItem.Name = "dilateBorderToolStripMenuItem";
            this.dilateBorderToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.dilateBorderToolStripMenuItem.Text = "DilateBorder";
            // 
            // inPicturevScrollBar1
            // 
            this.inPicturevScrollBar1.Location = new System.Drawing.Point(665, 54);
            this.inPicturevScrollBar1.Name = "inPicturevScrollBar1";
            this.inPicturevScrollBar1.Size = new System.Drawing.Size(28, 422);
            this.inPicturevScrollBar1.TabIndex = 12;
            // 
            // inPicturehScrollBar1
            // 
            this.inPicturehScrollBar1.Location = new System.Drawing.Point(149, 496);
            this.inPicturehScrollBar1.Name = "inPicturehScrollBar1";
            this.inPicturehScrollBar1.Size = new System.Drawing.Size(512, 21);
            this.inPicturehScrollBar1.TabIndex = 13;
            // 
            // outPicturevScrollBar1
            // 
            this.outPicturevScrollBar1.Location = new System.Drawing.Point(1221, 54);
            this.outPicturevScrollBar1.Name = "outPicturevScrollBar1";
            this.outPicturevScrollBar1.Size = new System.Drawing.Size(28, 422);
            this.outPicturevScrollBar1.TabIndex = 14;
            // 
            // outPicturehScrollBar1
            // 
            this.outPicturehScrollBar1.Location = new System.Drawing.Point(697, 496);
            this.outPicturehScrollBar1.Name = "outPicturehScrollBar1";
            this.outPicturehScrollBar1.Size = new System.Drawing.Size(512, 21);
            this.outPicturehScrollBar1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Set Iterations";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1259, 649);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outPicturehScrollBar1);
            this.Controls.Add(this.outPicturevScrollBar1);
            this.Controls.Add(this.inPicturehScrollBar1);
            this.Controls.Add(this.inPicturevScrollBar1);
            this.Controls.Add(this.iterNumberTextBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.outComboBox2);
            this.Controls.Add(this.inComboBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.morfComboBox1);
            this.Controls.Add(this.Excecutebutton2);
            this.Controls.Add(this.outPictureBox2);
            this.Controls.Add(this.inPictureBox1);
            this.Controls.Add(this.OpenButton1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenButton1;
        private System.Windows.Forms.PictureBox inPictureBox1;
        private System.Windows.Forms.PictureBox outPictureBox2;
        private System.Windows.Forms.Button Excecutebutton2;
        private System.Windows.Forms.ComboBox morfComboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox inComboBox1;
        private System.Windows.Forms.ComboBox outComboBox2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox iterNumberTextBox1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morfologicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilateBorderToolStripMenuItem;
        private System.Windows.Forms.VScrollBar inPicturevScrollBar1;
        private System.Windows.Forms.HScrollBar inPicturehScrollBar1;
        private System.Windows.Forms.VScrollBar outPicturevScrollBar1;
        private System.Windows.Forms.HScrollBar outPicturehScrollBar1;
        private System.Windows.Forms.Label label1;
    }
}

