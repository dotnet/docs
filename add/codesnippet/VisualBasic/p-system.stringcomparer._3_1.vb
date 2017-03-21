   Private Sub CompareCurrentCultureStringComparers()
      Dim stringComparer1 As StringComparer = StringComparer.CurrentCulture
      Dim stringComparer2 As StringComparer = StringComparer.CurrentCulture
      ' Displays False
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, _
                                                       stringComparer2))
   End Sub