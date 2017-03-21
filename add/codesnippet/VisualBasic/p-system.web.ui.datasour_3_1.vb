   ' The CsvDataSourceView does not currently
   ' permit deletion. You can modify or extend
   ' this sample to do so.
   Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
         Return False
      End Get
   End Property

   Protected Overrides Function ExecuteDelete(keys As IDictionary, values As IDictionary) As Integer
      Throw New NotSupportedException()
   End Function 'ExecuteDelete