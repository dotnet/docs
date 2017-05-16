<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Repeater Example</title>
<script language="C#" runat="server">

      void Page_Load(Object Sender, EventArgs e) 
      {
 
         if (!IsPostBack) 
         {
            ArrayList values = new ArrayList();
 
            values.Add(new PositionData("Item 1", "$6.00"));
            values.Add(new PositionData("Item 2", "$7.48"));
            values.Add(new PositionData("Item 3", "$9.96"));
 
            Repeater1.DataSource = values;
            Repeater1.DataBind();
         }

      }
      void Button_Click(Object Sender, EventArgs e) 
      {        
         Label1.Text = "The Items collection contains: <br />";

         foreach(RepeaterItem item in Repeater1.Items)
         {        
            Label1.Text += item.ItemType + " - " +
                           ((DataBoundLiteralControl)item.Controls[0]).Text +
                           "<br />";
         }
      }    
 
      public class PositionData 
      {
        
         private string item;
         private string price;
 
         public PositionData(string item, string price) 
         {
            this.item = item;
            this.price = price;
         }
 
         public string Item 
         {
            get 
            {
               return item;
            }
         }
 
         public string Price 
         {
            get 
            {
               return price;
            }
         }
      }
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>Repeater Example</h3>
         
      <br />
         
      <asp:Repeater id="Repeater1" 
                    runat="server">
         <HeaderTemplate>
            <table border="1">
               <tr>
                  <td><b>Item</b></td>
                  <td><b>Price</b></td>
               </tr>
         </HeaderTemplate>
             
         <ItemTemplate>
            <tr>
               <td> <%# DataBinder.Eval(Container.DataItem, "Item") %> </td>
               <td> <%# DataBinder.Eval(Container.DataItem, "Price") %> </td>
            </tr>
         </ItemTemplate>
            
         <FooterTemplate>
            </table>
         </FooterTemplate>
             
      </asp:Repeater>
      <br />

      <asp:Button id="Button1"
           Text="Display Items in Repeater"
           OnClick="Button_Click"
           runat="server"/>

      <br /><br />
         
      <asp:Label id="Label1"                 
                 runat="server"/>
   </form>
</body>
</html>
   
<!--</Snippet1>-->
