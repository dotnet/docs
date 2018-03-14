<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  protected void SubmitBtn_Click(object sender, ImageClickEventArgs e)
  {

    // Set the inner HTML of the Message span element.
    Message.InnerHtml = "The Submit button was clicked.";

  }

  protected void ClearBtn_Click(object sender, ImageClickEventArgs e)
  {
    
    // Set the inner HTML of the Message span element.
    Message.InnerHtml = "The Clear button was clicked.";
    
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" > 
   <head runat="server">
    <title> 
         
         </title>
</head>
<body>

      <form id="form1" runat="server">

         <input type="image"
                runat="server"
                id="Image1"
                onserverclick="SubmitBtn_Click" 
                alt="Submit button"
                src="Submit.jpg" 
                style="text-align:left; border:2" />

         <input type="image" 
                alt="Clear button"
                style="text-align:right"
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
