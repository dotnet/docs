<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--
   System.Web.HttpException.HttpException()
-->
<!--<Snippet1>-->

<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>
            Example for HttpException
         </title>
<script language="C#" runat="server">
         void CheckNumber()
         {
            try
            {
               // Check whether the value is an integer.
               String convertInt = textbox1.Text;
               Convert.ToInt32(convertInt);
            }
            catch(Exception e)
            {
               // Throw a 'HttpException' object.
               throw new HttpException();
            }
         }
      
         void Button_Click(Object sender, EventArgs e)
         {
            try
            {
               CheckNumber();
               label1.Text = "The integer value you entered is: "+textbox1.Text;
            }
            catch(HttpException exp)
            {
               label1.Text = "<font color='red'>An HttpException was raised!:"
                  + " The value entered in the textbox is not an integer.</font>";
            }
         }

         void page_load(object sender,EventArgs e)
         {
            label1.Text="";
         }
      </script>
   </head>
   
   <body>
      <center>
         <h3>
            Example for HttpException
         </h3>
      </center>
      
      <form id="WebForm9" method="post" runat="server">
         <center>
         <br />
         <b>Enter a value in the text box.</b>
         <br />
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