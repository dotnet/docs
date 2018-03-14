'Types:System.IO.WaitForChangedResult Vendor: Richter
'<snippet1>
Imports System.IO

Module Module1
    Sub Main()
        ' Define a path and a file name for a temporary file.
        Dim pathname As String = "C:\"
        Dim filename As String = "JunkFile.tmp"
        Dim filepathname As String = Path.Combine(pathname, filename)

        ' Create the temporary file and then close it.
        File.Create(filepathname).Close()

        Console.WriteLine("This application will terminate when you delete the {0} file", filepathname)

        ' Have a FileSystemWatcher monitor the path and file for changes.
        Dim fsw As New FileSystemWatcher(pathname, filename)
        fsw.NotifyFilter = NotifyFilters.FileName
        fsw.EnableRaisingEvents = True

        '<snippet2>
        ' Suspend the calling thread until the file has been deleted.
        Dim cr As IO.WaitForChangedResult = fsw.WaitForChanged(WatcherChangeTypes.Deleted)

        ' Tell the user the file is deleted and exit.
        Console.WriteLine("The {0} files is deleted; program is exiting", cr.Name)
        '</snippet2>
    End Sub
End Module

' This code produces the following output.
' 
'  This application will terminate when you delete the C:\JunkFile.tmp file
'  The JunkFile.tmp files is deleted; program is exiting
'</snippet1>
