         ' Get the current AppDomain.
         Dim myAppDomain As AppDomain = AppDomain.CurrentDomain
         Dim myAssemblyName As New AssemblyName()
         myAssemblyName.Name = "SampleAssembly"
         
         ' Create a dynamic assembly 'myAssembly' with access mode 'Run'.
         Dim myAssembly As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, _
                                                                     AssemblyBuilderAccess.Run)
         ' Create a dynamic module 'myModule' in 'myAssembly'.
         Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("MyDynamicModule", True)
         ' Define a public class 'MyDynamicClass'.
         Dim myTypeBuilder As TypeBuilder = myModule.DefineType("MyDynamicClass", _
                                                                        TypeAttributes.Public)
         ' Define a public string field.
         Dim myField As FieldBuilder = myTypeBuilder.DefineField("MyDynamicField", GetType(String), _
                                                                        FieldAttributes.Public)
         ' Create the constructor.
         Dim myConstructorArgs As Type() = {GetType(String)}
         Dim myConstructor As ConstructorBuilder = myTypeBuilder.DefineConstructor _
                        (MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs)
         
         ' Generate IL for 'myConstructor'.
         Dim myConstructorIL As ILGenerator = myConstructor.GetILGenerator()
         ' Emit the necessary opcodes.
         myConstructorIL.Emit(OpCodes.Ldarg_0)
         Dim mySuperConstructor As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
         myConstructorIL.Emit(OpCodes.Call, mySuperConstructor)
         myConstructorIL.Emit(OpCodes.Ldarg_0)
         myConstructorIL.Emit(OpCodes.Ldarg_1)
         myConstructorIL.Emit(OpCodes.Stfld, myField)
         myConstructorIL.Emit(OpCodes.Ret)
         
         ' Define a dynamic method named 'MyDynamicMethod'.
         Dim myMethod As MethodBuilder = myTypeBuilder.DefineMethod("MyDynamicMethod", _
                                 MethodAttributes.Public, GetType(String), Nothing)
         ' Generate IL for 'myMethod'.
         Dim myMethodIL As ILGenerator = myMethod.GetILGenerator()
         
         ' Begin the scope for a local variable.
         myMethodIL.BeginScope()
         
         Dim myLocalBuilder As LocalBuilder = myMethodIL.DeclareLocal(GetType(Integer))
         Console.WriteLine(ControlChars.NewLine + "Trying to access the local variable within" + _
                                                                              " the scope.")
         Console.WriteLine("'myLocalBuilder' type is: {0}", myLocalBuilder.LocalType)
         myMethodIL.Emit(OpCodes.Ldstr, "Local value")
         myMethodIL.Emit(OpCodes.Stloc_0, myLocalBuilder)
         
         ' End the scope of 'myLocalBuilder'.
         myMethodIL.EndScope()
         
         ' Access the local variable outside the scope.
         Console.WriteLine(ControlChars.NewLine + "Trying to access the local variable outside " + _
                                                   "the scope:")
         myMethodIL.Emit(OpCodes.Stloc_0, myLocalBuilder)
         myMethodIL.Emit(OpCodes.Ldloc_0)
         myMethodIL.Emit(OpCodes.Ret)
         
         ' Create 'MyDynamicClass' class.
         Dim myType1 As Type = myTypeBuilder.CreateType()