        ' Suspend the calling thread until the file has been deleted.
        Dim cr As IO.WaitForChangedResult = fsw.WaitForChanged(WatcherChangeTypes.Deleted)

        ' Tell the user the file is deleted and exit.
        Console.WriteLine("The {0} files is deleted; program is exiting", cr.Name)