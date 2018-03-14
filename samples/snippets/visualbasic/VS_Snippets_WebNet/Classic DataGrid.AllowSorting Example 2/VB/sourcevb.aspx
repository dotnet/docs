<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script language="VB" runat="server">
    
    Dim SortExpression As String
 
    Function CreateDataSource() As ICollection
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim Rand_Num As New Random()
        
        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
        
        Dim i As Integer
        For i = 0 To 14
            dr = dt.NewRow()
            
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * Rand_Num.Next(1, 15)
            
            dt.Rows.Add(dr)
        Next i
        
        Dim dv As New DataView(dt)
        dv.Sort = SortExpression
        Return dv
    End Function 'CreateDataSource


    Sub Page_Load(sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            
            If SortExpression = "" Then
                SortExpression = "IntegerValue"
            End If
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
        End If
    End Sub 'Page_Load
     

    Sub Sort_Grid(sender As Object, e As DataGridSortCommandEventArgs)
        SortExpression = e.SortExpression.ToString()
        ItemsGrid.DataSource = CreateDataSource()
        ItemsGrid.DataBind()
    End Sub 'Sort_Grid
 
 </script>
 
 <head runat="server">
    <title>DataGrid Sorting Example</title>
</head>
<body>
 
    <form id="form1" runat="server">
 
       <h3>DataGrid Sorting Example</h3>
 
       <asp:DataGrid id="ItemsGrid" runat="server"
            BorderColor="black"
            BorderWidth="1"
            CellPadding="3"
            AllowSorting="true"
            OnSortCommand="Sort_Grid"
            HeaderStyle-BackColor="#00aaaa"
            AutoGenerateColumns="true"/>
 
    </form>
 
 </body>
 </html>

<!--</Snippet1>-->
