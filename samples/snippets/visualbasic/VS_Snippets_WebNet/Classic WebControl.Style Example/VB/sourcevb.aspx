<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    Sub Button1_Click(sender As Object, e As EventArgs)
        If Label1.Style("visibility") = "hidden" Then
            Label1.Style("visibility") = "show"
        Else
            Label1.Style("visibility") = "hidden"
        End If
    End Sub
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Style Property Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
        <h3>Style Property of a Web Control</h3>
 
        <asp:Label id="Label1" Text="This is a label control." 
            BorderStyle="Solid" runat="server"/>

        <p>
            <asp:Button id="Button1" Text="Click to hide or unhide the label"
                OnClick="Button1_Click" runat="server"/>
        </p>

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
