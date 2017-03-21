      Dim myMethodBuilder As MethodBuilder = Nothing
      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      ' Create assembly in current CurrentDomain.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly(myAssemblyName, _
                 AssemblyBuilderAccess.Run)
      ' Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule", True)
      Dim myFieldInfo As FieldInfo = myModuleBuilder.DefineUninitializedData("myField", 2, _
                 FieldAttributes.Public)
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = myTypeBuilder.DefineField("Greeting", GetType(String), _
                 FieldAttributes.Public)
      Dim myConstructorArgs() As Type = { GetType(String) }
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = _
                myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _
                 myConstructorArgs)
      ' Display the name of the constructor.
      Console.WriteLine("The constructor name is  : " + myConstructor.Name)
      myConstructor.SetSymCustomAttribute("MySimAttribute", New Byte() {01, 00,00})