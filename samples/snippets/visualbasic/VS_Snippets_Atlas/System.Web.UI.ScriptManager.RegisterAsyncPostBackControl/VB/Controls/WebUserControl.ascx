<!-- <Snippet3> -->
<%@ Control Language="VB" ClassName="WebUserControl" %>

<script runat="server">
    Public Custom Event InnerClick As EventHandler
        AddHandler(ByVal value As EventHandler)
            AddHandler UCButton1.Click, value
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            RemoveHandler UCButton1.Click, value
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Public ReadOnly Property Name() As String
        Get
            Return UCTextBox1.Text
        End Get
    End Property
</script>

<asp:Panel ID="UCPanel1" runat="server" GroupingText="User Control">
    Enter your name:
    <asp:TextBox ID="UCTextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="UCButton1" runat="server" Text="Submit" />
</asp:Panel>
<!-- </Snippet3> -->
