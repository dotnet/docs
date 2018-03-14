' <Snippet1>
Imports System
Imports System.Runtime.Remoting


Public Class MyType
   Inherits MarshalByRefObject
      
   Public Sub New()
      Console.Write("Created an instance of MyType in an AppDomain with the ")
      Console.WriteLine("hashcode {0}", AppDomain.CurrentDomain.GetHashCode())
      Console.WriteLine("")
   End Sub 'New
   
   
   Public Function GetAppDomainHashCode() As Integer
      Return AppDomain.CurrentDomain.GetHashCode()
   End Function 'GetAppDomainHashCode

End Class 'MyType


Class Test
     
   Public Shared Sub Main()
      
      Console.WriteLine("The hash code of the default AppDomain is {0}.", AppDomain.CurrentDomain.GetHashCode())
      Console.WriteLine("")
      
      ' Creates another AppDomain.
      Dim domain As AppDomain = AppDomain.CreateDomain("AnotherDomain", Nothing, CType(Nothing, AppDomainSetup))
      
      ' <Snippet2>
      ' Creates an instance of MyType defined in the assembly called ObjectHandleAssembly.
      Dim obj As ObjectHandle = domain.CreateInstance("ObjectHandleAssembly", "MyType")
      
      ' Unwrapps the proxy to the MyType object created in the other AppDomain.
      Dim testObj As MyType = CType(obj.Unwrap(), MyType)
      
      If RemotingServices.IsTransparentProxy(testObj) Then
         Console.WriteLine("The unwrapped object is a proxy.")
      Else
         Console.WriteLine("The unwrapped object is not a proxy!")
      End If 
      Console.WriteLine("")
      Console.Write("Calling a method on the object located in an AppDomain with the hash code ")
      Console.WriteLine(testObj.GetAppDomainHashCode())
' </Snippet2>

   End Sub 'Main 

End Class 'Test 
' </Snippet1>
