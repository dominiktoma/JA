/*
 * Project Topic: Image Noise Addition Application (C# UI with C++ and Assembly DLLs)
 * Short Algorithm Description:
 *   Application entry point. Configures the Win32 DLL search path to locate compiled 
 *   x64 native libraries (C++ and ASM) in the solution output directory, initializes 
 *   Windows Forms visual styles, and launches the main application window (Form1).
 * Date: 23.11.2026 | Semester 5, Year 3 | Author: Dominik Toma
 * Current Version: v1.0
 * Version History:
 *   - v1.0 (23.11.2026): Initial configuration of dynamic DLL directory resolution 
 *     and application startup routine.
 *     
 * Note: Documentation comments in this file were generated using AI.
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppUI
{
    /// <summary>
    /// Static class containing the main entry point for the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Procedure Name: SetDllDirectory
        /// Description: Win32 API function that adds a directory to the search path used to locate DLLs for the application.
        /// Input Parameters:
        ///   - lpPathName (string): The directory path to be added to the search path. Range: valid file system path string or null.
        /// Output Parameters:
        ///   - Return value (bool): Returns true if the function succeeds, false otherwise.
        /// Modified Registers and Flags: Standard Win32 volatile registers (RAX, RCX, RDX, R8-R11) and CPU status flags.
        /// </summary>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        /// <summary>
        /// Procedure Name: Main
        /// Description: The main entry point for the application. Resolves the path to the x64\Debug 
        ///              folder containing native DLLs, registers it with the OS, and starts the GUI.
        /// Input Parameters: None.
        /// Output Parameters: None.
        /// Modified Registers and Flags: Managed CLR state only.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Determine the full path to the application's base execution directory
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up from bin\Debug\net8.0-windows to the solution's x64\Debug folder containing DLLs
            string dllFolder = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\..\x64\Debug"));

            // Register the x64\Debug directory in the OS as a valid source for DLL resolution
            SetDllDirectory(dllFolder);

            // Initialize application configuration and run the main form
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}