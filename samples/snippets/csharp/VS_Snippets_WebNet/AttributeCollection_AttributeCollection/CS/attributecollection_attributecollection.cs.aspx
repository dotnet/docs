<%@ Page language="c#" Debug = "true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="c#" runat="server">
   // System.Web.UI.AttributeCollection.AttributeCollection(StateBag)
 /*
The following example demonstrates the Constructor 'AttributeCollection(StateBag)' of the 
'Web.UI.AttributeCollection' class. On Page Load an instance of AttributeCollection is created
by passing ViewState as statebag. The statebag internally maintains state of all custom attributes 
added after postback. 
 */
// <Snippet1>       
AttributeCollection myAttributeCollection = null;

void Page_Load(object sender,EventArgs e)
{
// <Snippet2>
   myAttributeCollection = new AttributeCollection(ViewState);
// </Snippet2>
   Response.Write("<h3> AttributeCollection.AttributeCollection Sample </h3>");
   if (!IsPostBack)
   {  
// <snippet3>         
      myAttributeCollection.Add("Color" ,"Color.Red");
      myAttributeCollection.Add("BackColor","Color.blue");
// </snippet3>
// <snippet4>
      Response.Write("Attribute Collection  count before PostBack = " + myAttributeCollection.Count);
// </snippet4>
      Response.Write("<br /><u><h4>Enumerating Attributes for CustomControl before PostBack</h4></u>");
      IEnumerator keys = myAttributeCollection.Keys.GetEnumerator();
      int i =1;
      String key;
      while (keys.MoveNext())
      {
         key = (String)keys.Current;
         Response.Write(i + ". "+key + "=" + myAttributeCollection[key]+"<br />");
         i++;
      }
   }
   else
   {
      Response.Write("Attribute Collection  count after PostBack = "+myAttributeCollection.Count);
      Response.Write("<br /><u><h4>Enumerating Attributes for CustomControl after PostBack</h4></u>");
      IEnumerator keys = myAttributeCollection.Keys.GetEnumerator();
      int i =1;
      String key;
      while (keys.MoveNext())
      {
         key = (String)keys.Current;
         Response.Write(i + ". "+key + "=" + myAttributeCollection[key]+"<br />");
         i++;
      }
   }
}
// </Snippet1>
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title> AttributeCollection.AttributeCollection Sample </title>
</head>
   <body>
      <form id="form1" method="post" runat="server">
         <asp:Button Text="Submit" Runat="server"></asp:Button>
         <h5>
            Click Submit Button to force PostBack
         </h5>
      </form>
   </body>
</html>
