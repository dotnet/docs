 '<Snippet1>
Imports System
Imports System.Diagnostics



Class Program
    
    Shared Sub Main(ByVal args() As String) 
        ' Make sure there is an instance of notepad running.
        Dim notepads As Process() = Process.GetProcessesByName("notepad")
        If notepads.Length = 0 Then
            Process.Start("notepad")
        End If
        Dim threads As ProcessThreadCollection
        'Process[] notepads;
        ' Retrieve the Notepad processes.
        notepads = Process.GetProcessesByName("Notepad")
        ' Get the ProcessThread collection for the first instance
        threads = notepads(0).Threads
        ' Set the properties on the first ProcessThread in the collection
        threads(0).IdealProcessor = 0
        threads(0).ProcessorAffinity = CType(1, IntPtr)
    End Sub 'Main
End Class 'Program
'</Snippet1>