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

         ' Load sample data only once when, the page is first loaded.
         If Not IsPostBack Then 
     
            ItemsList.DataSource = CreateDataSource()
            ItemsList.DataBind()
         
         End If

      End Sub

      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the background color for the separator section of
         ' the DataList control.
         ItemsList.SeparatorStyle.BackColor = _
             System.Drawing.Color.FromName(ItemList.SelectedItem.Value)

      End Sub
 
   </script>
 
<head runat="server">
    <title>DataList SeparatorTemplate and SeparatorStyle Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList SeparatorTemplate and SeparatorStyle Example</h3>

      Select a background color for the separator between 
      items in the DataList.

      <br /><br />
 
      <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="5"
           CellSpacing="5"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           ShowFooter="True"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <ItemStyle BackColor="Silver">
         </ItemStyle>

         <AlternatingItemStyle BackColor="DarkGray">
         </AlternatingItemStyle>

         <SeparatorStyle BackColor="White">
         </SeparatorStyle>

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

         <SeparatorTemplate>

            <asp:Image id="SeparatorImage"
                 GenerateEmptyAlternateText='true' 
                 ImageUrl="SeparatorImage.jpg"
                 runat="server"/>

         </SeparatorTemplate>
 
      </asp:DataList>

      <hr />

      <table cellpadding="5">

         <tr>

            <td>

               Separator BackColor:
 
            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="ItemList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
                  <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                  <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                  <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                  <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

               </asp:DropDownList>
 
            </td>

         </tr>

      </table>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
