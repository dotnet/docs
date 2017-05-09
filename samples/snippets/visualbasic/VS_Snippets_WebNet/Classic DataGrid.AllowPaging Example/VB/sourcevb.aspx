<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="VB" runat="server">
 
        Dim Cart As DataTable
        Dim CartView As DAtaView

        Function CreateDataSource() As ICollection
            Dim dt As New DataTable()
            Dim dr As DataRow
            
            dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
            dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
            dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
            
            Dim i As Integer
            For i = 0 To 99
                dr = dt.NewRow()
                
                dr(0) = i
                dr(1) = "Item " + i.ToString()
                dr(2) = 1.23 *(i + 1)
                dt.Rows.Add(dr)
            Next i
            
            Dim dv As New DataView(dt)
            Return dv
        End Function 'CreateDataSource


        Sub Page_Load(sender As Object, e As EventArgs)
            
            If Not IsPostBack Then
                ' Need to load this data only once.
                ItemsGrid.DataSource = CreateDataSource()
                ItemsGrid.DataBind()
            End If
            
            If CheckBox1.Checked Then
                ItemsGrid.PagerStyle.Mode = PagerMode.NumericPages
            Else
                ItemsGrid.PagerStyle.Mode = PagerMode.NextPrev
            End If 
        End Sub 'Page_Load


        Sub Grid_Change(sender As Object, e As DataGridPageChangedEventArgs)
            
            ' Set CurrentPageIndex to the page the user clicked.
            ItemsGrid.CurrentPageIndex = e.NewPageIndex
            
            ' Rebind the data. 
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
        End Sub 'Grid_Change  
</script>
 
<head runat="server">
    <title>DataGrid Paging Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

   <h3>DataGrid Paging Example</h3>
 
   <asp:DataGrid id="ItemsGrid" runat="server"
        BorderColor="black"
        BorderWidth="1"
        CellPadding="3"
        AllowPaging="true"
        AutoGenerateColumns="false"        
        OnPageIndexChanged="Grid_Change">
 
      <HeaderStyle BackColor="#00aaaa">
      </HeaderStyle>
 
      <PagerStyle Mode="NextPrev">
      </PagerStyle> 

      <Columns>

         <asp:BoundColumn 
              HeaderText="Number" 
              DataField="IntegerValue"/>
 
        <asp:BoundColumn 
              HeaderText="Item" 
              DataField="StringValue"/>

         <asp:BoundColumn 
              HeaderText="Price" 
              DataField="CurrencyValue" 
              DataFormatString="{0:c}">
 
            <ItemStyle HorizontalAlign="right">
            </ItemStyle>
     
         </asp:BoundColumn>

      </Columns>

   </asp:DataGrid>

   <br />

   <asp:CheckBox id="CheckBox1" 
                 Text="Show page navigation"
                 AutoPostBack="true"
                 runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
