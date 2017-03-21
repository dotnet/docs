<%@ Page Language="VB" %>
<%@ Import namespace="System.IO" %>

<script runat="server">
  
    Sub Page_Load()
        Dim FileNames(2) As String
        FileNames(0) = "Test.txt"
        FileNames(1) = "Test2.txt"
        FileNames(2) = "Test3.txt"
        Response.AddFileDependencies(FileNames)
        Response.Write("File Dependencies sucessfully added!")
    End Sub
          
</script>
