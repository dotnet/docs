' The following code example compares SortKey objects created with cultures that have different sort orders.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesSortKey

   Public Shared Sub Main()

      ' Creates a SortKey using the en-US culture.
      Dim myComp_enUS As CompareInfo = New CultureInfo("en-US", False).CompareInfo
      Dim mySK1 As SortKey = myComp_enUS.GetSortKey("llama")

      ' Creates a SortKey using the es-ES culture with international sort.
      Dim myComp_esES As CompareInfo = New CultureInfo("es-ES", False).CompareInfo
      Dim mySK2 As SortKey = myComp_esES.GetSortKey("llama")

      ' Creates a SortKey using the es-ES culture with traditional sort.
      Dim myComp_es As CompareInfo = New CultureInfo(&H40A, False).CompareInfo
      Dim mySK3 As SortKey = myComp_es.GetSortKey("llama")

      ' Compares the en-US SortKey with each of the es-ES SortKey objects.
      Console.WriteLine("Comparing ""llama"" in en-US and in es-ES with international sort : {0}", SortKey.Compare(mySK1, mySK2))
      Console.WriteLine("Comparing ""llama"" in en-US and in es-ES with traditional sort   : {0}", SortKey.Compare(mySK1, mySK3))

   End Sub 'Main 

End Class 'SamplesSortKey


'This code produces the following output.
'
'Comparing "llama" in en-US and in es-ES with international sort : 0
'Comparing "llama" in en-US and in es-ES with traditional sort   : -1

' </snippet1>
