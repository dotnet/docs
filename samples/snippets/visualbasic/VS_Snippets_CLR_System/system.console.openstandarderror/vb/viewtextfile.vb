' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO

Module ViewTextFile
   Public Sub Main()
      Dim args() As String = Environment.GetCommandLineArgs()
      Dim errorOutput As String = ""
      ' Make sure that there is at least one command line argument.
      If args.Length <= 1 Then
         errorOutput += "You must include a filename on the command line." +
                        vbCrLf
      End If
      
      For ctr As Integer = 1 To args.GetUpperBound(0)
         ' Check whether the file exists.
         If Not File.Exists(args(ctr)) Then
            errorOutput += String.Format("'{0}' does not exist.{1}",
                                         args(ctr), vbCrLf)
         Else
            ' Display the contents of the file.
            Dim sr As New StreamReader(args(ctr))
            Dim contents As String = sr.ReadToEnd()
            sr.Close()
            Console.WriteLine("***** Contents of file '{0}':{1}{1}",
                              args(ctr), vbCrLf)
            Console.WriteLine(contents)
            Console.WriteLine("*****{0}", vbCrLf)
         End If
      Next

      ' Check for error conditions.
      If Not String.IsNullOrEmpty(errorOutput) Then
         ' Write error information to a file.
         Console.SetError(New StreamWriter(".\ViewTextFile.Err.txt"))
         Console.Error.WriteLine(errorOutput)
         Console.Error.Close()
         ' Reacquire the standard error stream.
         Dim standardError As New StreamWriter(Console.OpenStandardError())
         standardError.AutoFlush = True
         Console.SetError(standardError)
         Console.Error.WriteLine("{0}Error information written to ViewTextFile.Err.txt",
                                 vbCrLf)
      End If
   End Sub
End Module
' If the example is compiled and run with the following command line:
'     ViewTextFile file1.txt file2.txt
' and neither file1.txt nor file2.txt exist, it displays the
' following output:
'     Error information written to ViewTextFile.Err.txt
' and writes the following text to ViewFileText.Err.txt:
'     'file1.txt' does not exist.
'     'file2.txt' does not exist.
' </Snippet1>
