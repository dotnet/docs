' Visual Basic .NET Document
Option Strict On

Module StringComparerTest
   Public Sub Main()
      CompareCurrentCultureStringComparers()
      CompareCurrentCultureInsensitiveStringComparers()
   End Sub
   
   ' <Snippet1>
   Private Sub CompareCurrentCultureStringComparers()
      Dim stringComparer1 As StringComparer = StringComparer.CurrentCulture
      Dim stringComparer2 As StringComparer = StringComparer.CurrentCulture
      ' Displays False
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, _
                                                       stringComparer2))
   End Sub
   ' </Snippet1>
   
   ' <Snippet2>
   Private Sub CompareCurrentCultureInsensitiveStringComparers()
      Dim stringComparer1, stringComparer2 As StringComparer
      stringComparer1 = StringComparer.CurrentCultureIgnoreCase
      stringComparer2 = StringComparer.CurrentCultureIgnoreCase
      ' Displays False
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, _
                                                       stringComparer2))
   End Sub
   ' </Snippet2>
End Module

