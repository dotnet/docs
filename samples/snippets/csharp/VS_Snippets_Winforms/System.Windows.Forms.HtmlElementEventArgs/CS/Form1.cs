using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HtmlElementEventArgsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document != null)
            {
                //webBrowser1.Document.LosingFocus += new HtmlElementEventHandler(Document_LosingFocus);
                webBrowser1.Document.Click += new HtmlElementEventHandler(Document_Click);
            }
        }

        //<SNIPPET2>
        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;
            string msg = "ClientMousePosition: " + e.ClientMousePosition.ToString() + "\n" +
                "MousePosition: " + e.MousePosition + "\n" +
                "OffsetMousePosition: " + e.OffsetMousePosition;
            MessageBox.Show(msg);
        }
        //</SNIPPET2>

        void Document_LosingFocus(object sender, HtmlElementEventArgs e)
        {
            // Get element underneath.
            HtmlElement elem = e.FromElement;
            if (elem.TagName.Equals("INPUT") && elem.Name.Equals("fromDate"))
            {
                string date = elem.GetAttribute("VALUE");
                try
                {
                    DateTime d = DateTime.Parse(date);
                    elem.SetAttribute("VALUE", d.ToLongDateString());
                    elem.Style = "color:black;";
                }
                catch (Exception ex)
                {
                    elem.Style = "color:red;";
                }
            }
        }

        void Document_Focusing(object sender, HtmlElementEventArgs e)
        {
            // Get element underneath.
            HtmlElement elem = e.FromElement;
            if (elem.TagName.Equals("INPUT") && elem.Name.Equals("fromDate"))
            {
                string date = elem.GetAttribute("VALUE");
                try
                {
                    DateTime d = DateTime.Parse(date);
                    elem.SetAttribute("VALUE", d.ToLongDateString());
                    elem.Style = "color:black;";
                }
                catch (Exception ex)
                {
                    elem.Style = "color:red;";
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(@"D:\HtmlElementEventArgsProject\TestFormConvert.htm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(@"D:\HtmlElementEventArgsProject\TestTable.htm");
        }
    }
}