<!-- <snippet1> -->
<%@ Page language="vb" Debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ASP.NET Example</title>
<script runat="server">
    '  System.Web.UI.TemplateControl.ParseControl;
    '  The following example demonstrates the method 'ParseControl' of class TemplateControl.
      
    ' Since TemplateControl is abstract, this sample has been written using 'Page' class which derives from 
    ' 'TemplateControl' class.
    ' A button object is created by passing a string to contstruct a button using ASP syntax, to the 
    ' 'ParseControl' method. This button is added as one of the child controls of the page and displayed.

    Sub Page_Load(sender As Object, e As System.EventArgs)
       Dim c As Control 
       c = ParseControl("<asp:button text='Click here!' runat='server' />")
       myPlaceholder.Controls.Add(c)
    End Sub 'Page_Load
    </script>
  </head>

  <body>
    <form id="form1" runat="server">
      <asp:placeholder id ="myPlaceholder" runat="server" />
    </form>
  </body>
</html>
<!-- </snippet1> -->