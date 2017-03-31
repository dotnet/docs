' <Snippet1>
Public Class CopyToTest
    Public Shared Sub Main()
        ' Embed an array of characters in a string
        Dim strSource As String = "changed"
        Dim destination As Char() = {"T"c, "h"c, "e"c, " "c, "i"c, "n"c, "i"c, _
                    "t"c, "i"c, "a"c, "l"c, " "c, "a"c, "r"c, "r"c, "a"c, "y"c}

        ' Print the char array
        Console.WriteLine(destination)

        ' Embed the source string in the destination string
        strSource.CopyTo(0, destination, 4, strSource.Length)

        ' Print the resulting array
        Console.WriteLine(destination)

        strSource = "A different string"

        ' Embed only a section of the source string in the destination
        strSource.CopyTo(2, destination, 3, 9)

        ' Print the resulting array
        Console.WriteLine(destination)
    End Sub 
End Class 
' The example displays the following output:
'       The initial array
'       The changed array
'       Thedifferentarray
' </Snippet1>
