      // Creates an instance of MyType defined in the assembly called ObjectHandleAssembly.
      ObjectHandle obj = domain.CreateInstance("ObjectHandleAssembly", "MyType");

      // Unwrapps the proxy to the MyType object created in the other AppDomain.
      MyType testObj = (MyType)obj.Unwrap();

      if(RemotingServices.IsTransparentProxy(testObj))
         Console.WriteLine("The unwrapped object is a proxy.");
      else
         Console.WriteLine("The unwrapped object is not a proxy!");    

      Console.WriteLine("");
      Console.Write("Calling a method on the object located in an AppDomain with the hash code ");
      Console.WriteLine(testObj.GetAppDomainHashCode());