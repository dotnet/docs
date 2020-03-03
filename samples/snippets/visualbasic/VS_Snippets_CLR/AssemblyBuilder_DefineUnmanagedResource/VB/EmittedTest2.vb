' Note : Calls  EmitClass class from 'MyEmitTestAssembly.dll' using reflection emit.

Public Class MyAssemblyResourceApplication
   
   Public Shared Sub Main()
      Try
         CallEmitMethod()
      Catch Ex As TypeLoadException
         Console.WriteLine("Unable to load EmitClass type from MyEmitTestAssembly.dll!")
      End Try
   End Sub
   
   Private Shared Sub CallEmitMethod()
      Dim myEmit As New EmitClass()
      Console.WriteLine(myEmit.Display())
   End Sub
End Class