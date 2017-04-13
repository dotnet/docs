<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title>HyperLinkColumn Example</title>
<script runat="server">

      ICollection CreateDataSource() 
      {
         DataTable dt = new DataTable();
         DataRow dr;

         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("PriceValue", typeof(Double)));
       
         for (int i = 0; i < 3; i++) 
         {
            dr = dt.NewRow();

            dr[0] = i;
            dr[1] = (Double)i * 1.23;

            dt.Rows.Add(dr);
         }

         DataView dv = new DataView(dt);
         return dv;
      }

      void Page_Load(Object sender, EventArgs e) 
      {
         MyDataGrid.DataSource = CreateDataSource();
         MyDataGrid.DataBind();
      }

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
