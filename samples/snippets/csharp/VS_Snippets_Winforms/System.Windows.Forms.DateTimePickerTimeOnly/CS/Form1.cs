//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimePickerApplication
{
    public class Form1 : Form
    {
        public Form1()
        {
            InitializeTimePicker();
        }
//<snippet4>
        private DateTimePicker timePicker;

        private void InitializeTimePicker()
        {
            timePicker = new DateTimePicker();
            //<snippet2>
            timePicker.Format = DateTimePickerFormat.Time;
            //</snippet2>
            //<snippet3>
            timePicker.ShowUpDown = true;
            //</snippet3>
            timePicker.Location = new Point(10, 10);
            timePicker.Width = 100;
            Controls.Add(timePicker);
        }
//</snippet4>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        
    }
}
//</snippet1>