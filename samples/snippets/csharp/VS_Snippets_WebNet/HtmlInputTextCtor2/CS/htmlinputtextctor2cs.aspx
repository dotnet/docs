<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Page_Load(Object sender, EventArgs e)
      {

         // Create an HtmlInputText control.
         HtmlInputText text = new HtmlInputText("password");
         text.MaxLength = 20;
         text.Size = 22;
 
         // Add the control to the Controls collection of the 
         // PlaceHolder control.
         Place.Controls.Clear();
         Place.Controls.Add(text);
         
      }

      void Button_Click(Object sender, EventArgs e)
      {

         // Insert secure authentication here.
         // Make sure to use SSL to secure the connection.

      }
  
   </script>
  
<head runat="server">
    <title> HtmlInputText Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlInputText Constructor Example </h3> 
  
      Enter your password: <br />
      <asp:PlaceHolder id="Place" runat="server"/>

      <br /><br />
 
      <input type="submit"
             value="Submit"
             onserverclick="Button_Click" 
             runat="server"/> 
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
