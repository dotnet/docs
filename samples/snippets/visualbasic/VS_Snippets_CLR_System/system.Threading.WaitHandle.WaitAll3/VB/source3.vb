' <Snippet1>
Imports System
Imports System.IO
Imports System.Security.Permissions
Imports System.Threading

Public Class Test

    ' WaitHandle.WaitAll requires a multithreaded apartment 
    ' when using multiple wait handles.
    <MTAThreadAttribute> _
    Shared Sub Main()
        Const numberOfFiles As Integer = 5
        Dim dirName As String = "C:\TestTest"
        Dim fileName As String 

        Dim byteArray() As Byte 
        Dim randomGenerator As New Random()

        Dim manualEvents(numberOfFiles - 1) As ManualResetEvent
        Dim stateInfo As State 

        If Directory.Exists(dirName) <> True Then
            Directory.CreateDirectory(dirName)
        End If

        ' Queue the work items that create and write to the files.
        For i As Integer = 0 To numberOfFiles - 1
            fileName = String.Concat( _
                dirName, "\Test", i.ToString(), ".dat")

            ' Create random data to write to the file.
            byteArray = New Byte(1000000){}
            randomGenerator.NextBytes(byteArray)

            manualEvents(i) = New ManualResetEvent(false)

            stateInfo = _ 
                New State(fileName, byteArray, manualEvents(i))

            ThreadPool.QueueUserWorkItem(AddressOf _
                Writer.WriteToFile, stateInfo)
        Next i
    
        ' Since ThreadPool threads are background threads, 
        ' wait for the work items to signal before exiting.
        If WaitHandle.WaitAll( _
            manualEvents, New TimeSpan(0, 0, 5), false) = True  Then

            Console.WriteLine("Files written - main exiting.")
        Else
        
            ' The wait operation times out.
            Console.WriteLine("Error writing files - main exiting.")
        End If
    End Sub

End Class
 
' Maintain state to pass to WriteToFile.
Public Class State

    Public fileName As String
    Public byteArray As Byte()
    Public manualEvent As ManualResetEvent

    Sub New(fileName As String, byteArray() As Byte, _
        manualEvent As ManualResetEvent)
    
        Me.fileName = fileName
        Me.byteArray = byteArray
        Me.manualEvent = manualEvent
    End Sub

End Class

Public Class Writer

    Private Sub New()
    End Sub

    Shared workItemCount As Integer = 0

    Shared Sub WriteToFile(state As Object)
        Dim workItemNumber As Integer = workItemCount
        Interlocked.Increment(workItemCount)
        Console.WriteLine("Starting work item {0}.", _
            workItemNumber.ToString())
        Dim stateInfo As State = CType(state, State)
        Dim fileWriter As FileStream = Nothing

        ' Create and write to the file.
        Try
            fileWriter = New FileStream( _
                stateInfo.fileName, FileMode.Create)
            fileWriter.Write(stateInfo.byteArray, _
                0, stateInfo.byteArray.Length)
        Finally
            If Not fileWriter Is Nothing Then
                fileWriter.Close()
            End If

            ' Signal Main that the work item has finished.
            Console.WriteLine("Ending work item {0}.", _
                workItemNumber.ToString())
            stateInfo.manualEvent.Set()
        End Try
    End Sub

End Class
' </Snippet1>