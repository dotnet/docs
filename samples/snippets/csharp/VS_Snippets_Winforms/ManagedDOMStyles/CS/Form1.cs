using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace ManagedDOMStyles
{
    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        //<SNIPPET2>
        StyleGenerator sg = null;
        HtmlElement elem = null;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            sg = new StyleGenerator();

            webBrowser1.Document.MouseOver += new HtmlElementEventHandler(Document_MouseOver);
            webBrowser1.Document.MouseLeave += new HtmlElementEventHandler(Document_MouseLeave);
        }

        void Document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            elem = webBrowser1.Document.GetElementFromPoint(e.MousePosition);
            if (elem.TagName.Equals("DIV"))
            {
                sg.ParseStyleString(elem.Style);
                sg.SetStyle("font-style", "italic");
                elem.Style = sg.GetStyleString();
            }
        }

        void Document_MouseLeave(object sender, HtmlElementEventArgs e)
        {
            if (elem != null)
            {
                sg.RemoveStyle("font-style");
                elem.Style = sg.GetStyleString();
                // Reset, since we may mouse over a new DIV element next time.
                sg.Clear();
            }
        }
        //</SNIPPET2>
    }
}