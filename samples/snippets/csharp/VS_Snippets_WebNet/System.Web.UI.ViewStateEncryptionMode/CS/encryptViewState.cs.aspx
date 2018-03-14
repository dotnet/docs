<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    void Page_Load(Object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (yesRetrieve.Checked)
            {
                Page.RegisterRequiresViewStateEncryption();
                
                System.Data.SqlClient.SqlConnection conn = 
                    new System.Data.SqlClient.SqlConnection
                    ("server=localhost;database=Northwind;Integrated Security=SSPI");
                System.Data.SqlClient.SqlCommand command =
                    conn.CreateCommand();
                command.CommandText = "Select [CustomerID] From [Customers]";
                conn.Open();
                System.Data.SqlClient.SqlDataReader reader =
                    command.ExecuteReader();
                customerid.Text = reader["CustomerID"].ToString();
                reader.Close();
                conn.Close();
            }
            else
            {
                customerid.Text = "Not retrieved";
            }
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Customer Information</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Customer identifier: 
        <asp:Label ID="customerid" runat="server" Text="Not available" />
        <br />
        Retrieve customer info: 
        <asp:RadioButton ID="yesRetrieve" Text="yes" runat="server" GroupName="group1" /> 
        <asp:RadioButton ID="noRetrieve" Text="no" runat="server" GroupName="group1" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->