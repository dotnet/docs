<%--<snippet1>--%>
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs)

        ' Create a string to contain the paramaters'
        ' information.
        Dim paramInfo As String = ""

        Dim i, j As Integer

        ' Obtain a reference to the Request.Params
        ' collection.
        Dim pColl As NameValueCollection = Request.Params

        ' Iterate through the collection and add
        ' each key to the string variable.
        For i = 0 To pColl.Count - 1

            paramInfo += "Key: " + pColl.GetKey(i) + "<br />"

            ' Create a string array that contains
            ' the values associated with each key.
            Dim pValues() As String  = pColl.GetValues(i)

            ' Iterate through the array and add
            ' each value to the string variable.
            For j = 0 To pValues.Length - 1

                paramInfo += "Value:" + pValues(j) + "<br /><br />"

            Next j
        Next i

        ' Set a Label's Text property to the values
        ' contained in the string variable.
        lblValues.Text = paramInfo
    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label id="lblValues" runat="server" />
    </form>
</body>
</html>
<%--</snippet1>--%>
