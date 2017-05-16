<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="AspSample" Assembly="Samples.AspNet.VB.Controls" Namespace="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Verify attribute values.
    Dim p As ParseChildrenAttribute = _
    Attribute.GetCustomAttribute(GetType(CollectionPropertyControl), _
    GetType(ParseChildrenAttribute))

    Dim sb As New StringBuilder()
    sb.Append("The DefaultProperty property is " & p.DefaultProperty.ToString() & "<br />")
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
