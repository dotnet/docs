' <Snippet3>
Imports System

Public Class HelloServiceClass
   Inherits MarshalByRefObject
   
   Private Shared n_instance As Integer

      
   Public Sub New()
      n_instance += 1
      Console.WriteLine(Me.GetType().Name + " has been created.  Instance # = {0}", n_instance)
   End Sub 'New
      
   
   Protected Overrides Sub Finalize()
      Console.WriteLine("Destroyed instance {0} of HelloServiceClass.", n_instance)
      n_instance -= 1
      MyBase.Finalize()
   End Sub 'Finalize
   
   
   
   Public Function HelloMethod(name As [String]) As [String]
      
      ' Reports that the method was called.
      Console.WriteLine()
      Console.WriteLine("Called HelloMethod on instance {0} with the '{1}' parameter.", n_instance, name)
      
      ' Calculates and returns the result to the client.
      Return "Hi there " + name + "."

   End Function 'HelloMethod

End Class 'HelloServiceClass
' </Snippet3>