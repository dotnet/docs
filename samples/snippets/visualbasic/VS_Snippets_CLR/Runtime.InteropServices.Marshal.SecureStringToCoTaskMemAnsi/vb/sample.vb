'<snippet1>
Imports System.Runtime.InteropServices
Imports System.Security

Module Example
    Sub Main()
        Dim unmanagedRef As IntPtr

         ' Ask the user for a password.
         Console.Write("Please enter your password: ")
         Dim passWord As SecureString = GetPassword()

         Console.WriteLine("Copying and decrypting the string to unmanaged memory...")

         ' Copy the Secure string to unmanaged memory (and decrypt it).
         unmanagedRef = Marshal.SecureStringToCoTaskMemAnsi(passWord)

         If unmanagedRef <> IntPtr.Size Then
             Console.WriteLine("Zeroing out unmanaged memory...")
             Marshal.ZeroFreeCoTaskMemAnsi(unmanagedRef)
         End If
         passWord.Dispose()

        Console.WriteLine("Done.")
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
End Module
'</snippet1>