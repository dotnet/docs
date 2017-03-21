void DisplayUserName(Object sender, EventArgs ea) 
{
   Response.Write("Welcome to " + Server.HtmlEncode(userName.Text));
}
void RaiseEvent(Object sender, EventArgs ea)
{
   // Raise a post back event for a control.
   this.RaisePostBackEvent(userButton, "");
}
void Page_Load(Object sender, EventArgs ea)
{
   // Register a control as one that requires postback handling.
   this.RegisterRequiresRaiseEvent(userButton);
}