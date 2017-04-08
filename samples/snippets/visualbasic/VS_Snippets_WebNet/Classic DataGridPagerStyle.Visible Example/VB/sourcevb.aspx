<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
     
    Function CreateDataSource() As ICollection
        Dim dt As New DataTable()
        Dim dr As DataRow
        
        dt.Columns.Add( _
            New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add( _
            New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add( _
            New DataColumn("DateTimeValue", GetType(String)))
        dt.Columns.Add( _
            New DataColumn("BoolValue", GetType(Boolean)))
        
        Dim i As Integer
        For i = 0 To 99
            dr = dt.NewRow()
            
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = DateTime.Now.ToShortDateString()
            If i Mod 2 <> 0 Then
                dr(3) = True
            Else
                dr(3) = False
            End If
            
            dt.Rows.Add(dr)
        Next i
        
        Dim dv As New DataView(dt)
        Return dv
    End Function 'CreateDataSource

    Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        If chk1.Checked Then
            MyDataGrid.PagerStyle.Visible = True
        Else
            MyDataGrid.PagerStyle.Visible = False
        End If
        BindGrid()
    End Sub 'Page_Load

    Sub MyDataGrid_Page(ByVal sender As Object, _
        ByVal e As DataGridPageChangedEventArgs)

        MyDataGrid.CurrentPageIndex = e.NewPageIndex
        BindGrid()
    End Sub 'MyDataGrid_Page

    Sub BindGrid()
        MyDataGrid.DataSource = CreateDataSource()
        MyDataGrid.DataBind()
        ShowStats()
    End Sub 'BindGrid

    Sub ShowStats()
        lblEnabled.Text = "AllowPaging is " _
            & MyDataGrid.AllowPaging
        lblCurrentIndex.Text = "CurrentPageIndex is " _
            & MyDataGrid.CurrentPageIndex
        lblPageCount.Text = "PageCount is " _
            & MyDataGrid.PageCount
        lblPageSize.Text = "PageSize is " _
            & MyDataGrid.PageSize
    End Sub 'ShowStats

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Paging with DataGrid</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>

   <h3>Paging with DataGrid</h3>
 
      <asp:DataGrid id="MyDataGrid" runat="server"
          AllowPaging="True"
          PageSize="10"
          PagerStyle-Mode="NumericPages"
          PagerStyle-HorizontalAlign="Right"
          OnPageIndexChanged="MyDataGrid_Page"
          BorderColor="black"
          BorderWidth="1"
          GridLines="Both"
          CellPadding="3"
          CellSpacing="0"
          Font-Names="Verdana"
          Font-Size="8pt"
          HeaderStyle-BackColor="#aaaadd"
          AlternatingItemStyle-BackColor="#eeeeee" />
 
      <p>
          <asp:Checkbox id="chk1" runat="server"
              Text="Show pager"
              Font-Names="Verdana"
              Font-Size="8pt"
              AutoPostBack="true" />
      </p>
 
      <table style="background-color: #eeeeee" cellpadding="6">
          <tr>
              <td style="white-space: nowrap">
                  <asp:Label id="lblEnabled" 
                       runat="server"/><br />
                  <asp:Label id="lblCurrentIndex" 
                       runat="server"/><br />
                  <asp:Label id="lblPageCount" 
                       runat="server"/><br />
                  <asp:Label id="lblPageSize" 
                       runat="server"/><br />
              </td>
          </tr>
      </table>

   </div>
   </form>
</body>
</html>
<!--</Snippet1>-->
