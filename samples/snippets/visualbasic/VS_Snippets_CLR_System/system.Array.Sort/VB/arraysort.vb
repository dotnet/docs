' The following example shows how to sort the values in an array using the default comparer
' and a custom comparer that reverses the sort order.

' <Snippet1>
Imports System.Collections

Public Class ReverseComparer : Implements IComparer
   ' Call CaseInsensitiveComparer.Compare with the parameters reversed.
   Function Compare(x As Object, y As Object) As Integer _
            Implements IComparer.Compare
      Return New CaseInsensitiveComparer().Compare(y, x)
   End Function 
End Class

Public Module Example
   Public Sub Main()
      ' Create and initialize a new array.
      Dim words() As String =  { "The", "QUICK", "BROWN", "FOX", "jumps", 
                                 "over", "the", "lazy", "dog" }
      ' Instantiate a new custom comparer.
      Dim revComparer As New ReverseComparer()

      ' Display the values of the array.
      Console.WriteLine( "The original order of elements in the array:" )
      DisplayValues(words)

      ' Sort a section of the array using the default comparer.
      Array.Sort(words, 1, 3)
      Console.WriteLine( "After sorting elements 1-3 by using the default comparer:")
      DisplayValues(words)

      ' Sort a section of the array using the reverse case-insensitive comparer.
      Array.Sort(words, 1, 3, revComparer)
      Console.WriteLine( "After sorting elements 1-3 by using the reverse case-insensitive comparer:")
      DisplayValues(words)

      ' Sort the entire array using the default comparer.
      Array.Sort(words)
      Console.WriteLine( "After sorting the entire array by using the default comparer:")
      DisplayValues(words)

      ' Sort the entire array by using the reverse case-insensitive comparer.
      Array.Sort(words, revComparer)
      Console.WriteLine( "After sorting the entire array using the reverse case-insensitive comparer:")
      DisplayValues(words)
   End Sub 

   Public Sub DisplayValues(arr() As String)
      For i As Integer = arr.GetLowerBound(0) To arr.GetUpperBound(0)
         Console.WriteLine("   [{0}] : {1}", i, arr(i))
      Next 
      Console.WriteLine()
   End Sub 
End Module 
' The example displays the following output:
'    The original order of elements in the array:
'       [0] : The
'       [1] : QUICK
'       [2] : BROWN
'       [3] : FOX
'       [4] : jumps
'       [5] : over
'       [6] : the
'       [7] : lazy
'       [8] : dog
'    
'    After sorting elements 1-3 by using the default comparer:
'       [0] : The
'       [1] : BROWN
'       [2] : FOX
'       [3] : QUICK
'       [4] : jumps
'       [5] : over
'       [6] : the
'       [7] : lazy
'       [8] : dog
'    
'    After sorting elements 1-3 by using the reverse case-insensitive comparer:
'       [0] : The
'       [1] : QUICK
'       [2] : FOX
'       [3] : BROWN
'       [4] : jumps
'       [5] : over
'       [6] : the
'       [7] : lazy
'       [8] : dog
'    
'    After sorting the entire array by using the default comparer:
'       [0] : BROWN
'       [1] : dog
'       [2] : FOX
'       [3] : jumps
'       [4] : lazy
'       [5] : over
'       [6] : QUICK
'       [7] : the
'       [8] : The
'    
'    After sorting the entire array using the reverse case-insensitive comparer:
'       [0] : the
'       [1] : The
'       [2] : QUICK
'       [3] : over
'       [4] : lazy
'       [5] : jumps
'       [6] : FOX
'       [7] : dog
'       [8] : BROWN
' </Snippet1>