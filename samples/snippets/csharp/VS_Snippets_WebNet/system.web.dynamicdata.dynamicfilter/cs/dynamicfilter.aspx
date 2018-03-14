<!-- <Snippet1> -->
<%@ Page Language="C#" MasterPageFile="~/Site.master" 
    CodeFile="DynamicFilter.aspx.cs" Inherits="ForeignKeyFilter" %>

<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true" />

    <h2 class="DDSubHeader"><%= table.DisplayName%> ForeignKey filter</h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                EnableClientScript="true"
                HeaderText="List of validation errors" />
            <asp:DynamicValidator runat="server" ID="GridViewValidator" 
                ControlToValidate="GridView1" Display="None" />
            
            <!-- Show that the filter selection 
                is retained after a post-back -->
            <asp:Button ID="Button1" runat="server" Text="Cause Postback" /> &nbsp; &nbsp;
            <span></span>The filter selection is retained after a postback.</span> 
         
            <br />
            
            <!-- Set the DynamicFilter control attributes. --> 
            Select Category: <asp:DynamicFilter runat="server" ID="CategoryFilter" 
            DataField="ProductCategory" FilterUIHint="ForeignKey" 
            OnFilterChanged="OnFilterSelectedIndexChanged" /><br />

            <!-- Data-bound control that shows the filtered table rows. -->
            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" 
                EnablePersistedSelection="true" PageSize="5" 
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete"
                                CausesValidation="true" Text="Delete"
                                OnClientClick='return confirm("Are you sure you want to delete this item?");'
                            />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerStyle CssClass="footer"/>        
                <PagerTemplate>
                    <asp:GridViewPager runat="server" />
                </PagerTemplate>
                <EmptyDataTemplate>
                    There are currently no items in this table.
                </EmptyDataTemplate>
            </asp:GridView>
            
            <!-- The provider that connects to the database -->
            <asp:LinqDataSource ID="GridDataSource" runat="server" 
                EnableDelete="true" 
                ContextTypeName="AdventureWorksLTDataContext"
                TableName="Products">
            </asp:LinqDataSource>
            
            <!-- The control that handles the details for querying 
            the database, after a user's filtering action -->
            <asp:QueryExtender ID="QueryBlock1" TargetControlID="GridDataSource" 
                runat="server">
                <asp:DynamicFilterExpression ControlID="CategoryFilter" />
            </asp:QueryExtender>
            
        </ContentTemplate>
    </asp:UpdatePanel>
 
</asp:Content>
<!-- </Snippet1> -->
