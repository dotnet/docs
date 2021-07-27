'<SnippetPeReader>
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection.Metadata
Imports System.Reflection.PortableExecutable
Imports System.Runtime.InteropServices

Module ExamplePeReader
    Function IsAssembly(path As String) As Boolean

        Dim fs As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

        ' Try to read CLI metadata from the PE file.
        Dim peReader As PEReader = New PEReader(fs)
        Using (peReader)
            If Not peReader.HasMetadata Then
                Return False ' File does Not have CLI metadata.
            End If

            ' Check that file has an assembly manifest.
            Dim reader As MetadataReader = peReader.GetMetadataReader()
            Return reader.IsAssembly
        End Using
    End Function

    Sub CheckAssembly()
        Dim filePath As String = Path.Combine(
                RuntimeEnvironment.GetRuntimeDirectory(),
                "System.Net.dll")

        Try
            If IsAssembly(filePath) Then
                Console.WriteLine("Yes, the file is an assembly.")
            Else
                Console.WriteLine("The file is not an assembly.")
            End If
        Catch ex As BadImageFormatException
            Console.WriteLine("The file is not an executable.")
        Catch ex As FileNotFoundException
            Console.WriteLine("The file cannot be found.")
        End Try
    End Sub
End Module
' Output:  
' Yes, the file is an Assembly.
'</SnippetPeReader>
