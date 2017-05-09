' The following example shows how to sort the values in a section of an <see cref="System.Collections.ArrayList" /> using the default comparer and a custom comparer which reverses the sort order.

' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList

   Public Class myReverserClass
      Implements IComparer

      ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
      Public Function Compare( ByVal x As Object, ByVal y As Object) As Integer _
         Implements IComparer.Compare
         Return New CaseInsensitiveComparer().Compare(y, x)
      End Function 'IComparer.Compare

   End Class 'myReverserClass

   Public Shared Sub Main()

      ' Creates and initializes a new ArrayList.
      Dim myAL As New ArrayList()
      myAL.Add("The")
      myAL.Add("QUICK")
      myAL.Add("BROWN")
      myAL.Add("FOX")
      myAL.Add("jumped")
      myAL.Add("over")
      myAL.Add("the")
      myAL.Add("lazy")
      myAL.Add("dog")

      ' Displays the values of the ArrayList.
      Console.WriteLine("The ArrayList initially contains the following values:")
      PrintIndexAndValues(myAL)

      ' Sorts the values of the ArrayList using the default comparer.
      myAL.Sort(1, 3, Nothing)
      Console.WriteLine("After sorting from index 1 to index 3 with the default comparer:")
      PrintIndexAndValues(myAL)

      ' Sorts the values of the ArrayList using the reverse case-insensitive comparer.
      Dim myComparer = New myReverserClass()
      myAL.Sort(1, 3, myComparer)
      Console.WriteLine("After sorting from index 1 to index 3 with the reverse case-insensitive comparer:")
      PrintIndexAndValues(myAL)

   End Sub 'Main

   Public Shared Sub PrintIndexAndValues(myList As IEnumerable)
      Dim i As Integer = 0
      Dim obj As [Object]
      For Each obj In  myList
         Console.WriteLine(vbTab + "[{0}]:" + vbTab + "{1}", i, obj)
         i = i + 1
      Next obj
      Console.WriteLine()
   End Sub 'PrintIndexAndValues

End Class 'SamplesArrayList 


'This code produces the following output.
'The ArrayList initially contains the following values:
'        [0]:    The
'        [1]:    QUICK
'        [2]:    BROWN
'        [3]:    FOX
'        [4]:    jumped
'        [5]:    over
'        [6]:    the
'        [7]:    lazy
'        [8]:    dog
'
'After sorting from index 1 to index 3 with the default comparer:
'        [0]:    The
'        [1]:    BROWN
'        [2]:    FOX
'        [3]:    QUICK
'        [4]:    jumped
'        [5]:    over
'        [6]:    the
'        [7]:    lazy
'        [8]:    dog
'
'After sorting from index 1 to index 3 with the reverse case-insensitive comparer:
'        [0]:    The
'        [1]:    QUICK
'        [2]:    FOX
'        [3]:    BROWN
'        [4]:    jumped
'        [5]:    over
'        [6]:    the
'        [7]:    lazy
'        [8]:    dog

' </Snippet1>