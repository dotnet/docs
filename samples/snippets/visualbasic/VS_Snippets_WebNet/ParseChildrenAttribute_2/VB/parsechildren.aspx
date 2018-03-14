<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="AspSample" Assembly="Samples.AspNet.VB.Controls" Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Create a new employee object and add it to custom control.
    Dim e1 As New Employee("Employee 2", "Title 2", "Alias 2")
    CollectionPropertyControl1.Employees.Add(e1)

    ' Verify attribute values.
    Dim p As ParseChildrenAttribute = _
    Attribute.GetCustomAttribute(GetType(CollectionPropertyControl), _
    GetType(ParseChildrenAttribute))

    Dim sb As New StringBuilder()
    sb.Append("The ChildControlType property is " & p.ChildControlType.ToString() & "<br />")
    sb.Append("The ChildrenAsProperties property is " & p.ChildrenAsProperties.ToString() & "<br />")
    sb.Append("The IsDefaultAttribute method returns " & p.IsDefaultAttribute().ToString())
    Message.Text = sb.ToString()

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PersistChildrenAttribute</title>
</head>
<body>
    <form id="Form1" runat="server">
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
