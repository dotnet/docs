' This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml, FromXml, 
' GetPathList and SetPathList methods, and the AllFiles and AllLocalFiles properties  
' of the FileIOPermission class.
' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports Microsoft.VisualBasic

<Assembly: CLSCompliant(True)> 

Public Class FileIOPermissionDemo

    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    ' This method compares various FileIOPermission paths with FileIOPermissionAccess set to AllAccess.
    '<Snippet2>
    Private Function IsSubsetOfDemo() As Boolean

        Dim returnValue As Boolean = True
        Dim fileIO1 As String = ""
        Dim fileIO2 As String = ""
        Dim fileIOPerm1, fileIOPerm2 As FileIOPermission

        Dim fileIOGen1 As New FileIOGenerator()
        Dim fileIOGen2 As New FileIOGenerator()

        fileIOGen1.ResetIndex()
        While fileIOGen1.CreateFilePath(fileIO1)
            If fileIO1 = "" Then
                fileIOPerm1 = New FileIOPermission(PermissionState.None)
            Else
                fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.AllAccess, fileIO1)
            End If

            Console.WriteLine("**********************************************************" & ControlChars.Lf)

            fileIOGen2.ResetIndex()

            While fileIOGen2.CreateFilePath(fileIO2)
                If fileIO2 = "" Then
                    fileIOPerm2 = New FileIOPermission(PermissionState.None)
                Else
                    fileIOPerm2 = New FileIOPermission(FileIOPermissionAccess.AllAccess, fileIO2)
                End If
                Dim firstPermission As String = IIf(fileIO1 = "" Or fileIO1 Is Nothing, "null", fileIO1)
                Dim secondPermission As String = IIf(fileIO2 = "" Or fileIO2 Is Nothing, "null", fileIO2)
                If fileIOPerm2 Is Nothing Then
                    Continue While
                End If
                Try
                    If fileIOPerm1.IsSubsetOf(fileIOPerm2) Then

                        Console.WriteLine((firstPermission & " is a subset of " & secondPermission & ControlChars.Lf))
                    Else
                        Console.WriteLine((firstPermission & " is not a subset of " & secondPermission & ControlChars.Lf))
                    End If

                Catch e As Exception
                    Console.WriteLine(IIf("An exception was thrown for subset :" & fileIO1 = "", "null", IIf(fileIO1 & ControlChars.Lf & fileIO2 = "", "null", fileIO2 & ControlChars.Lf & e.ToString())))
                End Try

            End While

        End While
        Return returnValue
    End Function 'IsSubsetOfDemo
    '</Snippet2>

    ' Union creates a new permission that is the union of the current permission and the specified permission.
    '<Snippet3>
    Private Function UnionDemo() As Boolean

        Dim returnValue As Boolean = True

        Dim fileIO1 As String = ""
        Dim fileIO2 As String = ""
        Dim fileIOPerm1, fileIOPerm2 As FileIOPermission
        Dim fileIOPerm3 As IPermission

        Dim fileIOGen1 As New FileIOGenerator()
        Dim fileIOGen2 As New FileIOGenerator()

        fileIOGen1.ResetIndex()
        While fileIOGen1.CreateFilePath(fileIO1)
            If fileIO1 = "" Then
                fileIOPerm1 = New FileIOPermission(PermissionState.None)
            Else
                fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.Read, fileIO1)
            End If
            Console.WriteLine("**********************************************************" & ControlChars.Lf)
            fileIOGen2.ResetIndex()

            While fileIOGen2.CreateFilePath(fileIO2)

                Try
                    If fileIO2 = "" Then
                        fileIOPerm2 = New FileIOPermission(PermissionState.None)
                    Else
                        fileIOPerm2 = New FileIOPermission(FileIOPermissionAccess.Read, fileIO2)
                    End If
                    Dim firstPermission As String = IIf(fileIO1 = "" Or fileIO1 Is Nothing, "null", fileIO1)
                    Dim secondPermission As String = IIf(fileIO2 = "" Or fileIO2 Is Nothing, "null", fileIO2)
                    fileIOPerm3 = CType(fileIOPerm1.Union(fileIOPerm2), FileIOPermission)
                    fileIOPerm3 = fileIOPerm1.Union(fileIOPerm2)

                    If fileIOPerm3 Is Nothing Then
                        Console.WriteLine(("The union of " & firstPermission & "  and " & secondPermission & " is null."))
                    Else
                        Console.WriteLine(("The union of " & firstPermission & "  and " & secondPermission & " = " & ControlChars.Lf & ControlChars.Tab & CType(fileIOPerm3, FileIOPermission).GetPathList(FileIOPermissionAccess.Read)(0)))
                    End If
                Catch e As Exception
                    Console.WriteLine(("An exception was thrown for union " & e.ToString()))
                    returnValue = False
                End Try

            End While

        End While


        Return returnValue
    End Function 'UnionDemo
    '</Snippet3>

    ' Intersect creates and returns a new permission that is the intersection of the current 
    ' permission and the permission specified.
    '<Snippet4>
    Private Function IntersectDemo() As Boolean

        Dim returnValue As Boolean = True

        Dim fileIO1 As String = ""
        Dim fileIO2 As String = ""
        Dim fileIOPerm1, fileIOPerm2, fileIOPerm3 As FileIOPermission

        Dim fileIOGen1 As New FileIOGenerator()
        Dim fileIOGen2 As New FileIOGenerator()

        fileIOGen1.ResetIndex()
        While fileIOGen1.CreateFilePath(fileIO1)
            If fileIO1 = "" Then
                fileIOPerm1 = New FileIOPermission(PermissionState.None)
            Else
                fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.Read, fileIO1)
            End If
            Console.WriteLine("**********************************************************" & ControlChars.Lf)
            fileIOGen2.ResetIndex()

            While fileIOGen2.CreateFilePath(fileIO2)
                If fileIO2 = "" Then
                    fileIOPerm2 = New FileIOPermission(PermissionState.None)
                Else
                    fileIOPerm2 = New FileIOPermission(FileIOPermissionAccess.Read, fileIO2)
                End If
                Dim firstPermission As String = IIf(fileIO1 = "" Or fileIO1 Is Nothing, "null", fileIO1)
                Dim secondPermission As String = IIf(fileIO2 = "" Or fileIO2 Is Nothing, "null", fileIO2)
                Try

                    fileIOPerm3 = CType(fileIOPerm1.Intersect(fileIOPerm2), FileIOPermission)
                    If Not (fileIOPerm3 Is Nothing) AndAlso Not (fileIOPerm3.GetPathList(FileIOPermissionAccess.Read) Is Nothing) Then

                        Console.WriteLine(("The intersection of " & firstPermission & "  and " & ControlChars.Lf & ControlChars.Tab & secondPermission & " = " & ControlChars.Lf & ControlChars.Tab & CType(fileIOPerm3, FileIOPermission).GetPathList(FileIOPermissionAccess.Read)(0)))
                    Else
                        Console.WriteLine(("The intersection of " & firstPermission & "  and " & secondPermission & " is null."))
                    End If
                Catch e As Exception
                    Console.WriteLine(("An exception was thrown for intersection " & e.ToString()))
                    returnValue = False
                End Try

            End While

        End While

        Return returnValue
    End Function 'IntersectDemo
    '</Snippet4>

    'Copy creates and returns an identical copy of the current permission.
    '<Snippet5>
    Private Function CopyDemo() As Boolean
        Dim returnValue As Boolean = True
        Dim fileIO1 As String = ""
        Dim fileIOPerm1, fileIOPerm2 As FileIOPermission
        Dim fileIOGen1 As New FileIOGenerator()
        Dim fileIOGen2 As New FileIOGenerator()

        fileIOGen1.ResetIndex()
        While fileIOGen1.CreateFilePath(fileIO1)
            If fileIO1 = "" Then
                fileIOPerm1 = New FileIOPermission(PermissionState.None)
            Else
                fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.Read, fileIO1)
            End If
            Console.WriteLine("**********************************************************" & ControlChars.Lf)
            fileIOGen2.ResetIndex()
            Try
                fileIOPerm2 = CType(fileIOPerm1.Copy(), FileIOPermission)
                If Not (fileIOPerm2 Is Nothing) Then
                    Console.WriteLine(("Result of copy = " & fileIOPerm2.ToString() & ControlChars.Lf))
                Else
                    Console.WriteLine("Result of copy is null. " & ControlChars.Lf)
                End If
            Catch e As Exception
                If (True.ToString()) Then
                    If fileIO1 = "" Then
                        Console.WriteLine("The target FileIOPermission is empty, copy failed.")

                    Else
                        Console.WriteLine(e.ToString())
                    End If
                End If
                Continue While
            End Try

        End While
        Return returnValue
    End Function 'CopyDemo
    '</Snippet5>

    ' ToXml creates an XML encoding of the permission and its current state; 
    ' FromXml reconstructs a permission with the specified state from the XML encoding. 
    '<Snippet6>
    Private Function ToFromXmlDemo() As Boolean

        Dim returnValue As Boolean = True

        Dim fileIO1 As String = ""
        Dim fileIOPerm1, fileIOPerm2 As FileIOPermission

        Dim fileIOGen1 As New FileIOGenerator()
        Dim fileIOGen2 As New FileIOGenerator()

        fileIOGen1.ResetIndex()
        While fileIOGen1.CreateFilePath(fileIO1)
            If fileIO1 = "" Then
                fileIOPerm1 = New FileIOPermission(PermissionState.None)
            Else
                fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.Read, fileIO1)
            End If
            Console.WriteLine("********************************************************" & ControlChars.Lf)
            fileIOGen2.ResetIndex()
            Try
                fileIOPerm2 = New FileIOPermission(PermissionState.None)
                fileIOPerm2.FromXml(fileIOPerm1.ToXml())
                Console.WriteLine(("Result of ToFromXml = " & fileIOPerm2.ToString() & ControlChars.Lf))

            Catch e As Exception
                Console.WriteLine(("ToFromXml failed :" & fileIOPerm1.ToString() & e.ToString()))
                Continue While
            End Try

        End While

        Return returnValue
    End Function 'ToFromXmlDemo
    '</Snippet6>

    ' AddPathList adds access for the specified files and directories to the existing state of the permission.
    ' SetPathList sets the specified access to the specified files and directories, replacing the existing state 
    ' of the permission.
    ' GetPathList gets all files and directories that have the specified FileIOPermissionAccess.
    '<Snippet7>  
    Private Function SetGetPathListDemo() As Boolean
        Try
            Console.WriteLine("********************************************************" & ControlChars.Lf)

            Dim fileIOPerm1 As FileIOPermission
            Console.WriteLine("Creating a FileIOPermission with AllAccess rights for 'C:\Examples\Test\TestFile.txt")
            '<Snippet8>  
            fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\Examples\Test\TestFile.txt")
            '</Snippet8>
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
    '</Snippet7>  

    ' The AllFiles property gets or sets the permitted access to all files.
    ' The AllLocalFiles property gets or sets the permitted access to all local files.
    '<Snippet11>
    Private Function AllFilesDemo() As Boolean
        Try
            Console.WriteLine("********************************************************" & ControlChars.Lf)

            Dim fileIOPerm1 As FileIOPermission
            Console.WriteLine("Creating a FileIOPermission and adding read access for all files")
            fileIOPerm1 = New FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\Examples\Test\TestFile.txt")
            fileIOPerm1.AllFiles = FileIOPermissionAccess.Read
            Console.WriteLine("AllFiles access = " & fileIOPerm1.AllFiles.ToString())
            Console.WriteLine("Adding AllAccess rights for local files.")
            fileIOPerm1.AllLocalFiles = FileIOPermissionAccess.AllAccess
            Console.WriteLine("AllLocalFiles access = " & fileIOPerm1.AllLocalFiles.ToString())

        Catch e As ArgumentException
            Console.WriteLine(e.ToString())
            Return False
        End Try

        Return True
    End Function 'AllFilesDemo
    '</Snippet11>

    ' Invoke all demos.
    Public Function RunDemo() As Boolean

        Dim ret As Boolean = True
        Dim retTmp As Boolean
        ' Call the IsSubsetOfPath demo.
        retTmp = IsSubsetOfDemo()
        If retTmp Then
            Console.Out.WriteLine("IsSubsetOf demo completed successfully.")
        Else
            Console.Out.WriteLine("IsSubsetOf demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the Union demo.
        retTmp = UnionDemo()
        If retTmp Then
            Console.Out.WriteLine("Union demo completed successfully.")
        Else
            Console.Out.WriteLine("Union demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the Intersect demo.	
        retTmp = IntersectDemo()
        If retTmp Then
            Console.Out.WriteLine("Intersect demo completed successfully.")
        Else
            Console.Out.WriteLine("Intersect demo failed.")
        End If
        ret = retTmp AndAlso ret


        ' Call the Copy demo.
        retTmp = CopyDemo()
        If retTmp Then
            Console.Out.WriteLine("Copy demo completed successfully.")
        Else
            Console.Out.WriteLine("Copy demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the ToFromXml demo.	
        retTmp = ToFromXmlDemo()
        If retTmp Then
            Console.Out.WriteLine("ToFromXml demo completed successfully.")
        Else
            Console.Out.WriteLine("ToFromXml demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the SetGetPathList demo.	
        retTmp = SetGetPathListDemo()
        If retTmp Then
            Console.Out.WriteLine("SetGetPathList demo completed successfully.")
        Else
            Console.Out.WriteLine("SetGetPathList demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the AllFiles demo.	
        retTmp = AllFilesDemo()
        If retTmp Then
            Console.Out.WriteLine("AllFiles demo completed successfully.")
        Else
            Console.Out.WriteLine("AllFiles demo failed.")
        End If
        ret = retTmp AndAlso ret

        Return ret
    End Function 'RunDemo

    ' Test harness.
    Public Overloads Shared Sub Main(ByVal args() As [String])
        Try
            Dim democase As New FileIOPermissionDemo()
            Dim ret As Boolean = democase.RunDemo()
            If ret Then
                Console.Out.WriteLine("FileIOPermission demo completed successfully.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 100
            Else
                Console.Out.WriteLine("FileIOPermission demo failed.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 101
            End If
        Catch e As Exception
            Console.Out.WriteLine("FileIOPermission demo failed")
            Console.WriteLine(e.ToString())
            Console.Out.WriteLine("Press the Enter key to exit.")
            Dim consoleInput As String = Console.ReadLine()
            System.Environment.ExitCode = 101
        End Try
    End Sub 'Main
End Class 'FileIOPermissionDemo


' This class generates FileIOPermission objects.

Friend Class FileIOGenerator


    Private myFile As String() = {"C:\Examples\Test\TestFile.txt", "C:\Examples\Test\", "C:\Examples\Test\..", "C:\Temp"}

    Private myAccess As FileIOPermissionAccess() = {FileIOPermissionAccess.AllAccess, FileIOPermissionAccess.Append, FileIOPermissionAccess.NoAccess, FileIOPermissionAccess.PathDiscovery, FileIOPermissionAccess.Read, FileIOPermissionAccess.Write}

    Private fileIndex As Integer = 0


    Public Sub New()

        ResetIndex()
    End Sub 'New


    Public Sub ResetIndex()
        fileIndex = 0
    End Sub 'ResetIndex

    ' Create a file path.
    '<Snippet10>
    Public Function CreateFilePath(ByRef file As String) As Boolean

        If fileIndex = myFile.Length Then
            file = ""
            fileIndex &= 1
            Return True
        End If
        If fileIndex > myFile.Length Then
            file = ""
            Return False
        End If

        file = myFile(fileIndex)
        fileIndex = fileIndex + 1

        Try
            Return True
        Catch e As Exception
            Console.WriteLine(("Cannot create FileIOPermission: " & file & " " & e.ToString()))
            file = ""
            Return True
        End Try
    End Function
    '</Snippet10>
End Class
'</Snippet1>