<%--<snippet1>--%>
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<%--
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        '<snippet2>
        ' If there is a ScriptManager on the page, use it.
        ' If not, throw an exception.
        Dim SMgr As ScriptManager
        If ScriptManager.GetCurrent(Page) Is Nothing Then
            Throw New Exception("ScriptManager not found.")
        Else : SMgr = ScriptManager.GetCurrent(Page)
        End If
        '</snippet2>
    
        '<snippet3>
        Dim SRef As ScriptReference
        SRef = New ScriptReference()
        '</snippet3>
        
        '<snippet4>
        ' If you know that Smgr.ScriptPath is correct...
        SRef.Name = "Script.js"
        
        ' Or, to specify an app-relative path...
        SRef.Path = "~/Scripts/Script.js"
        '</snippet4>
        
        '<snippet5>
        ' To set ScriptMode for all scripts on the page...
        SMgr.ScriptMode = ScriptMode.Release
        
        'Or, set ScriptMode for just for the one script...
        SRef.ScriptMode = ScriptMode.Debug
        
        'If they conflict, the setting on the ScriptReference wins.
        '</snippet5>
        
        '<snippet6>
        SMgr.Scripts.Add(SRef)
        '</snippet6>
        
    End Sub
    
</script>
--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dynamic Script References</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager ID="ScriptManager1" runat="server" />
        <div>
        </div>
    </form>
</body>
</html>

<%--
        '<snippet7>
        SRef.Name = "Script.js"
        SRef.Assembly = "ScriptAssembly"
        '</snippet7>
--%>

<%--</snippet1>--%>
