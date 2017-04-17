' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Private Const ERROR_BAD_ARGUMENTS As Integer = &hA0
   Private Const ERROR_ARITHMETIC_OVERFLOW As Integer = &h216
   Private Const ERROR_INVALID_COMMAND_LINE As Integer = &h667
    
   Public Sub Main()
      Dim args() As String = Environment.GetCommandLineArgs()
      If args.Length = 1 Then
         Environment.ExitCode = ERROR_INVALID_COMMAND_LINE  
      Else
         Dim value As BigInteger = 0
         If BigInteger.TryParse(args(1), value) Then
            If value <= Int32.MinValue Or value >= Int32.MaxValue
               Environment.ExitCode = ERROR_ARITHMETIC_OVERFLOW
            Else
               Console.WriteLine("Result: {0}", value * 2)
            End If
         Else
            Environment.ExitCode = ERROR_BAD_ARGUMENTS
         End If     
      End If
   End Sub
End Module
' </Snippet1>
