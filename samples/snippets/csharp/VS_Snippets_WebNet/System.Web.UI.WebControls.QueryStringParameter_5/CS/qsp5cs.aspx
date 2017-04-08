<!--<Snippet1>-->
<%@page Language="C#" %>
<SCRIPT runat="server">
private void Page_Load(object sender, EventArgs e) {

    SqlDataSource aSqlDataSource = new SqlDataSource();

    // Security Note: The SqlDataSource uses a QueryStringParameter,
    // Security Note: which does not perform validation of input from the client.

    QueryStringParameter qs1 =
        new QueryStringParameter("QueryStringParam1","requestfield1");

    aSqlDataSource.SelectParameters.Add(qs1);

    QueryStringParameter qs3 =
        new QueryStringParameter("QueryStringParam2","requestfield2");

    aSqlDataSource.SelectParameters.Add(qs3);

    // Insert another QueryStringParameter with the same name as the previous parameter.
    aSqlDataSource.SelectParameters.Add( new QueryStringParameter("QueryStringParameter2","requestfield3") );

    // There are two parameters named QueryStringParam3. Use the
    // RemoveAt method to remove the last element from the collection.
    aSqlDataSource.SelectParameters.RemoveAt( (aSqlDataSource.SelectParameters.Count - 1) );

    // Iterate through the ParameterCollection and print out the
    // names of the Parameters contained by it.
    foreach (Parameter aParameter in aSqlDataSource.SelectParameters) {
        Response.Write(aParameter.Name + "<BR>");
        QueryStringParameter qsptemp = (QueryStringParameter) aParameter;
        Response.Write("QueryStringField is " + qsptemp.QueryStringField + "<BR>");
    }
}
</SCRIPT>
<!--</Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
