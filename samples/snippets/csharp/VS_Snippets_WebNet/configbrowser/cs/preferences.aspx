<%-- <Snippet109> --%>
<%-- <Snippet100> --%>
<%@ Page  Language="C#" AutoEventWireup="true" 
    Title="Configuration System Browser - Preferences"
    CodeFile="Preferences.aspx.cs"  MasterPageFile="~/Site.master" 
    Inherits="Preferences" %>
<%-- </Snippet100> --%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<%-- <Snippet101> --%>
    <h2>
        Preferences
    </h2>
    
    <asp:Panel ID="Panel2" runat="server" 
        GroupingText="Headings">
        <asp:Label ID="Label1" runat="server" 
            AssociatedControlID="HeadingTextBox" 
            Text="* Heading" class="bold">
        </asp:Label>
        <asp:TextBox ID="HeadingTextBox" runat="server">
        </asp:TextBox>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl="http://msdn.microsoft.com/en-us/library/ms178685.aspx">
            Configuration File Hierarchy Documentation
            </asp:HyperLink>
        <asp:RequiredFieldValidator ID="ConfigFileRequiredFieldValidator" 
            runat="server" 
            ControlToValidate="HeadingTextBox" 
            CssClass="errorMessage" 
            ErrorMessage="<br/>Enter a heading that corresponds to the information entered in the following section.">
        </asp:RequiredFieldValidator>
    </asp:Panel>
<%-- </Snippet101> --%>

<%-- <Snippet102> --%>
    <asp:Panel ID="Panel1" runat="server" 
        GroupingText="Select Configuration File">
        <asp:Label ID="Label5" runat="server" 
            AssociatedControlID="VirtualPathTextBox" Text="Virtual Path">
        </asp:Label>
        <asp:TextBox ID="VirtualPathTextBox" runat="server" TabIndex="2">
        </asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" 
            AssociatedControlID="SiteNameTextBox" Text="Site Name">
        </asp:Label>
        <asp:TextBox ID="SiteNameTextBox" runat="server">
        </asp:TextBox>
        <br />
        
        <asp:Label ID="Label3" runat="server" 
            AssociatedControlID="SubPathTextBox" Text="Sub Path">
        </asp:Label>
        <asp:TextBox ID="SubPathTextBox" runat="server">
        </asp:TextBox>
        <br />
        
        <asp:Label ID="Label4" runat="server" 
            AssociatedControlID="ServerTextBox" Text="Server">
        </asp:Label>
        <asp:TextBox ID="ServerTextBox" runat="server">
        </asp:TextBox>
        <br />
    </asp:Panel>
<%-- </Snippet102> --%>
<%-- <Snippet103> --%>
    * indicates required field.
    <br />
    <br />
    <asp:Button ID="SaveButton" runat="server" Text="Save" 
        TabIndex="6" onclick="SaveButton_Click" />&nbsp;
    <asp:Button ID="CancelButton" runat="server" Text="Cancel"
        CausesValidation="false" 
        TabIndex="7" onclick="CancelButton_Click" />
<%-- </Snippet103> --%>

</asp:Content>
<%-- </Snippet109> --%>
