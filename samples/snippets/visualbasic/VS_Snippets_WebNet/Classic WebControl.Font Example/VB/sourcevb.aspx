<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Label1.Text = "The current font is: " & Label1.Font.ToString()
    End Sub

    Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Label1.Font.Underline = Not Label1.Font.Underline
        If Label1.Font.Name = "Verdana" Then
            Label1.Font.Name = "Times"
        Else
            Label1.Font.Name = "Verdana"
        End If
            
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Enabled Property Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>FontUnit Property of a Web Control</h3>
        <asp:Label id="Label1" runat="server"
            Font-Names="Verdana" Font-Size="10pt"
            Text="This is a Label control." />  
 
            <p>
            <asp:Button id="Button1" runat="server"
                Text="Click to display font info"
                OnClick="Button1_Click" Width="300px" />
            </p>
 
            <p>
            <asp:Button id="Button2" runat="server"
                Text="Click to change font and underlining"
                OnClick="Button2_Click" Width="300px" />
            </p>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
