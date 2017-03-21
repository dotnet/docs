Public Class SampleObject
   Private stringValue As String = Nothing
   Private intValue As Integer = Integer.MinValue
   Private childValue As SampleObject = Nothing
   
   
   Public Property StringProperty() As String
      Get
         Return Me.stringValue
      End Get 
      Set
         Me.stringValue = value
      End Set
   End Property 
   
   Public Property IntProperty() As Integer
      Get
         Return Me.intValue
      End Get 
      Set
         Me.intValue = value
      End Set
   End Property 
   
   Public Property Child() As SampleObject
      Get
         Return Me.childValue
      End Get 
      Set
         Me.childValue = value
      End Set
   End Property
End Class 