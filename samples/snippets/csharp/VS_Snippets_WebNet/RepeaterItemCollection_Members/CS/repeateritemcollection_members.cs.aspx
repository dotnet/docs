<%--
   The following program demonstrates members of the RepeaterItemCollection class.

   It displays three buttons, Item, CopyTo and GetEnumerator. Each button allows you
   to display the items in the collection in a different way.
--%>
<!-- <Snippet2> -->
<!-- 
To see this snippet in the context of a complete example,
see the RepeaterItemCollection class topic.
-->
<!-- </Snippet2> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

// <Snippet1>
      void Page_Load(Object Sender, EventArgs e)
      {
if (!IsPostBack)
{
   ArrayList myDataSource = new ArrayList();

   myDataSource.Add(new PositionData("Item 1", "$6.00"));
   myDataSource.Add(new PositionData("Item 2", "$7.48"));
   myDataSource.Add(new PositionData("Item 3", "$9.96"));
   
   // Initialize the RepeaterItemCollection using the ArrayList as the data source.
   RepeaterItemCollection myCollection = new RepeaterItemCollection(myDataSource);
   myRepeater.DataSource = myCollection;
   myRepeater.DataBind();
}
      }
// </Snippet1>

// <Snippet3>
      void Item_Clicked(Object Sender, EventArgs e)
      {
labelDisplay.Text = "Using item indexer.<br />";
labelDisplay.Text += "The Items collection contains: <br />";

// Display the elements of the RepeaterItemCollection using the indexer.
RepeaterItemCollection  myItemCollection = myRepeater.Items;
for(int index=0;index < myItemCollection.Count;index++)
labelDisplay.Text += ((DataBoundLiteralControl)
   myItemCollection[index].Controls[0]).Text + "<br />";
      }
// </Snippet3>      

// <Snippet4>
      void CopyTo_Clicked(Object Sender, EventArgs e)
      {
labelDisplay.Text = "Invoking CopyTo method.<br />";
labelDisplay.Text += "The Items collection contains: <br />";

// Display the elements of the RepeaterItemCollection using the CopyTo method.
RepeaterItemCollection  myItemCollection = myRepeater.Items;
RepeaterItem[] myItemArray = new RepeaterItem[myItemCollection.Count];
myItemCollection.CopyTo(myItemArray,0);
for(int index=0;index < myItemArray.Length;index++)
{
   RepeaterItem myItem = (RepeaterItem)myItemArray.GetValue(index);
   labelDisplay.Text += ((DataBoundLiteralControl)
      myItem.Controls[0]).Text + "<br />";
}
      }
// </Snippet4>

// <Snippet5>
      void GetEnumerator_Clicked(Object Sender, EventArgs e)
      {
labelDisplay.Text = "Invoking GetEnumerator method.<br />";
labelDisplay.Text += "The Items collection contains: <br />";

// Display the elements of the RepeaterItemCollection using GetEnumerator.
RepeaterItemCollection  myItemCollection = myRepeater.Items;
IEnumerator myEnumertor = myItemCollection.GetEnumerator();
while(myEnumertor.MoveNext())
{
   RepeaterItem myItem = (RepeaterItem)myEnumertor.Current;
   labelDisplay.Text += ((DataBoundLiteralControl)
      myItem.Controls[0]).Text + "<br />";
}
      }
// </Snippet5>

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
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
            Repeater Example
         </title>
</head>
   <body>
      <form runat="server" id="Form1">
         <h3>
            Repeater Example
         </h3>
         <br />
            <asp:Repeater id="myRepeater" runat="server">
               <HeaderTemplate>
                  <table border="1">
                     <tr>
                        <td>
                           <b>Item</b>
                        </td>
                        <td>
                           <b>Price</b>
                        </td>
                     </tr>
               </HeaderTemplate>
               <ItemTemplate>
                  <tr>
                     <td>
                        <%# DataBinder.Eval(Container.DataItem, "Item") %>
                     </td>
                     <td>
                        <%# DataBinder.Eval(Container.DataItem, "Price") %>
                     </td>
                  </tr>
               </ItemTemplate>
               <FooterTemplate>
                  </table>
               </FooterTemplate>
            </asp:Repeater>
         <br />
            <br />
            <asp:Label runat="server">Select one of the options for display :</asp:Label>
            <br />
            <asp:Button id="buttonIndex" Text="Index" 
               OnClick="Item_Clicked" runat="server" />
            <asp:Button id="buttonCopyTo" Text="CopyTo" 
               OnClick="CopyTo_Clicked" runat="server" />
            <asp:Button id="buttonEnumerate" Text="IEnumerator" 
               OnClick="GetEnumerator_Clicked" runat="server" />
            <br />
            <asp:Label id="labelDisplay" runat="server" />
      </form>
   </body>
</html>
