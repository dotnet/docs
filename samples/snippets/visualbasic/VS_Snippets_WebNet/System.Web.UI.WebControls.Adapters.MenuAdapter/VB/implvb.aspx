<!--<Snippet11>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Menu Adapter</title>
</head>
<body>
<form id="Form1" runat="server">
    <asp:Menu ID="Menu1" 
        Orientation="Vertical" 
        Target="_top" 
        StaticDisplayLevels="2" 
        StaticSubMenuIndent="10"
        Font-Names="Arial" 
        Runat="server">
        <Items>
            <asp:MenuItem Text="Home" ToolTip="Home">
                <asp:MenuItem Text="Music" ToolTip="Music">
                    <asp:MenuItem Text="Classical" ToolTip="Classical">
                        <asp:MenuItem Text="Classical1" />
                        <asp:MenuItem Text="Classical2" />
                        <asp:MenuItem Text="Classical3" />
                    </asp:MenuItem>
                    <asp:MenuItem Text="Rock" ToolTip="Rock" />
                    <asp:MenuItem Text="Jazz" ToolTip="Jazz" />
                </asp:MenuItem>
                <asp:MenuItem Text="Movies" ToolTip="Movies">
                    <asp:MenuItem Text="Action" ToolTip="Action" />
                    <asp:MenuItem Text="Drama" ToolTip="Drama" />
                    <asp:MenuItem Text="Musical" ToolTip="Musical" />
                </asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
</form>
</body>
</html>
<!--</Snippet11>-->
