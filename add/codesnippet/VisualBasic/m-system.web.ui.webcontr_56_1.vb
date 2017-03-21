   ' The Value property is a type safe convenience property
   ' used when the StaticParameter represents string data.
   ' It gets the string value of the DataValue property, and
   ' sets the DataValue property directly.
   Public Property Value() As String
      Get
         Dim o As Object = DataValue
         If o Is Nothing OrElse Not TypeOf o Is String Then
            Return String.Empty
         End If
         Return CStr(o)
      End Get
      Set
         DataValue = value
         OnParameterChanged()
      End Set
   End Property