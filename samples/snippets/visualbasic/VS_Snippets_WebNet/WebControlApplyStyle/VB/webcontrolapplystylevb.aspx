<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Private Function CreateDataSource() As ICollection 
      
         Dim dt As DataTable = New DataTable
         Dim dr As DataRow
         Dim dv As DataView
         Dim i As Integer
 
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Integer)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
         for i = 0 to 9  
         
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " + i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)

         next i
 
         dv = New DataView(dt)
         CreateDataSource = dv

      End Function
 
      Private Sub Page_Load(sender As Object, e As EventArgs) 
      
         If Not IsPostBack Then 
            ' Load this data only once.
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
         End If

      End Sub

      Private Sub Button_Click(sender As Object, e As EventArgs) 
    
         Dim myStyle As Style = new Style()
         myStyle.ForeColor = System.Drawing.Color.Red
         myStyle.BackColor = System.Drawing.Color.Yellow
      
         ItemsGrid.ApplyStyle(myStyle)

      End Sub
 
   </script>
 
<head runat="server">
    <title>WebControl ApplyStyle Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>WebControl ApplyStyle Example</h3>
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <Columns>

            <asp:BoundColumn
                 HeaderText="Number" 
                 DataField="IntegerValue">
            </asp:BoundColumn>

            <asp:BoundColumn
                 HeaderText="Description" 
                 DataField="StringValue">
            </asp:BoundColumn>

            <asp:BoundColumn
                 HeaderText="Price" 
                 DataField="CurrencyValue" 
                 DataFormatString="{0:c}">
            </asp:BoundColumn>

         </Columns>
 
      </asp:DataGrid>

      <br /><br />

      <asp:Button id="Button1" 
           Text="Apply Custom Style"
           OnClick="Button_Click"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->