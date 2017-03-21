Imports System
Imports System.Text
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Principal
Imports System.Security.Permissions

Public Class HelloServiceClass
   Inherits MarshalByRefObject
   
   Private Shared n_instances As Integer
   Private instanceNum As Integer  
   
   Public Sub New()
      n_instances += 1
      instanceNum = n_instances
      Console.WriteLine(Me.GetType().Name + " has been created.  Instance # = {0}", instanceNum)
   End Sub 'New

   
   Protected Overrides Sub Finalize()
      Console.WriteLine("Destroyed instance {0} of HelloServiceClass.", instanceNum)
      MyBase.Finalize()
   End Sub 'Finalize
  
   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Function HelloMethod(name As [String]) As [String]
      
      'Extract the call context data
      Dim data As LogicalCallContextData = CType(CallContext.GetData("test data"), LogicalCallContextData)
      Dim myPrincipal As IPrincipal = data.Principal
      
      'Check the user identity
      If myPrincipal.Identity.Name = "Bob" Then
         Console.WriteLine()
         Console.WriteLine("Hello {0}, you are identified!", myPrincipal.Identity.Name)
         Console.WriteLine(data.numOfAccesses)
      Else
         Console.WriteLine("Go away! You are not identified!")
         Return [String].Empty
      End If
      
      ' calculate and return result to client	
      Return "Hi there " + name + "."
   End Function 'HelloMethod

End Class 'HelloServiceClass