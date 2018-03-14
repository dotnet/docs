<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="true" %>

<%@ Register TagPrefix="Samples" Namespace="SampleControl" Assembly="SampleControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ScriptReference</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" 
                                 EnablePartialRendering="True"
                                 runat="server">
             <Scripts>
                <asp:ScriptReference Assembly="SampleControl" Name="SampleControl.UpdatePanelAnimation.js" />
             </Scripts>
            </asp:ScriptManager>
            
                       
            <Samples:UpdatePanelAnimationWithClientResource 
                     ID="UpdatePanelAnimator1"
                     BorderColor="Green"
                     Animate="true"
                     UpdatePanelID="UpdatePanel1"
                     runat="server" >
            </Samples:UpdatePanelAnimationWithClientResource>
            <asp:UpdatePanel ID="UpdatePanel1" 
                               UpdateMode="Conditional"
                               runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="Calendar2" 
                                  runat="server">
                    </asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
