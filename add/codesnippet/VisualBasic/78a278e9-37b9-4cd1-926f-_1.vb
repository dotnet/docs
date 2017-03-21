  Public Class NorthwindEmployee

    Public Sub New()
    End Sub 'New 

    Private _employeeID As Integer
    <DataObjectFieldAttribute(True, True, False)> _
    Public Property EmployeeID() As Integer
      Get
        Return _employeeID
      End Get
      Set(ByVal value As Integer)
        _employeeID = value
      End Set
    End Property

    Private _firstName As String = String.Empty
    <DataObjectFieldAttribute(False, False, False)> _
    Public Property FirstName() As String
      Get
        Return _firstName
      End Get
      Set(ByVal value As String)
        _firstName = value
      End Set
    End Property

    Private _lastName As String = String.Empty
    <DataObjectFieldAttribute(False, False, False)> _
    Public Property LastName() As String
      Get
        Return _lastName
      End Get
      Set(ByVal value As String)
        _lastName = value
      End Set
    End Property

  End Class 'NorthwindEmployee