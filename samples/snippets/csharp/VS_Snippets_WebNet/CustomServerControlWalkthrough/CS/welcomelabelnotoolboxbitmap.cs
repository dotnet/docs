// <Snippet1>
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl1
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WelcomeLabel runat=server></{0}:WelcomeLabel>")]
    public class WelcomeLabel : Label
    {
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display when the user is not logged in."),
        Localizable(true)
        ]
        public virtual string DefaultUserName
        {
            get
            {
                string s = (string)ViewState["DefaultUserName"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["DefaultUserName"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.WriteEncodedText(Text);

            string displayUserName = DefaultUserName;
            if (Context != null)
            {
                string userName = Context.User.Identity.Name;
                if (!String.IsNullOrEmpty(userName))
                {
                    displayUserName = userName;
                }
            }

            if (!String.IsNullOrEmpty(displayUserName))
            {
                writer.Write(", ");
                writer.WriteEncodedText(displayUserName);
            }

            writer.Write("!");
        }
    }
}
// </Snippet1>
