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
      Dim myFieldInfo As FieldInfo = _ 
          myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public)
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = _ 
          myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = _ 
          myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
      Dim myConstructorArgs As Type() = {GetType(String)}
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = _ 
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _ 
                                          myConstructorArgs)
      ' Display the name of the constructor.
      Console.WriteLine("The constructor name is  : " + myConstructor.Name)
      ' Display the 'Type' object from which this object was obtained.
      Console.WriteLine("The reflected type  is  : " + myConstructor.ReflectedType.ToString())
      ' Display the signature of the field.
      Console.WriteLine(myConstructor.Signature)
      ' Display the constructor builder instance as a string.
      Console.WriteLine(myConstructor.ToString())