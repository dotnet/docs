<!-- <snippet1> -->
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data" %>

' The following OutputCache directive uses the OutputCacheLocation.Server
' enumeration value to allow output caching only on the origin server.
<%@ outputcache duration="10" varybyparam="none" Location="Server" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="vb" runat="server">

   Protected Sub Page_Load(Src As [Object], E As EventArgs)
     Dim ds As New DataSet()
   
     Dim fs As New FileStream(Server.MapPath("schemadata.xml"),FileMode.Open,FileAccess.Read)

   
   Dim reader As New StreamReader(fs)
     
      ds.ReadXml(reader)
      fs.Close()
 
   
   Dim [Source] As New DataView(ds.Tables(0))
      
   MyDataGrid.DataSource = [Source]   
   MyDataGrid.DataBind()
   
   TimeMsg.Text = DateTime.Now.ToString("G")

 End Sub 'Page_Load 

  </script>

<head runat="server">
    <title>Using the OutputCacheLocation Enumeration </title>
</head>
<body>
  <h4>Using the OutputCacheLocation Enumeration </h4>
  
  <form id="form1" runat="server">
    <ASP:DataGrid id="MyDataGrid" runat="server"
      Width="900"
      BackColor="#ccccff"
      BorderColor="black"
      ShowFooter="false"
      CellPadding="3"
      CellSpacing="0"
      Font-Names="Verdana"
      Font-Size="8pt"
      HeaderStyle-BackColor="#aaaadd"
      EnableViewState="false"
    />

    <i>Page last generated on:</i> <asp:label id="TimeMsg" runat="server" />

  </form>
</body>
</html>
<!-- </snippet1> -->