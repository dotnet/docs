    Private Function SetGetPathListDemo() As Boolean
        Try
            Console.WriteLine("********************************************************" & ControlChars.Lf)

            Dim fileIOPerm1 As FileIOPermission
            Console.WriteLine("Creating a FileIOPermission with AllAccess rights for 'C:\Examples\Test\TestFile.txt")
            fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\Examples\Test\TestFile.txt")
            Console.WriteLine("Adding 'C:\Temp' to the write access list, and " & ControlChars.Lf & " 'C:\Examples\Test' to read access.")
            fileIOPerm1.AddPathList(FileIOPermissionAccess.Write, "C:\Temp")
            fileIOPerm1.AddPathList(FileIOPermissionAccess.Read, "C:\Examples\Test")
            Dim paths As String() = fileIOPerm1.GetPathList(FileIOPermissionAccess.Read)
            Console.WriteLine("Read access before SetPathList = ")
            Dim path As String
            For Each path In paths
                Console.WriteLine((ControlChars.Tab & path))
            Next path
            Console.WriteLine("Setting the read access list to " & ControlChars.Lf & "'C:\Temp'")
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, "C:\Temp")
            paths = fileIOPerm1.GetPathList(FileIOPermissionAccess.Read)
            Console.WriteLine("Read access list after SetPathList = ")
            For Each path In paths
                Console.WriteLine((ControlChars.Tab & path))
            Next path

            paths = fileIOPerm1.GetPathList(FileIOPermissionAccess.Write)
            Console.WriteLine("Write access list after SetPathList = ")
            For Each path In paths
                Console.WriteLine((ControlChars.Tab & path))
            Next path

            Dim pathList() As String
            pathList = fileIOPerm1.GetPathList(FileIOPermissionAccess.AllAccess)

        Catch e As ArgumentException
            ' FileIOPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            Console.WriteLine(("An ArgumentException occurred as a result of using AllAccess. " & "This property cannot be used as a parameter in GetPathList " & "because it represents more than one type of file variable access. : " & ControlChars.Lf & e.ToString()))
        End Try

        Return True
    End Function 'SetGetPathListDemo