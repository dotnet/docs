<%-- <Snippet32> --%>
<%@ Page Language="C#" AutoEventWireup="true" 
    Title="Configuration System Browser - Sections in a Section Group"
    CodeFile="SectionGroup.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="SectionGroup" %>
<%-- </Snippet32> --%>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <Snippet34> --%>
    <h2>
        <asp:Label ID="HeadingLabel" runat="server" 
            Text="Sections in Section Group [name]">
        </asp:Label>
    </h2> 
    <%-- </Snippet34> --%>    
    <%-- <Snippet36> --%>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetSections" TypeName="SectionGroupDataSource">
        <SelectParameters>
            <asp:QueryStringParameter Name="sectionGroupName" 
                QueryStringField="SectionGroup" Type="String" 
                DefaultValue="system.web" />
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
    <%-- </Snippet36> --%>
    <%-- <Snippet38> --%>
    <div class="dataTable">
        <asp:GridView ID="SectionGroupGridView" runat="server" 
            AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1"
            Caption="Sections in Section Group [name]"
            summary="This table shows sections that are 
                contained in the specified section group."
             Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name" 
                    SortExpression="Name" >
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            Text='<%# Bind("Name") %>' 
                            NavigateUrl='<%# Bind("NameUrl") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TypeName" 
                    SortExpression="TypeName">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            Text='<%# Bind("TypeName") %>' 
                            NavigateUrl='<%# Bind("TypeNameUrl") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <%-- </Snippet38> --%>
</asp:Content>
