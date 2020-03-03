using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS1.Controls
{
    //<snippet1>
    public class CustomHyperLinkControl : WebControl
    {
        public CustomHyperLinkControl() { }

        // The TargetUrl property represents the URL that 
        // the custom hyperlink control navigates to.
        [UrlProperty()]
        public string TargetUrl
        {
            get
            {
                string s = (string)ViewState["TargetUrl"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["TargetUrl"] = value;
            }
        }

        // The Text property represents the visible text that 
        // the custom hyperlink control is displayed with.        
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        // Implement this method to render the control.
    }
    //</snippet1>
}
namespace Samples.AspNet.CS2.Controls
{
    //<snippet2>
    public class CustomHyperLinkControl : WebControl
    {
        public CustomHyperLinkControl() { }

        // The TargetUrl property represents the URL that 
        // the custom hyperlink control navigates to.
        [UrlProperty("*.aspx")]
        public string TargetUrl
        {
            get
            {
                string s = (string)ViewState["TargetUrl"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["TargetUrl"] = value;
            }
        }

        // The Text property represents the visible text that 
        // the custom hyperlink control is displayed with.        
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        // Implement method to render the control.
    }
    //</snippet2>
}
namespace Samples.AspNet.CS3.Controls
{
    //<snippet3>
    public class CustomHyperLinkControl : WebControl
    {
        public CustomHyperLinkControl() { }

        // The TargetUrl property represents the URL that 
        // the custom hyperlink control navigates to.
        [UrlProperty("*.aspx")]
        public string TargetUrl
        {
            get
            {
                string s = (string)ViewState["TargetUrl"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["TargetUrl"] = value;
            }
        }

        // The Text property represents the visible text that 
        // the custom hyperlink control is displayed with.        
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        // Implement method to render the control.
    }
    //</snippet3>
}
