<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    Sub SubmitBtn1_Click(sender As Object, e As EventArgs)
        SubmitBtn1.TabIndex = 0
        If TextBox1.Text = "" Then
            TextBox1.TabIndex = 0
        Else
            TextBox1.TabIndex = System.Int16.Parse(TextBox1.Text)
        End If
        If TextBox2.Text = "" Then
            TextBox2.TabIndex = 0
        Else
            TextBox2.TabIndex = System.Int16.Parse(TextBox2.Text)
        End If
        If TextBox3.Text = "" Then
            TextBox3.TabIndex = 0
        Else
            TextBox3.TabIndex = System.Int16.Parse(TextBox3.Text)
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

    <h3>TabIndex Property of a Web Control<br /></h3>

    <p>
        Enter a number (1, 2, or 3) in each text box, <br /> 
        click the Submit button to set the TabIndexes, then <br /> 
        click on the page and tab through the page to verify.
    </p>
 
    <asp:Button id="SubmitBtn1" OnClick="SubmitBtn1_Click" 
        Text="Submit" runat="server"/>
    <p>
        <asp:TextBox id="TextBox1" BackColor="Pink" 
            runat="server"/>
    </p>
    <p>
        <asp:TextBox id="TextBox2" BackColor="LightBlue" 
            runat="server"/>
    </p>
    <p>
        <asp:TextBox id="TextBox3" BackColor="LightGreen" 
            runat="server"/>
    </p>  

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
