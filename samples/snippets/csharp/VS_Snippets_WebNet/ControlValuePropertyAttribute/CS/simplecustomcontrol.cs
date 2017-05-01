// <Snippet1>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{
    // Set ControlValueProperty attribute to specify the default
    // property of this control that a ControlParameter object 
    // binds to at run time.
    [DefaultProperty("Text")]
    [ControlValueProperty("Text", "Default Text")]
    public class SimpleCustomControl : WebControl
    {
        private string text;

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
}

// </Snippet1>
