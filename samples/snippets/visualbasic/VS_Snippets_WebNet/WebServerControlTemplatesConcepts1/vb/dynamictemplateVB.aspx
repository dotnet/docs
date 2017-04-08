<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    ' <Snippet2>
    Public Class MyTemplate
        Implements System.Web.UI.ITemplate
        
        ' <Snippet3>
        Dim templateType As ListItemType
        
        Sub New(ByVal type As ListItemType)
            templateType = type
        End Sub
        
        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
          Implements System.Web.UI.ITemplate.InstantiateIn
            
            Dim ph As New PlaceHolder()
            Dim item1 As New Label()
            Dim item2 As New Label()
            item1.ID = "item1"
            item2.ID = "item2"
            
            Select Case (templateType)
                Case ListItemType.Header
                    ph.Controls.Add(New LiteralControl("<table border=""1"">" & _
                        "<tr><td><b>Category ID</b></td>" & _
                        "<td><b>Category Name</b></td></tr>"))
                Case ListItemType.Item
                    ph.Controls.Add(New LiteralControl("<tr><td>"))
                    ph.Controls.Add(item1)
                    ph.Controls.Add(New LiteralControl("</td><td>"))
                    ph.Controls.Add(item2)
                    ph.Controls.Add(New LiteralControl("</td></tr>"))
                    AddHandler ph.DataBinding, New EventHandler(AddressOf Item_DataBinding)
                Case ListItemType.AlternatingItem
                    ph.Controls.Add(New LiteralControl("<tr bgcolor=""lightblue""><td>"))
                    ph.Controls.Add(item1)
                    ph.Controls.Add(New LiteralControl("</td><td>"))
                    ph.Controls.Add(item2)
                    ph.Controls.Add(New LiteralControl("</td></tr>"))
                    AddHandler ph.DataBinding, New EventHandler(AddressOf Item_DataBinding)
                Case ListItemType.Footer
                    ph.Controls.Add(New LiteralControl("</table>"))
            End Select
            container.Controls.Add(ph)
        End Sub
        ' </Snippet3>        
    End Class
    ' </Snippet2>
    ' <Snippet4>
    Shared Sub Item_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ph As PlaceHolder = CType(sender, PlaceHolder)
        Dim ri As RepeaterItem = CType(ph.NamingContainer, RepeaterItem)
        Dim item1Value As Integer = _
            Convert.ToInt32(DataBinder.Eval(ri.DataItem, "CategoryID"))
        Dim item2Value As String = _
            Convert.ToString(DataBinder.Eval(ri.DataItem, "CategoryName"))
        CType(ph.FindControl("item1"), Label).Text = item1Value.ToString()
        CType(ph.FindControl("item2"), Label).Text = item2Value
    End Sub
    ' </Snippet4>

    ' <Snippet5>
    Protected Sub Page_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim conn As New System.Data.SqlClient.SqlConnection( _
            ConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
        
        Dim sqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
        Dim dsCategories1 As System.Data.DataSet
        
        sqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter( _
            "SELECT [CategoryID], [CategoryName] FROM [Categories]", conn)
        dsCategories1 = New System.Data.DataSet()
        
        Repeater1.HeaderTemplate = New MyTemplate(ListItemType.Header)
        Repeater1.ItemTemplate = New MyTemplate(ListItemType.Item)
        Repeater1.AlternatingItemTemplate = New MyTemplate(ListItemType.AlternatingItem)
        Repeater1.FooterTemplate = New MyTemplate(ListItemType.Footer)
        sqlDataAdapter1.Fill(dsCategories1, "Categories")
        Repeater1.DataSource = dsCategories1.Tables("Categories")
        Repeater1.DataBind()

    End Sub
    ' </Snippet5>

</script>
<!-- <Snippet6> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dynamically Creating Templates</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Repeater id="Repeater1" runat="server"></asp:Repeater>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet6> -->
<!-- </Snippet1> -->