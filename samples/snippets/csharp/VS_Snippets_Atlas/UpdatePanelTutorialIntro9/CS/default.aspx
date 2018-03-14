<%-- <Snippet10> --%>
<%@ Page Language="C#" MasterPageFile="MasterPage.master" Title="UpdatePanel in Master Pages" %>
<%-- <Snippet11> --%>
<%@ MasterType VirtualPath="MasterPage.master" %>
<%-- </Snippet11> --%>

<script runat="server">
    // <Snippet12>
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime newDateTime = 
            DateTime.Today.Add(new 
            TimeSpan(Master.Offset, 0, 0, 0));
        Calendar1.SelectedDate = newDateTime;
    }
    // </Snippet12>
    // <Snippet13>
    protected void Calendar1_SelectionChanged(object sender, 
        EventArgs e)
    {
        DateTime selectedDate = Calendar1.SelectedDate;
        Master.Offset =
           ((TimeSpan)Calendar1.SelectedDate.Subtract(
           DateTime.Today)).Days;
    }
    // </Snippet13>
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
