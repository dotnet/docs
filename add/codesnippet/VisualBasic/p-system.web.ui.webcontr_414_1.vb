   ' The DataValue can be any arbitrary object and is stored in ViewState.
   Public Property DataValue() As Object
      Get
         Return ViewState("Value")
      End Get
      Set
         ViewState("Value") = value
      End Set
   End Property