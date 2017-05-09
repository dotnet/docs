<%--<snippet1>--%>
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Page_Load(object sender, EventArgs e)
    {
        // Create a string to contain the paramaters'
        // information.
        string paramInfo = "";

        // Obtain a reference to the Request.Params
        // collection.
        NameValueCollection pColl = Request.Params;

        // Iterate through the collection and add
        // each key to the string variable.
        for(int i = 0; i <= pColl.Count - 1; i++)
        {
            paramInfo += "Key: " + pColl.GetKey(i) + "<br />";

            // Create a string array that contains
            // the values associated with each key.
            string[] pValues = pColl.GetValues(i);

            // Iterate through the array and add
            // each value to the string variable.
            for(int j = 0; j <= pValues.Length - 1; j++)
            {
                paramInfo += "Value:" + pValues[j] + "<br /><br />";

            }
        }

        // Set a Label's Text property to the values
        // contained in the string variable.
        lblValues.Text = paramInfo;
    }

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
