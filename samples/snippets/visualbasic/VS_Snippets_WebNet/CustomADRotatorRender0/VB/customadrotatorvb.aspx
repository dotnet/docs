<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom AdRotator - Render - VB.NET Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom AdRotator - Render - VB.NET Example</h3>
      <aspSample:CustomADRotatorRender id="CustomAdRotator1" runat="server" Target="_blank" AdvertisementFile="~/App_Data/Ads.xml" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
