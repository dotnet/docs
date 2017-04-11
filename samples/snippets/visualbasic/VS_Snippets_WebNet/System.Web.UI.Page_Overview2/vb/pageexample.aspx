<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim sb As New StringBuilder()
    
    If (Page.IsPostBack) Then
      
      sb.Append("You posted back to the page.<br />")
    
    End If
    
    sb.Append("The host address is " + Page.Request.UserHostAddress + ".<br />")
    sb.Append("The page title is """ + Page.Header.Title + """.")
    
    PageMessage.Text = sb.ToString()
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page Class Example</title>
</head>
<body>
    <form id="form1" 
          runat="server">
    <div>
    <asp:Label id="PageMessage" 
               runat="server"/>
    <br /> <br />
    <asp:Button id="PageButton"
                Text="PostBack"
                runat="server" />    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
