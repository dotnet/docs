Sub Page_Load(sender As [Object], e As EventArgs)
   If Not IsPostBack Then
      DataList1.AlternatingItemTemplate = LoadTemplate("newtemplate.ascx")
      
      DataList1.DataSource = CreateDataSource()
      DataList1.DataBind()
   End If
End Sub 'Page_Load
