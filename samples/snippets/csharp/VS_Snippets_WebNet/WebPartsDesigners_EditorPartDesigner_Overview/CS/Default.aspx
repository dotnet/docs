<!-- <snippet2> -->
<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="ccl" Namespace="Samples.AspNet.CS.Controls" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EditorPartDesigner Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager><br />
        <asp:EditorZone ID="EditorZone1" runat="server" Enabled="true" >
            <ZoneTemplate>
                <ccl:SecretEditorPart ID="SEPart1" runat="server" />
            </ZoneTemplate>
        </asp:EditorZone>
        <asp:WebPartZone ID="WebPartZone1" runat="server">
            <ZoneTemplate>
                <asp:Button ID="Button1" runat="server" Height="24px" Text="Button" />
            </ZoneTemplate>
        </asp:WebPartZone><br />
    </div>
    </form>
</body>
</html>
<!-- </snippet2> -->

