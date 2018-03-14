' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Security.Permissions
Imports Microsoft.Win32


Public Class RemoteKey

    Shared Sub Main(commandLineArgs As String())
    
        Dim environmentKey As RegistryKey

        ' Check that an argument was specified when the 
        ' program was invoked.
        If commandLineArgs.Length = 0 Then
            Console.WriteLine("Error: The name of the remote " & _
                "computer must be specified as input on the " & _
                "command line.")
            Return
        End If

        Try
            ' Open HKEY_CURRENT_USER\Environment on a remote computer.
            environmentKey = RegistryKey.OpenRemoteBaseKey( _
                RegistryHive.CurrentUser, _
                commandLineArgs(0)).OpenSubKey("Environment")
        Catch ex As IOException
            Console.WriteLine("{0}: {1}", _
                ex.GetType().Name, ex.Message)
            Return
        End Try

        ' Print the values.
        Console.WriteLine("\nThere are {0} values For {1}.", _
            environmentKey.ValueCount.ToString(), environmentKey.Name)

        For Each valueName As String In environmentKey.GetValueNames()
            Console.WriteLine("{0,-20}: {1}", valueName, _
                environmentKey.GetValue(valueName).ToString())
        Next

        ' Close the registry key.
        environmentKey.Close()
    
    End Sub
End Class
' </Snippet1>