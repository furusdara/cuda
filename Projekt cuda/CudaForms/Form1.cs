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

namespace CudaForms
{
    public partial class MainWIndow : Form
    {
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
                        this.Erode3x3(sender, e, map, iterNumberTextBox);
                    }

                    if (Erode3x3radioButton2.Checked)
                    {
                        this.Erode3x3Border(sender, e, map);
                    }

                    if (DilateradioButton3.Checked)
                    {
                        this.Dilate3x3(sender, e, map);
                    }

                    if (Dilate3x3radioButton4.Checked)
                    {
                        this.Dilate3x3Border(sender, e, map);
                    }

                    ///////////////////////////////////////////////////////////////////////////////////////////////
                    //still got exceptions
                    /*
                    ManagedCuda.CudaDeviceVariable<byte> test = new ManagedCuda.CudaDeviceVariable<byte>(256);
                    NppiSize size1 = new NppiSize(map.Width, map.Height);
                    NppiPoint point1 = new NppiPoint();
                    source.DilateBorder(dest, test, size1, point1, NppiBorderType.Replicate);

                    Bitmap mapd2 = new Bitmap(map.Width, map.Height);
                    dest.CopyToHost(mapd2);
                    outPictureBox2.Image = mapd2;
                    label.Text = mapd2.Width.ToString() + " xx " + mapd2.Height.ToString();
                    label.Text = source.SizeRoi.ToString();
                    mapd2.Save("DIlateBorder.jpg");
                     * */
                    ///////////////////////////////////////////////////////////////////////////////////////////////
                    
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

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void Erode3x3(object sender, EventArgs e, Bitmap map, TextBox Iterations)
        {
            UInt32 iterations = 1;

            try
            {
                iterations = Convert.ToUInt32(Iterations.Text);
            }
            catch (Exception ex)
            {
                iterations = 1;
            }

            ManagedCuda.NPP.NPPImage_8uC3 source = new NPPImage_8uC3(CudaHelper(map));
            ManagedCuda.NPP.NPPImage_8uC3 dest = new NPPImage_8uC3(source.Size);

            source.Erode3x3(dest);

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private void Erode3x3Border(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC3 source = new NPPImage_8uC3(CudaHelper(map));
            ManagedCuda.NPP.NPPImage_8uC3 dest = new NPPImage_8uC3(source.Size);

            source.Erode3x3Border(dest, NppiBorderType.Replicate);

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private void Dilate3x3(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC3 source = new NPPImage_8uC3(CudaHelper(map));
            ManagedCuda.NPP.NPPImage_8uC3 dest = new NPPImage_8uC3(source.Size);

            source.Dilate3x3Border(dest, NppiBorderType.Replicate);

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private void Dilate3x3Border(object sender, EventArgs e, Bitmap map)
        {
            ManagedCuda.NPP.NPPImage_8uC3 source = new NPPImage_8uC3(CudaHelper(map));
            ManagedCuda.NPP.NPPImage_8uC3 dest = new NPPImage_8uC3(source.Size);

            source.Dilate3x3(dest);

            Bitmap destMap = new Bitmap(map.Width, map.Height);
            dest.CopyToHost(destMap);
            outPictureBox2.Image = destMap;

            SetTextSize(this.label2, destMap);
        }

        private ManagedCuda.NPP.NPPImage_8uC3 CudaHelper(Bitmap map)
        {
            NppiSize size = new NppiSize(map.Width, map.Height);

            ManagedCuda.NPP.NPPImage_8uC3 source = new NPPImage_8uC3(size);
            
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
                    this.Erode3x3(sender, e, map, iterNumberTextBox);
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
