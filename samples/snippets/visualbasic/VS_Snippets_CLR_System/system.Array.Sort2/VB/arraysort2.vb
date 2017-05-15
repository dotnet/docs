' The following example shows how to sort two associated arrays
' where the first array contains the keys and the second array contains the values.
' Sorts are done using the default comparer and a custom comparer that reverses the sort order.

' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesArray

   Public Class myReverserClass
      Implements IComparer

      ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
      Function Compare(x As [Object], y As [Object]) As Integer _
         Implements IComparer.Compare
         Return New CaseInsensitiveComparer().Compare(y, x)
      End Function 'IComparer.Compare

   End Class 'myReverserClass


   Public Shared Sub Main()

      ' Creates and initializes a new Array and a new custom comparer.
      Dim myKeys As [String]() =  {"red", "GREEN", "YELLOW", "BLUE", "purple", "black", "orange"}
      Dim myValues As [String]() =  {"strawberries", "PEARS", "LIMES", "BERRIES", "grapes", "olives", "cantaloupe"}
      Dim myComparer = New myReverserClass()

      ' Displays the values of the Array.
      Console.WriteLine("The Array initially contains the following values:")
      PrintKeysAndValues(myKeys, myValues)

      ' Sorts a section of the Array using the default comparer.
      Array.Sort(myKeys, myValues, 1, 3)
      Console.WriteLine("After sorting a section of the Array using the default comparer:")
      PrintKeysAndValues(myKeys, myValues)

      ' Sorts a section of the Array using the reverse case-insensitive comparer.
      Array.Sort(myKeys, myValues, 1, 3, myComparer)
      Console.WriteLine("After sorting a section of the Array using the reverse case-insensitive comparer:")
      PrintKeysAndValues(myKeys, myValues)

      ' Sorts the entire Array using the default comparer.
      Array.Sort(myKeys, myValues)
      Console.WriteLine("After sorting the entire Array using the default comparer:")
      PrintKeysAndValues(myKeys, myValues)

      ' Sorts the entire Array using the reverse case-insensitive comparer.
      Array.Sort(myKeys, myValues, myComparer)
      Console.WriteLine("After sorting the entire Array using the reverse case-insensitive comparer:")
      PrintKeysAndValues(myKeys, myValues)

   End Sub 'Main


   Public Shared Sub PrintKeysAndValues(myKeys() As [String], myValues() As [String])

      Dim i As Integer
      For i = 0 To myKeys.Length - 1
         Console.WriteLine("   {0,-10}: {1}", myKeys(i), myValues(i))
      Next i
      Console.WriteLine()

   End Sub 'PrintKeysAndValues

End Class 'SamplesArray


'This code produces the following output.
'
'The Array initially contains the following values:
'   red       : strawberries
'   GREEN     : PEARS
'   YELLOW    : LIMES
'   BLUE      : BERRIES
'   purple    : grapes
'   black     : olives
'   orange    : cantaloupe
'
'After sorting a section of the Array using the default comparer:
'   red       : strawberries
'   BLUE      : BERRIES
'   GREEN     : PEARS
'   YELLOW    : LIMES
'   purple    : grapes
'   black     : olives
'   orange    : cantaloupe
'
'After sorting a section of the Array using the reverse case-insensitive comparer:
'   red       : strawberries
'   YELLOW    : LIMES
'   GREEN     : PEARS
'   BLUE      : BERRIES
'   purple    : grapes
'   black     : olives
'   orange    : cantaloupe
'
'After sorting the entire Array using the default comparer:
'   black     : olives
'   BLUE      : BERRIES
'   GREEN     : PEARS
'   orange    : cantaloupe
'   purple    : grapes
'   red       : strawberries
'   YELLOW    : LIMES
'
'After sorting the entire Array using the reverse case-insensitive comparer:
'   YELLOW    : LIMES
'   red       : strawberries
'   purple    : grapes
'   orange    : cantaloupe
'   GREEN     : PEARS
'   BLUE      : BERRIES
'   black     : olives

' </Snippet1>
