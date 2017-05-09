
'<Snippet1>
' This sample demonstrates the use of the WindowsIdentity class to impersonate a user.
' IMPORTANT NOTES: 
' This sample requests the user to enter a password on the console screen.
' Because the console window does not support methods allowing the password to be masked,
' it will be visible to anyone viewing the screen.
' On Windows Vista and later this sample must be run as an administrator. 

Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions
Imports Microsoft.VisualBasic
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.ConstrainedExecution
Imports System.Security

Module Module1

    Public Class ImpersonationDemo

        'Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], _
        '    ByVal lpszDomain As [String], ByVal lpszPassword As [String], _
        '    ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
        '    ByRef phToken As IntPtr) As Boolean

        Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], _
            ByVal lpszDomain As [String], ByVal lpszPassword As [String], _
            ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
            <Out()> ByRef phToken As SafeTokenHandle) As Boolean

        Public Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean

        ' Test harness.
        ' If you incorporate this code into a DLL, be sure to demand FullTrust.
        <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
        Public Overloads Shared Sub Main(ByVal args() As String)
            Dim safeTokenHandle As SafeTokenHandle
            Dim tokenHandle As New IntPtr(0)
            Try


                Dim userName, domainName As String

                ' Get the user token for the specified user, domain, and password using the 
                ' unmanaged LogonUser method.  
                ' The local machine name can be used for the domain name to impersonate a user on this machine.
                Console.Write("Enter the name of a domain on which to log on: ")
                domainName = Console.ReadLine()

                Console.Write("Enter the login of a user on {0} that you wish to impersonate: ", domainName)
                userName = Console.ReadLine()

                Console.Write("Enter the password for {0}: ", userName)

                Const LOGON32_PROVIDER_DEFAULT As Integer = 0
                'This parameter causes LogonUser to create a primary token.
                Const LOGON32_LOGON_INTERACTIVE As Integer = 2

                ' Call LogonUser to obtain a handle to an access token.
                Dim returnValue As Boolean = LogonUser(userName, domainName, Console.ReadLine(), LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, safeTokenHandle)

                Console.WriteLine("LogonUser called.")

                If False = returnValue Then
                    Dim ret As Integer = Marshal.GetLastWin32Error()
                    Console.WriteLine("LogonUser failed with error code : {0}", ret)
                    Throw New System.ComponentModel.Win32Exception(ret)

                    Return
                End If
                Using safeTokenHandle
                    Dim success As String
                    If returnValue Then success = "Yes" Else success = "No"
                    Console.WriteLine(("Did LogonUser succeed? " + success))
                    Console.WriteLine(("Value of Windows NT token: " + safeTokenHandle.DangerousGetHandle().ToString()))

                    ' Check the identity.
                    Console.WriteLine(("Before impersonation: " + WindowsIdentity.GetCurrent().Name))

                    ' Use the token handle returned by LogonUser.
                    Using impersonatedUser As WindowsImpersonationContext = WindowsIdentity.Impersonate(safeTokenHandle.DangerousGetHandle())

                        ' Check the identity.
                        Console.WriteLine(("After impersonation: " + WindowsIdentity.GetCurrent().Name))

                        ' Free the tokens.
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine(("Exception occurred. " + ex.Message))
            End Try
        End Sub 'Main 
    End Class 'Class1
End Module

Public NotInheritable Class SafeTokenHandle
    Inherits SafeHandleZeroOrMinusOneIsInvalid

    Private Sub New()
        MyBase.New(True)

    End Sub 'New

    Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], _
            ByVal lpszDomain As [String], ByVal lpszPassword As [String], _
            ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
            ByRef phToken As IntPtr) As Boolean
    <DllImport("kernel32.dll"), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), SuppressUnmanagedCodeSecurity()> _
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function
    Protected Overrides Function ReleaseHandle() As Boolean
        Return CloseHandle(handle)

    End Function 'ReleaseHandle
End Class 'SafeTokenHandle
'</Snippet1>
