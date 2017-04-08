<%@ Register TagPrefix="customControl" NameSpace="CustomControlNameSpace" Assembly="Control_OnUnload"%>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">

// System.Web.UI.Control.OnUnload()
// Grouping Clause . Snippet 1 and 2 go together.

/* The following example demonstrates the "OnUnload" event handler 
 of class Control. Resource clean up is done by the OnUnload handler.
*/

// <Snippet1>
// Create a StreamWriter to write data to a text file.
TextWriter myFile = File.CreateText("c:\\NewTextFile.txt");

void Page_Load(object sender,EventArgs e)
{
   // Write status to file.
   myFile.WriteLine("Page has loaded.");
}
void CustomControl_OnLoad(object sender,EventArgs e)
{
   myFile.WriteLine("Custom control has loaded.");
}

void CustomControl_OnUnload(object sender,EventArgs e)
{
   // Server controls final cleanup such as; 
   // closing files goes here         
   myFile.WriteLine("Custom control was unloaded.");
  // Close the stream object.
   myFile.Close();
}
// </Snippet1>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<% @ Import Namespace = "System.IO"  %>
   </head>
   <body>
      <form id="Form1" method="post" runat="server">
         <customcontrol:MyCustomControl Text="Test" OnUnload="CustomControl_OnUnload" OnLoad="CustomControl_OnLoad" runat="server" id="myCustomControl">
         </customcontrol:MyCustomControl>
      </form>
   </body>
</html>
