' <snippet11>
Imports System

Module IsSurrogateSample

    Sub Main()

        ' NOTE: Visual Basic doesn't give us a way to create a 32-bit Unicode 
        ' character composed of two 16-bit surrogate values, so a case where 
        ' IsSurrogate returns True cannot be included in this sample. 

        Console.WriteLine(Char.IsSurrogate("a"c))       ' Output: "False"

    End Sub

End Module
' </snippet11>
