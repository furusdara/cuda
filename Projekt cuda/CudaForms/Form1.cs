using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ManagedCuda.NPP;
using ManagedCuda;

namespace CudaForms
{
    public partial class MainWIndow : Form
    {
        public int Iterations
        {
            get
            {
                try
                {
                    return Int32.Parse(this.iterNumberTextBox.Text);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public MainWIndow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var s = (OpenFileDialog)sender;
            if(s.FileName != null && s.FileName != string.Empty)
            {
                try
                {
                    Bitmap map = new Bitmap(s.FileName);
                    SetTextSize(this.label1, map);
                    
                    if (map != null)
                    {
                        inPictureBox1.Image = map;
                    }
                    else
                    {
                        throw new Exception("Nie można wczytać pliku.");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap map = new Bitmap (inPictureBox1.Image);

                SetTextSize(this.label1, map);

                if (map != null)
                {
                    if (EroderadioButton1.Checked)
                    {
                        try
                        {
                            this.Erode3x3(sender, e, map);
                        }
                        catch (CudaException ex) { }
                    }

                    if (Erode3x3radioButton2.Checked)
                    {
                        try
                        {
                            this.Erode3x3Border(sender, e, map);
                        }
                        catch (CudaException ex) { }
                    }

                    if (DilateradioButton3.Checked)
                    {
                        try
                        {
                            this.Dilate3x3(sender, e, map);
                        }
                        catch (CudaException ex) { }
                    }

                    if (Dilate3x3radioButton4.Checked)
                    {
                        try
                        {
                            this.Dilate3x3Border(sender, e, map);
                        }
                        catch (CudaException ex){}
                    }
                }
            }
            catch (System.BadImageFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void inPictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                //Show full size image
                Form frm = new Form();
                PictureBox pb = new PictureBox();
                pb.Image = this.inPictureBox1.Image;
                pb.Dock = DockStyle.Fill;
                frm.Controls.Add(pb);
                frm.WindowState = FormWindowState.Normal;
                frm.Width = this.inPictureBox1.Image.Width;
                frm.Height = this.inPictureBox1.Image.Height;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void outPictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                //Show full size image
                Form frm = new Form();
                PictureBox pb = new PictureBox();
                pb.Image = this.outPictureBox2.Image;
                pb.Dock = DockStyle.Fill;
                frm.Controls.Add(pb);
                frm.WindowState = FormWindowState.Normal;
                frm.Width = this.inPictureBox1.Image.Width;
                frm.Height = this.inPictureBox1.Image.Height;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //add time to sava name
            try
            {
                this.outPictureBox2.Image.Save(DateTime.Now.ToString("yyyyMMdd_hhss") + ".jpeg");
                MessageBox.Show("Save succesful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Save failed");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button1_Click(sender, e);
        }

        private void excecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button2_Click(sender, e);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.inPictureBox1.Image = null;
            this.outPictureBox2.Image = null;
        }

        private void Erode3x3(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC4 source = new NPPImage_8uC4(map.Width, map.Height);
            source = CudaHelper(map);
            ManagedCuda.NPP.NPPImage_8uC4 dest = new NPPImage_8uC4(source.Size);

            Int32 iter = Iterations;
            for (int i = 0; i < iter; i++)
            {
                source.Erode3x3(dest);
                source = dest;
            }

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private void Erode3x3Border(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC4 source = new NPPImage_8uC4(map.Width, map.Height);
            source = CudaHelper(map);
            ManagedCuda.NPP.NPPImage_8uC4 dest = new NPPImage_8uC4(source.Size);

            Int32 iter = Iterations;
            for (int i = 0; i < iter; i++)
            {
                source.Erode3x3Border(dest, NppiBorderType.Replicate);
                source = dest;
            }

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private void Dilate3x3(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC4 source = new NPPImage_8uC4(map.Width, map.Height);
            source = CudaHelper(map);
            ManagedCuda.NPP.NPPImage_8uC4 dest = new NPPImage_8uC4(source.Size);

            Int32 iter = Iterations;
            for (int i = 0; i < iter; i++)
            {
                source.Dilate3x3(dest);
                source = dest;
            }
            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private void Dilate3x3Border(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC4 source = new NPPImage_8uC4(map.Width, map.Height);
            source = CudaHelper(map);
            ManagedCuda.NPP.NPPImage_8uC4 dest = new NPPImage_8uC4(source.Size);

            Int32 iter = Iterations;
            for (int i = 0; i < iter; i++)
            {
                source.Dilate3x3Border(dest, NppiBorderType.Replicate);
                source = dest;
            }

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private ManagedCuda.NPP.NPPImage_8uC4 CudaHelper(Bitmap map)
        {
            NppiSize size = new NppiSize(map.Width, map.Height);

            ManagedCuda.NPP.NPPImage_8uC4 source = new NPPImage_8uC4(size);
            
            source.CopyToDevice(map);

            return source;
        }

        private void SetTextSize(Label label, Bitmap destMap)
        {
            label.Text = destMap.Width.ToString() + " xx " + destMap.Height.ToString();
        }

        private void erodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap map = new Bitmap(inPictureBox1.Image);

                if (map != null)
                {
                    this.Erode3x3(sender, e, map);
                }
            }
            catch (System.BadImageFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void erodeBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap map = new Bitmap(inPictureBox1.Image);

                if (map != null)
                {
                    this.Erode3x3Border(sender, e, map);
                }
            }
            catch (System.BadImageFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dilateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap map = new Bitmap(inPictureBox1.Image);

                if (map != null)
                {
                    this.Dilate3x3(sender, e, map);
                }
            }
            catch (System.BadImageFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dilateBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap map = new Bitmap(inPictureBox1.Image);

                if (map != null)
                {
                    this.Dilate3x3Border(sender, e, map);
                }
            }
            catch (System.BadImageFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
