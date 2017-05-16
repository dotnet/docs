<%--<Snippet3>--%>
<%@ Page Language="VB" MasterPageFile="MasterVB.master"
    Title="ScriptManager in Content Page" %>

<%@ MasterType VirtualPath="MasterVB.master" %>

<script runat="server">

    Protected Sub Button3_Click(ByVal Sender As Object, ByVal E As EventArgs)
       Master.LastUpdate = DateTime.Now
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="Server">
    </asp:ScriptManagerProxy>
    <asp:Panel ID="Panel2"
               GroupingText="ContentPage"
               runat="server" >
        <asp:UpdatePanel ID="UpdatePanel1" 
                         UpdateMode="Conditional" 
                         runat="server">
            <ContentTemplate>
                <p>
                    Last updated: <strong>
                        <%= Master.LastUpdate.ToString() %>
                    </strong>
                </p>
                <asp:Button ID="Button3"
                            Text="Refresh Panel"
                            OnClick="Button3_Click"
                            runat="server"  />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
<%-- </Snippet3> --%>
