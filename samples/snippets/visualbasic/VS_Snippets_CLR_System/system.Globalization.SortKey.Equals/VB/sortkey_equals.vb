' The following code example shows the results of SortKey.Equals when compared with different SortKey objects.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesSortKey

   Public Shared Sub Main()

      ' Creates two identical en-US cultures and one de-DE culture.
      Dim myComp_enUS1 As CompareInfo = New CultureInfo("en-US", False).CompareInfo
      Dim myComp_enUS2 As CompareInfo = New CultureInfo("en-US", False).CompareInfo
      Dim myComp_deDE As CompareInfo = New CultureInfo("de-DE", False).CompareInfo

      ' Creates the base SortKey to compare with all the others.
      Dim mySK1 As SortKey = myComp_enUS1.GetSortKey("cant", CompareOptions.StringSort)
      ' Creates a SortKey that is derived exactly the same way as the base SortKey.
      Dim mySK2 As SortKey = myComp_enUS1.GetSortKey("cant", CompareOptions.StringSort)
      ' Creates a SortKey that uses word sort, which is the default sort.
      Dim mySK3 As SortKey = myComp_enUS1.GetSortKey("cant")
      ' Creates a SortKey for a different string.
      Dim mySK4 As SortKey = myComp_enUS1.GetSortKey("can't", CompareOptions.StringSort)
      ' Creates a SortKey from a different CompareInfo with the same culture.
      Dim mySK5 As SortKey = myComp_enUS2.GetSortKey("cant", CompareOptions.StringSort)
      ' Creates a SortKey from a different CompareInfo with a different culture.
      Dim mySK6 As SortKey = myComp_deDE.GetSortKey("cant", CompareOptions.StringSort)

      ' Compares the base SortKey with itself.
      Console.WriteLine("Comparing the base SortKey with itself: {0}", mySK1.Equals(mySK1))
      Console.WriteLine()

      ' Prints the header for the table.
      Console.WriteLine("CompareInfo   Culture      OriginalString   CompareOptions   Equals()")

      ' Compares the base SortKey with a SortKey that is
      '    created from the same CompareInfo with the same string and the same CompareOptions.
      Console.WriteLine("same          same         same             same             {0}", mySK1.Equals(mySK2))

      ' Compares the base SortKey with a SortKey that is 
      '    created from the same CompareInfo with the same string but with different CompareOptions.
      Console.WriteLine("same          same         same             different        {0}", mySK1.Equals(mySK3))

      ' Compares the base SortKey with a SortKey that is 
      '    created from the same CompareInfo with the different string 
      '    but with the same CompareOptions.
      Console.WriteLine("same          same         different        same             {0}", mySK1.Equals(mySK4))

      ' Compares the base SortKey with a SortKey that is 
      '    created from a different CompareInfo (same culture) 
      '    with the same string and the same CompareOptions.
      Console.WriteLine("different     same         same             same             {0}", mySK1.Equals(mySK5))

      ' Compares the base SortKey with a SortKey that is 
      '    created from a different CompareInfo (different culture) 
      '    with the same string and the same CompareOptions.
      Console.WriteLine("different     different    same             same             {0}", mySK1.Equals(mySK6))

   End Sub 'Main 

End Class 'SamplesSortKey


'This code produces the following output.
'
'Comparing the base SortKey with itself: True
'
'CompareInfo   Culture      OriginalString   CompareOptions   Equals()
'same          same         same             same             True
'same          same         same             different        False
'same          same         different        same             False
'different     same         same             same             True
'different     different    same             same             False

' </snippet1>
