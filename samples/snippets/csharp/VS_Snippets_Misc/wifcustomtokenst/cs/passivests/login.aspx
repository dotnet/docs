<%@ Page Title="Passive STS Log In" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="PassiveSTS.Login" %>

<%@ OutputCache Location="None" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>
            <%:Page.Title %>.</h1>
        <h2>Enter your user name and password below.</h2>
    </hgroup>
    <asp:Login ID="STSLogin" runat="server" DisplayRememberMe="False" OnAuthenticate="Login_Authenticate"
        TitleText="Enter any user name and password to sign-in">
        <LayoutTemplate>
            <p class="validation-summary-errors">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
            <fieldset>
                <legend>Log in Form</legend>
                <ol>
                    <li>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">User name</asp:Label>
                        <asp:TextBox runat="server" ID="UserName" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                            CssClass="field-validation-error" ErrorMessage="Enter any non-empty string as username, the user name field is required." />
                    </li>
                    <li>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password"
                            CssClass="field-validation-error" ErrorMessage="The password field is not required." />--%>
                    </li>
                </ol>
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" />
            </fieldset>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
