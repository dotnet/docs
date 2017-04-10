<!-- <Snippet2> -->

<%@ Page Language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    Dim config As Samples.AspNet.PageAppearanceSection = _
      CType(System.Configuration.ConfigurationManager.GetSection( _
        "pageAppearanceGroup/pageAppearance"),  _
      Samples.AspNet.PageAppearanceSection)
    
    Response.Write("<h2>Settings in the PageAppearance Section:</h2>")
    Response.Write("RemoteOnly: " _
                    + config.RemoteOnly.ToString() + "<br>")
    Response.Write("Font name and size: " _
                    + config.Font.Name + " " _
                    + config.Font.Size.ToString() + "<br>")
    Response.Write("Background and foreground color: " _
                    + config.Color.Background + " " _
                    + config.Color.Foreground + "<br>")
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Custom Configuration Section Example</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <h1>
  </div>
  </form>
</body>
</html>

<!-- </Snippet2> -->
