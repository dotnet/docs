<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Sub CheckNumber()
    
    Try

      ' Check whether the value is an integer.
      Dim convertInt As String = textbox1.Text
      Convert.ToInt32(convertInt)

    Catch e As Exception

      ' Throw an HttpException with customized message.
      Throw New HttpException("not an integer")

    End Try

  End Sub

  Sub CheckBoolean()
    
    Try

      ' Check whether the value is an boolean.
      Dim convertBool As String = textbox1.Text
      Convert.ToBoolean(convertBool)

    Catch e As Exception

      ' Throw an HttpException with customized message.
      Throw New HttpException("not a boolean")

    End Try

  End Sub

  Sub Button_Click(ByVal sender As [Object], ByVal e As EventArgs)
    
    Try

      ' Check to see which button was clicked.
      Dim b As Button = CType(sender, Button)
      If b.ID.StartsWith("button1") Then
        CheckNumber()
      ElseIf b.ID.StartsWith("button2") Then
        CheckBoolean()
      End If

      label1.Text = "You entered: " + textbox1.Text
      label1.ForeColor = System.Drawing.Color.Black

      ' Catch the HttpException.
    Catch exp As HttpException

      label1.Text = "An HttpException was raised. " + "The value entered in the textbox is " + exp.Message.ToString()
      label1.ForeColor = System.Drawing.Color.Red

    End Try

  End Sub
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