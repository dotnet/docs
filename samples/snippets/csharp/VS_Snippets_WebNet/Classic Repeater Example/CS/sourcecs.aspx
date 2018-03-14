<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Repeater Example</title>
<script language="C#" runat="server">
       void Page_Load(Object Sender, EventArgs e) {
          if (!IsPostBack) {
             ArrayList values = new ArrayList();
 
             values.Add(new PositionData("Microsoft", "Msft"));
             values.Add(new PositionData("Intel", "Intc"));
             values.Add(new PositionData("Dell", "Dell"));
 
             Repeater1.DataSource = values;
             Repeater1.DataBind();
                 
             Repeater2.DataSource = values;
             Repeater2.DataBind();
          }
       }
 
       public class PositionData {
         
          private string name;
          private string ticker;
 
          public PositionData(string name, string ticker) {
             this.name = name;
             this.ticker = ticker;
          }
 
          public string Name {
             get {
                return name;
             }
          }
 
          public string Ticker {
             get {
                return ticker;
             }
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
                <tr>
                   <td><b>Company</b></td>
                   <td><b>Symbol</b></td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "Name") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Ticker") %> </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
       <br />
         
       <b>Repeater2:</b>
       <br />
       <asp:Repeater id="Repeater2" runat="server">
         
          <HeaderTemplate>
             Company data:
          </HeaderTemplate>
             
          <ItemTemplate>
             <%# DataBinder.Eval(Container.DataItem, "Name") %> (<%# DataBinder.Eval(Container.DataItem, "Ticker") %>)
          </ItemTemplate>
             
          <SeparatorTemplate>, </SeparatorTemplate>
       </asp:Repeater>
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
