<%@ Page Title="Developers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Developers.aspx.cs" Inherits="WebApplication.Administrators" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Only developers (and Administrators) can see this page.</h2>
    </hgroup>

    <p>You have the developer role claim, or the Administrator group claim, if you can see this page.</p>

</asp:Content>