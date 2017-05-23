<%@ Page Title="Claims Based Authorization" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>Demonstrates use of claims for authorization.</h2>
            </hgroup>
            <p>
                This sample shows use of claims for authorization within an ASP.Net Web Application. See the
                <a href="readme.html">sample read me</a>for a full explanation of this sample.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Try accessing the seperately protected pages.</h3>
    <p>
        This page allows anonymous access, the other pages in this web application require
        authentication and specific claim types for access. By default you should be able to
        access the <a href="Developers.aspx">Developers page</a>. You should not initially be
        able to access the <a href="Administrators.aspx">Administrators page</a>. Access to the
        pages is controlled via web.config settings for specific claim values using the Claims
        Authorization Manager that is part of WIF. See the <a href="readme.html">sample readme</a>
        for a full explanation.
    </p>
    <h3>Your claims</h3>
    <p>
        By default this application is configured to use the Local STS that will issue claims to
        you as soon as authentication in the application is required. You can see the claims 
        associated with your user <a href="Claims.aspx">here</a>. You can change the claims issued to
        you via the Identity and Access extension or directly in the Local STS config. For this 
        project there are commented claim values for you to uncomment to allow access to the 
        <a href="Administrators.aspx">Administrators page</a>.
    </p>
</asp:Content>
