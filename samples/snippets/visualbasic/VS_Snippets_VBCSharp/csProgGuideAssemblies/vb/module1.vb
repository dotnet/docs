'<Snippet2>
Imports System.Runtime.CompilerServices
Imports System
<Assembly: InternalsVisibleTo("AssemblyB")> 

' Friend class.
Friend Class FriendClass
    Public Sub Test()
        Console.WriteLine("Sample Class")
    End Sub
End Class

' Public class with a Friend method.
Public Class ClassWithFriendMethod
    Friend Sub Test()
        Console.WriteLine("Sample Method")
    End Sub
End Class
'</Snippet2>

'<Snippet1>
Module Module1
    Sub Main()
        Try
            Dim testAssembly As Reflection.AssemblyName =
                                Reflection.AssemblyName.GetAssemblyName("C:\Windows\Microsoft.NET\Framework\v3.5\System.Net.dll")
            Console.WriteLine("Yes, the file is an Assembly.")
        Catch ex As System.IO.FileNotFoundException
            Console.WriteLine("The file cannot be found.")
        Catch ex As System.BadImageFormatException
            Console.WriteLine("The file is not an Assembly.")
        Catch ex As System.IO.FileLoadException
            Console.WriteLine("The Assembly has already been loaded.")
        End Try
        Console.ReadLine()
    End Sub
End Module
' Output (with .NET Framework 3.5 installed):
'        Yes, the file is an Assembly.
'</Snippet1>