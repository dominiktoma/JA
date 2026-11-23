using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppUI
{
    public partial class Form1 : Form
    {
        [DllImport("AsmLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double AddAsm(double a, double b);

        [DllImport("CppLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool AddNoise(IntPtr piksele, int szerokosc, int wysokosc, int stride);

        private Bitmap _originalBmp;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public bool selectedLibrary = true;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void num1_TextChanged(object sender, EventArgs e)
        {

        }

        private void library_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectedLibrary = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Wybierz plik BMP";
                openFileDialog.Filter = "Pliki BMP (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                pictureBox1.Image?.Dispose();
                pictureBox2.Image?.Dispose();
                pictureBox2.Image = null;
                _originalBmp?.Dispose();

                using (Bitmap temp = new Bitmap(openFileDialog.FileName))
                {
                    _originalBmp = temp.Clone(
                        new Rectangle(0, 0, temp.Width, temp.Height),
                        PixelFormat.Format24bppRgb);
                }

                pictureBox1.Image = (Bitmap)_originalBmp.Clone();
                label3.Text = "Wybrany plik: " + openFileDialog.FileName;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selectedLibrary = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedLibrary && _originalBmp != null)
            {
                Bitmap processedBmp = (Bitmap)_originalBmp.Clone();
                Rectangle rect = new Rectangle(0, 0, processedBmp.Width, processedBmp.Height);
                BitmapData bmpData = processedBmp.LockBits(rect, ImageLockMode.ReadWrite, processedBmp.PixelFormat);

                bool success = false;
                try
                {
                    success = AddNoise(bmpData.Scan0, processedBmp.Width, processedBmp.Height, bmpData.Stride);
                }
                finally
                {
                    processedBmp.UnlockBits(bmpData);
                }
                if (success)
                {
                    pictureBox2.Image?.Dispose();
                    pictureBox2.Image = processedBmp;
                }
                else
                {
                    processedBmp.Dispose();
                }
            }
            //else - asm
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
