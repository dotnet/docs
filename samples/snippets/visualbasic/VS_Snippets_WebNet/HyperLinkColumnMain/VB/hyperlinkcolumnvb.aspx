<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title>HyperLinkColumn Example</title>
<script runat="server">

      Function CreateDataSource() As ICollection 
      
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
         Dim i As Integer

         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("PriceValue", GetType(Double)))
       
         For i = 0 to 2 
         
            dr = dt.NewRow()

            dr(0) = i
            dr(1) = CDbl(i) * 1.23

            dt.Rows.Add(dr)

         Next i

         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function

      Sub Page_Load(sender As Object, e As EventArgs) 
    
         MyDataGrid.DataSource = CreateDataSource()
         MyDataGrid.DataBind()

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>HyperLinkColumn Example</h3>

      <asp:DataGrid id="MyDataGrid" 
           BorderColor="black"
           BorderWidth="1"
           GridLines="Both"
           AutoGenerateColumns="false"
           runat="server">

         <HeaderStyle BackColor="#aaaadd"/>

         <Columns>

            <asp:HyperLinkColumn
                 HeaderText="Select an Item"
                 DataNavigateUrlField="IntegerValue"
                 DataNavigateUrlFormatString="detailspage.aspx?id={0}"
                 DataTextField="PriceValue"
                 DataTextFormatString="{0:c}"
                 Target="_blank"/>
           
         </Columns>

      </asp:DataGrid>

   </form>

</body>
</html>
<!--</Snippet1>-->
