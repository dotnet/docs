'<Snippet5>
'<Snippet4>
'<Snippet3>
'<Snippet2>
'<Snippet1>
Option Explicit On 
Option Strict On

Imports System

Namespace GetFileSystemEntries
    Class Class1
        Overloads Shared Sub Main(ByVal args() As String)
            Dim snippets As New Class1()
            Dim path As String = System.IO.Directory.GetCurrentDirectory()
            Dim filter As String = "*.exe"
            snippets.PrintFileSystemEntries(path)
            snippets.PrintFileSystemEntries(path, filter)
            snippets.GetLogicalDrives()
            snippets.GetParent(path)
            snippets.Move("C:\proof", "C:\Temp")
        End Sub 'Main

        Sub PrintFileSystemEntries(ByVal path As String)
            Try
                ' Obtain the file system entries in the directory path.
                Dim directoryEntries As String()
                directoryEntries = System.IO.Directory.GetFileSystemEntries(path)
                Dim str As String
                For Each str In directoryEntries
                    System.Console.WriteLine(str)
                Next str
            Catch exp As ArgumentNullException
                System.Console.WriteLine("Path is a null reference.")
            Catch exp As System.Security.SecurityException
                System.Console.WriteLine("The caller does not have the " + _
                                        "required permission.")
            Catch exp As ArgumentException
                System.Console.WriteLine("Path is an empty string, " + _
                                        "contains only white spaces, " + _
                                        "or contains invalid characters.")
            Catch exp As System.IO.DirectoryNotFoundException
                System.Console.WriteLine("The path encapsulated in the " + _
                                        "Directory object does not exist.")
            End Try
        End Sub
        Sub PrintFileSystemEntries(ByVal path As String, _
                                   ByVal pattern As String)
            Try
                ' Obtain the file system entries in the directory
                ' path that match the pattern.
                Dim directoryEntries As String()
                directoryEntries = _
                   System.IO.Directory.GetFileSystemEntries(path, pattern)

                Dim str As String
                For Each str In directoryEntries
                    System.Console.WriteLine(str)
                Next str
            Catch exp As ArgumentNullException
                System.Console.WriteLine("Path is a null reference.")
            Catch exp As System.Security.SecurityException
                System.Console.WriteLine("The caller does not have the " + _
                                        "required permission.")
            Catch exp As ArgumentException
                System.Console.WriteLine("Path is an empty string, " + _
                                        "contains only white spaces, " + _
                                        "or contains invalid characters.")
            Catch exp As System.IO.DirectoryNotFoundException
                System.Console.WriteLine("The path encapsulated in the " + _
                                        "Directory object does not exist.")
            End Try
        End Sub

        ' Print out all logical drives on the system.
        Sub GetLogicalDrives()
            Try
                Dim drives As String()
                drives = System.IO.Directory.GetLogicalDrives()

                Dim str As String
                For Each str In drives
                    System.Console.WriteLine(str)
                Next str
            Catch exp As System.IO.IOException
                System.Console.WriteLine("An I/O error occurs.")
            Catch exp As System.Security.SecurityException
                System.Console.WriteLine("The caller does not have the " + _
                                           "required permission.")
            End Try
        End Sub
        Sub GetParent(ByVal path As String)
            Try
                Dim directoryInfo As System.IO.DirectoryInfo
                directoryInfo = System.IO.Directory.GetParent(path)
                System.Console.WriteLine(directoryInfo.FullName)
            Catch exp As ArgumentNullException
                System.Console.WriteLine("Path is a null reference.")
            Catch exp As ArgumentException
                System.Console.WriteLine("Path is an empty string, " + _
                                     "contains only white spaces, or " + _
                                     "contains invalid characters.")
            End Try
        End Sub
        Sub Move(ByVal sourcePath As String, ByVal destinationPath As String)
            Try
                System.IO.Directory.Move(sourcePath, destinationPath)
                System.Console.WriteLine("The directory move is complete.")
            Catch exp As ArgumentNullException
                System.Console.WriteLine("Path is a null reference.")
            Catch exp As System.Security.SecurityException
                System.Console.WriteLine("The caller does not have the " + _
                                           "required permission.")
            Catch exp As ArgumentException
                System.Console.WriteLine("Path is an empty string, " + _
                                        "contains only white spaces, " + _
                                        "or contains invalid characters.")
            Catch exp As System.IO.IOException
                System.Console.WriteLine("An attempt was made to move a " + _
                                        "directory to a different " + _
                                        "volume, or destDirName " + _
                                        "already exists.")
            End Try
        End Sub
    End Class
End Namespace

'</Snippet1>
'</Snippet2>
'</Snippet3>
'</Snippet4>
'</Snippet5>