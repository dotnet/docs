  ' The StaticParameter(string, object) constructor
  ' initializes the DataValue property and calls the
  ' Parameter(string) constructor to initialize the Name property.
   Public Sub New(name As String, value As Object)
      MyBase.New(name)
      DataValue = value
   End Sub