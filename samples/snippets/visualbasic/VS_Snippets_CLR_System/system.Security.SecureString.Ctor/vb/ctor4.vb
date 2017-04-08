' <Snippet4>
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Security

Public Class Example
    Public Shared Sub Main()
        ' Instantiate the secure string.
        Dim securePwd As New SecureString()
        Dim key As ConsoleKeyInfo
        
        Console.Write("Enter password: ")
        Do
           key = Console.ReadKey(True)

           ' Ignore any key out of range
           If CInt(key.Key) >= 65 And CInt(key.Key <= 90) Then    
              ' Append the character to the password.
              securePwd.AppendChar(key.KeyChar)
              Console.Write("*")
           End If                                    
        ' Exit if Enter key is pressed.
        Loop While key.Key <> ConsoleKey.Enter
        Console.WriteLine()
        
        Try
            Process.Start("Notepad.exe", "MyUser", securePwd, "MYDOMAIN")
        Catch e As Win32Exception
            Console.WriteLine(e.Message)
        Finally
           securePwd.Dispose()
        End Try
    End Sub
End Class
' </Snippet4>
