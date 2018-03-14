<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>
<%--The line below works around a Visual Studio bug that causes harmless page compilation warnings.--%>
<%=""%>
<%
    If Request.IsAuthenticated Then
    %>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account")%> ]
    <%
    Else
    %>
        [ <%= Html.ActionLink("Log On", "LogOn", "Account")%> ]
    <%        
    End If
%>