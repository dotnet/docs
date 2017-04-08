<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AdRotator AdCreated Example</title>
</head>
 
   <script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {

         // Create an EventHandler delegate for the method you want to handle the event
         // and then add it to the list of methods called when the event is raised.
         Ad.AdCreated += new System.Web.UI.WebControls.AdCreatedEventHandler(this.AdCreated_Event);

      }

      void AdCreated_Event(Object sender, AdCreatedEventArgs e) 
      {

         // Override the AlternateText value from the ads.xml file.
         e.AlternateText = "Visit this site!";   

      }      

   </script>
 
<body>
 
   <form id="form1" runat="server">
 
      <h3>AdRotator AdCreated Example</h3>

      Notice that the AlternateText property of the advertisement <br />
      has been programmatically modified from the value in the XML <br />
      file. 

      <br /><br />
 
      <asp:AdRotator id="Ad" runat="server"
           AdvertisementFile = "~/App_Data/Ads.xml"
           Borderwidth="1"
           Target="_blank"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
