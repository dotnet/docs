<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    void SubmitBtn1_Click(Object sender, EventArgs e)
    {
        SubmitBtn1.TabIndex = 0;
        TextBox1.TabIndex = (short)((TextBox1.Text=="") ? 0 : 
            System.Int32.Parse(TextBox1.Text));
        TextBox2.TabIndex = (short)((TextBox2.Text=="") ? 0 : 
            System.Int32.Parse(TextBox2.Text));
        TextBox3.TabIndex = (short)((TextBox3.Text=="") ? 0 : 
            System.Int32.Parse(TextBox3.Text));
    }

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
 
    <p><asp:Button id="SubmitBtn1" OnClick="SubmitBtn1_Click" 
            Text="Submit" runat="server"/>
    </p>

    <p><asp:TextBox id="TextBox1" BackColor="Pink" 
            runat="server"/>
    </p>
    <p><asp:TextBox id="TextBox2" BackColor="LightBlue" 
            runat="server"/>
    </p>
    <p><asp:TextBox id="TextBox3" BackColor="LightGreen" 
            runat="server"/>
    </p>  
     
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
