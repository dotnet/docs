<!-- <Snippet1> -->
<%@ Page Language="VB" Debug = "true"%>
<%@ Reference Control="Logonformvb.ascx" %>
<script language="VB" runat="server">
    ' The following example demonstrates how to load a user control dynamically at run time, and
    ' work with the ControlCachePolicy object associated with it.

    ' Loads and displays a UserControl defined in a seperate Logonform.ascx file.
    ' You need to have "Logonform.ascx" and "LogOnControl.vb" file in 
    ' the same directory as the aspx file.
    Sub Page_Init(ByVal Sender As Object, ByVal e As EventArgs)

        ' Obtain a PartialCachingControl object which wraps the 'LogOnControl' user control.
        Dim pcc As PartialCachingControl
        pcc = CType(LoadControl("Logonform.vb.ascx"), PartialCachingControl)
    
        Dim cacheSettings As ControlCachePolicy
        cacheSettings = pcc.CachePolicy
    
        ' If the control is slated to expire in greater than 60 Seconds
        If (cacheSettings.Duration > TimeSpan.FromSeconds(60)) Then
        
            ' Make it expire faster. Set a new expiration time to 30 seconds, and make it
            ' an absolute expiration if it isnt already.        
            cacheSettings.SetExpires(DateTime.Now.Add(TimeSpan.FromSeconds(30)))
            cacheSettings.SetSlidingExpiration(False)
        End If
        Controls.Add(pcc)

    End Sub ' Page_Init
              
</script>
<!-- </Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
