<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void CheckNumber()
    {
        try
        {
            // Check whether the value is an integer.
            String convertInt = textbox1.Text;
            Convert.ToInt32(convertInt);
        }
        catch (Exception e)
        {
            // Throw an HttpException with customized message.
            throw new HttpException("not an integer");
        }
    }
    void CheckBoolean()
    {
        try
        {
            // Check whether the value is an boolean.
            String convertBool = textbox1.Text;
            Convert.ToBoolean(convertBool);
        }
        catch (Exception e)
        {
            // Throw an HttpException with customized message.
            throw new HttpException("not a boolean");
        }
    }

    void Button_Click(Object sender, EventArgs e)
    {
        try
        {
            // Check to see which button was clicked.
            Button b = (Button)sender;
            if (b.ID.StartsWith("button1"))
                CheckNumber();
            else if (b.ID.StartsWith("button2"))
                CheckBoolean();

            label1.Text = "You entered: " + textbox1.Text;
            label1.ForeColor = System.Drawing.Color.Black;
        }
        // Catch the HttpException.
        catch (HttpException exp)
        {
            label1.Text = "An HttpException was raised. "
               + "The value entered in the textbox is " + exp.Message.ToString();
            label1.ForeColor = System.Drawing.Color.Red;
        }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpException Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <b>Enter a value in the text box.</b>
        <br />
        <asp:TextBox ID="textbox1" 
                     Runat="server">
        </asp:TextBox>
        <br />
        <asp:Button ID="button1"
                    Text="Check for integer."  
                    OnClick="Button_Click" 
                    Runat="server">
        </asp:Button>
        <br />
        <asp:Button ID="button2"
                    Text="Check for boolean." 
                    OnClick="Button_Click" 
                    Runat="server">
        </asp:Button>
        <br />
        <asp:Label ID="label1" 
                   Runat="server">
        </asp:Label>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->