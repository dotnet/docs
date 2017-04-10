using System;
using System.Web;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls{
   
    // The TestLinkButton control generates client-side JavaScript 
    // to cause postback to the server. It participates
    // in postback event handling by implementing
    // the IPostBackEventHandler interface. It
    // exposes a Click event which it raises in the
    // IPostBackEventHandler.RaisePostBackEvent method.
    [
    DefaultEvent("Click"),
    DefaultProperty("Text") 
    ]  
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
	public sealed class TestLinkButton : WebControl, IPostBackEventHandler
	{

        private static readonly object EventClick = new object();
      
        [
        Bindable(true),
        Category("Behavior"),
        DefaultValue(""),
        Description("The text to display on the link")
        ]
        public string Text {
            get {
                string s = (string)ViewState["Text"];
                return((s == null) ? String.Empty : s);
            }
            set {
                ViewState["Text"] = value;
            }
        }

        protected override HtmlTextWriterTag TagKey {
            get {
                return HtmlTextWriterTag.A;
            }
        }
        
        [
        Category("Action"),
        Description("Raised when the hyperlink is clicked")
        ]
        // <snippet1>
        // Create an event that adds and removes handlers from the
        // Control.Events collection when this event is called from
        // a participating page.
        public event EventHandler Click {
            add {
                Events.AddHandler(EventClick, value);
            }
            remove {
                Events.RemoveHandler(EventClick, value);
            }
        }
        // </snippet1>

        // Method of IPostBackEventHandler that raises postback events.
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument){        
            OnClick(EventArgs.Empty);
        }      
   
        // <snippet2>
        // Override the WebControl.AddAttributesToRender method to add an
        // HRef attribute and a string that represents EcmaScript passed from 
        // using the GetPostBackClientHyperlink method.
        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
			writer.AddAttribute(HtmlTextWriterAttribute.Href, Page.ClientScript.GetPostBackClientHyperlink(this, String.Empty));
            //writer.AddAttribute(HtmlTextWriterAttribute.Href, Page.GetPostBackClientHyperlink(this, String.Empty));  
        }
        // </snippet2>
       
        // Retrieves the delegate for the Click event and 
        // invokes the handlers registered with the delegate.
        public void OnClick(EventArgs e) { 
            EventHandler clickHandler = (EventHandler)Events[EventClick];
            if (clickHandler != null) {
                clickHandler(this, e);
            }  
        } 
        // <snippet3>
        // Override the Render method to ensure that this control
        // is nested in an HtmlForm server control, between a <form runat=server>
        // opening tag and a </form> closing tag.
        protected override void Render(HtmlTextWriter writer) {
            // Ensure that the control is nested in a server form.
            if (Page != null) {
                Page.VerifyRenderingInServerForm(this);
            }
            base.Render(writer);
        }
        // </snippet3>

        protected override void RenderContents(HtmlTextWriter writer) {
            writer.Write(Text);
        }
    } 
}

