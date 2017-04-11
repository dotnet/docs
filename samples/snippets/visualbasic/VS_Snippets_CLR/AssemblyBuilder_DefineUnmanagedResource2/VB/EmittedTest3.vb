'   Supporting file for AssemblyBuilder_DefineUnmanagedResource2.cs
'   Note : Calls  EmitClass class from 'MyEmitTestAssembly.dll' using reflection emit.

Imports System

Public Class MyAssemblyResourceApplication
   
   Public Shared Sub Main()
      Try
         CallEmitMethod()
       Catch Ex As TypeLoadException
         Console.WriteLine("Unable to load EmitClass type from MyEmitTestAssembly.dll!")
      End Try
   End Sub 'Main
   
   Private Shared Sub CallEmitMethod()
      Dim myEmit As New EmitClass()
      Console.WriteLine(myEmit.Display())
   End Sub 'CallEmitMethod
End Class 'MyAssemblyResourceApplication