<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="AspSample" Assembly="Samples.AspNet.CS.Controls" Namespace="PersistChildrenSamples" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  protected void Page_Load(object sender, EventArgs e)
  {

    // Create two new employees and add them to the custom control.
    Employee e1 = new Employee("Employee 1", "Title 1", "Alias 1");
    Employee e2 = new Employee("Employee 2", "Title 2", "Alias 2");
    CollectionPropertyControl1.Employees.Add(e1);
    CollectionPropertyControl1.Employees.Add(e2);

    // Verify attribute values.
    PersistChildrenAttribute p =
      (PersistChildrenAttribute)Attribute.GetCustomAttribute(typeof(CollectionPropertyControl), 
      typeof(PersistChildrenAttribute));

    StringBuilder sb = new StringBuilder();
    sb.Append("The Persist property is " + p.Persist.ToString() + "<br />");
    sb.Append("The UseCustomPersistence property is " + p.UsesCustomPersistence.ToString() + "<br />");
    sb.Append("The IsDefault method returns " + p.IsDefaultAttribute().ToString());
    Message.Text = sb.ToString();
    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PersistChildrenAttribute</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="Message"
                 runat="server"/>
      <AspSample:CollectionPropertyControl id="CollectionPropertyControl1" 
                                           runat="server">
      </AspSample:CollectionPropertyControl>
    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->
