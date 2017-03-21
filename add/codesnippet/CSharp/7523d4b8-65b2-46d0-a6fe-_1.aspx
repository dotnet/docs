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
        new QueryStringParameter("QueryStringParam3","requestfield3");
    aSqlDataSource.SelectParameters.Add(qs3);

    // Insert
    aSqlDataSource.SelectParameters.Insert(1, new QueryStringParameter("QueryStringParam2", "requestField2") );

    // Iterate through the ParameterCollection and print out the
    // names of the Parameters contained by it.
    foreach (Parameter aParameter in aSqlDataSource.SelectParameters) {
        Response.Write(aParameter.Name + "<BR>");
    }
}
</SCRIPT>