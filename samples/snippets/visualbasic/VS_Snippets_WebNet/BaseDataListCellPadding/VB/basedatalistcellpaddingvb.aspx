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

         For i = 0 to 8 
        
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
 
         ' Load sample data only once when the page is first loaded.
         If Not IsPostBack Then 
  
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()

         End If

      End Sub

      Sub Index_Change(sender As Object, e As EventArgs) 

         ItemsGrid.CellPadding = CellPaddingList.SelectedIndex
         ItemsGrid.CellSpacing = CellSpacingList.SelectedIndex

      End Sub
 
   </script>
 
<head runat="server">
    <title>BaseDataList CellPadding and CellSpacing Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>BaseDataList CellPadding and CellSpacing Example</h3>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 
 
      </asp:DataGrid>

      <br />

      <h4>Select different values for the cell padding and cell spacing:</h4>
      <table cellpadding="5">

         <tr>

            <td>

               Cell padding:

            </td>

            <td>

               Cell spacing:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="CellPaddingList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Index_Change"
                    runat="server">

                  <asp:ListItem>0</asp:ListItem>
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem>2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>
                  <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5</asp:ListItem>

               </asp:DropDownList>

            </td>

            <td>

               <asp:DropDownList id="CellSpacingList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Index_Change"
                    runat="server">

                  <asp:ListItem>0</asp:ListItem>
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem>2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>
                  <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5</asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>

      </table>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
