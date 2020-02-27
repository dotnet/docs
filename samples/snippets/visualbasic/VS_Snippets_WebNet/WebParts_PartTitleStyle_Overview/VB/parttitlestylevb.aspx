<!-- <snippet1> -->
<%@ page Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      title="Zone 1">
        <parttitlestyle 
          font-bold="true" 
          BorderWidth="2" 
          ForeColor="#3300cc" />
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <zonetemplate>
          <asp:calendar 
            ID="cal1" 
            Runat="server" 
            Title="My Calendar" />
          <asp:Label id="label1" runat="server" 
            Title="A WebPart Label">
            The label control acts as a WebPart.
          </asp:Label>
          </zonetemplate>
    </asp:webpartzone>
  </form>
</body>
</html>
<!-- </snippet1> -->