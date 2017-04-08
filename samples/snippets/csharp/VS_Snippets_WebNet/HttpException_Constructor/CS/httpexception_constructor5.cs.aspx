<!-- 
   System.Web.HttpException.HttpException(int,String,int)
-->

<!-- <Snippet1> -->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>HttpException Example</title>
<script language="C#" runat="server">
         void SubmitButton_Click(Object sender, EventArgs e)
         {
            try
            {
               if(Textbox1.Text.Length==0 || Textbox2.Text.Length==0)
               {
                  // Raise an Exception if the username or the emailfield field is empty.
                  throw new HttpException(901,"User name or e-mail ID not provided.",333);
               }
               else
               {
                  MyLabel.Text="Hello "+Textbox1.Text+"<br />";
                  MyLabel.Text+="The Weekly newsletter is mailed to :"+
                           Textbox2.Text+"<br />";
               }
            }
            catch(HttpException ex)
            { 
               // Display the error code returned by the GetHttpCode method.
               MyLabel.Text="<h4><font color=\"red\">The exception is "+
                  ex.GetHttpCode() +" - "+ ex.Message + "</font></h4>";
            }
         }

         void Page_Load(object sender,EventArgs e)
         {
            MyLabel.Text="";
         }
      </script>
   </head>

   <body>
      <form runat="server" id="Form1">
         <h3>HttpException Example</h3>
         Enter UserName and Email
         <br /><br />
         UserName :
         <asp:TextBox ID="Textbox1" Runat="server"></asp:TextBox>
         <br />
         E-mail ID :
         <asp:TextBox ID="Textbox2" Runat="server"></asp:TextBox>
         <asp:Button ID="Button1" Text="Submit" OnClick="SubmitButton_Click" runat="server" />
         <br />
         <asp:label id="MyLabel" runat="server" />
      </form>
   </body>
</html>
<!-- </Snippet1> -->