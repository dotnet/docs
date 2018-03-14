<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="server">
    <title>AdRotator Example</title>
</head>
 
    <script language="vb" runat="server">
       Sub AdCreated_Event(sender As Object, e As AdCreatedEventArgs) 
          Message.Text = e.AdProperties("Caption")
       End Sub     
    </script>
 
 <body>
 
    <form id="form1" runat="server">
 
       <h3>AdRotator Example</h3>
 
       <asp:AdRotator id="test1" runat="server"
            AdvertisementFile = "Ads.xml"
        Borderwidth="1"
            Target="_newwwindow"
            OnAdCreated="AdCreated_Event"/><br /><br />
 
       <asp:label id="Message" runat="server"/>
 
    </form>
 
 </body>
 </html>

<!--</Snippet1>-->
