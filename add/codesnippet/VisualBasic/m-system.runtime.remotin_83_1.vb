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