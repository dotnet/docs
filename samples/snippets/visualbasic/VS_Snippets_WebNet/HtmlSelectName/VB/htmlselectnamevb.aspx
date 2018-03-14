<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Page_Load(sender as Object, e As EventArgs)

         ' Bind a data source to the Repeater control. 
         Repeater1.DataSource = CreateRepeaterSource()
         Repeater1.DataBind()

      End Sub

      Sub Item_Bound(sender As Object, e As RepeaterItemEventArgs)

         ' Each item in the Repeater control contains an HtmlSelect 
         ' control. This method binds a data source to the HtmlSelect
         ' control as each item in the Repeater control is being
         ' bound to data.
 
         ' The ItemDataBound event is raised when data is bound to an
         ' item in the Repeater control. Items can include the Header,
         ' Footer, and so on. Use the following logic only if the item 
         ' being bound is an Item or AlternatingItem.
         If (e.Item.ItemType = ListItemType.Item) Or _
            (e.Item.ItemType = ListItemType.AlternatingItem) Then

            ' Bind a data source to the HtmlSelect control.
            Dim selectControl As HtmlSelect = _
                CType(e.Item.FindControl("Select1"), HtmlSelect)
            selectControl.DataSource = CreateHtmlSelectSource()
            selectControl.DataBind()

            ' The runtime automatically generates a unique identifier 
            ' for each control embedded in a list control, such as the 
            ' Repeater. The Name property of the HtmlSelect control 
            ' contains this unique identifier and is commonly used 
            ' to identify a specific control.

            ' Select the last item in the HtmlSelect control if the Name 
            ' property contains the value "Repeater1:_ctl3:Select1".
            If selectControl.Name = "Repeater1:_ctl3:Select1" Then 

               selectControl.SelectedIndex = selectControl.Items.Count - 1

            End If

         End If

      End Sub

      Function CreateHtmlSelectSource() As DataView 

         ' Create a DataTable that contains sample data for the 
         ' HtmlSelect controls.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         dt.Columns.Add(New DataColumn("Text", GetType(String)))
         dt.Columns.Add(New DataColumn("Value", GetType(String)))
 
         ' Populate the DataTable with sample values.
         Dim i As Integer
         
         For i = 0 To 4 
     
            dr = dt.NewRow()
 
            dr(0) = "Item " & i.ToString()
            dr(1) = i.ToString()
 
            dt.Rows.Add(dr)
         
         Next i
 
         ' Create a DataView from the DataTable.
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function

      Function CreateRepeaterSource() As DataView 

         ' Create a DataTable that contains sample data for the 
         ' Repeater control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         dt.Columns.Add(new DataColumn("Category", GetType(String)))
 
         ' Populate the DataTable with sample values.
         Dim i As Integer

         For i = 0 To 4  

            dr = dt.NewRow()
 
            dr(0) = "Category " & i.ToString()

            dt.Rows.Add(dr)

         Next i
 
         ' Create a DataView from the DataTable.
         Dim dv As DataView = new DataView(dt)
         return dv

      End Function
  
   </script>
  
<head runat="server">
    <title> HtmlSelect Name Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlSelect Name Example </h3>

      Notice that Category 3 has a different item selected by default. <br /> 
  
      <asp:Repeater id="Repeater1"
           OnItemDataBound="Item_Bound"
           runat="server">

         <ItemTemplate>

            <h4><%# DataBinder.Eval(Container.DataItem, "Category") %></h4>

            Select Item:

            <br />

            <select id="Select1"
                    datatextfield="Text"
                    datavaluefield="Value"
                    runat="server"/> 

            <br /><br />

            <hr />

         </ItemTemplate>

      </asp:Repeater>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
