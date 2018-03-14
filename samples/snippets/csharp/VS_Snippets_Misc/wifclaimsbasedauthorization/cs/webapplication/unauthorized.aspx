<%@ Page Title="Unauthorized" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Unauthorized.aspx.cs" Inherits="WebApplication.Administrators" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Your do not have authorization to view this page.</h2>
    </hgroup>

    <p>
        You can't see this page.
    </p>
</asp:Content>