<!-- <Snippet2> -->

<%@ Page Language="VB" %>

<%@ Register Src="Controls/WebUserControl.ascx" TagName="WebUserControl"
	TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-'W3C'DTD XHTML 1.0 Transitional'EN" 
  "http:'www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)
        ScriptManager1.RegisterAsyncPostBackControl(WebUserControl1)
    End Sub
    

    Protected Sub Button1_Click(ByVal Sender As Object, ByVal E As EventArgs)
        Label1.Text = "Panel refreshed at " + DateTime.Now.ToString()
    End Sub
    
    
    Protected Sub WebUserControl1_Click(ByVal Sender As Object, ByVal E As EventArgs)
        Label1.Text = "Panel refreshed at " + DateTime.Now.ToString() + _
            ".  Welcome " + WebUserControl1.Name + ". "
    End Sub
    

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ScriptManager RegisterAsyncPostBackControl Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <legend>Update Panel</legend>
                        <asp:Label ID="Label1" runat="server">Initial postback occurred.</asp:Label>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="Button1" runat="server" Text="Update Panel" OnClick="Button1_Click" />
            <uc1:webusercontrol id="WebUserControl1" runat="server" oninnerclick="WebUserControl1_Click" />
        </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
