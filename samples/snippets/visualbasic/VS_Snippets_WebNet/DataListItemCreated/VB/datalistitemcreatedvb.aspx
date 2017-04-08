<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Function CreateDataSource() As ICollection 
      
         ' Create sample data for the DataList control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 8 

            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Description for item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)

         Next i
 
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
 
      Sub Page_Load(sender As Object, e As EventArgs) 

         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then
         
            ItemsList.DataSource = CreateDataSource()
            ItemsList.DataBind()
         
         End If

      End Sub

      Sub Item_Created(sender As Object, e As DataListItemEventArgs)

         If e.Item.ItemType = ListItemType.Item Or _
             e.Item.ItemType = ListItemType.AlternatingItem Then


            ' Retrieve the Label control in the current DataListItem.
            Dim PriceLabel As Label = _
                CType(e.Item.FindControl("PriceLabel"), Label)

            ' Retrieve the text of the CurrencyColumn from the DataListItem
            ' and convert the value to a Double.
            Dim Price As Double = Convert.ToDouble( _
                (CType(e.Item.DataItem, DataRowView)).Row.ItemArray(2).ToString())

            ' Format the value as currency and redisplay it in the DataList.
            PriceLabel.Text = Price.ToString("c")

         End If

      End Sub
 
   </script>
 
<head runat="server">
    <title>DataList ItemCreated Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList ItemCreated Example</h3>
 
      <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="5"
           CellSpacing="5"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           OnItemCreated="Item_Created"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>

            List of items

         </HeaderTemplate>
               
         <ItemTemplate>

            Description: <br />
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

            <br />

            Price: 
            <asp:Label id="PriceLabel"
                 runat="server"/>

         </ItemTemplate>
 
      </asp:DataList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
