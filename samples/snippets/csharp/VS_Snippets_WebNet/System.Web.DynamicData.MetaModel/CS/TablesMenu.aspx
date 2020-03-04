<!-- <Snippet5> -->
<%@ Page Language="C#" AutoEventWireup="true" 
CodeFile="TablesMenu.aspx.cs" 
Inherits="TablesMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<body>
    <h2>Tables</h2>

    <form runat="server">
   
        <h4>Visible Tables</h4>
        <asp:GridView ID="Menu1" runat="server" 
        AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("ListActionPath") %>'><%#Eval("DisplayName") %></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
 
         <h4>Tables in the Data Model</h4>
        <asp:GridView ID="Menu2" runat="server" 
        AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("ListActionPath") %>'><%#Eval("DisplayName") %></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        
    </form>
    
</body>
<!-- </Snippet5> -->