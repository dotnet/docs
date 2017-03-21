   ' Customizes the use of CustomSection
    ' by setting _ReadOnly to false.
   ' Remember you must use it along with ThrowIfReadOnly.
   Protected Overrides Function GetRuntimeObject() As Object
      ' To enable property setting just assign true to
      ' the following flag.
      _ReadOnly = True
      Return MyBase.GetRuntimeObject()
   End Function 'GetRuntimeObject
   