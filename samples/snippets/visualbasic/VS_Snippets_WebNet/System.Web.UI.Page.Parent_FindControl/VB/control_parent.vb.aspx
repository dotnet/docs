<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">

' System.Web.UI.Control.Parent

'   The following example demonstrates the property 'Parent' of class 
'   'Control'. This program invokes FindControl to find a control on the page,
'   it then gets its parent and displays it on the page.

' <Snippet1>

   Private Sub Button1_Click(sender As Object, MyEventArgs As EventArgs)
   ' Find control on page.
   Dim myControl1 As Control = FindControl("TextBox2")
   If (Not myControl1 Is Nothing)
      ' Get control's parent.
      Dim myControl2 As Control = myControl1.Parent
      Response.Write("Parent of the text box is : " & myControl2.ID)
   Else
      Response.Write("Control not found.....")
   End If
   End Sub

' </Snippet1>

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
