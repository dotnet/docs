' The following example shows how to copy the elements of an ArrayList to a string array.
' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesArrayList

    Public Shared Sub Main()

        ' Creates and initializes a new ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("The")
        myAL.Add("quick")
        myAL.Add("brown")
        myAL.Add("fox")
        myAL.Add("jumped")
        myAL.Add("over")
        myAL.Add("the")
        myAL.Add("lazy")
        myAL.Add("dog")

        ' Displays the values of the ArrayList.
        Console.WriteLine("The ArrayList contains the following values:")
        PrintIndexAndValues(myAL)

        ' Copies the elements of the ArrayList to a string array.
        Dim myArr As String() = CType(myAL.ToArray(GetType(String)), String())

        ' Displays the contents of the string array.
        Console.WriteLine("The string array contains the following values:")
        PrintIndexAndValues(myArr)

    End Sub 'Main

    Overloads Public Shared Sub PrintIndexAndValues(myList As ArrayList)
        Dim i As Integer = 0
        Dim o As [Object]
        For Each o In  myList
            Console.WriteLine("        [{0}]:    {1}", i, o)
            i = i + 1
        Next o
        Console.WriteLine()
    End Sub 'PrintIndexAndValues

    Overloads Public Shared Sub PrintIndexAndValues(myArr() As String)
        Dim i As Integer
        For i = 0 To myArr.Length - 1
            Console.WriteLine("        [{0}]:    {1}", i, myArr(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintIndexAndValues

End Class 'SamplesArrayList


'This code produces the following output.
'
'The ArrayList contains the following values:
'        [0]:    The
'        [1]:    quick
'        [2]:    brown
'        [3]:    fox
'        [4]:    jumped
'        [5]:    over
'        [6]:    the
'        [7]:    lazy
'        [8]:    dog
'
'The string array contains the following values:
'        [0]:    The
'        [1]:    quick
'        [2]:    brown
'        [3]:    fox
'        [4]:    jumped
'        [5]:    over
'        [6]:    the
'        [7]:    lazy
'        [8]:    dog

' </Snippet1>