<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace = "System.Data" %> 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Repeater Example</title>
<script language="C#" runat="server">
       void Page_Load(Object Sender, EventArgs e) {
 
          if (!IsPostBack) {
 
             DataTable dt1 = new DataTable("Dt1");
 
             DataRow dr;
  
             dt1.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
             dt1.Columns.Add(new DataColumn("StringValue", typeof(string)));
             dt1.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
          
             DataSet ds= new DataSet("ds1");            
 
             ds.Tables.Add(dt1);
 
             for (int i = 0; i < 9; i++) {
                dr = dt1.NewRow();
 
                dr[0] = i;
                dr[1] = "Item " + i.ToString();
                dr[2] = 1.23 * (i+1);
   
                dt1.Rows.Add(dr);
             }
 
             DataTable dt2 = new DataTable("Dt2");
  
             dt2.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
             dt2.Columns.Add(new DataColumn("StringValue", typeof(string)));
             dt2.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));           
 
             ds.Tables.Add(dt2);
 
             for (int i = 0; i < 9; i++) {
                dr = dt2.NewRow();
 
                dr[0] = i;
                dr[1] = "Item " + i.ToString();
                dr[2] = 4.56 * (i+1);
   
                dt2.Rows.Add(dr);
             }
 
             Repeater1.DataSource = ds;
             Repeater1.DataMember = "Dt1";
             Repeater1.DataBind();
 
          }
       }
 
    </script>
 
 </head>
 <body>
 
    <h3>Repeater Example</h3>
 
    <form id="form1" runat="server">
 
       <b>Repeater1:</b>
       <br />
         
       <asp:Repeater id="Repeater1" runat="server">
             
          <HeaderTemplate>
             <table border="1">
          </HeaderTemplate>
 
          <ItemTemplate>
             <tr>
                <td> 
                   <%# DataBinder.Eval(Container.DataItem, "StringValue") %> 
                </td>
                <td> 
                   <%# DataBinder.Eval(Container.DataItem, "CurrencyValue") %> 
                </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
         
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
