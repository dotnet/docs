  Public Class class1
      Private myStrings() As String
      Sub New(ByVal size As Integer)
          ReDim myStrings(size)
      End Sub
      Default Property myProperty(ByVal index As Integer) As String
          Get
              ' The Get property procedure is called when the value
              ' of the property is retrieved.
              Return myStrings(index)
          End Get
          Set(ByVal Value As String)
              ' The Set property procedure is called when the value
              ' of the property is modified.
              ' The value to be assigned is passed in the argument 
              ' to Set.
              myStrings(index) = Value
          End Set
      End Property
  End Class