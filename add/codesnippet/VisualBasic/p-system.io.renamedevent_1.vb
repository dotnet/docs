    ' This method is called when a file is renamed.
    Private Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)

        ' Show that a file has been renamed.
        Dim wct As WatcherChangeTypes = e.ChangeType
        Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString())
    End Sub