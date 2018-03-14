'<snippet1>
Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Principal

Module Example
    ' PInvoke into the Win32 API to provide access to the
    ' LogonUser and CloseHandle functions.
    <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function LogonUser(ByVal username As String, ByVal domain As String, _
                       ByVal password As IntPtr, ByVal logonType As Integer, _
                       ByVal logonProvider As Integer, ByRef token As IntPtr) _
                       As Boolean
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Function CloseHandle(ByVal handle As IntPtr) As Boolean
    End Function

    ' Define the required LogonUser enumerations.
    Const LOGON32_PROVIDER_DEFAULT As Integer = 0
    Const LOGON32_LOGON_INTERACTIVE As Integer = 2

    Sub Main(ByVal args() As String)
        ' Display the current user before impersonation.
        Console.WriteLine("Before impersonation: {0}",
                          WindowsIdentity.GetCurrent().Name)

        ' Ask the user for a network domain.
        Console.Write("Please enter your domain:")
        Dim domain As String = Console.ReadLine()

        ' Ask the user for a user name.
        Console.Write("Please enter your user name:")
        Dim username As String = Console.ReadLine()

        ' Ask the user for a password.
        Console.Write("Please enter your password:")
        Dim passWord As SecureString = GetPassword()

        ' Impersonate the account provided by the user.
        Try
            Dim userContext As WindowsImpersonationContext =
                            ImpersonateUser(passWord, username, domain)
            ' Display the current user after impersonation.
            Console.WriteLine("After impersonation: {0}",
                              WindowsIdentity.GetCurrent().Name)
         Catch e As ArgumentException
            Console.WriteLine(e.Message)
             Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
         Catch e As Win32Exception
             Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
         Finally
              passWord.Dispose()
         End Try
    End Sub

    Function GetPassword() As SecureString
        Dim password As New SecureString()

        ' get the first character of the password
        Dim nextKey As ConsoleKeyInfo = Console.ReadKey(True)

        While nextKey.Key <> ConsoleKey.Enter
            If nextKey.Key = ConsoleKey.BackSpace Then
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

    Function ImpersonateUser(ByVal password As SecureString,
                             ByVal userName As String,
                             ByVal domainName As String) As WindowsImpersonationContext
        Dim tokenHandle As IntPtr = IntPtr.Zero
        Dim passwordPtr As IntPtr = IntPtr.Zero
        Dim returnValue As Boolean = False
        Dim err As Integer = 0
        
        ' Marshal the SecureString to unmanaged memory.
        passwordPtr = Marshal.SecureStringToGlobalAllocUnicode(password)

        ' Pass LogonUser the unmanaged (and decrypted) copy of the password.
        returnValue = LogonUser(userName, domainName, passwordPtr,
                                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                                tokenHandle)
        If Not returnValue AndAlso tokenHandle = IntPtr.Zero Then
            err = Marshal.GetLastWin32Error()
        End If
        
        ' Perform cleanup whether or not the call succeeded.
        ' Zero-out and free the unmanaged string reference.
        Marshal.ZeroFreeGlobalAllocUnicode(passwordPtr)
        ' Close the token handle.
        CloseHandle(tokenHandle)

        ' Throw an exception if an error occurred.
        If err <> 0 Then
            Throw New System.ComponentModel.Win32Exception(err)
        End If
        ' The token that is passed to the following constructor must 
        ' be a primary token in order to use it for impersonation.
        Dim newId As New WindowsIdentity(tokenHandle)

        Return newId.Impersonate()
    End Function
End Module
'</snippet1>