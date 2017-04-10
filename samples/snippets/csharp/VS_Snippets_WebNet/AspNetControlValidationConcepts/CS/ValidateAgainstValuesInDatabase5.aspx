<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate Against Values in a Database for ASP.NET Server Controls</title>
</head>

<script runat="server">
    
    //<Snippet5>
    private void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        DataView dv;
        DataSet dataSet11 = new DataSet();
        
        dv = dataSet11.Tables[0].DefaultView;
        string txtEmail;
        args.IsValid = false;    // Assume False
        // Loop through table and compare each record against user's entry
        foreach (DataRowView datarow in dv)
        {
            // Extract e-mail address from the current row
            txtEmail = datarow["Alias "].ToString();
            // Compare e-mail address against user's entry
            if (txtEmail == args.Value)
            {
                args.IsValid = true;
            }
        }
    }
    //</Snippet5>

</script>

<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
