   ' The CsvDataSourceView does not currently
   ' permit insertion of a new record. You can
   ' modify or extend this sample to do so.
   Public Overrides ReadOnly Property CanInsert() As Boolean
      Get
         Return False
      End Get
   End Property

   Protected Overrides Function ExecuteInsert(values As IDictionary) As Integer
      Throw New NotSupportedException()
   End Function 'ExecuteInsert