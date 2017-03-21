    //  This method is called when a file is created, changed, or deleted.
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        //  Show that a file has been created, changed, or deleted.
        WatcherChangeTypes wct = e.ChangeType;
        Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString());
    }