<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="ConnectionSampleCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <!-- Reference the WebPartManager control. -->
      <asp:WebPartManager ID="WebPartManager1" runat="server"  
          CloseProviderWarning="You are closing a provider control." />
    <div>
      <uc1:DisplayModeMenuCS ID="displaymode1" runat="server" />
      <!-- Reference consumer and provider controls in a zone. -->
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <aspSample:ZipCodeWebPart ID="zip1" 
            runat="server" 
            Title="Zip Code Control"/>
          <aspSample:WeatherWebPart ID="weather1" 
            runat="server" 
            Title="Weather Control" />
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <!-- Add a ConnectionsZone so users can connect controls. -->
      <asp:ConnectionsZone ID="ConnectionsZone1" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->