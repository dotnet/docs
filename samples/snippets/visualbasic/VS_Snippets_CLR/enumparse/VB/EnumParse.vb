'<snippet1>
Imports System

Public Class ParseTest

    <FlagsAttribute()> _
    Enum Colors
        Red = 1
        Green = 2
        Blue = 4
        Yellow = 8
    End Enum

    Public Shared Sub Main()
        Console.WriteLine("The entries of the Colors enumeration are:")
        Dim colorName As String
        For Each colorName In [Enum].GetNames(GetType(Colors))
            Console.WriteLine("{0} = {1:D}", colorName, [Enum].Parse(GetType(Colors), colorName))
        Next
        Console.WriteLine()

        Dim orange As Colors = CType([Enum].Parse(GetType(Colors), "Red, Yellow"), Colors)
        Console.WriteLine("The orange value {0:D} has the combined entries of {0}", orange)
    End Sub
End Class

'This example displays the following output:
'
'The entries of the Colors Enum are:
'Red = 1
'Green = 2
'Blue = 4
'Yellow = 8
'
'The myOrange value 9 has the combined entries of Red, Yellow
'
'</snippet1>
