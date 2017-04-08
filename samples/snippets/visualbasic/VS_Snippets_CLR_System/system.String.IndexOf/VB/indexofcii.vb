'<snippet1>
' Example for the String.IndexOf( Char, Integer, Integer ) method.
Imports System
Imports Microsoft.VisualBasic

Module IndexOfCII
   
    Sub Main()
        Dim br1 As String = _
            "0----+----1----+----2----+----3----+----" & _
            "4----+----5----+----6----+----7"
        Dim br2 As String = _
            "0123456789012345678901234567890123456789" & _
            "0123456789012345678901234567890"
        Dim str As String = _
            "ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi " & _
            "ABCDEFGHI abcdefghi ABCDEFGHI"
          
        Console.WriteLine( _
            "This example of String.IndexOf( Char, Integer, Integer )" & _
            vbCrLf & "generates the following output." )
        Console.WriteLine( _
            "{0}{1}{0}{2}{0}{3}{0}", _
            Environment.NewLine, br1, br2, str)

        FindAllChar("A"c, str)
        FindAllChar("a"c, str)
        FindAllChar("I"c, str)
        FindAllChar("i"c, str)
        FindAllChar("@"c, str)
        FindAllChar(" "c, str)
    End Sub 'Main
       
    Sub FindAllChar(target As Char, searched As String)

        Console.Write( _
            "The character ""{0}"" occurs at position(s): ", target)
          
        Dim startIndex As Integer = - 1
        Dim hitCount As Integer = 0
          
        ' Search for all occurrences of the target.
        While True
            startIndex = searched.IndexOf( _
                target, startIndex + 1, _
                searched.Length - startIndex - 1)

            ' Exit the loop if the target is not found.
            If startIndex < 0 Then
                Exit While
            End If 

            Console.Write("{0}, ", startIndex)
            hitCount += 1
        End While
          
        Console.WriteLine("occurrences: {0}", hitCount)

    End Sub 'FindAllChar
End Module 'IndexOfCII

' This example of String.IndexOf( Char, Integer, Integer )
' generates the following output.
' 
' 0----+----1----+----2----+----3----+----4----+----5----+----6----+----7
' 01234567890123456789012345678901234567890123456789012345678901234567890
' ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI
' 
' The character "A" occurs at position(s): 0, 20, 40, 60, occurrences: 4
' The character "a" occurs at position(s): 10, 30, 50, occurrences: 3
' The character "I" occurs at position(s): 8, 28, 48, 68, occurrences: 4
' The character "i" occurs at position(s): 18, 38, 58, occurrences: 3
' The character "@" occurs at position(s): occurrences: 0
' The character " " occurs at position(s): 9, 19, 29, 39, 49, 59, occurrences: 6
'</snippet1>
