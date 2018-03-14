
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace ASPNET.Sample
{
        [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
        public sealed class ViewStateControl3 : WebControl
        {
                private String _text;

                // <Snippet1>
                // Override the OnLoad method to check if the 
                // page that uses this control has posted back.
                // If so, check whether this controls contains
                // only literal content, and if it does,
                // it gets the UniqueID property and writes it
                // to the page. Otherwise, it writes a message
                // that the control contains more than literal content.
                protected override void OnLoad(EventArgs e)
                {
                        if (Page.IsPostBack)
                        {
                                String s;

                                if (this.IsLiteralContent())
                                {
                                        s = Controls[0].UniqueID;
                                        Context.Response.Write(s);
                                }
                                else
                                {
                                        Context.Response.Write(
                                                "The control contains more than literal content.");
                                }
                        }
                }
                // </Snippet1>
                public String Text
                {
                        get
                        {
                                if (_text == null)
                                {
                                        return String.Empty;
                                }
                                else
                                {
                                        return _text;
                                }
                        }
                        set
                        {
                                _text = value;
                        }
                }
                public String TextInViewState
                {
                        get
                        {
                                Object o = ViewState["TextInViewState"];
                                if (o == null)
                                {
                                        return String.Empty;
                                }
                                else
                                {
                                        return o.ToString();
                                }
                        }
                        set
                        {
                                ViewState["TextInViewState"] = value;
                        }
                }
                // <Snippet2>
                // Override the ViewStateIgnoresCase property to allow the same
                // entries with different casing to be stored in the control's
                // ViewState property.
                protected override bool ViewStateIgnoresCase
                {
                        get
                        { 
                                return true; 
                        }
                }
                // </Snippet2>

                protected override void RenderContents(HtmlTextWriter writer)
                {
                        writer.Write("Text = ");
                        writer.Write(Text);
                        writer.Write("TextInViewState = ");
                        writer.Write(TextInViewState);
                }

        }
}