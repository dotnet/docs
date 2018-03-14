<!-- <snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, System.EventArgs e)
  {
    StringBuilder sb = new StringBuilder();
    String nl = "<br />";

    sb.Append("AppDomainAppId = " + 
      HttpRuntime.AppDomainAppId + nl);
    sb.Append("AppDomainAppPath = " + 
      HttpRuntime.AppDomainAppPath + nl);
    sb.Append("AppDomainAppVirtualPath = " + 
      HttpRuntime.AppDomainAppVirtualPath + nl);
    sb.Append("AppDomainId = " + 
      HttpRuntime.AppDomainId + nl);
    sb.Append("AspInstallDirectory = " + 
      HttpRuntime.AspInstallDirectory + nl);
    sb.Append("BinDirectory = " + 
      HttpRuntime.BinDirectory + nl);
    sb.Append("ClrInstallDirectory = " + 
      HttpRuntime.ClrInstallDirectory + nl);
    sb.Append("CodegenDir = " + 
      HttpRuntime.CodegenDir + nl);
    sb.Append("IsOnUNCShare = " + 
      HttpRuntime.IsOnUNCShare.ToString() + nl);
    sb.Append("MachineConfigurationDirectory = " + 
      HttpRuntime.MachineConfigurationDirectory + nl);

    label1.Text = sb.ToString();
  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpRuntime Example</title>
  </head>
  <body>    
    <form id="form1" runat="server">
      <asp:label id="label1" runat="server"/>
    </form>
  </body>
</html>
<!-- </snippet1> -->
