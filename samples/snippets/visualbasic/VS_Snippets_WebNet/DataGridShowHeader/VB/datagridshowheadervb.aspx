<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Function CreateDataSource() As ICollection 
      
         ' Create a Random object to mix up the order of items in the 
         ' sample data.
         Dim Rand_Num As Random = New Random()

         ' Create sample data for the DataGrid control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(new DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(new DataColumn("CurrencyValue", GetType(Double)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 8 
        
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & Rand_Num.Next(1, 15).ToString()
            dr(2) = 1.23 * Rand_Num.Next(1, 15)
 
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

      Sub Check_Change(sender As Object, e As EventArgs)
   
         ' Show or hide the header depending on the user's selection.
         If ShowHeaderCheckBox.Checked Then

            ItemsGrid.ShowHeader = True

         Else

            ItemsGrid.ShowHeader = False

         End If

         ' Show or hide the footer depending on the user's selection.
         If ShowFooterCheckBox.Checked Then

            ItemsGrid.ShowFooter = True

         Else

            ItemsGrid.ShowFooter = False

         End If

      End Sub

   </script>
 
<head runat="server">
    <title>DataGrid ShowHeader and ShowFooter Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid ShowHeader and ShowFooter Example</h3>

      Select whether to show or hide the header and footer sections
      in the DataGrid control.

      <br /><br />
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowHeader="True"
           ShowFooter="True"
           AutoGenerateColumns="False"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue" 
                 SortExpression="IntegerValue"
                 HeaderText="Item"/>

            <asp:BoundColumn DataField="StringValue"
                 SortExpression="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 SortExpression="CurrencyValue"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>

         </Columns> 
 
      </asp:DataGrid>

      <hr />

      <asp:CheckBox id="ShowHeaderCheckBox"
           Text="Show header"
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>

      &nbsp;&nbsp

      <asp:CheckBox id="ShowFooterCheckBox"
           Text="Show footer"
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->