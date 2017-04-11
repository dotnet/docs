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
         dt.Columns.Add(new DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(new DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(new DataColumn("CurrencyValue", GetType(Double)))
         dt.Columns.Add(new DataColumn("BooleanValue", GetType(Boolean)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 4 
        
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
            dr(3) = False
 
            dt.Rows.Add(dr)
         
         Next i

         ' To persist the data source between posts to the server,
         ' store it in session state.  
         Session("Source") = dt
 
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then 
         
            ' Make sure to set the header text before binding the data to 
            ' the DataGrid control; otherwise, the change will not appear 
            ' until the next time the page is refreshed.
            ItemsGrid.Columns(0).HeaderText = "Item"

            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
        
         End If

      End Sub

      Sub Button_Click(sender As Object, e As EventArgs) 

         Dim subtotal As Double = 0.0

         ' Update the data source with the user's selection and 
         ' calculate the subtotal.
         Dim dt As DataTable = UpdateSource(subtotal)

         ' Display the subtotal in the footer section of the third column.
         ItemsGrid.Columns(2).FooterText = _
             "Subtotal: " & subtotal.ToString("c")

         ' Create a DataView and bind it to the DataGrid control.
         Dim dv As DataView = New DataView(dt)
         ItemsGrid.DataSource = dv
         ItemsGrid.DataBind()

      End Sub

      ' This version of UpdateSource updates the data source and
      ' calculates the subtotal.
      Function UpdateSource(ByRef subtotal As Double) As DataTable 

         ' Retrieve the data table from session state.
         Dim dt As DataTable = CType(Session("Source"), DataTable)
         Dim item As DataGridItem 

         ' Iterate through the Items collection and update the data source
         ' with the user's  selections. If an item is selected, add the
         ' amount of the item to the subtotal.
         For Each item in ItemsGrid.Items

            ' Retrieve the SelectCheckBox CheckBox control from the
            ' specified item (row) in the DataGrid control.
            Dim selection As CheckBox = _
                CType(item.FindControl("SelectCheckBox"), CheckBox)

            If Not selection Is Nothing

               ' Update the BooleanValue field with the value of 
               ' the check box.
               dt.Rows(item.ItemIndex)(3) = selection.Checked

               ' Add the value of the item to the subtotal if the item
               ' is selected.
               If selection.Checked Then
           
                  subtotal += _
                      Convert.ToDouble(item.Cells(2).Text.Substring(1))

               End If

            End If

         Next

         ' Save the data source.
         Session("Source") = dt

         Return dt

      End Function

      ' This version of UpdateSource updates the data source only.
      Function UpdateSource() As DataTable 

         ' Retrieve the data table from session state.
         Dim dt As DataTable = CType(Session("Source"), DataTable)
         Dim item As DataGridItem 

         ' Iterate through the Items collection and update the data source
         ' with the user's  selections. If an item is selected, add the
         ' amount of the item to the subtotal.
         For Each item in ItemsGrid.Items

            ' Retrieve the SelectCheckBox CheckBox control from the
            ' specified item (row) in the DataGrid control.
            Dim selection As CheckBox = _
                CType(item.FindControl("SelectCheckBox"), CheckBox)

            If Not selection Is Nothing

               ' Update the BooleanValue field with the value of 
               ' the check box.
               dt.Rows(item.ItemIndex)(3) = selection.Checked

            End If

         Next

         ' Save the data source.
         Session("Source") = dt

         Return dt

      End Function

      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the image for the header section of the first column in
         ' the DataGrid control.
         ItemsGrid.BackImageUrl = List.SelectedItem.Value

         ' Create a DataView and bind it to the DataGrid control. This
         ' will refresh the DataGrid control with the updated header image.
         Dim dv As DataView = New DataView(UpdateSource())
         ItemsGrid.DataSource = dv
         ItemsGrid.DataBind()

      End Sub

   </script>
 
<head runat="server">
    <title>DataGrid BackImageUrl Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid BackImageUrl Example</h3>

      Select a background image for the DataGrid control.

      <br /><br />
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="True"
           AutoGenerateColumns="False"
           BackImageUrl="image1.jpg"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue"/>

            <asp:BoundColumn DataField="StringValue"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>

            <asp:TemplateColumn>

               <ItemTemplate>

                  <asp:CheckBox id="SelectCheckBox"
                       Text="Add to Cart"
                       Checked='<%# DataBinder.Eval(Container.DataItem, "BooleanValue") %>'
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
       
      <hr />

      Background image: <br /> 

      <asp:DropDownList id="List"
           AutoPostBack="True"
           OnSelectedIndexChanged="Selection_Change"
           runat="server">

         <asp:ListItem Selected="True" Value="image1.jpg"> Image 1 </asp:ListItem>
         <asp:ListItem Value="image2.jpg"> Image 2 </asp:ListItem>
         <asp:ListItem Value="image3.jpg"> Image 3 </asp:ListItem>
         <asp:ListItem Value="image4.jpg"> Image 4 </asp:ListItem>

      </asp:DropDownList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->