// MailLink.cs
// <Snippet1>
using System;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly:TagPrefix("Samples.AspNet", "Sample")]
namespace Samples.AspNet
{
    
   
    [
        AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
        AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal),
        ParseChildren(true, "Text"),
        DefaultProperty("Email"),
        ToolboxData("<{0}:MailLink ID='MailLinkID' Text='Mail Web Master' runat=\"server\"> </{0}:MailLink>")
    ]
    public class MailLink : WebControl
    {
        [
            Browsable(true),
            Category("Appearance"),
            DefaultValue("webmaster@contoso.com"),
            Description("The e-mail address.")
        ]
        public virtual string Email
        {
            get
            {
                string s = (string)ViewState["Email"];
                return (s == null) ? "webmaster@contoso.com" : s;
            }
            set
            {
                ViewState["Email"] = value;
            }
        }

        [
            Browsable(true),
            Category("Appearance"),
            DefaultValue("Web Master"),
            Description("The name to display."),
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
