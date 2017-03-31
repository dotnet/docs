<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">

        Sub Page_Load(Sender As Object, e As EventArgs)
            
            If Not IsPostBack Then
                Dim values As New ArrayList()
                
                values.Add("Apple")
                values.Add("Orange")
                values.Add("Pear")
                values.Add("Banana")
                values.Add("Grape")
                
                Repeater1.DataSource = values
                Repeater1.DataBind()
            End If
        End Sub

    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Repeater Example</title>
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
 
          <AlternatingItemTemplate>
             <tr>
                <td><b> <%# Container.DataItem %> </b> </td>
             </tr>
          </AlternatingItemTemplate>
 
          <ItemTemplate>
             <tr>
                <td> <%# Container.DataItem %> </td>
             </tr>
          </ItemTemplate>
 
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
       <br />
         
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
