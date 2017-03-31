<%@ Register TagPrefix="SimpleControlSamples"  Namespace="SimpleControlSample" Assembly="ControlClass_Samples" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
// System.Web.UI.Control.Init
// System.Web.UI.Control.ID
/* The following C# code example demonstrates the event 'Init' of class
   'Control Class'.The program explains the init event handler.*/
   
// <Snippet2>
// <Snippet3>
void Page_Init(object sender,EventArgs e)
{
   // Add a event Handler for 'Init'.
   myControl.Init += new System.EventHandler(Control_Init);
}

void Control_Init(object sender,EventArgs e)
{ 
  Response.Write("The ID of the object initially : " + myControl.ID);      
  // Change the ID property.
   myControl.ID="TestControl";
   Response.Write("<br />The changed ID : " + myControl.ID);
}
// </Snippet3>
// </Snippet2>
 
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
</head>
   <body>
      <form id="form1" method="POST" runat="server">
         <SimpleControlSamples:Simple id="myControl" OnInit="Control_Init" runat="server" />
         <asp:Button ID="submit" Text="Submit" Runat="server" />
      </form>
   </body>
</html>
