' The following example shows how to sort the values in an <see cref="System.Collections.ArrayList" /> using the default comparer and a custom comparer which reverses the sort order.

' <Snippet1>
Imports System.Collections

Public Class SamplesArrayList

   Public Class myReverserClass
      Implements IComparer

      ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
      Public Function Compare( ByVal x As Object, ByVal y As Object) As Integer _
         Implements IComparer.Compare
         Return New CaseInsensitiveComparer().Compare(y, x)
      End Function 'IComparer.Compare

   End Class

   Public Shared Sub Main()

      ' Creates and initializes a new ArrayList.
      Dim myAL As New ArrayList()
      myAL.Add("The")
      myAL.Add("quick")
      myAL.Add("brown")
      myAL.Add("fox")
      myAL.Add("jumps")
      myAL.Add("over")
      myAL.Add("the")
      myAL.Add("lazy")
      myAL.Add("dog")

      ' Displays the values of the ArrayList.
      Console.WriteLine("The ArrayList initially contains the following values:")
      PrintIndexAndValues(myAL)

      ' Sorts the values of the ArrayList using the default comparer.
      myAL.Sort()
      Console.WriteLine("After sorting with the default comparer:")
      PrintIndexAndValues(myAL)

      ' Sorts the values of the ArrayList using the reverse case-insensitive comparer.
      Dim myComparer = New myReverserClass()
      myAL.Sort(myComparer)
      Console.WriteLine("After sorting with the reverse case-insensitive comparer:")
      PrintIndexAndValues(myAL)

   End Sub

   Public Shared Sub PrintIndexAndValues(myList As IEnumerable)
      Dim i As Integer = 0
      Dim obj As [Object]
      For Each obj In  myList
         Console.WriteLine(vbTab + "[{0}]:" + vbTab + "{1}", i, obj)
         i = i + 1
      Next obj
      Console.WriteLine()
   End Sub

End Class


'This code produces the following output.
'The ArrayList initially contains the following values:
'        [0]:    The
'        [1]:    quick
'        [2]:    brown
'        [3]:    fox
'        [4]:    jumps
'        [5]:    over
'        [6]:    the
'        [7]:    lazy
'        [8]:    dog
'
'After sorting with the default comparer:
'        [0]:    brown
'        [1]:    dog
'        [2]:    fox
'        [3]:    jumps
'        [4]:    lazy
'        [5]:    over
'        [6]:    quick
'        [7]:    the
'        [8]:    The
'
'After sorting with the reverse case-insensitive comparer:
'        [0]:    the
'        [1]:    The
'        [2]:    quick
'        [3]:    over
'        [4]:    lazy
'        [5]:    jumps
'        [6]:    fox
'        [7]:    dog
'        [8]:    brown

' </Snippet1>
