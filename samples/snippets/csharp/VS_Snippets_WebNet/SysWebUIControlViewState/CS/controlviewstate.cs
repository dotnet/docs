// <snippet1>
// This control renders values stored in view state for Text and FontSize properties.
using System;
using System.Web;
using System.Web.UI;

namespace ViewStateControlSamples
{

    public class CustomLabel : Control
    {
        private const int defaultFontSize = 3;

        // <snippet2>        
        // Add property values to view state with set;
        // retrieve them from view state with get.
        public String Text
        {
            get 
            { 
                object o = ViewState["Text"]; 
                return (o == null)? String.Empty : (string)o;
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        // </snippet2>

        public int FontSize
        {
            get
            {
                object o = ViewState["FontSize"];
                return (o == null) ? defaultFontSize : (int)o;
            }
            set
            {
                ViewState["FontSize"] = value;
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void Render(HtmlTextWriter output)
        {
            output.Write("<font size=" + this.FontSize.ToString() + ">" + this.Text + "</font>");
        }
    }
}
// </snippet1>
