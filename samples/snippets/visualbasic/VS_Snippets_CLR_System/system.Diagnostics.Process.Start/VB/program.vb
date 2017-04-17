'<Snippet1>
' This sample requires a text.txt file file in your documents folder.
' You'll also need to set the startup object in the project to Sub Main.
Imports System.Diagnostics
Imports System.Security
Imports System.ComponentModel

Module Program
    Sub Main()
        Console.Write("Enter your domain: ")
        Dim domain As String = Console.ReadLine()
        Console.Write("Enter you user name: ")
        Dim uname As String = Console.ReadLine()
        Console.Write("Enter your password: ")
        Dim password As New SecureString()
        Dim key As ConsoleKeyInfo
        Do
           key = Console.ReadKey(True)

           ' Ignore any key out of range.
           If key.Key >= 33 AndAlso key.Key <= 90 AndAlso key.Key <> ConsoleKey.Enter Then
              ' Append the character to the password.
              password.AppendChar(key.KeyChar)
              Console.Write("*")
           End If
        ' Exit if Enter key is pressed.
        Loop While key.Key <> ConsoleKey.Enter
        Console.WriteLine()

        Try
            Console.WriteLine(vbCrLf + "Trying to launch NotePad using your login information...")
            Process.Start("notepad.exe", uname, password, domain)
        Catch ex As Win32Exception
            Console.WriteLine(ex.Message)
        End Try

        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"

        Try
            ' The following call to Start succeeds if test.txt exists.
            Console.WriteLine(vbCrLf + "Trying to launch 'text.txt'...")
            Process.Start(path + "Text.txt")
        Catch ex As Win32Exception
            Console.WriteLine(ex.Message)
        End Try

        Try
            ' Attempting to start in a shell using this Start overload fails. This causes
            ' the following exception, which is picked up in the catch block below:
            ' The specified executable is not a valid application for this OS platform.
            Console.WriteLine(vbCrLf + "Trying to launch 'text.txt' with your login information...")
            Process.Start(path + "Text.txt", uname, password, domain)
        Catch ex As Win32Exception
            Console.WriteLine(ex.Message)
        Finally
            password.Dispose()
        End Try
    End Sub
End Module
'</Snippet1>