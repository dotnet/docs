'<snippet1>
Imports System
Imports System.Diagnostics
Imports System.Threading

Class PrintProcessClass

    Private WithEvents myProcess As New Process
    Private elapsedTime As Integer
    Private eventHandled As Boolean

    Public Event Exited As EventHandler

    ' Print a file with any known extension.
    Sub PrintDoc(ByVal fileName As String)

        elapsedTime = 0
        eventHandled = False

        Try
            ' Start a process to print a file and raise an event when done.
            myProcess.StartInfo.FileName = fileName
            myProcess.StartInfo.Verb = "Print"
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.EnableRaisingEvents = True
            myProcess.Start()

        Catch ex As Exception
            Console.WriteLine("An error occurred trying to print ""{0}"":" & _
                vbCrLf & ex.Message, fileName)
            Return
        End Try

        ' Wait for Exited event, but not more than 30 seconds.
        Const SLEEP_AMOUNT As Integer = 100
        Do While Not eventHandled
            elapsedTime += SLEEP_AMOUNT
            If elapsedTime > 30000 Then
                Exit Do
            End If
            Thread.Sleep(SLEEP_AMOUNT)
        Loop
    End Sub

    ' Handle Exited event and display process information.
    Private Sub myProcess_Exited(ByVal sender As Object, _
            ByVal e As System.EventArgs) Handles myProcess.Exited

        eventHandled = True
        Console.WriteLine("Exit time:    {0}" & vbCrLf & _
            "Exit code:    {1}" & vbCrLf & "Elapsed time: {2}", _
            myProcess.ExitTime, myProcess.ExitCode, elapsedTime)
    End Sub

    Shared Sub Main(ByVal args() As String)

        ' Verify that an argument has been entered.
        If args.Length <= 0 Then
            Console.WriteLine("Enter a file name.")
            Return
        End If

        ' Create the process and print the document.
        Dim myPrintProcess As New PrintProcessClass
        myPrintProcess.PrintDoc(args(0))
    End Sub
End Class
'</snippet1>
