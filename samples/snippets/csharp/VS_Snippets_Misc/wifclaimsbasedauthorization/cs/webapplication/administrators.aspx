<%@ Page Title="Administrators" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrators.aspx.cs" Inherits="WebApplication.Administrators" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Only administrators can see this page</h2>
    </hgroup>

    <p>You  belong to the Administrators group and have the country claim USA if you can see this page</p>

</asp:Content>