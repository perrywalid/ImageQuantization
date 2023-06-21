using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageQuantization
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                siticonePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, siticonePictureBox1);
            }
            siticoneTextBox1.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            siticoneTextBox2.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            PixelOperations po = new PixelOperations();
            po.imageMatrix = ImageMatrix;
            int k = int.Parse(kValue.Text);
            siticonePictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageOperations.DisplayImage(po.Quantize(k), siticonePictureBox2);

            mstValue.Text = po.mstSUM.ToString();
            distinctValue.Text = po.distinctSize.ToString();
            //double sigma = double.Parse(txtGaussSigma.Text);
            //int maskSize = (int)nudMaskSize.Value ;
            //ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            //ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void txtGaussSigma_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void distinctLabel_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                siticonePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, siticonePictureBox1);
            }
            siticoneTextBox1.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            siticoneTextBox2.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            PixelOperations po = new PixelOperations();
            po.imageMatrix = ImageMatrix;
            int k = int.Parse(kValue.Text);
            siticonePictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageOperations.DisplayImage(po.Quantize(k), siticonePictureBox2);

            mstValue.Text = po.mstSUM.ToString();
            distinctValue.Text = po.distinctSize.ToString();
            //double sigma = double.Parse(txtGaussSigma.Text);
            //int maskSize = (int)nudMaskSize.Value ;
            //ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            //ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }
    }

}