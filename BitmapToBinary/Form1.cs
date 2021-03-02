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

namespace BitmapToBinary
{
    public partial class Form1 : Form
    {
        Bitmap img;
        StreamWriter textFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All images|*.bmp; *.jpg;";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName.ToString();
                img = new Bitmap(openFileDialog1.FileName.ToString());
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            textFile = new StreamWriter("C:\\Users\\Merve Ayas\\Desktop\\binary_image.txt");
            string text = "";
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    if (img.GetPixel(j, i).R.ToString() == "255"
                        && img.GetPixel(j, i).G.ToString() == "255" 
                        && img.GetPixel(j, i).B.ToString() == "255")
                    {
                        text = text + "0";
                    }
                    else
                    {
                        text = text + "1";
                    }
                    
                }
               
                    text = text + "\r\n";
                
               
            }
            textFile.WriteLine(text);
            textFile.Close();
        }
    }
}
