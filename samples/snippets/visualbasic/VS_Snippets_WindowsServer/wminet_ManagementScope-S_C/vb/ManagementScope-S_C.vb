'<Snippet1>
Imports System
Imports System.Management
Public Class RemoteConnect

    Public Overloads Shared Function Main( _
    ByVal args() As String) As Integer


        ' Build an options object for the remote connection
        ' if you plan to connect to the remote
        ' computer with a different user name
        ' and password than the one you are currently using

        ' Dim options As ConnectionOptions 
        ' options = new ConnectionOptions()

        ' Then set the options.Username and 
        ' options.Password properties to the correct values
        ' and also set 
        ' options.Authority = "ntlmdomain:DOMAIN"
        ' and replace DOMAIN with the remote computer's
        ' domain.  You can also use Kerberos instead
        ' of ntlmdomain.


        ' Make a connection to a remote computer.
        ' Replace the "FullComputerName" section of the
        ' string "\\FullComputerName\root\cimv2" with
        ' the full computer name or IP address of the
        ' remote computer.
        Dim scope As ManagementScope
        scope = New ManagementScope( _
            "\\FullComputerName\root\cimv2")
        scope.Connect()

        ' Use this code if you are connecting with a 
        ' different user name and password:
        '
        ' Dim scope As ManagementScope
        ' scope = New ManagementScope( _
        '     "\\FullComputerName\root\cimv2", options)
        ' scope.Connect()

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
End Class
'</Snippet1>