<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="AspSample" Assembly="Samples.AspNet.VB.Controls" Namespace="PersistChildrenSampleVB" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Create two new employees and add them to the custom control.
    Dim e1 As New Employee("Employee 1", "Title 1", "Alias 1")
    Dim e2 As New Employee("Employee 2", "Title 2", "Alias 2")
    CollectionPropertyControl1.Employees.Add(e1)
    CollectionPropertyControl1.Employees.Add(e2)

    ' Verify attribute values.
    Dim p As PersistChildrenAttribute = _
    Attribute.GetCustomAttribute(GetType(CollectionPropertyControl), _
    GetType(PersistChildrenAttribute))

    Dim sb As New StringBuilder()
    sb.Append("The Persist property is " & p.Persist.ToString() & "<br />")
    sb.Append("The UseCustomPersistence property is " & p.UsesCustomPersistence.ToString() & "<br />")
    sb.Append("The IsDefault method returns " & p.IsDefaultAttribute().ToString())
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
      </AspSample:CollectionPropertyControl>
    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->