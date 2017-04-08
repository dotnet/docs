<!-- <Snippet3> -->
<%@ Page Language="C#" Debug="true" %>
<%@ Register TagPrefix="AspSample" Assembly="Samples.AspNet.CS.Controls" Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    
    // Verify attribute values.
    ParseChildrenAttribute p = 
      (ParseChildrenAttribute)Attribute.GetCustomAttribute(typeof(CollectionPropertyControl),
      typeof(ParseChildrenAttribute));

    StringBuilder sb = new StringBuilder();
    sb.Append("The DefaultProperty property is " + p.DefaultProperty.ToString() + "<br />");
    sb.Append("The ChildrenAsProperties property is " + p.ChildrenAsProperties.ToString() + "<br />");
    sb.Append("The IsDefaultAttribute method returns " + p.IsDefaultAttribute().ToString());
    Message.Text = sb.ToString();

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ParseChildrenAttribute Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="Message"
                 runat="server"/>
      <AspSample:CollectionPropertyControl id="CollectionPropertyControl1" 
                                           runat="server">
        <AspSample:Employee Name="Employee 1" 
                            Title="Title 1" 
                            Alias="Alias 1" />
        <AspSample:Employee Name="Employee 2" 
                            Title="Title 2" 
                            Alias="Alias 2" />
      </AspSample:CollectionPropertyControl>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->