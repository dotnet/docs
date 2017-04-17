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
         dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
         dt.Columns.Add(New DataColumn("ImageValue", GetType(String)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 8 

            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Description for item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
            dr(3) = "Image" & i.ToString() & ".jpg"
 
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
 
      Sub Button_Click(sender As Object, e As EventArgs) 
 
         ' Set the repeat direction based on the selected value of the
         ' DirectionList DropDownList control.
         ItemsList.RepeatDirection = _
             CType(DirectionList.SelectedIndex, RepeatDirection)

         ' Set the repeat layout based on the selected value of the
         ' LayoutList DropDownList control.
         ItemsList.RepeatLayout = CType(LayoutList.SelectedIndex, RepeatLayout)

         ' Set the number of columns to display based on the selected
         ' value of the ColumnsList DropDownList control.
         ItemsList.RepeatColumns = ColumnsList.SelectedIndex

         ' Show or hide the gridlines based on the value of the
         ' ShowBorderCheckBox. Note that gridlines are displayed
         ' only if the RepeatLayout property is set to Table.
         If ShowBorderCheckBox.Checked _
             And ItemsList.RepeatLayout = RepeatLayout.Table Then 

            ItemsList.BorderWidth = Unit.Pixel(1)
            ItemsList.GridLines = GridLines.Both
         
         Else  
    
            ItemsList.BorderWidth = Unit.Pixel(0)
            ItemsList.GridLines = GridLines.None
         
         End If
    
      End Sub    
 
   </script>
 
<head runat="server">
    <title>DataList Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList Example</h3>
 
      <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="5"
           CellSpacing="5"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="0"
           BorderWidth="0"
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

            Price: <%# DataBinder.Eval(Container.DataItem, "CurrencyValue", "{0:c}") %>

            <br />

            <asp:Image id="ProductImage"
                 AlternatingText='<%# DataBinder.Eval(Container.DataItem, "StringValue") %>'
                 ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageValue") %>'
                 runat="server"/>

         </ItemTemplate>
 
      </asp:DataList>
 
      <hr />

      <table cellpadding="5">

         <tr>

            <th>

               Repeat direction:

            </th>

            <th>

               Repeat layout:

            </th>

            <th>

               Repeat columns:

            </th>

            <th>

               <asp:CheckBox id="ShowBorderCheckBox"
                    Text="Show border"
                    Checked="False" 
                    runat="server" />

            </th>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="DirectionList" 
                    runat="server">

                  <asp:ListItem>Horizontal</asp:ListItem>
                  <asp:ListItem Selected="True">Vertical</asp:ListItem>

               </asp:DropDownList>

            </td>

            <td>

               <asp:DropDownList id="LayoutList" 
                    runat="server">

                  <asp:ListItem Selected="True">Table</asp:ListItem>
                  <asp:ListItem>Flow</asp:ListItem>

               </asp:DropDownList>

            </td>

            <td>

               <asp:DropDownList id="ColumnsList" 
                    runat="server">

                  <asp:ListItem Selected="True">0</asp:ListItem>
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem>2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>
                  <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5</asp:ListItem>

               </asp:DropDownList>

            </td>

            <td>

               &nbsp;

            </td>


         </tr>

      </table>     
         
      <asp:LinkButton id="RefreshButton" 
           Text="Refresh DataList" 
           OnClick="Button_Click" 
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
