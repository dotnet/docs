   ' The StaticParameter copy constructor is provided to ensure that
   ' the state contained in the DataValue property is copied to new
   ' instances of the class.
   Protected Sub New(original As StaticParameter)
      MyBase.New(original)
      DataValue = original.DataValue
   End Sub

   ' The Clone method is overridden to call the
   ' StaticParameter copy constructor, so that the data in
   ' the DataValue property is correctly transferred to the
   ' new instance of the StaticParameter.
   Protected Overrides Function Clone() As Parameter
      Return New StaticParameter(Me)
   End Function