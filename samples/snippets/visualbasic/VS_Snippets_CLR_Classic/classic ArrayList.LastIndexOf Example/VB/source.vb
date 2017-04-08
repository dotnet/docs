' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList
   
   Public Shared Sub Main()
      
      ' Creates and initializes a new ArrayList with three elements of the same value.
      Dim myAL As New ArrayList()
      myAL.Add("the")
      myAL.Add("quick")
      myAL.Add("brown")
      myAL.Add("fox")
      myAL.Add("jumps")
      myAL.Add("over")
      myAL.Add("the")
      myAL.Add("lazy")
      myAL.Add("dog")
      myAL.Add("in")
      myAL.Add("the")
      myAL.Add("barn")
      
      ' Displays the values of the ArrayList.
      Console.WriteLine("The ArrayList contains the following values:")
      PrintIndexAndValues(myAL)
      
      ' Searches for the last occurrence of the duplicated value.
      Dim myString As [String] = "the"
      Dim myIndex As Integer = myAL.LastIndexOf(myString)
      Console.WriteLine("The last occurrence of ""{0}"" is at index {1}.", myString, myIndex)
      
      ' Searches for the last occurrence of the duplicated value in the first section of the ArrayList.
      myIndex = myAL.LastIndexOf(myString, 8)
      Console.WriteLine("The last occurrence of ""{0}"" between the start and index 8 is at index {1}.", myString, myIndex)
      
      ' Searches for the last occurrence of the duplicated value in a section of the ArrayList.  Note that the start index is greater than the end index because the search is done backward.
      myIndex = myAL.LastIndexOf(myString, 10, 6)
      Console.WriteLine("The last occurrence of ""{0}"" between index 10 and index 5 is at index {1}.", myString, myIndex)
   End Sub 'Main
   
   
   Public Shared Sub PrintIndexAndValues(myList As IEnumerable)
      Dim i as Integer
      Dim obj As [Object]
      For Each obj In  myList
         Console.WriteLine("   [{0}]:    {1}", i, obj)
         i = i + 1
      Next obj
      Console.WriteLine()
   End Sub 'PrintIndexAndValues

End Class 'SamplesArrayList

' This code produces the following output.
'
' The ArrayList contains the following values:
'    [0]:    the
'    [1]:    quick
'    [2]:    brown
'    [3]:    fox
'    [4]:    jumps
'    [5]:    over
'    [6]:    the
'    [7]:    lazy
'    [8]:    dog
'    [9]:    in
'    [10]:    the
'    [11]:    barn
'
' The last occurrence of "the" is at index 10.
' The last occurrence of "the" between the start and index 8 is at index 6.
' The last occurrence of "the" between index 10 and index 5 is at index 10.

' </Snippet1>