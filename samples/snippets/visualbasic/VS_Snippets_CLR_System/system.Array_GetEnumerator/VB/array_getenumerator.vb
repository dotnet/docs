' The following example shows how to use GetEnumerator to list the elements of an array.

' <Snippet1>
Imports System

Public Class SamplesArray

   Public Shared Sub Main()

      ' Creates and initializes a new Array.
      Dim myArr(10) As [String]
      myArr(0) = "The"
      myArr(1) = "quick"
      myArr(2) = "brown"
      myArr(3) = "fox"
      myArr(4) = "jumped"
      myArr(5) = "over"
      myArr(6) = "the"
      myArr(7) = "lazy"
      myArr(8) = "dog"

      ' Displays the values of the Array.
      Dim i As Integer = 0
      Dim myEnumerator As System.Collections.IEnumerator = myArr.GetEnumerator()
      Console.WriteLine("The Array contains the following values:")
      While myEnumerator.MoveNext() And Not (myEnumerator.Current Is Nothing)
         Console.WriteLine("[{0}] {1}", i, myEnumerator.Current)
         i += 1
      End While 

   End Sub 'Main

End Class 'SamplesArray 


'This code produces the following output.
'
'The Array contains the following values:
'[0] The
'[1] quick
'[2] brown
'[3] fox
'[4] jumped
'[5] over
'[6] the
'[7] lazy
'[8] dog

' </Snippet1>