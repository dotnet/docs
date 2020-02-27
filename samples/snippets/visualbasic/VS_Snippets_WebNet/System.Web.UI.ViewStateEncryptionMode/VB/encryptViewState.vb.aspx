<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">    
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If IsPostBack Then
            
            If (yesRetrieve.Checked) Then
                Page.RegisterRequiresViewStateEncryption()
                
                Dim conn As System.Data.SqlClient.SqlConnection = _
                  New System.Data.SqlClient.SqlConnection _
                  ("server=localhost;database=Northwind;Integrated Security=SSPI")
                Dim command As System.Data.SqlClient.SqlCommand = _
                  conn.CreateCommand()
                command.CommandText = "Select [CustomerID] From [Customers]"
                conn.Open()
                Dim reader As System.Data.SqlClient.SqlDataReader = _
                  command.ExecuteReader()
                customerid.Text = reader("CustomerID").ToString()
                reader.Close()
                conn.Close()
            End If
        End If
    End Sub
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
