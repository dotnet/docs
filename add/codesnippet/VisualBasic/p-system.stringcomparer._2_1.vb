   Private Sub CompareCurrentCultureInsensitiveStringComparers()
      Dim stringComparer1, stringComparer2 As StringComparer
      stringComparer1 = StringComparer.CurrentCultureIgnoreCase
      stringComparer2 = StringComparer.CurrentCultureIgnoreCase
      ' Displays False
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, _
                                                       stringComparer2))
   End Sub