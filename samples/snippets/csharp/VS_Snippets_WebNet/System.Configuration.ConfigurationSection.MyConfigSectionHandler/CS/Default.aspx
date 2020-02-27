<!-- <Snippet2> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_Load(object sender, EventArgs e)
  {
    Samples.AspNet.PageAppearanceSection config =
        (Samples.AspNet.PageAppearanceSection)System.Configuration.ConfigurationManager.GetSection(
        "pageAppearanceGroup/pageAppearance");

    Response.Write("<h2>Settings in the PageAppearance Section:</h2>");
    Response.Write(string.Format("RemoteOnly: {0}<br>", 
        config.RemoteOnly));
    Response.Write(string.Format("Font name and size: {0} {1}<br>",
        config.Font.Name, config.Font.Size));
    Response.Write(
        string.Format("Background and foreground color: {0} {1}<br>",
        config.Color.Background, config.Color.Foreground));
  }
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
