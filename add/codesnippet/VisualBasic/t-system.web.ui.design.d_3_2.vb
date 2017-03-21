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