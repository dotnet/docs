'<Snippet2>
Imports System
Imports System.Collections

Public Class ScrambleList
    Inherits ArrayList

    Public Shared Sub Main()
        ' Create an empty ArrayList, and add some elements.
        Dim integerList As New ScrambleList()

        For i As Integer = 0 To 9
            integerList.Add(i)
        Next i

        Console.WriteLine("Ordered:" + vbNewLine)
        For Each value As Integer In integerList
            Console.Write("{0}, ", value)
        Next value
        Console.WriteLine("<end>" + vbNewLine + vbNewLine + "Scrambled:" + vbNewLine)

        ' Scramble the order of the items in the list.
        integerList.Scramble()

        For Each value As Integer In integerList
            Console.Write("{0}, ", value)
        Next value
        Console.WriteLine("<end>" + vbNewLine)
    End Sub

    Public Sub Scramble()
        Dim limit As Integer = MyClass.Count
        Dim temp As Integer
        Dim swapindex As Integer
        Dim rnd As New Random()
        For i As Integer = 0 To limit - 1
            ' The Item property of ArrayList is the default indexer. Thus,
            ' Me(i) and MyClass.Item(i) are used interchangeably.
            temp = CType(Me(i), Integer)
            swapindex = rnd.Next(0, limit - 1)
            MyClass.Item(i) = Me(swapindex)
            MyClass.Item(swapindex) = temp
        Next i
    End Sub
End Class

' The program produces output similar to the following:
'
' Ordered:
'
' 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, <end>
'
' Scrambled:
'
' 5, 2, 8, 9, 6, 1, 7, 0, 4, 3, <end>
'</Snippet2>



