<%--<snippet2>--%>
<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="Insert.aspx.cs" Inherits="Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true" />

    <h2> DynamicData\CustomPages\ProductDescriptions\Insert.aspx <%= table.DisplayName %></h2>
    <p>   <asp:Label ID="LblMetaTbl" runat="server" Text="Label"></asp:Label>   </p>

    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1" />

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
        HeaderText="List of validation errors" />
    <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="DetailsView1" Display="None" />

    <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="DetailsDataSource" DefaultMode="Insert"
        AutoGenerateInsertButton="True" OnItemCommand="DetailsView1_ItemCommand" OnItemInserted="DetailsView1_ItemInserted"
        CssClass="detailstable" FieldHeaderStyle-CssClass="bold"
        OnDataBound="DetailsView1_DataBound">
    </asp:DetailsView>

    <asp:LinqDataSource ID="DetailsDataSource" runat="server" EnableInsert="true">
    </asp:LinqDataSource>
</asp:Content>

<%--</snippet2>--%>