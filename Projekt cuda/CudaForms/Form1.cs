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
    public partial class Form1 : Form
    {
        public Form1()
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
                    if (map != null)
                    {
                        // TODO: size od pictureBox need be set based on size of the main window
                        pictureBox1.Image = map;
                        //pictureBox1.Size = map.Size;
                        pictureBox2.Location = new Point(pictureBox1.Location.X + map.Size.Width + 10, 
                            pictureBox1.Location.Y + map.Size.Height + 10);
                        pictureBox2.Size = map.Size;
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
                Bitmap map = (Bitmap)pictureBox1.Image;
                if (map != null)
                {
                    //got exception when try to allocate new memory
                    //ManagedCuda.NPP.NPPImage_8uC1 test = new NPPImage_8uC1(map.Width, map.Height);
                    //comment this part of exception will occur 
                    ManagedCuda.NPP.NPPImage_8uC3 test = new NPPImage_8uC3(1024, 1024);

                    //test.CopyToHost(map);
                    //test.CopyToDevice(map);
                    //pictureBox1.Image = map;

                    /*EXAMPLE
                        //Load an image
                        Bitmap bmp = new Bitmap("niceImage.png");

                        //Alloc device memory using NPP images
                        NPPImage_8uC3 bmp_d = new NPPImage_8uC3(bmp.Width, bmp.Height);
                        NPPImage_8uC3 bmpDest_d = new NPPImage_8uC3(bmp.Width, bmp.Height);

                        //Copy image to GPU
                        bmp_d.CopyToDevice(bmp);
                        //Run a NPP function
                        bmp_d.FilterGaussBorder(bmpDest_d, MaskSize.Size_5_X_5, NppiBorderType.Replicate);
                        //Copy result back to host
                        bmpDest_d.CopyToHost(bmp);
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
    }
}
