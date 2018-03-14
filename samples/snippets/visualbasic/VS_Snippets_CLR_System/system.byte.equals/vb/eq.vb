'<snippet1>
' This code example demonstrates the System.Byte.Equals(Object) and
' System.Byte.Equals(Byte) methods.

Imports System

Class Sample
    Public Shared Sub Main() 
        Dim byteVal1 As Byte = &H7F
        Dim byteVal2 As Byte = 127
        Dim objectVal3 As Object = byteVal2
        '
        Console.WriteLine("byteVal1 = {0}, byteVal2 = {1}, objectVal3 = {2}" & vbCrLf, _
                          byteVal1, byteVal2, objectVal3)
        Console.WriteLine("byteVal1 equals byteVal2?: {0}", byteVal1.Equals(byteVal2))
        Console.WriteLine("byteVal1 equals objectVal3?: {0}", byteVal1.Equals(objectVal3))
    End Sub 'Main
End Class 'Sample

'
'This code example produces the following results:
'
'byteVal1 = 127, byteVal2 = 127, objectVal3 = 127
'
'byteVal1 equals byteVal2?: True
'byteVal1 equals objectVal3?: True
'
'</snippet1>