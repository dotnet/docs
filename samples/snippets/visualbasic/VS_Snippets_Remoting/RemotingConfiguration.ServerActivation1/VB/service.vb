 ' <Snippet4>
Public Class HelloService
   Inherits MarshalByRefObject
   
   Private Shared n_instances As Integer
     
   Public Sub New()
      n_instances += 1
      Console.WriteLine("")
      Console.WriteLine("HelloService activated - instance # {0}.", n_instances)
   End Sub
   
   
   Protected Overrides Sub Finalize()
      Console.WriteLine("HelloService instance {0} destroyed.", n_instances)
      n_instances -= 1
      MyBase.Finalize()
   End Sub
   
   
   Public Function HelloMethod(name As [String]) As [String]
      Console.WriteLine("HelloMethod called on HelloService instance {0}.", n_instances)
      Return "Hi there " + name + "."
   End Function 'HelloMethod

End Class
' </Snippet4>