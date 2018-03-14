//<snippet1>
//<snippet2>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//</snippet2>
//<snippet3>
    public class Form1 : Form
//</snippet3>
    {
        //<snippet4>
        public Form1() {}
        //</snippet4>  
  
        //<snippet5>
        [STAThread]
        public static void Main()
        {
          Application.EnableVisualStyles();
          Application.Run(new Form1());

        }
        
        //</snippet5>
    }

    //</snippet1>