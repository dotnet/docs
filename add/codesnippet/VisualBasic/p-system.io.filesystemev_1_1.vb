    ' This method is called when a file is created, changed, or deleted.
    Private Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)

        ' Show that a file has been created, changed, or deleted.
        Dim wct As WatcherChangeTypes = e.ChangeType
        Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString())
    End Sub