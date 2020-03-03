<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Set HTML Server Control Properties Programmatically</title>
</head>

<script  runat="server">
    
  private void Page_Load()
  {
      int TotalCost = 0;
      
       //<Snippet3>
       myAnchor.HRef = "http://www.microsoft.com";
       Text1.MaxLength = 20;
       Text1.Text = string.Format("{0:$####}", TotalCost);
       Span1.InnerHtml = "You must enter a value for Email Address.";
       //</Snippet3>

       //<Snippet4>    
       // Adds a new attribute.
       Text1.Attributes.Add("bgcolor", "red");
       // Removes one attribute.
       Text1.Attributes.Remove("maxlength");
       // Removes all attributes, clearing all properties.
       Text1.Attributes.Clear();
       // Creates comma-delimited list of defined attributes
       string strTemp = "";
       foreach (string key in Text1.Attributes.Keys)
       {
           strTemp += Text1.Attributes[key] + ", ";
       }
       //</Snippet4>
      
}
        
 </script>
 
<body>
    <form id="form1" runat="server">
      <asp:TextBox id="Text1" runat="server"></asp:TextBox>
      <span id="Span1" runat="server"></span>
      <a id="myAnchor" runat="server">Microsoft</a>
    </form>
</body>
</html>
