<%-- <Snippet1> --%>
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="System.Web.Script.Serialization.TypeResolver.VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) 
    
        Dim customObject As New ColorType()
        Dim serializer As JavaScriptSerializer
        
        Select Case CType(sender, RadioButtonList).SelectedIndex
            Case 0
                serializer = New JavaScriptSerializer()
                Label1.Text = serializer.Serialize(customObject)
            Case 1
                serializer = New JavaScriptSerializer(New SimpleTypeResolver())
                Label1.Text = serializer.Serialize(customObject)
            Case 2
                serializer = New JavaScriptSerializer(New CustomTypeResolver())
                Label1.Text = serializer.Serialize(customObject)
        End Select

    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Type Resolvers</title>
    <style type="text/css">
        body {  font: 10pt Trebuchet MS;
                font-color: #000000;
             }

        .text { font: 8pt Trebuchet MS }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Select one of the following serialization types:
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="0">Serialization with no type resolver</asp:ListItem>
            <asp:ListItem Value="1">Serialization with the SimpleTypeResolver class</asp:ListItem>
            <asp:ListItem Value="2">Serialization with a custom type resolver</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        Note the different resulting serialized strings. The ones that use type resolvers have an extra __type tag.
        <hr />
        Results:
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" ></asp:Label><br />
                </td>
            </tr>
        </table>        
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
<%-- </Snippet1> --%>