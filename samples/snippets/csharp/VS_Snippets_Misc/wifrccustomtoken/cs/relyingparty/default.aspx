<%@ Page Title="Custom Token" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="RelyingParty._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>Demonstrates how to implement a custom security token.</h2>
            </hgroup>
            <p>
                This sample shows bhow to create, issue and use a custom security token in an ASP.Net Web
                Application. See the <a href="readme.html">sample read me</a>for a full explanation
                of this sample.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Hi
        <%: Page.User.Identity.Name %>!</h3>
    <p>
        Above you can see the name of an authenticated user. Below you can see the claims that were issued
        in the custom security token.
    </p>
    <h3>Your claims</h3>
    <p>
        <asp:GridView ID="ClaimsGridView" AutoGenerateColumns="true" runat="server" CellPadding="3">
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />
            <%--<Columns>
                <asp:BoundField DataField="Issuer" HeaderText="Issuer" Visible="true" />
                <asp:BoundField DataField="OriginalIssuer" HeaderText="Original Issuer" Visible="true" />
                <asp:BoundField DataField="Type" HeaderText="Type" Visible="true" />
                <asp:BoundField DataField="Value" HeaderText="Value" Visible="true" />
                <asp:BoundField DataField="ValueType" HeaderText="Value Type" Visible="true" />
            </Columns>--%>
        </asp:GridView>
    </p>
    <h3>The custom token</h3>
    <p>
        <asp:Label ID="tokenStringLabel" runat="server" Visible="false" ForeColor="Black" Text="The raw token issued by the security token service: <br/>"/>
    </p>
</asp:Content>
