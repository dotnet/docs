<%-- <Snippet10> --%>
<%@ Page Language="VB" MasterPageFile="MasterPage.master" Title="UpdatePanel in Master Pages" %>
<%-- <Snippet11> --%>
<%@ MasterType VirtualPath="MasterPage.master" %>
<%-- </Snippet11> --%>

<script runat="server">
    ' <Snippet12>
    Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)
        Dim newDateTime As DateTime
        newDateTime = DateTime.Today.Add(New TimeSpan(Master.Offset, 0, 0, 0))
        Calendar1.SelectedDate = newDateTime
    End Sub
    ' </Snippet12>
    ' <Snippet13>
    Protected Sub Calendar1_SelectionChanged(ByVal Sender As Object, ByVal E As EventArgs)
        Dim selectedDate As DateTime
        selectedDate = Calendar1.SelectedDate
        Master.Offset = _
           Calendar1.SelectedDate.Subtract(DateTime.Today).Days

    End Sub
    ' </Snippet13>
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Content Page<br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <fieldset>
        <legend>UpdatePanel</legend>
           <asp:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar> 
        </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%-- </Snippet10> --%>
