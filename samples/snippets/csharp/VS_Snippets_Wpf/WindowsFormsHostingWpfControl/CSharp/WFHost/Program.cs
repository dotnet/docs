#region Using directives

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

#endregion

namespace WFHost
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Run the application
            System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.EnableRTLMirroring();
            System.Windows.Forms.Application.Run(new Form1());
        }
    }
}
