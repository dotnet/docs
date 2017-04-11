<!-- <Snippet50> -->
<%@ Page Language="C#" %>
<%@ Register Tagprefix="aspSample"
             Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:gridview
          id="GridView1"
          runat="server"
          allowsorting="True"
          datasourceid="CsvDataSource1" />

      <aspSample:CsvDataSource
          id = "CsvDataSource1"
          runat = "server"
          filename = "sample.csv"
          includescolumnnames="True" />

    </form>
  </body>
</html>
<!-- </Snippet50> -->