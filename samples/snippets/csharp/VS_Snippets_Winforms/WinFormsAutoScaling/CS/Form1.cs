//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//<SNIPPET2>
using Microsoft.Win32;
//</SNIPPET2>

namespace WinFormsAutoScaling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //<SNIPPET3>
            this.Font = SystemFonts.IconTitleFont;
            SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            //</SNIPPET3>
        }

        //<SNIPPET4>
        void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Window)
            {
                this.Font = SystemFonts.IconTitleFont;
            }
        }
        //</SNIPPET4>

        //<SNIPPET5>
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
        }
        //</SNIPPET5>
    }
}
//</SNIPPET1>
