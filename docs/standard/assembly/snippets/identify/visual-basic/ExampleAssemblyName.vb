'<SnippetAssemblyName>
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Module ExampleAssemblyName
    Sub CheckAssembly()
        Try
            Dim filePath As String = Path.Combine(
                RuntimeEnvironment.GetRuntimeDirectory(),
                "System.Net.dll")

            Dim testAssembly As AssemblyName =
                                AssemblyName.GetAssemblyName(filePath)
            Console.WriteLine("Yes, the file is an Assembly.")
        Catch ex As FileNotFoundException
            Console.WriteLine("The file cannot be found.")
        Catch ex As BadImageFormatException
            Console.WriteLine("The file is not an Assembly.")
        Catch ex As FileLoadException
            Console.WriteLine("The Assembly has already been loaded.")
        End Try
    End Sub
End Module
' Output:  
' Yes, the file is an Assembly.  
'</SnippetAssemblyName>
