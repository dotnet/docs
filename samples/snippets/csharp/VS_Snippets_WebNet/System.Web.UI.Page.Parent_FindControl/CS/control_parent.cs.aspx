<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
// System.Web.UI.Control.Parent
/* 
    The following example demonstrates the property 'Parent' of class 
   'Control'. This program invokes FindControl to find a control on the page, it then gets its
   parent and displays it on the page.
*/

// <Snippet1>
private void Button1_Click(object sender, EventArgs MyEventArgs)
{
      // Find control on page.
      Control myControl1 = FindControl("TextBox2");
      if(myControl1!=null)
      {
         // Get control's parent.
         Control myControl2 = myControl1.Parent;
         Response.Write("Parent of the text box is : " + myControl2.ID);
      }
      else
      {
         Response.Write("Control not found");
      }
}
// </Snippet1>
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
</head>
   <body>
      <form id="form1" method="post" runat="server">
         <asp:button id="Button1" runat="server" OnClick="Button1_Click" Text="Button"></asp:button>
         <asp:Panel Runat="server" id="Panel1">
            <asp:textbox id="Textbox2" runat="server" Text="SomeText"></asp:textbox>
         </asp:Panel>
      </form>
   </body>
</html>
