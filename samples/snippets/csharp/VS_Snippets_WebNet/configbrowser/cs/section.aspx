<%-- <Snippet52> --%>
<%@ Page  Language="C#" AutoEventWireup="true" 
    Title="Configuration System Browser - Elements in a Section"
    CodeFile="Section.aspx.cs"  MasterPageFile="~/Site.master" 
    Inherits="Section" %>
<%-- </Snippet52> --%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%-- <Snippet53> --%>
    <h2>
        <asp:Label ID="HeadingLabel" runat="server" 
            Text="Elements in Section [name]">
        </asp:Label>
    </h2> 
    <%-- </Snippet53> --%>   
    <%-- <Snippet54> --%>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetProperties" TypeName="SectionDataSource">
        <SelectParameters>
            <asp:QueryStringParameter Name="sectionName" 
                QueryStringField="Section" Type="String" 
                DefaultValue="system.web/httpHandlers" />
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
    <%-- </Snippet54> --%>
    <%-- <Snippet55> --%>
    <div class="dataTable">
        <asp:ListView ID="ListView1" runat="server" 
            DataSourceID="ObjectDataSource1" 
            onprerender="ListView1_PreRender" >
    <%-- </Snippet55> --%>
    <%-- <Snippet56> --%>
            <LayoutTemplate>
                <table class="listViewTable" width="100%"
                    cellpadding="5" rules="all" border="1" 
                    summary="This table shows elements that are 
                        contained in the specified section.">
                    <caption runat="server" ID="ElementTableCaption">
                        Elements in the system.web/httpHandlers Section
                    </caption>
                    <thead>
                        <tr style="">
                            <th scope="col">Name</th>
                            <th scope="col">Type</th>
                            <th scope="col">Value</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
    <%-- </Snippet56> --%>
    <%-- <Snippet57> --%>
            <ItemTemplate>
                <tr>
                    <td scope="row" class="rowHeading">
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            Text='<%# Eval("Name") %>' 
                            NavigateUrl='<%# Eval("NameUrl") %>'>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            Text='<%# Eval("TypeName") %>' 
                            NavigateUrl='<%# Eval("TypeNameUrl") %>'>
                        </asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("Value") %>' >
                        </asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
    <%-- </Snippet57> --%>
    <%-- <Snippet58> --%>
            <EmptyDataTemplate>
                <asp:Label ID="NoElementsLabel" runat="server" 
                    Text="The [name] section 
                        does not contain any elements.">
                </asp:Label>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    <%-- </Snippet58> --%>
</asp:Content>
