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
                        pictureBox1.Image = map;
                        pictureBox1.Size = map.Size;
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
            //ManagedCuda.NPP.NPPNativeMethods.NPPi.MorphologyFilter2D.
            
        }
    }
}
