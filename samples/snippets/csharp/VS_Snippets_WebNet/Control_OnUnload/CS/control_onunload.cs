// Snippet marked here to be grouped with Snippet1 in aspx file.

using System;
using System.Web.UI;
using System.IO;

namespace CustomControlNameSpace
{
    public class MyCustomControl : Control
    {
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        // <Snippet2>
        // Override the OnUnLoad method to set _text to
        // a default value if it is null.
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (_text == null)
                _text = "Here is some default text.";
        }
        // </Snippet2>

        // <Snippet3>      
        // Override the OnLoad method to set _text to
        // a default value if it is null.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_text == null)
                _text = "Here is some default text.";
        }
        // </Snippet3>
        protected override void Render(HtmlTextWriter output)
        {
            output.Write("<INPUT TYPE ='Text' name = " + this.UniqueID + " Value = " + this.Text + " >");
        }

    }
}
