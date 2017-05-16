<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>OnItemDataBound Example</title>
<script language="C#" runat="server">
       void Page_Load(Object Sender, EventArgs e) {
 
          if (!IsPostBack) {
             ArrayList values = new ArrayList();
 
             values.Add(new Evaluation("Razor Wiper Blades", "Good"));
             values.Add(new Evaluation("Shoe-So-Soft Softening Polish", "Poor"));
             values.Add(new Evaluation("DynaSmile Dental Fixative", "Fair"));
 
             Repeater1.DataSource = values;
             Repeater1.DataBind();
          }
       }
 
       void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
                              
          // This event is raised for the header, the footer, separators, and items.

          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                 
             if (((Evaluation)e.Item.DataItem).Rating == "Good") {
                ((Label)e.Item.FindControl("RatingLabel")).Text= "<b>***Good***</b>";
             }
          }
       }    
 
       public class Evaluation {
         
          private string productid;
          private string rating;
 
          public Evaluation(string productid, string rating) {
             this.productid = productid;
             this.rating = rating;
          }
 
          public string ProductID {
             get {
                return productid;
             }
          }
 
          public string Rating {
             get {
                return rating;
             }
          }
       }
 
    </script>
 
 </head>
 <body>
 
    <h3>OnItemDataBound Example</h3>
 
    <form id="form1" runat="server">
 
       <br />
       <asp:Repeater id="Repeater1" OnItemDataBound="R1_ItemDataBound" runat="server">
          <HeaderTemplate>
             <table border="1">
                <tr>
                   <td><b>Product</b></td>
                   <td><b>Consumer Rating</b></td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>' Runat="server"/> </td>
                <td> <asp:Label id="RatingLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Rating") %>' Runat="server"/> </td>
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
