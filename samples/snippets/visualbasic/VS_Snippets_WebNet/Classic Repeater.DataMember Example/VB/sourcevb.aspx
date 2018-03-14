<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace = "System.Data" %> 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Repeater Example</title>
<script language="VB" runat="server">

    Sub Page_Load(Sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            
            Dim dt1 As New DataTable("Dt1")
            
            Dim dr As DataRow
            
            dt1.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
            dt1.Columns.Add(New DataColumn("StringValue", GetType(String)))
            dt1.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
            
            Dim ds As New DataSet("ds1")
            
            ds.Tables.Add(dt1)
            
            Dim i As Integer
            For i = 0 To 8
                dr = dt1.NewRow()
                
                dr(0) = i
                dr(1) = "Item " + i.ToString()
                dr(2) = 1.23 *(i + 1)
                
                dt1.Rows.Add(dr)
            Next i
            
            Dim dt2 As New DataTable("Dt2")
            
            dt2.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
            dt2.Columns.Add(New DataColumn("StringValue", GetType(String)))
            dt2.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
            
            ds.Tables.Add(dt2)
            
            For i = 0 To 8
                dr = dt2.NewRow()
                
                dr(0) = i
                dr(1) = "Item " + i.ToString()
                dr(2) = 4.56 *(i + 1)
                
                dt2.Rows.Add(dr)
            Next i
            
            Repeater1.DataSource = ds
            Repeater1.DataMember = "Dt1"
            Repeater1.DataBind()
        End If 
    End Sub
 
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
