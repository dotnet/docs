'<snippet1>  
'This sample demonstrates methods of classes found in the System.IO IsolatedStorage namespace.
Imports System
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Security.Policy
Imports Microsoft.VisualBasic
Imports Microsoft.Win32.SafeHandles
Imports System.Security.Permissions



Namespace ISOCS
    _
    Class ConsoleApp


        <STAThread()> _
       Overloads Shared Sub Main(ByVal args() As String)

            ' Prompt the user for their username.
            Console.WriteLine("Enter your login ID:")

            ' Does no error checking.
            Dim lp As New LoginPrefs(Console.ReadLine())

            If lp.NewPrefs Then
                Console.WriteLine("Please set preferences for a new user.")
                GatherInfoFromUser(lp)

                ' Write the new preferences to storage.
                Dim percentUsed As Double = lp.SetPrefsForUser()
                Console.WriteLine(("Your preferences have been written. Current space used is " & percentUsed.ToString() & " %"))
            Else
                Console.WriteLine("Welcome back.")

                Console.WriteLine("Your preferences have expired, please reset them.")
                GatherInfoFromUser(lp)
                lp.SetNewPrefsForUser()

                Console.WriteLine("Your news site has been set to {0}" & ControlChars.Cr & " and your sports site has been set to {1}.", lp.NewsUrl, lp.SportsUrl)
            End If
            lp.GetIsoStoreInfo()
            Console.WriteLine("Enter 'd' to delete the IsolatedStorage files and exit, or press any other key to exit without deleting files.")
            Dim consoleInput As String = Console.ReadLine()
            If consoleInput.ToLower() = "d" Then
                lp.DeleteFiles()
                lp.DeleteDirectories()
            End If
        End Sub 'Main


        Shared Sub GatherInfoFromUser(ByVal lp As LoginPrefs)
            Console.WriteLine("Please enter the URL of your news site.")
            lp.NewsUrl = Console.ReadLine()
            Console.WriteLine("Please enter the URL of your sports site.")
            lp.SportsUrl = Console.ReadLine()
        End Sub 'GatherInfoFromUser
    End Class 'ConsoleApp
    _

    <SecurityPermissionAttribute(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Public Class LoginPrefs

        Public Sub New(ByVal myUserName As String)
            userName = myUserName
            myNewPrefs = GetPrefsForUser()
        End Sub 'New
        Private userName As String

        Private myNewsUrl As String

        Public Property NewsUrl() As String
            Get
                Return myNewsUrl
            End Get
            Set(ByVal Value As String)
                myNewsUrl = Value
            End Set
        End Property
        Private mySportsUrl As String

        Public Property SportsUrl() As String
            Get
                Return mySportsUrl
            End Get
            Set(ByVal Value As String)
                mySportsUrl = Value
            End Set
        End Property
        Private myNewPrefs As Boolean

        Public ReadOnly Property NewPrefs() As Boolean
            Get
                Return myNewPrefs
            End Get
        End Property

        '<snippet4>   
        Private Function GetPrefsForUser() As Boolean
            Try
                '<Snippet15>
                ' Retrieve an IsolatedStorageFile for the current Domain and Assembly.
                Dim isoFile As IsolatedStorageFile = _
                    IsolatedStorageFile.GetStore(IsolatedStorageScope.User _
                    Or IsolatedStorageScope.Assembly _
                    Or IsolatedStorageScope.Domain, Nothing, Nothing)

                Dim isoStream As New IsolatedStorageFileStream("substituteUsername", System.IO.FileMode.Open, _
                    System.IO.FileAccess.Read, System.IO.FileShare.Read)
                '</Snippet15>
                ' farThe code executes to this point only if a file corresponding to the username exists.
                ' Though you can perform operations on the stream, you cannot get a handle to the file.
                Try

                    Dim aFileHandle As SafeFileHandle = isoStream.SafeFileHandle
                    Console.WriteLine(("A pointer to a file handle has been obtained. " & aFileHandle.ToString() & " " & aFileHandle.GetHashCode()))

                Catch ex As Exception
                    ' Handle the exception.
                    Console.WriteLine("Expected exception")
                    Console.WriteLine(ex.ToString())
                End Try

                Dim reader As New StreamReader(isoStream)
                ' Read the data.
                Me.NewsUrl = reader.ReadLine()
                Me.SportsUrl = reader.ReadLine()
                reader.Close()
                isoFile.Close()
                Return False
            Catch ex As System.IO.FileNotFoundException
                ' Expected exception if a file cannot be found. This indicates that we have a new user.
                Return True
            End Try
        End Function 'GetPrefsForUser

        '</snippet4>
        '<snippet3> 
        Public Function GetIsoStoreInfo() As Boolean
            Try
                'Get a User store with type evidence for the current Domain and the Assembly.
                Dim isoFile As IsolatedStorageFile = _
                    IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                    IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))
                '<Snippet16>
                Dim dirNames As String() = isoFile.GetDirectoryNames("*")
                Dim fileNames As String() = isoFile.GetFileNames("*")
                Dim name As String

                ' List directories currently in this Isolated Storage.
                If dirNames.Length > 0 Then

                    For Each name In dirNames
                        Console.WriteLine("Directory Name: " & name)
                    Next name
                End If

                ' List the files currently in this Isolated Storage.
                ' The list represents all users who have personal preferences stored for this application.
                If fileNames.Length > 0 Then

                    For Each name In fileNames
                        Console.WriteLine("File Name: " & name)
                    Next name
                End If
                '</Snippet16>
                isoFile.Close()
                Return True
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Function 'GetIsoStoreInfo

        '</snippet3>
        '<snippet2>
        Public Function SetPrefsForUser() As Double
            Try
                '<snippet10>    
                Dim isoFile As IsolatedStorageFile
                isoFile = IsolatedStorageFile.GetUserStoreForDomain()

                ' Open or create a writable file.
                Dim isoStream As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, _
                    FileAccess.Write, isoFile)

                Dim writer As New StreamWriter(isoStream)
                writer.WriteLine(Me.NewsUrl)
                writer.WriteLine(Me.SportsUrl)
                ' Calculate the amount of space used to record the user's preferences.
                Dim d As Double = Convert.ToDouble(isoFile.CurrentSize) / Convert.ToDouble(isoFile.MaximumSize)
                Console.WriteLine(("CurrentSize = " & isoFile.CurrentSize.ToString()))
                Console.WriteLine(("MaximumSize = " & isoFile.MaximumSize.ToString()))
                ' StreamWriter.Close implicitly closes isoStream.
                writer.Close()
                isoFile.Dispose()
                isoFile.Close()
                Return d
                '</snippet10>
            Catch ex As Exception
                ' Add code here to handle the exception.
                Console.WriteLine(ex)
                Return 0.0
            End Try
        End Function 'SetPrefsForUser


        '</snippet2>
        '<snippet6>  
        Public Sub DeleteFiles()
            '<snippet9>  
            Try
                Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                    IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))
                Dim name As String
                Dim dirNames As String() = isoFile.GetDirectoryNames("*")
                Dim fileNames As String() = isoFile.GetFileNames("*")
                '</snippet9>
                ' List the files currently in this Isolated Storage.
                ' The list represents all users who have personal
                ' preferences stored for this application.
                If fileNames.Length > 0 Then
                    For Each name In fileNames
                        ' Delete the files.
                        isoFile.DeleteFile(name)
                    Next name
                    'Confirm no files are left.
                    fileNames = isoFile.GetFileNames("*")
                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Sub 'DeleteFiles

        '</snippet6>
        '<snippet8>  
        ' This method deletes directories in the specified Isolated Storage, after first 
        ' deleting the files they contain. In this example, the Archive directory is deleted. 
        ' There should be no other directories in this Isolated Storage.
        Public Sub DeleteDirectories()
            Try
                Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User _
                    Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))
                Dim name As String
                Dim dirNames As String() = isoFile.GetDirectoryNames("*")
                Dim fileNames As String() = isoFile.GetFileNames("Archive\*")
                ' Delete all the files currently in the Archive directory.
                If fileNames.Length > 0 Then
                    For Each name In fileNames
                        isoFile.DeleteFile(("Archive\" & name))
                    Next name
                    'Confirm no files are left.
                    fileNames = isoFile.GetFileNames("Archive\*")
                End If
                If dirNames.Length > 0 Then
                    For Each name In dirNames
                        ' Delete the Archive directory.
                        isoFile.DeleteDirectory(name)
                    Next name
                End If
                dirNames = isoFile.GetDirectoryNames("*")
                isoFile.Remove()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Sub 'DeleteDirectories

        '</snippet8>
        '<snippet7>  
        Public Function SetNewPrefsForUser() As Double
            Try
                Dim inputChar As Byte
                Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                    IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))

                ' If this is not a new user, archive the old preferences and 
                ' overwrite them using the new preferences.
                If Not Me.myNewPrefs Then
                    If isoFile.GetDirectoryNames("Archive").Length = 0 Then
                        isoFile.CreateDirectory("Archive")
                    Else

                        Dim source As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, isoFile)
                        Dim canWrite, canRead As Boolean
                        ' This is the stream from which data will be read.
                        If source.CanRead Then canRead = True Else canRead = False
                        Console.WriteLine("Is the source file readable? " & canRead)
                        Console.WriteLine("Creating new IsolatedStorageFileStream for Archive.")
                        '<Snippet11>
                        ' Open or create a writable file.
                        Dim target As New IsolatedStorageFileStream("Archive\ " & Me.userName, _
                             FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write, isoFile)
                        '</Snippet11>
                        ' This is the stream to which data will be written.
                        '<Snippet13>
                        If target.CanWrite Then canWrite = True Else canWrite = False
                        Console.WriteLine("Is the target file writable? " & canWrite)
                        '</Snippet13>
                        target.SetLength(0)  'rewind the target file

                        ' Stream the old file to a new file in the Archive directory.
                        If source.IsAsync And target.IsAsync Then
                            ' IsolatedStorageFileStreams cannot be asynchronous.  However, you
                            ' can use the asynchronous BeginRead and BeginWrite functions
                            ' with some possible performance penalty.
                            Console.WriteLine("IsolatedStorageFileStreams cannot be asynchronous.")
                        Else
                            '<Snippet14>
                            Console.WriteLine("Writing data to the new file.")
                            While source.Position < source.Length
                                inputChar = CByte(source.ReadByte())
                                target.WriteByte(inputChar)
                            End While

                            ' Determine the size of the IsolatedStorageFileStream
                            ' by checking its Length property.
                            Console.WriteLine(("Total Bytes Read: " & source.Length))
                            '</Snippet14>
                        End If

                        ' After you have read and written to the streams, close them.	
                        target.Close()
                        source.Close()
                    End If
                End If
                '<Snippet12>
                ' Open or create a writable file with a maximum size of 10K.
                Dim isoStream As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, _
                    FileAccess.Write, FileShare.Write, 10240, isoFile)
                '</Snippet12>
                isoStream.SetLength(0) 'Position to overwrite the old data.
                '</snippet7>
                '<snippet5>  
                Dim writer As New StreamWriter(isoStream)
                ' Update the data based on the new inputs.
                writer.WriteLine(Me.NewsUrl)
                writer.WriteLine(Me.SportsUrl)

                '  Calculate the amount of space used to record this user's preferences.
                Dim d As Double = Convert.ToDouble(isoFile.CurrentSize) / Convert.ToDouble(isoFile.MaximumSize)
                Console.WriteLine(("CurrentSize = " & isoFile.CurrentSize.ToString()))
                Console.WriteLine(("MaximumSize = " & isoFile.MaximumSize.ToString()))
                '</snippet5>
                ' StreamWriter.Close implicitly closes isoStream.
                writer.Close()
                isoFile.Close()

                Return d
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Return 0.0
            End Try
        End Function 'SetNewPrefsForUser
    End Class 'LoginPrefs
End Namespace 'ISOCS
'</snippet1>