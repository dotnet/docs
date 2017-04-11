<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Function CreateDataSource() As ICollection

         ' Create sample data for the DataGrid control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow 
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
         ' Populate the table with sample values.
         Dim i As Integer         

         For i=0 To 10 

            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)
         
         Next i
 
         Dim dv As DataView = New DataView(dt)

         return dv
      
      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs)
 
         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then
         
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
         
         End If

      End Sub
 
      Sub Item_Created(sender As Object, e As DataGridItemEventArgs) 
 
         ' Customize the footer section with an image.
         If e.Item.ItemType = ListItemType.Footer Then         
 
           ' Create an Image control.
           Dim NewImageControl As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()

           ' Set the properties of the Image control.
           NewImageControl.ImageUrl = "Image1.jpg"
           NewImageControl.AlternateText = "Image 1"
           
           ' Add the Image control to the Controls collection of the 
           ' cell representing the third column in the DataGrid.
           e.Item.Cells(2).Controls.Add(NewImageControl)

         End If         
 
      End Sub
 
</script>
 
<head runat="server">
    <title>DataGrid ItemCreated Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid ItemCreated Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true"
           OnItemCreated="Item_Created">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>

   </form>
 
</body>
</html>

<!-- </Snippet1> -->