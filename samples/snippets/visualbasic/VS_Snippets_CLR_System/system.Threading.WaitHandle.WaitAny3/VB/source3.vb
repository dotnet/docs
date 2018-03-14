' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Threading

Public Class Test

    <MTAThread> _
    Shared Sub Main()
        Dim search As New Search()
        search.FindFile("SomeFile.dat")
    End Sub    
End Class

Public Class Search

    ' Maintain state information to pass to FindCallback.
    Class State
        Public autoEvent As AutoResetEvent 
        Public fileName As String         

        Sub New(anEvent As AutoResetEvent, fName As String)
            autoEvent = anEvent
            fileName = fName
        End Sub
    End Class

    Dim autoEvents() As AutoResetEvent
    Dim diskLetters() As String

    Sub New()

        ' Retrieve an array of disk letters.
        diskLetters = Environment.GetLogicalDrives()

        autoEvents = New AutoResetEvent(diskLetters.Length - 1) {}
        For i As Integer = 0 To diskLetters.Length - 1
            autoEvents(i) = New AutoResetEvent(False)
        Next i
    End Sub    
    
    ' Search for fileName in the root directory of all disks.
    Sub FindFile(fileName As String)
        For i As Integer = 0 To diskLetters.Length - 1
            Console.WriteLine("Searching for {0} on {1}.", _
                fileName, diskLetters(i))
        
            ThreadPool.QueueUserWorkItem(AddressOf FindCallback, _ 
                New State(autoEvents(i), diskLetters(i) & fileName))
        Next i

        ' Wait for the first instance of the file to be found.
        Dim index As Integer = WaitHandle.WaitAny( _
            autoEvents, New TimeSpan(0, 0, 3), False)
        If index = WaitHandle.WaitTimeout
            Console.WriteLine(vbCrLf & "{0} not found.", fileName)
        Else
            Console.WriteLine(vbCrLf & "{0} found on {1}.", _
                fileName, diskLetters(index))
        End If
    End Sub

    ' Search for stateInfo.fileName.
    Sub FindCallback(state As Object)
        Dim stateInfo As State = DirectCast(state, State)

        ' Signal if the file is found.
        If File.Exists(stateInfo.fileName) Then
            stateInfo.autoEvent.Set()
        End If
    End Sub

End Class
' </Snippet1>