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
         dt.Columns.Add(New DataColumn("StringValue", GetType(string)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(double)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 to 4 
        
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)

         Next i
 
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then 
  
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()

         End If

      End Sub

      Sub Button_Click(sender As Object, e As EventArgs) 

         ' Count the number of selected items in the DataGrid control.
         Dim count As Integer = 0

         ' Display the selected times.
         Message.Text = "You Selected: <br />"

         ' Iterate through each item (row) in the DataGrid control and
         ' determine whether it is selected.
         Dim item As DataGridItem
 
         For Each item In ItemsGrid.Items

            DetermineSelection(item, count)        

         Next

         ' If no items are selected, display the appropriate message.
         If count = 0 Then

            Message.Text = "No items selected"

         End If

      End Sub

      Sub DetermineSelection(item As DataGridItem, ByRef count As Integer)

         ' Retrieve the SelectCheckBox CheckBox control from the 
         ' specified item (row) in the DataGrid control.
         Dim selection As CheckBox = _
             CType(item.FindControl("SelectCheckBox"), CheckBox)

         ' If the item is selected, display the appropriate message and
         ' increment the count of selected items.
         If Not selection Is Nothing Then

           If selection.Checked Then
           
              Message.Text &= "- " & item.Cells(1).Text & "<br />"
              count = count + 1
           
           End If

         End If    

      End Sub

      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the background color for the header and footer sections
         ' of the first column in the DataGrid control.
         ItemsGrid.Columns(0).HeaderStyle.BackColor = _
             System.Drawing.Color.FromName(List.SelectedItem.Value)
         ItemsGrid.Columns(0).FooterStyle.BackColor = _
             System.Drawing.Color.FromName(List.SelectedItem.Value)

      End Sub

   </script>
 
<head runat="server">
    <title>DataGridColumn HeaderStyle and FooterStyle Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGridColumn HeaderStyle and FooterStyle Example</h3>

      Select a background color for the header and 
      footer sections of the first column.

      <br /><br />
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="True"
           AutoGenerateColumns="False"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue" 
                 HeaderText="Item">

               <HeaderStyle BackColor="White">
               </HeaderStyle>

               <FooterStyle BackColor="White">
               </FooterStyle>

            </asp:BoundColumn>

            <asp:BoundColumn DataField="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>

            <asp:TemplateColumn HeaderText="Select Item">

               <ItemTemplate>

                  <asp:CheckBox id="SelectCheckBox"
                       Text="Add to Cart"
                       Checked="False"
                       runat="server"/>

               </ItemTemplate>

            </asp:TemplateColumn>
 
         </Columns> 
 
      </asp:DataGrid>

      <br /><br />

      <asp:Button id="SubmitButton"
           Text="Submit"
           OnClick = "Button_Click"
           runat="server"/>

      <br /><br />

      <asp:Label id="Message"
           runat="server"/>

      <hr />

      Header and footer BackColor: <br /> 

      <asp:DropDownList id="List"
           AutoPostBack="True"
           OnSelectedIndexChanged="Selection_Change"
           runat="server">

         <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
         <asp:ListItem Value="Silver"> Silver </asp:ListItem>
         <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
         <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
         <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

      </asp:DropDownList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->