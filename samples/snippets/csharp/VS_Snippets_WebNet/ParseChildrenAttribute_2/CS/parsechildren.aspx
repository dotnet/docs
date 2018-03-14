<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="AspSample" Assembly="Samples.AspNet.CS.Controls" Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    // Create a new employee object and add it to the custom control.
    Employee e1 = new Employee("Employee 2", "Title 2", "Alias 2");
    CollectionPropertyControl1.Employees.Add(e1);

    // Verify attribute values.
    ParseChildrenAttribute p = 
      (ParseChildrenAttribute)Attribute.GetCustomAttribute(typeof(CollectionPropertyControl),
      typeof(ParseChildrenAttribute));

    StringBuilder sb = new StringBuilder();
    sb.Append("The ChildControlType property is " + p.ChildControlType.ToString() + "<br />");
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
      <Employees>
        <AspSample:Employee Name="Employee 1" 
                            Title="Title 1" 
                            Alias="Alias 1" />
      </Employees>
      </AspSample:CollectionPropertyControl>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->