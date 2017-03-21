Private pApplicationName As String

Public Overrides Property ApplicationName As String 
  Get
    Return pApplicationName
  End Get
  Set
    pApplicationName = value
  End Set
End Property