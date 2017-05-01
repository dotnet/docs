<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--
System.Web.HttpException.HttpException(String,Exception)
-->

<!-- <Snippet1> -->

<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>Example for HttpException</title>
<script language="C#" runat="server">    
         void CheckNumber()
         {
            try
            {
               // Check whether the value is an integer.
               String convertInt= textbox1.Text;
               Convert.ToInt32(convertInt);
            }
            catch(Exception e)
            {
               // Throw an HttpException object with a message.
               throw new HttpException("THe value entered in the text box is not a integer", e);
            }
         }
      
         void Button_Click(Object sender, EventArgs e)
         {
            try
            {
               CheckNumber();
               label1.Text = "The integer value you entered is: " + textbox1.Text;
            }
            catch(HttpException exp)
            {
               // Display the exception thrown.
               label1.Text = "<font color='red'>An HttpException was raised: " + exp.Message + "</font>";
               Exception myInnerException = exp.InnerException;
               label2.Text = "InnerException is : " + myInnerException.GetType();
            }
         }

         void page_load(Object sender,EventArgs e)
         {
            label1.Text="";
            label2.Text="";
         }
      </script>
   </head>

   <body>
      <center>
         <h3>Example for HttpException</h3>
      </center>
      <form id="Form1" method="post" runat="server">
         <center>
            <b>Enter the value in the text box </b>
            <br />
            <asp:TextBox Runat="server" ID="textbox1"></asp:TextBox>
            <br />
            <asp:Button Text="Click Here" OnClick="Button_Click" Runat="server" ID="Button1"></asp:Button>
            <br />
            <b>
               <asp:Label Runat="server" ID="label1"></asp:Label>
               <br />
               <asp:Label Runat="server" ID="label2"></asp:Label>
            </b>
         </center>
      </form>
   </body>
</html>

<!-- </Snippet1> -->