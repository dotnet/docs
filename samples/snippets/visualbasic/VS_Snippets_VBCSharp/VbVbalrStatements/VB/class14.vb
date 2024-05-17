Public Class Class14
    ' While...End While Statement (Visual Basic)
    ' b931d1ce-e8ed-44d8-a13d-92a4f5458a1e

    Public Sub Process()
        Example1()
        Example2()
        ShowText("c:\temp2\mytest.txt")
    End Sub

    Private Sub Example1()
        '<Snippet171>
        Dim index As Integer = 0
        While index <= 10
            Debug.Write(index.ToString & " ")
            index += 1
        End While

        Debug.WriteLine("")
        ' Output: 0 1 2 3 4 5 6 7 8 9 10 
        '</Snippet171>
    End Sub

    Private Sub Example2()
        '<Snippet172>
        Dim index As Integer = 0
        While index < 100000
            index += 1

            ' If index is between 5 and 7, continue
            ' with the next iteration.
            If index >= 5 And index <= 8 Then
                Continue While
            End If

            ' Display the index.
            Debug.Write(index.ToString & " ")

            ' If index is 10, exit the loop.
            If index = 10 Then
                Exit While
            End If
        End While

        Debug.WriteLine("")
        ' Output: 1 2 3 4 9 10
        '</Snippet172>
    End Sub

    '<Snippet173>
    Private Sub ShowText(ByVal textFilePath As String)
        If System.IO.File.Exists(textFilePath) = False Then
            Debug.WriteLine("File Not Found: " & textFilePath)
        Else
            Dim sr As System.IO.StreamReader = System.IO.File.OpenText(textFilePath)

            While sr.Peek() >= 0
                Debug.WriteLine(sr.ReadLine())
            End While

            sr.Close()
        End If
    End Sub
    '</Snippet173>

End Class
