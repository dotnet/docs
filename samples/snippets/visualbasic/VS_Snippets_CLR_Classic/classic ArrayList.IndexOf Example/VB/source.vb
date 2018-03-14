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

        ' Search for the first occurrence of the duplicated value.
        Dim myString As [String] = "the"
        Dim myIndex As Integer = myAL.IndexOf(myString)
        Console.WriteLine("The first occurrence of ""{0}"" is at index {1}.", myString, myIndex)

        ' Search for the first occurrence of the duplicated value in the last section of the ArrayList.
        myIndex = myAL.IndexOf(myString, 4)
        Console.WriteLine("The first occurrence of ""{0}"" between index 4 and the end is at index {1}.", myString, myIndex)

        ' Search for the first occurrence of the duplicated value in a section of the ArrayList.
        myIndex = myAL.IndexOf(myString, 6, 6)
        Console.WriteLine("The first occurrence of ""{0}"" between index 6 and index 11 is at index {1}.", myString, myIndex)

        ' Search for the first occurrence of the duplicated value in a small section at the end of the ArrayList.
        myIndex = myAL.IndexOf(myString, 11)
        Console.WriteLine("The first occurrence of ""{0}"" between index 11 and the end is at index {1}.", myString, myIndex)

    End Sub 'Main

    Public Shared Sub PrintIndexAndValues(ByVal myList As IEnumerable)
        Dim i As Integer
        Dim obj As [Object]
        For Each obj In myList
            Console.WriteLine("   [{0}]:    {1}", i, obj)
            i = i + 1
        Next obj
        Console.WriteLine()
    End Sub 'PrintIndexAndValues

End Class 'SamplesArrayList

' This code produces the following output.
'
' The ArrayList contains the following values:
' 	[0]:	the
' 	[1]:	quick
' 	[2]:	brown
' 	[3]:	fox
' 	[4]:	jumps
' 	[5]:	over
' 	[6]:	the
' 	[7]:	lazy
' 	[8]:	dog
' 	[9]:	in
' 	[10]:	the
' 	[11]:	barn
' 
' The first occurrence of "the" is at index 0.
' The first occurrence of "the" between index 4 and the end is at index 6.
' The first occurrence of "the" between index 6 and index 11 is at index 6.
' The first occurrence of "the" between index 11 and the end is at index -1.
' 
' </Snippet1>