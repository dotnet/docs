using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InPlaceHostingManagerProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show("What?" + ex.ToString());
            }
        }
    }
}