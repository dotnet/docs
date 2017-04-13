<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AdRotator Constructor Example</title>
<script runat="server">

      void Page_Load(Object sender, EventArgs e) 
      {
         // Create an AdRotator control.
         AdRotator rotator = new AdRotator();

         // Set the control's properties.
         rotator.AdvertisementFile = @"~\App_Data\Ads.xml";

         // Add the control to the Controls collection of a 
         // PlaceHolder control.  
         myPlaceHolder.Controls.Add(rotator);
      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>AdRotator Constructor Example</h3>

      <asp:Placeholder id="myPlaceHolder" 
           runat="server"/>

   </form>

</body>
</html>

<!-- </Snippet1> -->