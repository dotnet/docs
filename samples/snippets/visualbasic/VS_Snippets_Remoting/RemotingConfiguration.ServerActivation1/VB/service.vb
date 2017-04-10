 ' <Snippet4>
Imports System


Public Class HelloService
   Inherits MarshalByRefObject
   
   Private Shared n_instances As Integer
     
   Public Sub New()
      n_instances += 1
      Console.WriteLine("")
      Console.WriteLine("HelloService activated - instance # {0}.", n_instances)
   End Sub 'New
   
   
   Protected Overrides Sub Finalize()
      Console.WriteLine("HelloService instance {0} destroyed.", n_instances)
      n_instances -= 1
      MyBase.Finalize()
   End Sub 'Finalize
   
   
   Public Function HelloMethod(name As [String]) As [String]
      Console.WriteLine("HelloMethod called on HelloService instance {0}.", n_instances)
      Return "Hi there " + name + "."
   End Function 'HelloMethod

End Class 'HelloService
' </Snippet4>