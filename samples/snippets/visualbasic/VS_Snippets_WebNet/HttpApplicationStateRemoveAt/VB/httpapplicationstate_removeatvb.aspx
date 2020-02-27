<!-- <Snippet1> -->
<%@ Page language="VB" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpApplicationState - RemoveAt - VB.NET Example</title>
    <script runat="server">
      Sub Page_Load(sender As Object, e As EventArgs)

          ' Add two new application state variables.
          Application.Add("City", "Redmond")
          Application.Add("State", "WA")
        
          ' Show the contents of both application state variables.
          Label1.Text = "Application.Keys(0) contains: " & Application.Keys(0).ToString()
          Label1.Text += "<br />Application.Keys(1) contains: " & Application.Keys(1).ToString()
              
          ' Remove the City application state variable, which is at
          ' the first index location.
          Application.RemoveAt(0)
          Label2.Text = "<br />Call:&nbsp; Application.RemoveAt(0)"
              
          ' Show the contents of the application state variable,
          ' in the first index location, which is now the State variable.
          Label3.Text = "<br />Application.Keys(0) contains: " & Application.Keys(0).ToString()
      End Sub
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
            <h3>HttpApplicationState - RemoveAt - VB.NET Example</h3>
      <asp:Label id="Label1" runat="server" /><br />
      <asp:Label id="Label2" runat="server" /><br />
      <asp:Label id="Label3" runat="server" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
