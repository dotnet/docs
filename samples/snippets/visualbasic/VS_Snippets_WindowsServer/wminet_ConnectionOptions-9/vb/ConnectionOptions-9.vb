'<Snippet1>
Imports System
Imports System.Management
Imports System.Security

Public Class RemoteConnect

    Public Overloads Shared Function Main( _
    ByVal args() As String) As Integer


        ' Build an options object for the remote connection
        ' if you plan to connect to the remote
        ' computer with a different user name
        ' and password than the one you are currently using.

        Dim pw As SecureString
        pw = GetPassword()
        Dim options As ConnectionOptions
        options = New ConnectionOptions("MS_409", "userName", pw, _
             "ntlmdomain:DOMAIN", _
             System.Management.ImpersonationLevel.Impersonate, _
             System.Management.AuthenticationLevel.Default, True, _
             Nothing, System.TimeSpan.MaxValue)

        ' Make a connection to a remote computer.
        ' Replace the "FullComputerName" section of the
        ' string "\\FullComputerName\root\cimv2" with
        ' the full computer name or IP address of the
        ' remote computer.
        Dim scope As ManagementScope
        scope = New ManagementScope( _
            "\\FullComputerName\root\cimv2", options)
        scope.Connect()

        ' Query system for Operating System information
        Dim query As ObjectQuery
        query = New ObjectQuery( _
            "SELECT * FROM Win32_OperatingSystem")
        Dim searcher As ManagementObjectSearcher
        searcher = _
            New ManagementObjectSearcher(scope, query)

        Dim queryCollection As ManagementObjectCollection
        queryCollection = searcher.Get()

        Dim m As ManagementObject
        For Each m In queryCollection
            ' Display the remote computer information
            Console.WriteLine("Computer Name : {0}", _
                m("csname"))
            Console.WriteLine("Windows Directory : {0}", _
                m("WindowsDirectory"))
            Console.WriteLine("Operating System: {0}", _
                m("Caption"))
            Console.WriteLine("Version: {0}", m("Version"))
            Console.WriteLine("Manufacturer : {0}", _
                m("Manufacturer"))
        Next

        Return 0
    End Function


    ' Read a password from the console into a SecureString
    Public Shared Function GetPassword() As SecureString

        Dim password As New SecureString()
        Console.WriteLine("Enter password: ")

        ' get the first character of the password
        Dim nextKey As ConsoleKeyInfo
        nextKey = Console.ReadKey(True)

        While nextKey.Key <> ConsoleKey.Enter

            If nextKey.Key = ConsoleKey.Backspace Then
                If password.Length > 0 Then
                    password.RemoveAt(password.Length - 1)

                    ' erase the last * as well
                    Console.Write(nextKey.KeyChar)
                    Console.Write(" ")
                    Console.Write(nextKey.KeyChar)
                End If
            Else
                password.AppendChar(nextKey.KeyChar)
                Console.Write("*")
            End If

            nextKey = Console.ReadKey(True)
        End While

        Console.WriteLine()

        ' lock the password down
        password.MakeReadOnly()
        Return password
    End Function
End Class
'</Snippet1>