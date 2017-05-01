<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >  

<head>
    <title>How to: Set HTML Server Control Properties Programmatically</title>
    
</head>
<script runat="server" language="vb">

    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        '<Snippet3>
        Dim TotalCost As Integer
        myAnchor.HRef = "http://www.microsoft.com"
        Text1.MaxLength = 20
        Text1.Text = String.Format("{0:$###}", TotalCost)
        Span1.InnerHtml = "You must enter a value for Email Address."
        '</Snippet3>
        
        '<Snippet4>
        ' Adds new attribute.
        Text1.Attributes.Add("bgcolor", "red")
        ' Removes one attribute.
        Text1.Attributes.Remove("maxlength")
        ' Removes all attributes, clearing all properties.
        'Text1.Attributes.Clear()
        ' Creates comma-delimited list of defined attributes
        Dim strTemp As String = ""
        Dim key As String
        For Each key In Text1.Attributes.Keys
            strTemp &= Text1.Attributes(key) & ", "
        Next
    End Sub
    '</Snippet4>
</script>
 
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="Text1" runat="server"></asp:TextBox>
    <span id="Span1" runat="server"></span>
    <a id="myAnchor" runat="server">Microsoft</a>
    
    </form>
</body>
</html>

