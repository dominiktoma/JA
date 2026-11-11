using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppUI
{
    internal static class Program
    {
        // Import funkcji Win32 API do dodawania ścieżek poszukiwania DLL
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        [STAThread]
        static void Main()
        {
            // Wyznaczamy pełną ścieżkę do katalogu x64\Debug w rozwiązaniu
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            // Wychodzimy z bin/Debug/net8.0-windows do głównego folderu z plikami DLL
            string dllFolder = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\..\x64\Debug"));

            // Rejestrujemy folder x64\Debug w systemie jako źródło bibliotek DLL
            SetDllDirectory(dllFolder);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}