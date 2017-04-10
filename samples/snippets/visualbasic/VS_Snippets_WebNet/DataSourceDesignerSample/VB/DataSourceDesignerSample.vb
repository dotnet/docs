'<Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Security.Permissions
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace ASPNet.Design.Samples_VB
    <Designer(GetType(CustomDataSourceDesigner)), _
        ToolboxData("<{0}:CustomDataSource runat=""server""></{0}:CustomDataSource>")> _
    Public Class CustomDataSource
        Inherits ObjectDataSource

        Dim _defaultViewName As String = "BookList"
        Dim _view As ObjectDataSourceView = Nothing

        Public Sub New()
            MyBase.New()
        End Sub

        ' Gets a view by name
        Protected Overrides Function GetView(ByVal viewName As String) As DataSourceView
            ' This data source only allows one view
            If Not (viewName.Equals(_defaultViewName)) Then
                Return Nothing
            ElseIf IsNothing(_view) Then
                _view = New CustomDataSourceView(Me, _
                    _defaultViewName, HttpContext.Current)
            End If

            Return _view
        End Function

        ' Gets a list of view names for this class
        Protected Overrides Function GetViewNames() As ICollection
            Dim ar As New ArrayList()
            ar.Add(_defaultViewName)
            Return CType(ar, ICollection)
        End Function

    End Class

    ' The runtime data source view
    Public Class CustomDataSourceView
        Inherits ObjectDataSourceView

        Dim _data As ArrayList = Nothing

        Public Sub New(ByVal owner As CustomDataSource, ByVal viewName As String, ByVal context As HttpContext)
            MyBase.New(owner, viewName, context)
            owner.SelectCountMethod = "GetCount"
        End Sub

        ' This method would typically get a set of live data
        ' rather than create some dummy data
        Protected Overrides Function ExecuteSelect(ByVal arguments As DataSourceSelectArguments) As System.Collections.IEnumerable
            If (IsNothing(_data)) Then
                _data = New ArrayList()
                _data.Add(New BookItem("ID_1", "Runtime Title 01"))
                _data.Add(New BookItem("ID_2", "Runtime Title 02"))
                _data.Add(New BookItem("ID_3", "Runtime Title 03"))
            End If
            Return CType(_data, IEnumerable)
        End Function

        ' Allow getting the record count
        Public Overrides ReadOnly Property CanRetrieveTotalRowCount() As Boolean
            Get
                Return True
            End Get
        End Property

        ' Returns the number of records in the current set of data
        Public ReadOnly Property GetCount() As Integer
            Get
                If IsNothing(_data) Then
                    Return 0
                Else
                    Return _data.Count
                End If
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
        ' Do not allow updating
        Public Overrides ReadOnly Property CanUpdate() As Boolean
            Get
                Return False
            End Get
        End Property

    End Class

    ' A class to define a record of the data
    Public Class BookItem
        Private _id As String
        Private _title As String

        Public Sub New(ByVal id As String, ByVal title As String)
            _id = id
            _title = title
        End Sub

        Public ReadOnly Property ID() As String
            Get
                Return _id
            End Get
        End Property

        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property
    End Class

    ' Custom designer for the CustomDataSource control.
    Public Class CustomDataSourceDesigner
        Inherits DataSourceDesigner

        Private _control As CustomDataSource = Nothing
        Private _defaultViewName As String = "BookList"
        Private _view As CustomDesignDataSourceView = Nothing

        Public Overrides Sub Initialize(ByVal cmponent As IComponent)
            MyBase.Initialize(cmponent)
            _control = CType(cmponent, CustomDataSource)
        End Sub

        ' Get a view
        Public Overrides Function GetView(ByVal viewName As String) As DesignerDataSourceView
            If Not (viewName.Equals(_defaultViewName)) Then
                Return Nothing
            ElseIf IsNothing(_view) Then
                _view = New CustomDesignDataSourceView(Me, _
                    _defaultViewName)
            End If

            Return _view
        End Function

        ' Get a list of view names
        Public Overrides Function GetViewNames() As String()
            Return New String() {"BookList"}
        End Function

        ' Don't allow refreshing the schema
        Public Overrides ReadOnly Property CanRefreshSchema() As Boolean
            Get
                Return False
            End Get
        End Property
        ' Do not allow resizing
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                Return False
            End Get
        End Property
    End Class

    '<Snippet2>
    ' A     design-time data source view
    Public Class CustomDesignDataSourceView
        Inherits DesignerDataSourceView

        Private _data As ArrayList = Nothing

        Public Sub New(ByVal owner As CustomDataSourceDesigner, ByVal viewName As String)
            MyBase.New(owner, viewName)
        End Sub

        '<Snippet3>
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
        '</Snippet3>

        '<Snippet4>
        Public Overrides ReadOnly Property Schema() As IDataSourceViewSchema
            Get
                Return New BookListViewSchema()
            End Get
        End Property
        '</Snippet4>

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
    '</Snippet2>

    '<Snippet5>
    ' A custom View Schema class
    Public Class BookListViewSchema
        Implements IDataSourceViewSchema

        Public Sub New()
        End Sub

        ' The name of this View Schema
        Public ReadOnly Property Name() As String Implements IDataSourceViewSchema.Name
            Get
                Return "BookList"
            End Get
        End Property

        ' Build a Field Schema array
        Public Function GetFields() As IDataSourceFieldSchema() Implements IDataSourceViewSchema.GetFields
            Dim fields(1) As IDataSourceFieldSchema
            fields(0) = New CustomIDFieldSchema()
            fields(1) = New CustomTitleFieldSchema()
            Return fields
        End Function
        ' There are no child views, so return Nothing
        Public Function GetChildren() As IDataSourceViewSchema() Implements IDataSourceViewSchema.GetChildren
            Return Nothing
        End Function
    End Class

    ' A custom Field Schema class for ID
    Public Class CustomIDFieldSchema
        Implements IDataSourceFieldSchema

        Public Sub New()
        End Sub

        ' Name is ID
        Public ReadOnly Property Name() As String Implements IDataSourceFieldSchema.Name
            Get
                Return "ID"
            End Get
        End Property
        ' Data type is string
        Public ReadOnly Property DataType() As Type Implements IDataSourceFieldSchema.DataType
            Get
                Return GetType(String)
            End Get
        End Property
        ' This is not an Identity field
        Public ReadOnly Property Identity() As Boolean Implements IDataSourceFieldSchema.Identity
            Get
                Return False
            End Get
        End Property
        ' This field is read only
        Public ReadOnly Property IsReadOnly() As Boolean Implements IDataSourceFieldSchema.IsReadOnly
            Get
                Return True
            End Get
        End Property
        ' This field is unique
        Public ReadOnly Property IsUnique() As Boolean Implements IDataSourceFieldSchema.IsUnique
            Get
                Return True
            End Get
        End Property
        ' This field can't be longer than 20
        Public ReadOnly Property Length() As Integer Implements IDataSourceFieldSchema.Length
            Get
                Return 20
            End Get
        End Property
        ' This field can't be null
        Public ReadOnly Property Nullable() As Boolean Implements IDataSourceFieldSchema.Nullable
            Get
                Return False
            End Get
        End Property
        ' This is a Primary Key
        Public ReadOnly Property PrimaryKey() As Boolean Implements IDataSourceFieldSchema.PrimaryKey
            Get
                Return True
            End Get
        End Property

        ' These properties do not apply
        Public ReadOnly Property Precision() As Integer Implements IDataSourceFieldSchema.Precision
            Get
                Return -1
            End Get
        End Property
        Public ReadOnly Property Scale() As Integer Implements IDataSourceFieldSchema.Scale
            Get
                Return -1
            End Get
        End Property
    End Class

    ' A custom Field Schema class for Title
    Public Class CustomTitleFieldSchema
        Implements IDataSourceFieldSchema

        Public Sub New()
        End Sub

        ' Name is Title
        Public ReadOnly Property Name() As String Implements IDataSourceFieldSchema.Name
            Get
                Return "Title"
            End Get
        End Property
        ' Type is string
        Public ReadOnly Property DataType() As Type Implements IDataSourceFieldSchema.DataType
            Get
                Return GetType(String)
            End Get
        End Property
        ' This is not an Identity field
        Public ReadOnly Property Identity() As Boolean Implements IDataSourceFieldSchema.Identity
            Get
                Return False
            End Get
        End Property
        ' This field is not read only
        Public ReadOnly Property IsReadOnly() As Boolean Implements IDataSourceFieldSchema.IsReadOnly
            Get
                Return False
            End Get
        End Property
        ' This field is not unique
        Public ReadOnly Property IsUnique() As Boolean Implements IDataSourceFieldSchema.IsUnique
            Get
                Return False
            End Get
        End Property
        ' This field can't be longer than 100
        Public ReadOnly Property Length() As Integer Implements IDataSourceFieldSchema.Length
            Get
                Return 100
            End Get
        End Property
        ' This field can't be null
        Public ReadOnly Property Nullable() As Boolean Implements IDataSourceFieldSchema.Nullable
            Get
                Return False
            End Get
        End Property
        ' This is not the Primary Key
        Public ReadOnly Property PrimaryKey() As Boolean Implements IDataSourceFieldSchema.PrimaryKey
            Get
                Return False
            End Get
        End Property

        ' These properties do not apply
        Public ReadOnly Property Precision() As Integer Implements IDataSourceFieldSchema.Precision
            Get
                Return -1
            End Get
        End Property
        Public ReadOnly Property Scale() As Integer Implements IDataSourceFieldSchema.Scale
            Get
                Return -1
            End Get
        End Property
    End Class
    '</Snippet5>

End Namespace
'</Snippet1>