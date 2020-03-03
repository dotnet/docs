<!--
   System.Web.HttpException.HttpException()
-->
<!--<Snippet1>-->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>Example for HttpException</title>
<script language="VB" runat="server">
         Sub CheckNumber()
            Try
               ' Check whether the value is an integer.
               Dim convertInt As [String] = textbox1.Text
               Convert.ToInt32(convertInt)
            Catch e As Exception
               ' Throw the 'HttpException' object.
               Throw New HttpException()
            End Try
         End Sub 'CheckNumber
 
         Sub Button_Click(sender As [Object], e As EventArgs)
            Try
               CheckNumber()
               label1.Text = "The integer value you entered is: " + textbox1.Text
            Catch exp As HttpException
               label1.Text = "<font color='red'>An HttpException was raised!:" _
                  & " The value entered in the textbox is not an integer</font>"
            End Try
         End Sub 'Button_Click
       
         Sub Page_Load(sender As [Object], e As EventArgs)
            label1.Text=""
         End Sub
      </script>
   </head>

   <body>
      <center>
         <h3>Example for HttpException</h3>
      </center>
      <form id="WebForm9" method="post" runat="server">
         <center>
            <b>Enter a value in the text box.</b>
            <asp:TextBox Runat="server" ID="textbox1"></asp:TextBox>
            <br />
            <asp:Button Text="Click Here" OnClick="Button_Click" Runat="server"></asp:Button>
            <br />
            <b><asp:Label Runat="server" ID="label1"></asp:Label></b>
         </center>
      </form>
   </body>
</html>
<!--</Snippet1>-->