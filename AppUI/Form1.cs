using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AppUI
{
    public partial class Form1 : Form
    {
        [DllImport("AsmLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double AddAsm(double a, double b);

        [DllImport("CppLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool AddNoise(IntPtr piksele, int szerokosc, int wysokosc, int stride);

        private Bitmap _originalBmp;
        private bool selectedCppLibrary = true;

        public Form1()
        {
            InitializeComponent();
            originalImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            processedImageBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void asmButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedCppLibrary = false;
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Wybierz plik BMP";
                openFileDialog.Filter = "Pliki BMP (*.bmp)|*.bmp";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                originalImageBox.Image?.Dispose();
                processedImageBox.Image?.Dispose();
                processedImageBox.Image = null;
                _originalBmp?.Dispose();

                using (Bitmap temp = new Bitmap(openFileDialog.FileName))
                {
                    _originalBmp = temp.Clone(
                        new Rectangle(0, 0, temp.Width, temp.Height),
                        PixelFormat.Format24bppRgb);
                }

                originalImageBox.Image = (Bitmap)_originalBmp.Clone();
                pathLabel.Text = "Wybrany plik: " + openFileDialog.FileName;

            }
        }

        private void cppButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedCppLibrary = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (selectedCppLibrary && _originalBmp != null)
            {
                Bitmap processedBmp = (Bitmap)_originalBmp.Clone();
                Rectangle rect = new Rectangle(0, 0, processedBmp.Width, processedBmp.Height);
                BitmapData bmpData = processedBmp.LockBits(rect, ImageLockMode.ReadWrite, processedBmp.PixelFormat);

                bool success = false;
                Stopwatch sw;
                try
                {
                    sw = Stopwatch.StartNew();
                    success = AddNoise(bmpData.Scan0, processedBmp.Width, processedBmp.Height, bmpData.Stride);
                    sw.Stop();
                }
                finally
                {
                    processedBmp.UnlockBits(bmpData);
                }
                if (success)
                {
                    processedImageBox.Image?.Dispose();
                    processedImageBox.Image = processedBmp;
                    timeLabel.Text = sw.ElapsedMilliseconds.ToString()+"ms";
                }
                else
                {
                    processedBmp.Dispose();
                }
            }
            //else - asm
        }
    }
}
