' <Snippet1>
Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Security.Permissions

Public Class Watcher
    
    Public Shared Sub Main()
	
         Run()
  
    End Sub

    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    Private Shared Sub Run

      Dim args() As String = System.Environment.GetCommandLineArgs()
        ' If a directory is not specified, exit the program.
        If args.Length <> 2 Then
            ' Display the proper way to call the program.
            Console.WriteLine("Usage: Watcher.exe (directory)")
            Return
        End If
        
        ' Create a new FileSystemWatcher and set its properties.
        Dim watcher As New FileSystemWatcher()
        watcher.Path = args(1)
        ' Watch for changes in LastAccess and LastWrite times, and
        ' the renaming of files or directories. 
        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        ' Only watch text files.
        watcher.Filter = "*.txt"
        
        ' Add event handlers.
        AddHandler watcher.Changed, AddressOf OnChanged
        AddHandler watcher.Created, AddressOf OnChanged
        AddHandler watcher.Deleted, AddressOf OnChanged
        AddHandler watcher.Renamed, AddressOf OnRenamed
        
        ' Begin watching.
        watcher.EnableRaisingEvents = True
        
        ' Wait for the user to quit the program.
        Console.WriteLine("Press 'q' to quit the sample.")
        While Chr(Console.Read()) <> "q"c
        End While
    End Sub
     
    ' Define the event handlers.
    Private Shared Sub OnChanged(source As Object, e As FileSystemEventArgs)
        ' Specify what is done when a file is changed, created, or deleted.
        Console.WriteLine("File: " & e.FullPath & " " & e.ChangeType)
    End Sub    
    
    Private Shared Sub OnRenamed(source As Object, e As RenamedEventArgs)
        ' Specify what is done when a file is renamed.
        Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath)
    End Sub
    
End Class

' </Snippet1>
