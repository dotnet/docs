<!-- <snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    Dim sb As New StringBuilder()
    Dim nl As String = "<br />"

    sb.Append("AppDomainAppId = " & _
      HttpRuntime.AppDomainAppId & nl)
    sb.Append("AppDomainAppPath = " & _
      HttpRuntime.AppDomainAppPath & nl)
    sb.Append("AppDomainAppVirtualPath = " & _
      HttpRuntime.AppDomainAppVirtualPath & nl)
    sb.Append("AppDomainId = " & _
      HttpRuntime.AppDomainId & nl)
    sb.Append("AspInstallDirectory = " & _
      HttpRuntime.AspInstallDirectory & nl)
    sb.Append("BinDirectory = " & _
      HttpRuntime.BinDirectory & nl)
    sb.Append("ClrInstallDirectory = " & _
      HttpRuntime.ClrInstallDirectory & nl)
    sb.Append("CodegenDir = " & _
      HttpRuntime.CodegenDir & nl)
    sb.Append("IsOnUNCShare = " & _
      HttpRuntime.IsOnUNCShare.ToString() & nl)
    sb.Append("MachineConfigurationDirectory = " & _
      HttpRuntime.MachineConfigurationDirectory & nl)

    label1.Text = sb.ToString()

  End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpRuntime Example</title>
  </head>
  <body>    
    <form id="Form1" runat="server">
      <asp:label id="label1" runat="server"/>
    </form>
  </body>
</html>
<!-- </snippet1> -->
