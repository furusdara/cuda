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
                    label.Text = map.Width.ToString() + "x" + map.Height.ToString();
                    
                    if (map != null)
                    {
                        // TODO: size od pictureBox need be set based on size of the main window
                        inPictureBox1.Image = map;
                        //pictureBox1.Size = map.Size;
                        //outPictureBox2.Location = new Point(inPictureBox1.Location.X + map.Size.Width + 10, 
                        //    inPictureBox1.Location.Y + map.Size.Height + 10);
                        //outPictureBox2.Size = map.Size;
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

            // to co trzeba zrobic
            //ManagedCuda.NPP.NPPNativeMethods.NPPi.MorphologyFilter2D.nppiDilate_16u_C1R(map, 10, map, 10, 3, 1, 1, 1);

            try
            {
                Bitmap map = new Bitmap (inPictureBox1.Image);
                if (map != null)
                {
                    inPictureBox1.Image = null;
                    inPictureBox1.Image = map;

                    NppiSize size = new NppiSize(map.Width, map.Height);

                    ManagedCuda.NPP.NPPImage_8uC3 source = new NPPImage_8uC3(size);
                    ManagedCuda.NPP.NPPImage_8uC3 dest = new NPPImage_8uC3(size);

                    source.CopyToDevice(map);

                    /*
                    //erode
                    source.Erode3x3(dest);
                    Bitmap mapd1 = new Bitmap(map.Width,map.Height);
                    dest.CopyToHost(mapd1);
                    outPictureBox2.Image = mapd1;
                    mapd1.Save("Eroded");
                     * */

                    /*
                    source.Erode3x3Border(dest, NppiBorderType.Replicate);
                    Bitmap mapd2 = new Bitmap(map.Width, map.Height);
                    dest.CopyToHost(mapd2);
                    outPictureBox2.Image = mapd2;
                    mapd2.Save("ErodedBOrder");
                     * */

                    /*
                    source.Dilate3x3(dest);
                    Bitmap mapd2 = new Bitmap(map.Width, map.Height);
                    dest.CopyToHost(mapd2);
                    outPictureBox2.Image = mapd2;
                    mapd2.Save("DIlate");
                    */

                    
                    source.Dilate3x3Border(dest, NppiBorderType.Replicate);
                    Bitmap mapd2 = new Bitmap(map.Width, map.Height);
                    dest.CopyToHost(mapd2);
                    outPictureBox2.Image = mapd2;
                    label.Text = mapd2.Width.ToString() + " xx " + mapd2.Height.ToString();
                    label.Text = source.SizeRoi.ToString();
                    mapd2.Save("DIlateBorder.jpg");
                    

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
                    

                    //EXAMPLE
                    /*
                        //Load an image
                        Bitmap bmp = new Bitmap(map.Width, map.Height);
                        bmp = map;

                        //Alloc device memory using NPP images
                        NPPImage_8uC3 bmp_d = new NPPImage_8uC3(bmp.Width, bmp.Height);
                        NPPImage_8uC3 bmpDest_d = new NPPImage_8uC3(bmp.Width, bmp.Height);

                        //Copy image to GPU
                        bmp_d.CopyToDevice(bmp);
                        //Run a NPP function
                        bmp_d.FilterGaussBorder(bmpDest_d, MaskSize.Size_5_X_5, NppiBorderType.Replicate);
                        //Copy result back to host
                        bmpDest_d.CopyToHost(mapd);
                        outPictureBox2.Image = mapd;
                        //Use the result
                        bmp.Save("niceImageFiltered.png");
                    */
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

            //ManagedCuda.NPP.NPPNativeMethods.NPPi.MorphologyFilter2D.nppiDilate_16u_C1R(test., 10, test, 10, 3, 1, 1, 1);
        }

        private void inPictureBox1_Click(object sender, EventArgs e)
        {
            //Show full size image
        }

        private void outPictureBox2_Click(object sender, EventArgs e)
        {
            //Show full size image
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void morfComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //every selected morf oper should be run
        }

        private void inComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show list of previously selected image
        }

        private void outComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show list of previously morfed image
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //exceptions
            //add messageBox wiht succes info
            this.outPictureBox2.Image.Save(DateTime.Now.ToString() + "png");
        }

        private void iterNumberTextBox1_TextChanged(object sender, EventArgs e)
        {
            //set number of iteration
            //default 1
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
    }
}
