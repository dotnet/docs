

<!--
System.Web.HttpException.HttpException(Int32,String,Exception)
-->

<!--<Snippet1>-->

<%@ Import Namespace="System.Drawing" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>Example for HttpException</title>
<script language="C#" runat="server">
         void CheckNumber()
         {
            try
            {
               // Check whether the value is an integer.
               String convertInt = textbox1.Text;
               Convert.ToInt32(convertInt);
            }
            catch(Exception ex)
            {
               // Throw an HttpException object that contains the HTTP error code,
               // message, and inner exception.
               throw new HttpException(500, "The entered value is not an integer.", ex);
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
               label1.ForeColor = Color.Red;
               label1.Text = "An HttpException was raised!: " + exp.Message;
               Exception myInnerException = exp.InnerException;
               
               // Display the inner exception.
               label2.Text = "The InnerException is : " + myInnerException.GetType();
                
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
         <form id="WebForm9" method="post" runat="server">
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
         </form>
      </center>
   </body>
</html>
<!--</Snippet1>-->