// <snippet1>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.Controls
{
    public sealed class CustomLogin : Login
    {
        public CustomLogin() { }
        
        protected override void OnLoggingIn(LoginCancelEventArgs e)
        {
            // Set the Membership provider for the Login control from a DropDownList.
            DropDownList list = (DropDownList)this.FindControl("domain");
            this.MembershipProvider = list.SelectedValue;
            base.OnLoggingIn(e);
        }
        
        protected override void CreateChildControls()
        {
            LayoutTemplate = new MyTemplate();
            base.CreateChildControls();
        }
    }
    
    // A Template that contains the child controls.
    public class MyTemplate : ITemplate
    {
        void ITemplate.InstantiateIn(Control container)
        {
            // A TextBox for the user name.
            TextBox username = new TextBox();
            username.ID = "username";
            
            // A TextBox for the password.
            TextBox password = new TextBox();
            password.ID = "password";
            
            // A CheckBox to remember the user on subsequent visits.
            CheckBox remember = new CheckBox();
            remember.ID = "RememberMe";
            remember.Text = "Don't forget me!";
            
            // Failure Text.
            Literal failure = new Literal();
            failure.ID = "FailureText";
            
            // A DropDownList to choose the Membership provider.
            DropDownList domain = new DropDownList();
            domain.ID = "Domain";
            domain.Items.Add(new ListItem("SqlMembers"));
            domain.Items.Add(new ListItem("SqlMembers2"));
            
            // A Button to log in.
            Button submit = new Button();
            submit.CommandName = "login";
            submit.Text = "LOGIN";

            container.Controls.Add(new LiteralControl("UserName:"));
            container.Controls.Add(username);
            container.Controls.Add(new LiteralControl("<br>Password:"));
            container.Controls.Add(password);
            container.Controls.Add(new LiteralControl("<br>"));
            container.Controls.Add(remember);
            container.Controls.Add(new LiteralControl("<br>Domain:"));
            container.Controls.Add(domain);
            container.Controls.Add(new LiteralControl("<br>"));
            container.Controls.Add(failure);
            container.Controls.Add(new LiteralControl("<br>"));
            container.Controls.Add(submit);
        }
    }    
}
// </snippet1>