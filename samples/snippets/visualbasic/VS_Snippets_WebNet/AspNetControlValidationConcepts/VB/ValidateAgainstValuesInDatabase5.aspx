<%@ Page Language="VB" %>
<%@ Import Namespace= "System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate Against Values in a Database for ASP.NET Server Controls</title>
</head>

<script runat="server">
    
    '<Snippet5>
    Private Sub CustomValidator1_ServerValidate(ByVal _
       source As System.Object, ByVal args As _
       System.Web.UI.WebControls.ServerValidateEventArgs) _
       Handles CustomValidator1.ServerValidate
        
        Dim dv As DataView
        Dim dataset11 As New Data.DataSet
        
        dv = dataset11.Tables(0).DefaultView
        
        Dim datarow As DataRowView
        Dim txtEmail As String
        args.IsValid = False    ' Assume False
        ' Loop through table and compare each record against user's entry
        For Each datarow In dv
            ' Extract e-mail address from the current row
            txtEmail = datarow.Item("Alias").ToString()
            ' Compare e-mail address against user's entry
            If txtEmail = args.Value Then
                args.IsValid = True
                Exit For
            End If
        Next
    End Sub
    '</Snippet5>

</script>

<body>
    <form id="form1" runat="server">
    <div>
      <asp:CustomValidator id="CustomValidator1" runat="server"></asp:CustomValidator>
    </div>
    </form>
</body>
</html>
