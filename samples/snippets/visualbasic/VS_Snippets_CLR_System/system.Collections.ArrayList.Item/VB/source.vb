'<Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class Example

    Public Shared Sub Main

        ' Create an empty ArrayList, and add some elements.
        Dim stringList As New ArrayList

        stringList.Add("a")
        stringList.Add("abc")
        stringList.Add("abcdef")
        stringList.Add("abcdefg")

        ' Item is the default property, so the property name is
        ' not required.
        Console.WriteLine("Element {0} is ""{1}""", 2, stringList(2))

        ' Assigning a value to the property changes the value of
        ' the indexed element.
        stringList(2) = "abcd"
        Console.WriteLine("Element {0} is ""{1}""", 2, stringList(2))

        ' Accessing an element outside the current element count
        ' causes an exception. The ArrayList index is zero-based,
        ' so the index of the last element is (Count - 1). 
        Console.WriteLine("Number of elements in the list: {0}", _
            stringList.Count)
        Try
            Console.WriteLine("Element {0} is ""{1}""", _
                stringList.Count, _
                stringList(stringList.Count))
        Catch aoore As ArgumentOutOfRangeException
            Console.WriteLine("stringList({0}) is out of range.", _
                stringList.Count)
        End Try

        ' You cannot use the Item property to add new elements.
        Try
            stringList(stringList.Count) = "42"
        Catch aoore As ArgumentOutOfRangeException
            Console.WriteLine("stringList({0}) is out of range.", _
                stringList.Count)
        End Try

        Console.WriteLine()
        For i As Integer = 0 To stringList.Count - 1
            Console.WriteLine("Element {0} is ""{1}""", i, stringList(i))
        Next

        Console.WriteLine()
        For Each o As Object In stringList
            Console.WriteLine(o)
        Next

    End Sub

End Class
'
' This code example produces the following output:
'
'Element 2 is "abcdef"
'Element 2 is "abcd"
'Number of elements in the list: 4
'stringList(4) is out of range.
'stringList(4) is out of range.
'
'Element 0 is "a"
'Element 1 is "abc"
'Element 2 is "abcd"
'Element 3 is "abcdefg"
'
'a
'abc
'abcd
'abcdefg
'</Snippet1>
