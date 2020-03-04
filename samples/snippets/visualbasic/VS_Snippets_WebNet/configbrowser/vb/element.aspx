<%-- <Snippet90> --%>
<%-- <Snippet81> --%>
<%@ Page Language="VB" AutoEventWireup="true" 
    Title="Configuration System Browser - Element Properties"
    CodeFile="Element.aspx.vb" MasterPageFile="~/Site.master" 
    Inherits="Element" %>
<%-- </Snippet81> --%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%-- <Snippet82> --%>
    <h2>
        <asp:Label ID="HeadingLabel" runat="server" 
            Text="Elements in Section [name]">
        </asp:Label>
    </h2> 
    <%-- </Snippet82> --%>   
    <%-- <Snippet83> --%>
    <asp:ObjectDataSource ID="OuterObjectDataSource" runat="server" 
        SelectMethod="GetElements" TypeName="ElementDataSource">
        <SelectParameters>
            <asp:QueryStringParameter Name="sectionName" 
                QueryStringField="Section" Type="String" 
                DefaultValue="system.web/webParts" />
            <asp:QueryStringParameter Name="elementName" 
                QueryStringField="Element" Type="String" 
                DefaultValue="Transformers" />
            <asp:SessionParameter Name="virtualPath" 
                SessionField="Path" Type="String" 
                DefaultValue="" />
            <asp:SessionParameter Name="site" 
                SessionField="Site" Type="String" 
                DefaultValue="" />
            <asp:SessionParameter Name="locationSubPath" 
                SessionField="SubPath" Type="String" 
                DefaultValue="" />
            <asp:SessionParameter Name="server" 
                SessionField="Server" Type="String" 
                DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <%-- </Snippet83> --%>
    <%-- <Snippet84> --%>
    <div class="dataTable">
        <asp:ListView ID="ListView1" runat="server" 
            DataSourceID="OuterObjectDataSource"
            OnPreRender="ListView1_PreRender" 
            onitemdatabound="ListView1_ItemDataBound">
    <%-- </Snippet84> --%>
    <%-- <Snippet85> --%>
            <LayoutTemplate>
                <table class="listViewTable" width="100%"
                    cellpadding="5" rules="all" border="1"
                    summary="This table shows properties of items 
                        contained in an element collection.">
                    <caption runat="server" ID="ElementTableCaption">
                        Properties of the [name] Element
                    </caption>
                    <tr style="">
                        <th id="hdrName" axis="field">Name</th>
                        <th id="hdrType" axis="field">Type</th>
                        <th id="hdrValue" axis="field">Value</th>
                    </tr>
                    <tbody id="itemPlaceholder" runat="server"></tbody>
                </table>
            </LayoutTemplate>
    <%-- </Snippet85> --%>
    <%-- <Snippet86> --%>
            <ItemTemplate>
                <tr>
                    <th colspan="3" 
                        id="<%# GetElementHeaderID(Container) %>" axis="item">
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("ItemName") %>' >
                        </asp:Label>
                    </th>
                </tr>
    <%-- </Snippet86> --%>
    <%-- <Snippet87> --%>
                <asp:ObjectDataSource ID="InnerObjectDataSource" runat="server" 
                    SelectMethod="GetProperties" TypeName="ElementDataSource">
                    <SelectParameters>
                        <asp:Parameter Name="sectionName" Type="String" 
                            DefaultValue="system.web/webParts" />
                        <asp:Parameter Name="elementName" 
                            Type="String" DefaultValue="Transformers" />
                        <asp:Parameter Name="index" Type="Int32"
                            DefaultValue="1" />
                        <asp:SessionParameter Name="virtualPath" 
                            SessionField="Path" Type="String" 
                            DefaultValue="" />
                        <asp:SessionParameter Name="site" 
                            SessionField="Site" Type="String" 
                            DefaultValue="" />
                        <asp:SessionParameter Name="locationSubPath" 
                            SessionField="SubPath" Type="String" 
                            DefaultValue="" />
                        <asp:SessionParameter Name="server" 
                            SessionField="Server" Type="String" 
                            DefaultValue="" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <%-- </Snippet87> --%>
    <%-- <Snippet88> --%>
                <asp:ListView ID="PropertiesListView" runat="server" 
                    DataSourceID="InnerObjectDataSource">
                    <LayoutTemplate>
                        <tr id="itemPlaceHolder" runat="server"></tr>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td id="<%# GetPropertyHeaderID(Container) %>"
                                axis="property">
                                <%# Eval("Name") %>
                            </td>
                            <td headers="<%# GetColumnHeaderIDs(Container, "hdrType") %>">
                                <asp:HyperLink ID="HyperLink2" 
                                    runat="server" 
                                    Text='<%# Eval("TypeName") %>' 
                                    NavigateUrl='<%# Eval("TypeNameUrl") %>'>
                                </asp:HyperLink>
                            </td>
                            <td headers="<%# GetColumnHeaderIDs(Container, "hdrValue") %>">
                                <%# Eval("Value") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </ItemTemplate>
    <%-- </Snippet88> --%>
    <%-- <Snippet89> --%>
            <EmptyDataTemplate>
                <asp:Label ID="NoElementsLabel" runat="server" 
                    Text="No information is available for the [element] element.">
                </asp:Label>
            </EmptyDataTemplate>
        </asp:ListView>
        </div>
    <%-- </Snippet89> --%>
</asp:Content>
<%-- </Snippet90> --%>

