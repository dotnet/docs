' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim totalSize As Long = 0

        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length = 1 Then
            Console.WriteLine("There are no command line arguments.")
            Return
        End If
        If Not Directory.Exists(args(1))
            Console.WriteLine("The directory does not exist.")
            Return
        End If

        Dim files() As String = Directory.GetFiles(args(1))
        Parallel.For(0, files.Length,
                     Sub(index As Integer)
                         Dim fi As New FileInfo(files(index))
                         Dim size As Long = fi.Length
                         Interlocked.Add(totalSize, size)
                     End Sub)
        Console.WriteLine("Directory '{0}':", args(1))
        Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize)
    End Sub
End Module
' The example displays output like the following:
'       Directory 'c:\windows\':
'       32 files, 6,587,222 bytes
' </Snippet1>
