<!-- <snippet1> -->
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data" %>

// The following OutputCache directive uses the OutputCacheLocation.Server
// enumeration value to allow output caching only on the origin server.
<%@ outputcache duration="10" varybyparam="none" Location="Server" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="C#" runat="server">

    protected void Page_Load(Object Src, EventArgs E) 
    {
        DataSet ds = new DataSet();

        FileStream fs = new FileStream(Server.MapPath("schemadata.xml"),FileMode.Open,FileAccess.Read);
        StreamReader reader = new StreamReader(fs);
        ds.ReadXml(reader);
        fs.Close();

        DataView Source = new DataView(ds.Tables[0]);

        // Use the LiteralControl constructor to create a new
        // instance of the class.
        LiteralControl myLiteral = new LiteralControl();

        // Set the LiteralControl.Text property to an HTML
        // string and the TableName value of a data source.
        myLiteral.Text = "<h6><font face=\"verdana\">Caching an XML Table: " + Source.Table.TableName + " </font></h6>";

        MyDataGrid.DataSource = Source;
        MyDataGrid.DataBind();

        TimeMsg.Text = DateTime.Now.ToString("G");

     }

  </script>

<head runat="server">
    <title>Using the OutputCacheLocation Enumeration </title>
</head>
<body>

  <h6>Using the OutputCacheLocation Enumeration </h6>
  
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