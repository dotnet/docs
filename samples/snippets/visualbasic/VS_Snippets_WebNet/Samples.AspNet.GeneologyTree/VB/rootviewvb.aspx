<!-- <snippet1> -->
<%@Page language="VB" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.VB.Controls" 
    Assembly="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>VB Example</title>
  </head>

  <body>
    <form id="Form1" method="post" runat="server">

        <aspSample:geneologytree
          id="GeneologyTree1"
          runat="server"
          datatextfield="title"
          datasourceid="XmlDataSource1" />

        <asp:xmldatasource
          id="XmlDataSource1"
          datafile="geneology.xml"          
          runat="server" />
          
    </form>
  </body>
</html>
<!-- </snippet1> -->