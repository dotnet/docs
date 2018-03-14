'<snippet1>
Module Example
    Public Sub Main()
        Dim causeOfFailure As String = "A catastrophic failure has occured."
        ' Assume your application has failed catastrophically and must
        ' terminate immediately. The try-finally block is not executed 
        ' and is included only to demonstrate that instructions within 
        ' try-catch blocks and finalizers are not performed.

        Try
            Environment.FailFast(causeOfFailure)
        Finally
            Console.WriteLine("This finally block will not be executed.")
        End Try
    End Sub
End Module
'
' The code example displays no output because the application is
' terminated. However, an entry is made in the Windows Application event
' log, and the log entry contains the text from the causeOfFailure variable.
'</snippet1>
