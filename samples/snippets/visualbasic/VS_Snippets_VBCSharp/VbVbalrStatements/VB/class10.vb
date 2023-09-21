Public Class Class10
    ' 892f9096-b3e2-4aee-834d-83bc4e2c379d
    ' Do...Loop Statement (Visual Basic)

    Public Sub Process()
        Example1()
        Example2()
        Example3()
    End Sub

    Private Sub Example1()
        '<Snippet131>
        Dim index As Integer = 0
        Do
            Debug.Write(index.ToString & " ")
            index += 1
        Loop Until index > 10

        Debug.WriteLine("")
        ' Output: 0 1 2 3 4 5 6 7 8 9 10 
        '</Snippet131>
    End Sub

    Private Sub Example2()
        '<Snippet132>
        Dim index As Integer = 0
        Do While index <= 10
            Debug.Write(index.ToString & " ")
            index += 1
        Loop

        Debug.WriteLine("")
        ' Output: 0 1 2 3 4 5 6 7 8 9 10 
        '</Snippet132>
    End Sub

    Private Sub Example3()
        ' Also used in Exit Statement (Visual Basic).
        '<Snippet133>
        Dim index As Integer = 0
        Do While index <= 100
            If index > 10 Then
                Exit Do
            End If

            Debug.Write(index.ToString & " ")
            index += 1
        Loop

        Debug.WriteLine("")
        ' Output: 0 1 2 3 4 5 6 7 8 9 10 
        '</Snippet133>
    End Sub

    '<Snippet134>
    Private Sub ShowText(ByVal textFilePath As String)
        If System.IO.File.Exists(textFilePath) = False Then
            Debug.WriteLine("File Not Found: " & textFilePath)
        Else
            Dim sr As System.IO.StreamReader = System.IO.File.OpenText(textFilePath)

            Do While sr.Peek() >= 0
                Debug.WriteLine(sr.ReadLine())
            Loop

            sr.Close()
        End If
    End Sub
    '</Snippet134>

End Class
