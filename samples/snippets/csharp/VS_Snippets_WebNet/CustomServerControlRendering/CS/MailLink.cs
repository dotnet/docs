// <Snippet1>
// MailLink.cs
using System;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{
    [
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal),
    DefaultProperty("Email"),
    ParseChildren(true, "Text"),
    ToolboxData("<{0}:MailLink runat=\"server\"> </{0}:MailLink>")
    ]
    public class MailLink : WebControl
    {
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The e-mail address.")
        ]
        public virtual string Email
        {
            get
            {
                string s = (string)ViewState["Email"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["Email"] = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on the link."),
        Localizable(true),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.A;
            }
        }

        protected override void AddAttributesToRender(
            HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, 
                "mailto:" + Email);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Text == String.Empty)
            {
                Text = Email;
            }
            writer.WriteEncodedText(Text);
        }
    }
}
// </Snippet1>
