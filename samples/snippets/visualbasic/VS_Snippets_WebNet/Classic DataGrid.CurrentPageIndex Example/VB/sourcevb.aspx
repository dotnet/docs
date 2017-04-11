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
        For i = 0 To 199
            dr = dt.NewRow()
            
            dr(0) = i
            dr(1) = "Item " + i.ToString()
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


    Sub Page_Load(sender As Object, e As EventArgs)
        If chk1.Checked Then
            MyDataGrid.PagerStyle.Visible = True
        Else
            MyDataGrid.PagerStyle.Visible = False
        End If 
        BindGrid()
    End Sub 'Page_Load


    Sub PagerButtonClick(sender As Object, e As EventArgs)
        ' Used by external paging UI.
        Dim arg As String = CType(sender, LinkButton).CommandArgument
        
        Select Case arg
            Case "next"
                If MyDataGrid.CurrentPageIndex < MyDataGrid.PageCount - 1 Then
                    MyDataGrid.CurrentPageIndex += 1
                End If
            Case "prev"
                If MyDataGrid.CurrentPageIndex > 0 Then
                    MyDataGrid.CurrentPageIndex -= 1
                End If
            Case "last"
                MyDataGrid.CurrentPageIndex = MyDataGrid.PageCount - 1
            Case Else

                ' Page number.
                MyDataGrid.CurrentPageIndex = Convert.ToInt32(arg)
        End Select
        BindGrid()
    End Sub 'PagerButtonClick


    Sub MyDataGrid_Page(sender As Object, e As DataGridPageChangedEventArgs)
        ' Used by built-in pager.  CurrentPageIndex is already set.
        BindGrid()
    End Sub 'MyDataGrid_Page


    Sub BindGrid()
        MyDataGrid.DataSource = CreateDataSource()
        MyDataGrid.DataBind()
        ShowStats()
    End Sub 'BindGrid


    Sub ShowStats()
        lblCurrentIndex.Text = "CurrentPageIndex is " & MyDataGrid.CurrentPageIndex
        lblPageCount.Text = "PageCount is " & MyDataGrid.PageCount
    End Sub 'ShowStats

   </script>

<head runat="server">
    <title>DataGrid Custom Paging Controls</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>DataGrid Custom Paging Controls</h3>

      <asp:DataGrid id="MyDataGrid"
           AllowPaging="True"
           PageSize="10"
           OnPageIndexChanged="MyDataGrid_Page"
           BorderColor="black"
           BorderWidth="1"
           GridLines="Both"
           CellPadding="3"
           CellSpacing="0"
           Font-Names="Verdana"
           Font-Size="8pt"
           runat="server">

          <PagerStyle Mode="NumericPages"
                      HorizontalAlign="Right">
          </PagerStyle>

          <HeaderStyle BackColor="#aaaadd">
          </HeaderStyle>

          <AlternatingItemStyle BackColor="#eeeeee">
          </AlternatingItemStyle>

      </asp:DataGrid>

      <br />

      <asp:LinkButton id="btnPrev"
           Text="Previous page"
           CommandArgument="prev"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      &nbsp;

      <asp:LinkButton id="btnNext"
           Text="Next page"
           CommandArgument="next"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      &nbsp;

      <asp:LinkButton id="btnPage8" runat="server"
           Text="Go to Page 8"
           CommandArgument="7"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"/>

      &nbsp;
 
      <asp:LinkButton id="btnFirst"
           Text="Go to the first page"
           CommandArgument="0"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      &nbsp;

      <asp:LinkButton id="btnLast"
           Text="Go to the last page"
           CommandArgument="last"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      <br />

      <asp:Checkbox id="chk1"
           Text="Show built-in pager"
           Font-Names="Verdana"
           Font-Size="8pt"
           AutoPostBack="true"
           runat="server"/>

      <br />

      <table style="background-color:#eeeeee; padding:6">
         <tr>
            <td style="display:inline">
               

                  <asp:Label id="lblCurrentIndex" 
                       runat="server" />
                  <br />

                  <asp:Label id="lblPageCount" 
                       runat="server" />
                  <br />

               
            </td>
         </tr>
      </table>
   </form>

</body>
</html>

<!--</Snippet1>-->
