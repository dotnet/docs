      ' Define a constructor of the dynamic class.
      Dim myConstructorBuilder As ConstructorBuilder = _ 
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _ 
                                          myConstructorArgs)
      ' Get a reference to the module that contains this constructor.
      Dim myModule As [Module] = myConstructorBuilder.GetModule()
      Console.WriteLine("Module Name : " + myModule.Name)
      ' Get the 'MethodToken' that represents the token for this constructor.
      Dim myMethodToken As MethodToken = myConstructorBuilder.GetToken()
      Console.WriteLine("Constructor Token is : " + myMethodToken.Token.ToString())
      ' Get the method implementation flags for this constructor.
      Dim myMethodImplAttributes As MethodImplAttributes = _
          myConstructorBuilder.GetMethodImplementationFlags()
      Console.WriteLine("MethodImplAttributes : " + myMethodImplAttributes.ToString())