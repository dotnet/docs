<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AdCreatedEventArgs AlternateText Example</title>
<script runat="server">
   
       void AdCreated_Event(Object sender, AdCreatedEventArgs e) 
       {

          e.AlternateText = "New Alternate Text Value";   
       
       }      

   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">
 
      <h3>AdCreatedEventArgs AlternateText Example</h3>
 
      <asp:AdRotator id="AdRotator1" runat="server"
           AdvertisementFile = "Ads.xml"
           Target="_newwwindow"
           OnAdCreated="AdCreated_Event"/>
 
   </form>
 
</body>
</html>
<!--</Snippet1>-->
