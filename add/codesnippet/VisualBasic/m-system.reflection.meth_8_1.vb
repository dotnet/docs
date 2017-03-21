      Dim myMethodBuilder As MethodBuilder = Nothing
      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      ' Create assembly in current CurrentDomain.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Create a dynamic assembly.
      myAssemblyBuilder = _ 
                myCurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)
      ' Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = _ 
                   myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = _ 
               myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
       Dim myConstructorArgs As Type() = {GetType(String)}
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