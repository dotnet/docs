<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    '<snippet1>
    '<snippet2>
    Dim myParserError As New ParserError()
    '</snippet2>
    '<snippet3>
    myParserError.ErrorText = "My Error Text"
    '</snippet3>
    '<snippet4>
    myParserError.Line = 5
    '</snippet4>
    '<snippet5>
    myParserError.VirtualPath = "MyPath"
    '</snippet5>
    '</snippet1>
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ParserError Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
