<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--
   System.Web.HttpException.HttpException(Int32,String,Exception)
-->

<!--<Snippet1>-->

<%@ Import Namespace="System.Drawing" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>Example for HttpException</title>
<script language="VB" runat="server">
         Sub CheckNumber()
            Try
               'Check whether the value is integer.
               Dim convertInt As [String] = textbox1.Text
               Convert.ToInt32(convertInt)
            Catch ex As Exception
               ' Throw an HttpException object that contains the HTTP error code,
               ' message, and inner exception.
               Throw New HttpException(500, "The entered value is not an integer.", ex)
            End Try
         End Sub
 
         Sub Button_Click(sender As [Object], e As EventArgs)
            Try
               CheckNumber()
               label1.Text = "The integer Value you entered is: " & textbox1.Text

            Catch exp As HttpException
               ' Display the Exception thrown.
               label1.ForeColor = Color.Red
               label1.Text = "An HttpException was raised: " & exp.Message

               Dim myInnerException As Exception = exp.InnerException

               ' Display the inner exception.
               label2.Text = "InnerException is : " & myInnerException.GetType().ToString()
                
            End Try
         End Sub 

         Sub page_load(sender As [Object], e As EventArgs)
            label1.Text = ""
            label2.Text = ""
         End Sub 
      </script>
   </head>

   <body>
      <center>
         <h3>Example for HttpException</h3>
         <form id="WebForm9" method="post" runat="server">
            <b>Enter the value in the text box.</b>
            <asp:TextBox Runat="server" ID="textbox1"></asp:TextBox>
            <br />
            <asp:Button Text="Click Here" OnClick="Button_Click" Runat="server" ID="Button1"></asp:Button>
            <br />
            <b>
            <asp:Label Runat="server" ID="label1"></asp:Label>
            <br />
            <asp:Label Runat="server" ID="label2"></asp:Label>
            </b>
         </form>
      </center>
   </body>
</html>
<!--</Snippet1>-->

