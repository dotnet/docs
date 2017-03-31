<%-- <Snippet2> --%>
<%@ Page Title="" MasterPageFile="~/Seasons.master" AutoEventWireup="true" %>

<%@ Register Src="Seasons.ascx" TagName="Seasons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:Seasons ID="Seasons1" runat="server" />
</asp:Content>
<%-- </Snippet2> --%>