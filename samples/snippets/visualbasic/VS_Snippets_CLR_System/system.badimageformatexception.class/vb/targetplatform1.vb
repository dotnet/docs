' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.IO
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim args() As String = Environment.GetCommandLineArgs()
      If args.Length = 1 Then
         Console.WriteLine()
         Console.WriteLine("Syntax:   PlatformInfo <filename> ")
         Console.WriteLine()
         Exit Sub
      End If
      Console.WriteLine()
      
      ' Loop through files and display information about their platform.
      For ctr As Integer = 1 To args.Length - 1
         Dim fn As String = args(ctr)
         If Not File.Exists(fn) Then
            Console.WriteLine("File: {0}", fn)
            Console.WriteLine("The file does not exist.")
            Console.WriteLine()
         Else
            Try
               Dim an As AssemblyName = AssemblyName.GetAssemblyName(fn)
               Console.WriteLine("Assembly: {0}", an.Name)
               If an.ProcessorArchitecture = ProcessorArchitecture.MSIL Then
                  Console.WriteLine("Architecture: AnyCPU")
               Else
                  Console.WriteLine("Architecture: {0}", an.ProcessorArchitecture)
               End If
            Catch e As BadImageFormatException
               Console.WriteLine("File: {0}", fn)
               Console.WriteLine("Not a valid assembly.\n")
            End Try
            Console.WriteLine()
         End If
      Next
   End Sub
End Module
' </Snippet4>
