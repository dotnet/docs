AttributeCollection myAttributeCollection = null;

void Page_Load(object sender,EventArgs e)
{
   myAttributeCollection = new AttributeCollection(ViewState);
   Response.Write("<h3> AttributeCollection.AttributeCollection Sample </h3>");
   if (!IsPostBack)
   {  
      myAttributeCollection.Add("Color" ,"Color.Red");
      myAttributeCollection.Add("BackColor","Color.blue");
      Response.Write("Attribute Collection  count before PostBack = " + myAttributeCollection.Count);
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