<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Page_Load(Object sender, EventArgs e)
      {
         // Create a new HtmlInputHidden control.
         HtmlInputHidden hidden = new HtmlInputHidden();
         hidden.ID = "HiddenValue";
         hidden.Value = "Hidden Text";

         // Add the control to the Controls collection of the
         // PlaceHolder control.
         Place.Controls.Add(hidden);

         // Display the value of the HtmlInputHidden control.
         Message.InnerHtml = 
            "This page contains an HtmlInputHidden control that contains " +
            "the value \"" + 
            ((HtmlInputHidden)Place.FindControl("HiddenValue")).Value + "\"";
        
      }
  
   </script>
  
<head runat="server">
    <title> HtmlInputHidden Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlInputHidden Constructor Example </h3> 
  
      <asp:PlaceHolder id="Place" runat="server"/>
   
      <h5>
         <span id="Message"  
               runat="server">

         </span>
      </h5>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
