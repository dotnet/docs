<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Read HTML Attributes for Controls in Web Forms Pages (Visual Basic)</title>
</head>

<script runat="server">
    
    Public Sub Page_Load()
        
        '<Snippet6> 
        Response.Write(Button1.Attributes.Item("Style") & "<br />")
        Dim key As String
        For Each key In Button1.Attributes.Keys
            Response.Write(key & "=" & Button1.Attributes.Item(key) & "<br />")
        Next
        For Each key In Submit1.Attributes.Keys
            Response.Write(key & "=" & Submit1.Attributes.Item(key) & "<br />")
        Next
        '</Snippet6>
        
    End Sub
    
</script>

<body>
    <form id="form1" runat="server">
      <asp:Button id="Button1" runat="server" />
      <asp:Button id ="Submit1" runat="server" />
    </form>
</body>
</html>
