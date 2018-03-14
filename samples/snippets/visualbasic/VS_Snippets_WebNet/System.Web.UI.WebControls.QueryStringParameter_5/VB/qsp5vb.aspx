<!--<Snippet1>-->
<%@page Language="VB" %>
<SCRIPT runat="server">
Sub Page_Load(sender As Object, e As EventArgs)

    Dim aSqlDataSource As New SqlDataSource()

    ' Security Note: The SqlDataSource uses a QueryStringParameter,
    ' Security Note: which does not perform validation of input from the client.

    Dim qs1 As New QueryStringParameter("QueryStringParam1","requestfield1")
    aSqlDataSource.SelectParameters.Add(qs1)

    Dim qs2 As New QueryStringParameter("QueryStringParam2","requestfield2")
    aSqlDataSource.SelectParameters.Add(qs2)

    ' Insert another QueryStringParameter with the same name as the previous parameter.
    Dim qs3 As New QueryStringParameter("QueryStringParam2","requestfield3")
    aSqlDataSource.SelectParameters.Add(qs3)

    ' There are two parameters named QueryStringParam3. Use the
    ' RemoveAt method to remove the last element from the collection.
    aSqlDataSource.SelectParameters.RemoveAt( (aSqlDataSource.SelectParameters.Count - 1) )

    ' Iterate through the ParameterCollection and print out the
    ' names of the Parameters contained by it.
    Dim aParameter As Parameter
    For Each aParameter in aSqlDataSource.SelectParameters
        Response.Write(aParameter.Name & "<BR>")
        Dim qsptemp As QueryStringParameter = CType(aParameter, QueryStringParameter)
        Response.Write("QueryStringField is " & qsptemp.QueryStringField & "<BR>")
    Next
End Sub ' Page_Load
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
