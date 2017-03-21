   ' The StaticParameter(string, TypeCode, object) constructor
   ' initializes the DataValue property and calls the
   ' Parameter(string, TypeCode) constructor to initialize the Name and
   ' Type properties.
   Public Sub New(name As String, type As TypeCode, value As Object)
      MyBase.New(name, type)
      DataValue = value
   End Sub