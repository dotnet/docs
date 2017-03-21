    //  This method is called when a file is renamed.
    private static void OnRenamed(object source, RenamedEventArgs e)
    {
        //  Show that a file has been renamed.
        WatcherChangeTypes wct = e.ChangeType;
        Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString());
    }