<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ outputcache duration="30" varybyparam="none" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="Server">
    Sub Page_Load()
        ' Create a Cache Dependency 
        ' using a CacheDependency object.
        Dim authorsDependency("authors.xml") As CacheDependency

        ' Make the page invalid if either of the
        ' cached items change or expire.        
        Response.AddCacheDependency(authorsDependency)

        ' Display the current time for cache reference
        lblOutputCacheMsg.Text = DateTime.Now.ToString()
        
        
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Cache Dependencies</title> 
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table>
            <tbody>
                <tr>
                    <td style="WIDTH: 118px">
                        The page was generated at:</td>
                    <td>
                        <asp:Label id="lblOutputCacheMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
<!-- </snippet1> -->