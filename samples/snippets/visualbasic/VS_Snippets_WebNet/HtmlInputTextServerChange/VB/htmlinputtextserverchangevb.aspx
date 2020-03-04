<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputText ServerChange Example</title>
<script runat="server">

     Sub Server_Change(ByVal sender As Object, ByVal e As EventArgs)

       Span1.InnerHtml = String.Format("You typed: {0}", Text1.Value)

     End Sub

     Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

       ' Create an EventHandler delegate for the method you want to
       ' handle the event, and then add it to the list of methods
       ' called when the event is raised.
       AddHandler Text1.ServerChange, AddressOf Server_Change
      
     End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>HtmlInputText ServerChange Example</h3>

      Enter a value in the input field below and 
      click the Submit button.

      <br />

      <input type="text" 
             id="Text1" 
             runat="server"/>
      <br />

      <input type="submit" 
             id="Button1" 
             value="Submit" 
             runat="server"/>

      <br />

      <span id="Span1" 
            runat="server" />

   </form>

</body>
</html>

<!-- </Snippet1> -->   