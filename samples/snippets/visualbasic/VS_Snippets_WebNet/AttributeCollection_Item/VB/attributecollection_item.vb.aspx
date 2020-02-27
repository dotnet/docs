<%@ Page language="VB"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="vb" runat="server">

' System.Web.UI.AttributeCollection.Item;
' System.Web.UI.AttributeCollection.AddAttributes

'   The following example demonstrates the 'Item' property and 'AddAttributes'
'   method of 'AttributeCollection' class. Two attributes are added to the  
'   AttributeCollection of 'Button'. When the page loads the Html writer renders
'   the attributes that are added.

Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
' <Snippet2>
   myButton.Attributes.Clear()
   myTextBox.Attributes.Clear()
   myButton.Attributes("onClick") = "javascript:alert('Visiting msn.com');"
   
   myTextBox.Attributes("name") = "MyTextBox"
   
   myTextBox.Attributes("onBlur") = "javascript:alert('Leaving MyTextBox...');"
   
   Dim myHttpResponse As HttpResponse = Response
   Dim myHtmlTextWriter As New HtmlTextWriter(myHttpResponse.Output)
   
   myButton.Attributes.AddAttributes(myHtmlTextWriter)
   myTextBox.Attributes.AddAttributes(myHtmlTextWriter)
' </Snippet2>
' </Snippet1>
End Sub  

   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>
         Attributes Property of a Web Control
      </title>
</head>
   <body>
      <h3>
         Attributes Property of a Web Control
      </h3>
      <form runat="server" id="form1">
         <asp:Button ID="myButton" Runat="server" Text="Button"></asp:Button>
         <asp:TextBox ID="myTextBox" Runat="server" Text="TextBox. Try leavingthis!"></asp:TextBox>
      </form>
   </body>
</html>
