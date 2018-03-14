<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create an HtmlInputText control.
         Dim text As HtmlInputText = New HtmlInputText("password")
         text.MaxLength = 20
         text.Size = 22
 
         ' Add the control to the Controls collection of the 
         ' PlaceHolder control.
         Place.Controls.Clear()
         Place.Controls.Add(text)
         
      End Sub

      Sub Button_Click(sender As Object, e As EventArgs)

         ' Insert secure authentication here.
         ' Make sure to use SSL to secure the connection.

      End Sub
  
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
