<%-- <Snippet27> --%>
<%@ Page Language="VB" MasterPageFile="~/Site.master" 
    Title="Configuration System Browser - Home Page" 
    AutoEventWireup="true" 
    CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%-- </Snippet27> --%>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <Snippet20> --%>
    <h2>
        <asp:Label ID="HeadingLabel" runat="server" 
            Text="Section Groups in Machine.config">
        </asp:Label>
    </h2> 
    <%-- </Snippet20> --%>
    <%-- <Snippet21> --%>
    <div class="listColumn">
        <asp:Literal ID="SectionGroupsLiteral" runat="server" />
    </div>
    <div class="checkboxColumn">
        <p>
            Click the checkboxes to refresh the screen with the selected 
            options.
        </p>
        <asp:Image ID="Image1" 
            runat="server"
            ImageUrl="~/Images/headerGRADIENT_Tall.gif"
            GenerateEmptyAlternateText="false" Width="100%" Height="4px">
        </asp:Image>
        <asp:CheckBoxList runat="server" AutoPostBack="True" 
            RepeatLayout="UnorderedList" ID="OptionsCheckBoxList">
            <asp:ListItem>Show Sections</asp:ListItem>
            <asp:ListItem>Show Contained Section Groups</asp:ListItem>
        </asp:CheckBoxList>
    </div>
    <%-- </Snippet21> --%>
</asp:Content>
