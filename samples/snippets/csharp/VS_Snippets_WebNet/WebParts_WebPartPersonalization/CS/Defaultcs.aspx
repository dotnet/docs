<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="control"  TagName="colorcontrol" Src="~/color.ascx"%>
<%@Register TagPrefix="pmode" TagName="persmode" Src="~/persMode.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Create Web Part manager and zone for the color user control. -->
        <asp:WebPartManager ID="WebPartManager1" runat="server"></asp:WebPartManager>
            <asp:WebPartZone ID="WebPartZone1" runat="server" HeaderText="Color Change Zone">
                <ZoneTemplate>
                <!-- Note that the control is Shared since it is declared on the page. -->
                    <control:colorcontrol id="color1" title="Color Control" runat="server" />
                </ZoneTemplate>
            </asp:WebPartZone>
        
        <br />
            <!-- Create Web Part zone for the personalization mode user control. -->
            <asp:WebPartZone ID="WebPartZone2" runat="server" HeaderText="Scope Change Zone" Height="109px">
                <ZoneTemplate>
                    <pmode:persmode  ID="Persmode1" runat="server" title="Scope Tool"/>
                </ZoneTemplate>
            </asp:WebPartZone>
   
    </form>
</body>
</html>
<!-- </snippet1> -->