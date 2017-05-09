<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script language="VB" runat="server">
 
Function CreateDataSource() As ICollection
    Dim dt As New DataTable()
    Dim dr As DataRow
    
    dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
    dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
    dt.Columns.Add(New DataColumn("DateTimeValue", GetType(String)))
    dt.Columns.Add(New DataColumn("BoolValue", GetType(Boolean)))
    
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


Sub Page_Load(sender As Object, E As EventArgs)
    If chk1.Checked Then
        MyDataGrid.PagerStyle.Mode = PagerMode.NumericPages
    Else
        MyDataGrid.PagerStyle.Mode = PagerMode.NextPrev
    End If 
    BindGrid()
End Sub 'Page_Load


Sub MyDataGrid_Page(sender As Object, e As DataGridPageChangedEventArgs)
    MyDataGrid.CurrentPageIndex = e.NewPageIndex
    BindGrid()
End Sub 'MyDataGrid_Page


Sub BindGrid()
    MyDataGrid.DataSource = CreateDataSource()
    MyDataGrid.DataBind()
    ShowStats()
End Sub 'BindGrid


Sub ShowStats()
    lblEnabled.Text = "AllowPaging is " & MyDataGrid.AllowPaging
    lblCurrentIndex.Text = "CurrentPageIndex is " & MyDataGrid.CurrentPageIndex
    lblPageCount.Text = "PageCount is " & MyDataGrid.PageCount
    lblPageSize.Text = "PageSize is " & MyDataGrid.PageSize
End Sub 'ShowStats
 
 
 </script>
 
 <head runat="server">
    <title>DataGrid Paging Example</title>
</head>
<body>
 
    <h3>DataGrid Paging Example</h3>
 
    <form id="form1" runat="server">
 
       <asp:DataGrid id="MyDataGrid" runat="server"
            AllowPaging="True"
            PageSize="10"
            OnPageIndexChanged="MyDataGrid_Page"
            BorderColor="black"
            BorderWidth="1"
            GridLines="Both"
            CellPadding="3"
            CellSpacing="0"
            Font-Names="Verdana"
            Font-Size="8pt">

          <PagerStyle Mode="NumericPages"
                      HorizontalAlign="Right">
          </PagerStyle>

          <HeaderStyle BackColor="#aaaadd">
          </HeaderStyle>

          <AlternatingItemStyle BackColor="#eeeeee">
          </AlternatingItemStyle>
 
       </asp:DataGrid>
       
       <br />
 
       <asp:Checkbox id="chk1" runat="server"
            Text="Show numeric page navigation buttons"
            Font-Names="Verdana"
            Font-Size="8pt"
            AutoPostBack="true"/>
 
       <br />
 
       <table style="background-color:#eeeeee; padding:6">
          <tr>
             <td style="display:inline">
                
 
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
 
    </form>
 
 </body>
 </html>

<!--</Snippet1>-->
