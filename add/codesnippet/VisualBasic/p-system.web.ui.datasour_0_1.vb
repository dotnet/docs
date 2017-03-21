   ' The CsvDataSourceView does not currently
   ' permit update operations. You can modify or
   ' extend this sample to do so.
   Public Overrides ReadOnly Property CanUpdate() As Boolean
      Get
         Return False
      End Get
   End Property

   Protected Overrides Function ExecuteUpdate(keys As IDictionary, _
                                              values As IDictionary, _
                                              oldValues As IDictionary) As Integer
      Throw New NotSupportedException()
   End Function 'ExecuteUpdate

End Class 'CsvDataSourceView