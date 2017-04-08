<!-- <Snippet2> -->
<%@ Page Language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim c As New AC_Render.AttribRender()
    c.Attributes.Add("Text", "Hello World!")
    c.Attributes.Add("Attribute1", "The value for Attribute1.")
    Place1.Controls.Add(c)

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AttributeCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:PlaceHolder id="Place1" runat="server"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
