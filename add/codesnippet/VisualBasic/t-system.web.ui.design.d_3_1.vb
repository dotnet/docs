    ' A     design-time data source view
    Public Class CustomDesignDataSourceView
        Inherits DesignerDataSourceView

        Private _data As ArrayList = Nothing

        Public Sub New(ByVal owner As CustomDataSourceDesigner, ByVal viewName As String)
            MyBase.New(owner, viewName)
        End Sub

        ' Get data for design-time display
        Public Overrides Function GetDesignTimeData( _
            ByVal minimumRows As Integer, _
            ByRef isSampleData As Boolean) As IEnumerable

            If IsNothing(_data) Then
                ' Create a set of design-time fake data
                _data = New ArrayList()
                Dim i As Integer
                For i = 1 To minimumRows
                    _data.Add(New BookItem("ID_" & i.ToString(), _
                        "Design-Time Title 0" & i.ToString()))
                Next
            End If
            isSampleData = True
            Return CType(_data, IEnumerable)
        End Function

        Public Overrides ReadOnly Property Schema() As IDataSourceViewSchema
            Get
                Return New BookListViewSchema()
            End Get
        End Property

        ' Allow getting the record count
        Public Overrides ReadOnly Property CanRetrieveTotalRowCount() As Boolean
            Get
                Return True
            End Get
        End Property
        ' Do not allow deletions
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                Return False
            End Get
        End Property
        ' Do not allow insertions
        Public Overrides ReadOnly Property CanInsert() As Boolean
            Get
                Return False
            End Get
        End Property
        ' Do not allow updates
        Public Overrides ReadOnly Property CanUpdate() As Boolean
            Get
                Return False
            End Get
        End Property
        ' Do not allow paging
        Public Overrides ReadOnly Property CanPage() As Boolean
            Get
                Return False
            End Get
        End Property
        ' Do not allow sorting
        Public Overrides ReadOnly Property CanSort() As Boolean
            Get
                Return False
            End Get
        End Property
    End Class