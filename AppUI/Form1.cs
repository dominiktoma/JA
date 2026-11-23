/*
 * Project Topic: Image Noise Addition Application (C# UI with C++ and Assembly DLLs)
 * Short Algorithm Description:
 *   The graphical user interface loads a 24-bit RGB BMP image, locks its pixel memory 
 *   in RAM using LockBits, and passes the raw memory pointer along with image dimensions 
 *   and stride to an external native library (C++ or ASM) to apply a noise filter. 
 *   The execution time is measured and the resulting image is displayed on screen.
 * Date: 23.11.2026 | Semester 5, Year 3 | Author: Dominik Toma
 * Current Version: v1.0
 * Version History:
 *   - v1.0 (23.11.2026): Initial implementation of the GUI, BMP file loading, 
 *     memory locking mechanism, execution timer, and C++ DLL integration.
 *     
 * Note: Documentation comments in this file were generated using AI.
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace AppUI
{
    /// <summary>
    /// Main application form handling user interaction, image loading, and native library calls.
    /// </summary>
    public partial class Form1 : Form
    {
        // =========================================================================
        // EXTERNAL NATIVE FUNCTIONS (DLL IMPORTS)
        // =========================================================================

        /// <summary>
        /// Procedure Name: AddAsm
        /// Description: External Assembly procedure for adding two floating-point numbers (test function).
        /// Input Parameters:
        ///   - a (double): First addend. Value range: standard IEEE 754 double precision.
        ///   - b (double): Second addend. Value range: standard IEEE 754 double precision.
        /// Output Parameters:
        ///   - Return value (double): Sum of a and b. Value range: standard IEEE 754 double precision.
        /// Modified Registers and Flags: XMM0, XMM1 (modified during floating-point operations, managed by cdecl).
        /// </summary>
        [DllImport("AsmLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double AddAsm(double a, double b);

        /// <summary>
        /// Procedure Name: AddNoise
        /// Description: External C++ procedure that modifies raw RGB pixel data in-place by adding random noise.
        /// Input Parameters:
        ///   - pixels (IntPtr): Pointer to the unmanaged memory block containing image pixel data (24bpp RGB). Range: valid non-null memory address.
        ///   - width (int): Image width in pixels. Range: > 0.
        ///   - height (int): Image height in pixels. Range: > 0.
        ///   - stride (int): Width of a single row of pixels in bytes (including padding). Range: >= width * 3.
        /// Output Parameters:
        ///   - Return value (bool): Returns true if processing succeeded, false if an error occurred (e.g., null pointer).
        /// Modified Registers and Flags: Standard volatile registers (RAX, RCX, RDX, R8-R11) and CPU status flags (ZF, CF, SF, OF) restored per cdecl convention.
        /// </summary>
        [DllImport("CppLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool AddNoise(IntPtr pixels, int width, int height, int stride);

        // =========================================================================
        // CLASS FIELDS (VARIABLES)
        // =========================================================================

        /// <summary>
        /// Stores the original loaded bitmap converted to 24-bit RGB format.
        /// </summary>
        private Bitmap _originalBmp;

        /// <summary>
        /// Flag indicating which native library is currently selected by the user (true = C++ DLL, false = ASM DLL).
        /// </summary>
        private bool _selectedCppLibrary = true;

        // =========================================================================
        // CONSTRUCTOR & EVENT HANDLERS
        // =========================================================================

        /// <summary>
        /// Procedure Name: Form1 (Constructor)
        /// Description: Initializes form components and configures PictureBox display modes.
        /// Input Parameters: None.
        /// Output Parameters: None.
        /// Modified Registers and Flags: Managed CLR state only.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            originalImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            processedImageBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Procedure Name: asmButton_CheckedChanged
        /// Description: Event handler triggered when the Assembly radio button state changes. Sets the active library flag to ASM.
        /// Input Parameters:
        ///   - sender (object): Reference to the control that raised the event.
        ///   - e (EventArgs): Event data.
        /// Output Parameters: None.
        /// Modified Registers and Flags: Managed CLR state only.
        /// </summary>
        private void asmButton_CheckedChanged(object sender, EventArgs e)
        {
            _selectedCppLibrary = false;
        }

        /// <summary>
        /// Procedure Name: selectFileButton_Click
        /// Description: Opens a file dialog to select a BMP image, disposes of previous bitmaps, 
        ///              converts the image to 24bpp RGB format, and displays it in the UI.
        /// Input Parameters:
        ///   - sender (object): Reference to the button control that raised the event.
        ///   - e (EventArgs): Event data.
        /// Output Parameters: None.
        /// Modified Registers and Flags: Managed CLR state only.
        /// </summary>
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            // Initialize and configure the file selection dialog for BMP files
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a BMP file";
                openFileDialog.Filter = "BMP Files (*.bmp)|*.bmp";

                // Abort if the user cancels the dialog
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                // Free unmanaged GDI+ resources from previously loaded images
                originalImageBox.Image?.Dispose();
                processedImageBox.Image?.Dispose();
                processedImageBox.Image = null;
                _originalBmp?.Dispose();

                // Load the image temporarily and clone it into a standardized 24-bit RGB format
                using (Bitmap temp = new Bitmap(openFileDialog.FileName))
                {
                    _originalBmp = temp.Clone(
                        new Rectangle(0, 0, temp.Width, temp.Height),
                        PixelFormat.Format24bppRgb);
                }

                // Display the loaded image and update the file path label
                originalImageBox.Image = (Bitmap)_originalBmp.Clone();
                pathLabel.Text = "Selected file: " + openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Procedure Name: cppButton_CheckedChanged
        /// Description: Event handler triggered when the C++ radio button state changes. Sets the active library flag to C++.
        /// Input Parameters:
        ///   - sender (object): Reference to the control that raised the event.
        ///   - e (EventArgs): Event data.
        /// Output Parameters: None.
        /// Modified Registers and Flags: Managed CLR state only.
        /// </summary>
        private void cppButton_CheckedChanged(object sender, EventArgs e)
        {
            _selectedCppLibrary = true;
        }

        /// <summary>
        /// Procedure Name: startButton_Click
        /// Description: Clones the original bitmap, locks its memory bits, invokes the selected native DLL 
        ///              to process the image while measuring execution time, and renders the output.
        /// Input Parameters:
        ///   - sender (object): Reference to the button control that raised the event.
        ///   - e (EventArgs): Event data.
        /// Output Parameters: None.
        /// Modified Registers and Flags: Managed CLR state; native registers modified temporarily during DLL call.
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            // Ensure C++ library is selected and a valid source image is loaded
            if (_selectedCppLibrary && _originalBmp != null)
            {
                // Create a working copy of the original bitmap
                Bitmap processedBmp = (Bitmap)_originalBmp.Clone();
                Rectangle rect = new Rectangle(0, 0, processedBmp.Width, processedBmp.Height);

                // Lock bitmap bits in system memory to obtain a direct pointer for unmanaged code
                BitmapData bmpData = processedBmp.LockBits(rect, ImageLockMode.ReadWrite, processedBmp.PixelFormat);

                bool success = false; // Stores the execution result of the native function
                Stopwatch sw;         // High-resolution timer for benchmarking DLL execution

                try
                {
                    sw = Stopwatch.StartNew();
                    // Execute the external C++ noise generation function
                    success = AddNoise(bmpData.Scan0, processedBmp.Width, processedBmp.Height, bmpData.Stride);
                    sw.Stop();
                }
                finally
                {
                    // Always unlock the memory bits regardless of whether an exception occurred
                    processedBmp.UnlockBits(bmpData);
                }

                // Update UI if processing succeeded; otherwise, release the working bitmap
                if (success)
                {
                    processedImageBox.Image?.Dispose();
                    processedImageBox.Image = processedBmp;
                    timeLabel.Text = sw.ElapsedMilliseconds.ToString() + " ms";
                }
                else
                {
                    processedBmp.Dispose();
                }
            }
            // else - ASM implementation branch
        }
    }
}