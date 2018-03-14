<!-- <Snippet2> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal Sender As Object, ByVal E As EventArgs)
        If DropDownList1.SelectedValue = "1" Then
            UpdatePanel1.Update()
        Else : If DropDownList1.SelectedValue = "2" Then
                UpdatePanel2.Update()
                DropDownList1.SelectedIndex = 0
            End If
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UpdatePanelUpdateMode Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1"
                               runat="server" />
            <asp:Panel ID="Panel1" runat="server" GroupingText="Panel 1">
                <asp:UpdatePanel ID="UpdatePanel1" 
                    UpdateMode="Conditional" 
                    runat="server">
                    <ContentTemplate>
                        <p>
                            UpdatePanel.Update() method is called if this panel is selected
                            to be updated from DropDownList control. Last updated:
                            <%= DateTime.Now.ToString()%>
                        </p>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" GroupingText="Panel 2">
                <asp:UpdatePanel ID="UpdatePanel2" 
                    UpdateMode="Conditional"
                    runat="server">
                    <ContentTemplate>
                        <p>
                            UpdatePanel.Update() method is called if this panel is selected
                            to be updated from DropDownList control. Last updated:
                            <%= DateTime.Now.ToString() %>
                            <br />
                            <br />
                            <asp:DropDownList ID="DropDownList1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                runat="server">
                                <asp:ListItem Text="Select a panel to update..." Value="0" Selected="True" />
                                <asp:ListItem Text="Refresh Panel 1 and 2" Value="1" />
                                <asp:ListItem Text="Refresh Panel just 2" Value="2" />
                            </asp:DropDownList>
                        </p>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
