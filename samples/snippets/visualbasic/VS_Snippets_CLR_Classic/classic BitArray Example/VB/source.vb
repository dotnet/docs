' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesBitArray

    Public Shared Sub Main()

        ' Creates and initializes several BitArrays.
        Dim myBA1 As New BitArray(5)

        Dim myBA2 As New BitArray(5, False)

        Dim myBytes() As Byte = {1, 2, 3, 4, 5}
        Dim myBA3 As New BitArray(myBytes)

        Dim myBools() As Boolean = {True, False, True, True, False}
        Dim myBA4 As New BitArray(myBools)

        Dim myInts() As Integer = {6, 7, 8, 9, 10}
        Dim myBA5 As New BitArray(myInts)

        ' Displays the properties and values of the BitArrays.
        Console.WriteLine("myBA1")
        Console.WriteLine("   Count:    {0}", myBA1.Count)
        Console.WriteLine("   Length:   {0}", myBA1.Length)
        Console.WriteLine("   Values:")
        PrintValues(myBA1, 8)

        Console.WriteLine("myBA2")
        Console.WriteLine("   Count:    {0}", myBA2.Count)
        Console.WriteLine("   Length:   {0}", myBA2.Length)
        Console.WriteLine("   Values:")
        PrintValues(myBA2, 8)

        Console.WriteLine("myBA3")
        Console.WriteLine("   Count:    {0}", myBA3.Count)
        Console.WriteLine("   Length:   {0}", myBA3.Length)
        Console.WriteLine("   Values:")
        PrintValues(myBA3, 8)

        Console.WriteLine("myBA4")
        Console.WriteLine("   Count:    {0}", myBA4.Count)
        Console.WriteLine("   Length:   {0}", myBA4.Length)
        Console.WriteLine("   Values:")
        PrintValues(myBA4, 8)

        Console.WriteLine("myBA5")
        Console.WriteLine("   Count:    {0}", myBA5.Count)
        Console.WriteLine("   Length:   {0}", myBA5.Length)
        Console.WriteLine("   Values:")
        PrintValues(myBA5, 8)

    End Sub 'Main

    Public Shared Sub PrintValues(myList As IEnumerable, myWidth As Integer)
        Dim i As Integer = myWidth
        Dim obj As [Object]
        For Each obj In  myList
            If i <= 0 Then
                i = myWidth
                Console.WriteLine()
            End If
            i -= 1
            Console.Write("{0,8}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesBitArray 


' This code produces the following output.
' 
' myBA1
'    Count:    5
'    Length:   5
'    Values:
'    False   False   False   False   False
' myBA2
'    Count:    5
'    Length:   5
'    Values:
'    False   False   False   False   False
' myBA3
'    Count:    40
'    Length:   40
'    Values:
'     True   False   False   False   False   False   False   False
'    False    True   False   False   False   False   False   False
'     True    True   False   False   False   False   False   False
'    False   False    True   False   False   False   False   False
'     True   False    True   False   False   False   False   False
' myBA4
'    Count:    5
'    Length:   5
'    Values:
'     True   False    True    True   False
' myBA5
'    Count:    160
'    Length:   160
'    Values:
'    False    True    True   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'     True    True    True   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False    True   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'     True   False   False    True   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False    True   False    True   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False
'    False   False   False   False   False   False   False   False

' </Snippet1>