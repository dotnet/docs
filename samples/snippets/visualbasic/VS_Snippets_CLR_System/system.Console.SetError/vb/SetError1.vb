' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.IO
Imports System.Reflection

Module RedirectStdErr
   Public Sub Main()
      ' Define file to receive error stream.
      Dim appStart As Date = Date.Now
      Dim fn As String = "c:\temp\errlog" & appStart.ToString("yyyyMMddHHmm") & ".log"
      Dim errStream As New StreamWriter(fn)
      Dim appName As String = GetType(RedirectStdErr).Assembly.Location
      appName = Mid(appName, InStrRev(appName, "\") + 1)
      ' Redirect standard error stream to file.
      Console.SetError(errStream)
      ' Write file header.
      Console.Error.WriteLine("Error Log for Application {0}", appName)
      Console.Error.WriteLine()
      Console.Error.WriteLine("Application started at {0}.", appStart)
      Console.Error.WriteLine()
      '
      ' Application code along with error output 
      '
      ' Close redirected error stream.
      Console.Error.Close()
   End Sub
End Module
' </Snippet1>
