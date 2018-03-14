<!-- <Snippet1> -->
<%@ Page Language="VB" Culture="auto" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim localresourcestring As String
    Dim globalresourcestring As String
    
    ' Get the local resource string.
    Try

      localresourcestring = "Found the local resource string and it's value is: " & _
        Convert.ToString(GetLocalResourceObject("LocalResourceString1")) & "."
      
    Catch
    
      localresourcestring = "Could not find local resource."

    End Try
    
    ' Get the global resource string.
    Try

      ' Look in the global resource file called MyResource.resx.
      globalresourcestring = "Found the global resource string and it's value is: " & _
        Convert.ToString(GetGlobalResourceObject("MyResource", "GlobalResourceString1")) & "."

    Catch

      globalresourcestring = "Could not find global resource."

    End Try

    LocalResourceMessage.InnerText = localresourcestring
    GlobalResourceMessage.InnerText = globalresourcestring

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TemplateControl GetGlobalResourceObject and GetLocalResourceObject Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>TemplateControl GetGlobalResourceObject and GetLocalResourceObject Example</h3>
      <span id="LocalResourceMessage"
            runat="server"/>
      <br />
      <span id="GlobalResourceMessage"
            runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->