'  System.TypeLoadException.TypeLoadException

'  This program demonstrates the 'TypeLoadException(string,Exception)
'  constructor of 'TypeLoadException' class. It attempts to call a 
'  non-existent method located in NonExistentDLL.dll, which will throw
'  an exception. A new exception is thrown with this exception as an 
'  inner exception.

Imports Microsoft.VisualBasic
' <Snippet1>
Imports System
Imports System.Runtime.InteropServices

Public Class TypeLoadException_Constructor3
   Public Shared Sub Main()
      Console.WriteLine("Calling a method in a non-existent DLL which triggers a TypeLoadException.")
      Try
         TypeLoadExceptionDemoClass.GenerateException()
      Catch e As TypeLoadException
         Console.WriteLine(("TypeLoadException: " + ControlChars.Cr + ControlChars.Tab + "Error Message = " + e.Message))
         Console.WriteLine(("TypeLoadException: " + ControlChars.Cr + ControlChars.Tab + "InnerException Message = " + e.InnerException.Message))
      Catch e As Exception
         Console.WriteLine(("Exception: " + ControlChars.Cr + ControlChars.Tab + "Error Message = " + e.Message))
      End Try
   End Sub 'Main
End Class 'TypeLoadException_Constructor3

Class TypeLoadExceptionDemoClass
   ' A call to this method will raise a TypeLoadException.
   Public Declare Sub NonExistentMethod Lib "NonExistentDLL.DLL" Alias "MethodNotExists" ()

   Public Shared Sub GenerateException()
      Try
         NonExistentMethod()
      Catch e As TypeLoadException
         ' Rethrow exception with the exception as inner exception
         Throw New TypeLoadException("This exception was raised due to a call to an invalid method.", e)
      End Try
   End Sub 'GenerateException
End Class 'TypeLoadExceptionDemoClass
' </Snippet1>