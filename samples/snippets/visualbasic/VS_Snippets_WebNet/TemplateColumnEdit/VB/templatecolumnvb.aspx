<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">

      Private Store As DataTable = New DataTable()
      Private StoreView As DataView  

      Sub Page_Load(sender As Object, e As EventArgs) 
     
         If IsNothing(Session("StoreData")) Then 
         
            Dim dr As DataRow
            Dim i As Integer
 
            Store = New DataTable()      

            Store.Columns.Add(New DataColumn("Tax", GetType(String)))
            Store.Columns.Add(New DataColumn("Item", GetType(String)))
            Store.Columns.Add(New DataColumn("Price", GetType(String)))

            Session("StoreData") = Store
            
            ' Create sample data.
            For i = 1 to 4 
    
               dr = Store.NewRow()

               dr(0) = "0.0%"
               dr(1) = "Item " & i.ToString()
               dr(2) = (1.23 * (i + 1)).ToString()
 
               Store.Rows.Add(dr)

            Next i       

         Else
            Store = Session("StoreData")

         End If

         StoreView = New DataView(Store)
         StoreView.Sort="Item"

         If Not IsPostBack Then                    
            BindGrid()
         End If
                   
      End Sub

      Sub MyDataGrid_Edit(sender As Object, e As DataGridCommandEventArgs) 
      
         MyDataGrid.EditItemIndex = e.Item.ItemIndex
         BindGrid()

      End Sub

      Sub MyDataGrid_Cancel(sender As Object, e As DataGridCommandEventArgs) 
      
         MyDataGrid.EditItemIndex = -1
         BindGrid()

      End Sub

      Sub MyDataGrid_Update(sender As Object, e As DataGridCommandEventArgs) 
      
         ' Get the text box that contains the price to edit. 
         ' For bound columns the edited value is stored in a text box.
         ' The text box is the first control in the Controls collection.
         Dim priceText As TextBox = e.Item.Cells(3).Controls(0)

         ' Get the check box that indicates whether to include tax from the 
         ' TemplateColumn. Notice that in this case, the check box control is
         ' second control in the Controls collection.
         Dim taxCheck As CheckBox = e.Item.Cells(2).Controls(1)

         Dim item As String = e.Item.Cells(1).Text
         Dim price As String = priceText.Text
       
         Dim dr As DataRow

         ' With a database, use an update command.  Since the data source is 
         ' an in-memory DataTable, delete the old row and replace it with a new one.

         ' Remove old entry.
         StoreView.RowFilter = "Item='" & item & "'"
         If StoreView.Count > 0 Then
            StoreView.Delete(0)
         End If
         StoreView.RowFilter = ""
 
         ' Add new entry.
         dr = Store.NewRow()

         If taxCheck.Checked Then
            dr(0) = "8.6%"
         Else 
            dr(0) = "0.0%"
         End If
         dr(1) = item
         dr(2) = price
         Store.Rows.Add(dr)

         MyDataGrid.EditItemIndex = -1
         BindGrid()

      End Sub

      Sub BindGrid() 
      
         MyDataGrid.DataSource = StoreView
         MyDataGrid.DataBind()
      
      End Sub

   </script>

<head runat="server">
    <title>TemplateColumn Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>TemplateColumn Example</h3>

      <asp:DataGrid id="MyDataGrid" runat="server"
           BorderColor="black"
           CellPadding="2"        
           OnEditCommand="MyDataGrid_Edit"
           OnCancelCommand="MyDataGrid_Cancel"
           OnUpdateCommand="MyDataGrid_Update"
           ShowFooter="True"
           AutoGenerateColumns="false">

         <Columns>

            <asp:EditCommandColumn
                 EditText="Edit"
                 CancelText="Cancel"
                 UpdateText="Update"
                 ItemStyle-Wrap="false"
                 HeaderText="Edit Controls"/>

            <asp:BoundColumn HeaderText="Description" 
                 ReadOnly="true" 
                 DataField="Item"/>

            <asp:TemplateColumn>

               <HeaderTemplate>
                  <b> Tax </b>
               </HeaderTemplate>

               <ItemTemplate>
                  <asp:Label
                       Text='<%# DataBinder.Eval(Container.DataItem, "Tax") %>'
                       runat="server"/>
               </ItemTemplate>

               <EditItemTemplate>

                  <asp:CheckBox
                       Text="Taxable" 
                       runat="server"/>

               </EditItemTemplate>

               <FooterTemplate>
                  <asp:HyperLink id="HyperLink1"
                       Text="Microsoft"
                       NavigateUrl="http://www.microsoft.com"
                       runat="server"/>
               </FooterTemplate>

            </asp:TemplateColumn>

            <asp:BoundColumn HeaderText="Price" 
                 DataField="Price"/>

         </Columns>

      </asp:DataGrid>

   </form>

</body>
</html>

<!--</Snippet1>-->