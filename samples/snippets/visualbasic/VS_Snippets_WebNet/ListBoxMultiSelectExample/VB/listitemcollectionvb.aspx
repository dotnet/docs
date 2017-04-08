<!-- <Snippet1> -->
<!-- This example demonstrates how to select multiple items from a DataList 
and add the selected items to a DataGrid. The example uses a For Each loop 
to iterate through the ListItem objects in the ListItemCollection of ListBox1. -->

<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code snippet in a fully-working example, see the 
ListItemCollection Class topic. -->

<!-- </Snippet2> -->
<!-- <Snippet3> -->
<%@ Page language="VB" AutoEventWireup="true"%>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
            ' Global Variables.
            Private dv As DataView
            Private dt As New DataTable()

            Private Sub Page_Load(sender As Object, e As System.EventArgs)
' <Snippet4>
                ' Set the number of rows displayed in the ListBox to be
                ' the number of items in the ListBoxCollection.
                ListBox1.Rows = ListBox1.Items.Count
' </Snippet4>

                ' If the DataTable is already stored in the Web form's default
                ' HttpSessionState variable, then don't recreate the DataTable.
                If Session("data") Is Nothing Then
                    ' Add columns to the DataTable.
                    dt.Columns.Add(New DataColumn("Item"))
                    dt.Columns.Add(New DataColumn("Price"))
            ' Store the DataTable in the Session variable so it can be 
                    ' accessed again later.
                    Session("data") = dt
                    
                    ' Use the table to create a DataView, because the DataGrid
                    ' can only bind to a data source that implements IEnumerable.
                    dv = New DataView(dt)
            
                    ' Set the DataView as the data source, and bind it to the DataGrid.
                    DataGrid1.DataSource = dv
                    DataGrid1.DataBind()
                End If
            End Sub

            Private Sub addButton_Click(sender As Object, e As System.EventArgs)
' <Snippet5>
                ' Add the items selected in ListBox1 to DataGrid1.
                Dim item As ListItem
                For Each item In ListBox1.Items
                    If item.Selected Then
                        ' Add the item to the DataGrid.
                        ' First, get the DataTable from the Session variable.
                        dt = CType(Session("data"), DataTable)
            
                        If  Not (dt Is Nothing) Then
                            ' Create a new DataRow in the DataTable.
                            Dim dr As DataRow
                            dr = dt.NewRow()
                            ' Add the item to the new DataRow.
                            dr("Item") = item.Text
                            ' Add the item's value to the DataRow.
                            dr("Price") = item.Value
                            ' Add the DataRow to the DataTable.
                            dt.Rows.Add(dr)
' </Snippet5>

                            ' Rebind the data to DataGrid1.
                            dv = new DataView(dt)
                            DataGrid1.DataSource = dv
                            DataGrid1.DataBind()
                        End If
                    End If
                Next item
            End Sub
        </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title> ListItemCollection Example </title>
</head>
    
    <body>
        <form id="form1" runat="server">

            <h3> ListItemCollection Example </h3>

            <table cellpadding="6" border="0">
                <tr>
                    <td valign="top">
                        <asp:ListBox id="ListBox1" runat="server" SelectionMode="Multiple">
                            <asp:ListItem Value=".89">apples</asp:ListItem>
                            <asp:ListItem Value=".49">bananas</asp:ListItem>
                            <asp:ListItem Value="2.99">cherries</asp:ListItem>
                            <asp:ListItem Value="1.49">grapes</asp:ListItem>
                            <asp:ListItem Value="2.00">mangos</asp:ListItem>
                            <asp:ListItem Value="1.09">oranges</asp:ListItem>
                        </asp:ListBox>
                    </td>

                    <td valign="top">
                        <asp:Button id="addButton" runat="server" Text="Add -->"
                            Width="100px" OnClick="addButton_Click"></asp:Button>
                    </td>

                    <td valign="top">
                        <asp:DataGrid Runat="server" ID="DataGrid1" CellPadding="4">
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>        
        </form>
    </body>
</html>
<!-- </Snippet3> -->