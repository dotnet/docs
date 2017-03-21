<%@ Page Language="C#" %>
<%@ Import namespace="System.IO" %>

<script runat="server">
    private void Page_Load()
    {
        String[] FileNames = new String[3];
        FileNames[0] = "Test.txt";
        FileNames[1] = "Test2.txt";
        FileNames[2] = "Test3.txt";
        Response.AddFileDependencies(FileNames);
        Response.Write("File Dependencies sucessfully added!");
    }
          
</script>
