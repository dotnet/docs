' The following code example shows how Compare returns different values depending on the culture associated with the Comparer.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Globalization

Public Class SamplesComparer

   Public Shared Sub Main()

      ' Creates the strings to compare.
      Dim str1 As [String] = "llegar"
      Dim str2 As [String] = "lugar"
      Console.WriteLine("Comparing ""{0}"" and ""{1}"" ...", str1, str2)

      ' Uses the DefaultInvariant Comparer.
      Console.WriteLine("   Invariant Comparer: {0}", Comparer.DefaultInvariant.Compare(str1, str2))

      ' Uses the Comparer based on the culture "es-ES" (Spanish - Spain, international sort).
      Dim myCompIntl As New Comparer(New CultureInfo("es-ES", False))
      Console.WriteLine("   International Sort: {0}", myCompIntl.Compare(str1, str2))

      ' Uses the Comparer based on the culture identifier 0x040A (Spanish - Spain, traditional sort).
      Dim myCompTrad As New Comparer(New CultureInfo(&H40A, False))
      Console.WriteLine("   Traditional Sort  : {0}", myCompTrad.Compare(str1, str2))

   End Sub 'Main 

End Class 'SamplesComparer


'This code produces the following output.
'
'Comparing "llegar" and "lugar" ...
'   Invariant Comparer: -1
'   International Sort: -1
'   Traditional Sort  : 1

' </snippet1>