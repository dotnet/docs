<!-- <Snippet1> -->
<%@ Import Namespace="System"%>
<%@ Import Namespace="System.IO"%>
<%@ Import Namespace="System.Net"%>
<%@ Import NameSpace="System.Web"%>

<Script language="VB" runat=server>
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
        Dim f As String
        Dim file
        For Each f In Request.Files.AllKeys
            file = Request.Files(f)
            file.SaveAs("c:\inetpub\test\UploadedFiles\" & file.FileName)
        Next f
        
    End Sub

</Script>
<html>
<body>
<p> Upload complete. </p>
</body>
</html>
<!-- </Snippet1> -->