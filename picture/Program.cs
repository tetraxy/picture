using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;


    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new picture.Form1()); // Запускаем Form1
        }
    }

