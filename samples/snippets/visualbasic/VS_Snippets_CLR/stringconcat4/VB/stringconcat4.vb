' <Snippet1>
Public Class ConcatTest
    Public Shared Sub Main()
        Dim fName As String = "Simon"
        Dim mName As String = "Jake"
        Dim lName As String = "Harrows"
        
        ' We want to simply quickly add this person's name together.
        ' Because we want a name to appear with a space in between each name, 
        ' we put a space on the front of the middle, and last name, allowing for
        ' the fact that a space may already be there.
        mName = " " + mName.Trim()
        lName = " " + lName.Trim()
        
        ' This line simply concatenates the two strings.
        Console.WriteLine("Welcome to this page, '{0}'!", _
                          String.Concat(String.Concat(fName, mName), lName))
    End Sub
End Class
' The example displays the following output:
'       Welcome to this page, 'Simon Jake Harrows'!
' </Snippet1>
