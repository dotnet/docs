<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <p>This example demonstrates using the AdRotator control.</p>
    <p>
      <asp:AdRotator ID="AdRotator1" Runat="server" 
        DataSourceID="Ads"
        Winwap:NavigateUrlField="WMLNavigateUrl"
        Winwap:ImageUrlField="WmlImageUrl"
        Winwap:AlternateTextField="WmlAlternateText"
      />
      <asp:XmlDataSource ID="Ads" 
        Runat="server" 
        DataFile="~/App_Data/AdvertisementList.xml">
      </asp:XmlDataSource>
    </p>
  </div>
  </form>
</body>
</html>
<!--</Snippet1>-->