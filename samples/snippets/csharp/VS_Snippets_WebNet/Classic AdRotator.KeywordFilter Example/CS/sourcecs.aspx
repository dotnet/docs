<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 
 <head runat="server">
    <title>AdRotator Example</title>
</head>
 
 <body>
    <form id="form1" runat="server">
 
       <h3>AdRotator Example</h3>
 
       <asp:AdRotator id="AdRotator1" runat="server"
            Target="_self"
            KeywordFilter="Games"
            AdvertisementFile="~/App_Data/Ads.xml"/>
 
    </form>
 </body>
 
 </html>
<!-- </Snippet1> -->
