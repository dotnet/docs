<%@ Page Title="Claims" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Claims.aspx.cs" Inherits="WebApplication.Claims" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>
            <%: Page.Title %>.</h1>
        <h2>All authenticated users can see this page.</h2>
    </hgroup>
    <article>
        <h3>Hi
            <asp:Label ID="nameLabel" runat="server"></asp:Label>!</h3>
        <p>
            Claims associated with an authenticated user can be accessed directly, for example
        the name displayed above is accessed in the code behind of claims.aspx page
        by creating a ClaimsPrincipal from the current user rather than the Page.User.Identity.Name
        property. 
        </p>
        <p>
            Below you can see all of the claims associated with the authenticated user in the GridView
        where we have used the ClaimsPrincipal as the data source in the code behind.
        You can authenticate using either forms auth, the Local STS or other identity provider
        and the same code will display your claims below.
        </p>
        <h3>Your claims</h3>
        <p>
            <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">
                <AlternatingRowStyle BackColor="White" />
                <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />
            </asp:GridView>
        </p>
    </article>
</asp:Content>
