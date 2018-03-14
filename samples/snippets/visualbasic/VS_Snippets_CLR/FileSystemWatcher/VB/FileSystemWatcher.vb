'Types:System.IO.ErrorEventHandler Vendor: Richter
'Types:System.IO.FileSystemEventArgs Vendor: Richter
'Types:System.IO.FileSystemEventHandler Vendor: Richter
'Types:System.IO.InternalBufferOverflowException Vendor: Richter
'Types:System.IO.RenamedEventArgs Vendor: Richter
'Types:System.IO.RenamedEventHandler Vendor: Richter
'Types:System.IO.WatcherChangeTypes Vendor: Richter
'<snippet1>
Imports System.IO

Module Module1
    '<snippet6>
    Sub Main()
        '<snippet2>
        ' Create a FileSystemWatcher to monitor all files on drive C.
        Dim fsw As New FileSystemWatcher("C:\")
        '</snippet2> 

        '<snippet3>
        ' Watch for changes in LastAccess and LastWrite times, and
        ' the renaming of files or directories. 
        fsw.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite _ 
            Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        '</snippet3>

        '<snippet4>
        ' Register a handler that gets called when a 
        ' file is created, changed, or deleted.
        AddHandler fsw.Changed, New FileSystemEventHandler(AddressOf OnChanged)

        ' The commented line of code below is a shorthand of the above line.
        ' AddHandler fsw.Changed, AddressOf OnChanged

        ' NOTE: The shorthand version is used in the remainder of this code.
        ' FileSystemEventHandler
        AddHandler fsw.Created, AddressOf OnChanged 
        ' FileSystemEventHandler
        AddHandler fsw.Deleted, AddressOf OnChanged

        ' Register a handler that gets called when a file is renamed.
        ' RenamedEventHandler
        AddHandler fsw.Renamed, AddressOf OnRenamed

        ' Register a handler that gets called if the 
        ' FileSystemWatcher needs to report an error.
        ' ErrorEventHandler
        AddHandler fsw.Error, AddressOf OnError
        '</snippet4>

        '<snippet5>
        ' Begin watching.
        fsw.EnableRaisingEvents = True
        '</snippet5> 

        ' Wait for the user to quit the program.
        Console.WriteLine("Press 'Enter' to quit the sample.")
        Console.ReadLine()
    End Sub
        '</snippet6> 

    '<snippet7>  
    ' This method is called when a file is created, changed, or deleted.
    Private Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)

        ' Show that a file has been created, changed, or deleted.
        Dim wct As WatcherChangeTypes = e.ChangeType
        Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString())
    End Sub
    '</snippet7>

    '<snippet8>
    ' This method is called when a file is renamed.
    Private Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)

        ' Show that a file has been renamed.
        Dim wct As WatcherChangeTypes = e.ChangeType
        Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString())
    End Sub
    '</snippet8>

    '<snippet9> 
    ' This method is called when the FileSystemWatcher detects an error.
    Private Sub OnError(ByVal source As Object, ByVal e As ErrorEventArgs)

        ' Show that an error has been detected.
        Console.WriteLine("The FileSystemWatcher has detected an error")

        ' Give more information if the error is due to an internal buffer overflow.
        If TypeOf e.GetException Is InternalBufferOverflowException Then
            ' This can happen if Windows is reporting many file system events quickly 
            ' and internal buffer of the  FileSystemWatcher is not large enough to handle this
            ' rate of events. The InternalBufferOverflowException error informs the application
            ' that some of the file system events are being lost.
            Console.WriteLine( _
                "The file system watcher experienced an internal buffer overflow: " _
                + e.GetException.Message)
        End If
    End Sub
    '</snippet9>
End Module
'</snippet1>




