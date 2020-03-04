<%@ Page Language="VB"  %>
<%@ Import Namespace= "System.Data"%>
<%@ Import Namespace= "System.Data.SqlClient"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Create Web Server Control Templates Dynamically</title>
</head>

<script runat="server">
       
    '<Snippet5>
    Public Class MyTemplate
        Implements ITemplate
        Shared itemcount As Integer = 0
        Dim TemplateType As ListItemType

        Sub New(ByVal type As ListItemType)
            TemplateType = type
        End Sub

        Sub InstantiateIn(ByVal container As Control) _
           Implements ITemplate.InstantiateIn
            
            Dim lc As New Literal()
            
            Select Case TemplateType
                Case ListItemType.Header
                    lc.Text = "<table border=""1""><tr><th>Items</th></tr>"
                Case ListItemType.Item
                    lc.Text = "<tr><td>Item number: " & itemcount.ToString _
                       & "</td></tr>"
                Case ListItemType.AlternatingItem
                    lc.Text = "<tr><td bgcolor=""lightblue"">Item number: " _
                       & itemcount.ToString & "</td></tr>"
                Case ListItemType.Footer
                    lc.Text = "</table>"
            End Select
            
            container.Controls.Add(lc)
            itemcount += 1
            
        End Sub
    End Class
    '</Snippet5>
    
    
    '<Snippet6>
    Private Sub Page_Load(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim conn As SqlConnection = _
          New SqlConnection(ConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
        Dim SqlDataAdapter1 As SqlDataAdapter
        Dim DsCategories1 As DataSet
        
        SqlDataAdapter1 = New SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories", conn)
        DsCategories1 = new Dataset()
        
        Repeater1.HeaderTemplate = New MyTemplate(ListItemType.Header)
        Repeater1.ItemTemplate = New MyTemplate(ListItemType.Item)
        Repeater1.AlternatingItemTemplate = _
           New MyTemplate(ListItemType.AlternatingItem)
        Repeater1.FooterTemplate = New MyTemplate(ListItemType.Footer)
        SqlDataAdapter1.Fill(DsCategories1, "Categories")
        Repeater1.DataSource = DsCategories1.Tables("Categories")
        Repeater1.DataBind()

    End Sub
    '</Snippet6>
    
    
    Private Sub Button1_Click()
        Dim TemplateType As ListItemType
        
        '<Snippet7>
        Dim lc As New Literal()
        
        Select Case TemplateType
            Case ListItemType.Item
                lc.Text = "<tr><td>"
                AddHandler lc.DataBinding, AddressOf TemplateControl_DataBinding
        End Select
        '</Snippet7>
        
    End Sub
    
    '<Snippet8>
    '<Snippet9>
    Private Sub TemplateControl_DataBinding(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    '</Snippet9>
  
        Dim lc As Literal
        lc = CType(sender, Literal)
        
        Dim container As RepeaterItem
        
        container = CType(lc.NamingContainer, RepeaterItem)
        lc.Text &= DataBinder.Eval(container.DataItem, "CategoryName")
        lc.Text &= "</td></tr>"
    End Sub
    '</Snippet8>
    
</script>
<body>
    <form id="form1" runat="server">
      <asp:Repeater id="Repeater1" runat="server"></asp:Repeater>
      <asp:Button id="Button1" runat= "server" />
    </form>
</body>
</html>
