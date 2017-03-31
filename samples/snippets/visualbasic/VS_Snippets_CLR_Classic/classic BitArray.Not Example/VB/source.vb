' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesBitArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes two BitArrays of the same size.
        Dim myBA1 As New BitArray(4)
        Dim myBA2 As New BitArray(4)
        myBA1(0) = False
        myBA1(1) = False
        myBA1(2) = True
        myBA1(3) = True
        myBA2(0) = False
        myBA2(2) = False
        myBA2(1) = True
        myBA2(3) = True
        
        ' Performs a bitwise NOT operation between BitArray instances of the same size.
        Console.WriteLine("Initial values")
        Console.Write("myBA1:")
        PrintValues(myBA1, 8)
        Console.Write("myBA2:")
        PrintValues(myBA2, 8)
        Console.WriteLine()
        
        myBA1.Not()
        myBA2.Not()
        
        Console.WriteLine("After NOT")
        Console.Write("myBA1:")
        PrintValues(myBA1, 8)
        Console.Write("myBA2:")
        PrintValues(myBA2, 8)
        Console.WriteLine()
    End Sub    
    
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

End Class


' This code produces the following output.
' 
' Initial values
' myBA1:    False    False    True    True
' myBA2:    False    True    False    True
' 
' After NOT
' myBA1:    True    True    False    False
' myBA2:    True    False    True    False 
' </Snippet1>
