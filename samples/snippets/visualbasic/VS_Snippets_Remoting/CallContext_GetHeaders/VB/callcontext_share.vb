' System.Runtime.Remoting.CallContext.SetHeaders(Header[])
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Contexts
Imports System.Security
Imports System.Security.Principal
Imports System.Security.Permissions

Namespace RemotingSamples

' <Snippet3>
   Public Class HelloService
      Inherits MarshalByRefObject

      Public Function HelloMethod(name As String) As String
         Console.WriteLine(("Hello " + name))
         Return "Hello " + name
      End Function 'HelloMethod

      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Function HeaderMethod(name As String, arrHeader() As Header) As String
         Console.WriteLine("HeaderMethod " + name)
         'Header Set with the header array passed
         CallContext.SetHeaders(arrHeader)
         Return "HeaderMethod " + name
      End Function 'HeaderMethod
   End Class 'HelloService
' </Snippet3>

   ' 'CallContext' and 'ILogicalThreadAffinative' is needed to pass information between threads
   ' on either end of a call across an application domain boundary or context boundary.
   <Serializable()> _
   Public Class MyLogicalCallContextData
      Implements ILogicalThreadAffinative
      Private noOfAccesses As Integer
      Private myIprincipal As IPrincipal
      Public ReadOnly Property numOfAccesses() As String
         Get
            Return String.Format("The identity of {0} has been accessed {1} times.", _
                                                   myIprincipal.Identity.Name, noOfAccesses)
         End Get
      End Property

      Public ReadOnly Property Principal() As IPrincipal
         Get
            noOfAccesses += 1
            Return myIprincipal
         End Get
      End Property

      Public Sub New(p As IPrincipal)
         noOfAccesses = 0
         myIprincipal = p
      End Sub 'New
   End Class 'MyLogicalCallContextData
End Namespace 'RemotingSamples

