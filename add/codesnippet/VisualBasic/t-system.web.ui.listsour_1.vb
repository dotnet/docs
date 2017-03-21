       #Region "Implementation of IDataSource"

       Public Overridable Function GetView(viewName As String) As DataSourceView Implements IDataSource.GetView
          If view Is Nothing Then
             view = New SomeDataSourceView(Me)
          End If
          Return view
       End Function 'GetView


       Public Overridable Function GetViewNames() As ICollection Implements IDataSource.GetViewNames
          Dim al As New ArrayList(1)
          al.Add(GetView(String.Empty).Name)
          Return CType( al, ICollection)
       End Function 'GetViewNames

       Event DataSourceChanged As EventHandler Implements IDataSource.DataSourceChanged

       #End Region

       #Region "Implementation of IListSource"

       ReadOnly Property ContainsListCollection() As Boolean Implements IListSource.ContainsListCollection
          Get
             Return ListSourceHelper.ContainsListCollection(Me)
          End Get
       End Property


       Function GetList() As IList Implements IListSource.GetList
          Return ListSourceHelper.GetList(Me)
       End Function 'IListSource.GetList

       #End Region