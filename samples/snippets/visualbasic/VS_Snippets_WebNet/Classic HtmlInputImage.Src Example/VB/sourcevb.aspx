<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub SubmitBtn_Click(ByVal Source As Object, ByVal E As ImageClickEventArgs)
    Message.InnerHtml = "The Submit button was clicked."
  End Sub
 
  Sub ClearBtn_Click(ByVal Source As Object, ByVal E As ImageClickEventArgs)
    Message.InnerHtml = "The Clear button was clicked."
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
 
   <head runat="server">
    <title>HtmlInputImage Example</title>
</head>
<body>
      <h3>HtmlInputImage Example</h3>

      <form id="form1" runat="server">

         <input type="image"
                alt="Submit button" 
                src="Submit.jpg" 
                onserverclick="SubmitBtn_Click" 
                runat="server"
                id="Image1" />

         <input type="image"
                alt="Clear button" 
                src="Clear.jpg" 
                onserverclick="ClearBtn_Click" 
                runat="server" 
                id="Image2" />
 
         <h1> 
         
         <span id="Message" 
               runat="server">
         </span>

         </h1>

      </form>

   </body>

</html>

<!--</Snippet1>-->
