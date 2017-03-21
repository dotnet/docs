         Dim myMethodBuilder As MethodBuilder = Nothing
         Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
         ' Create assembly in current CurrentDomain.
         Dim myAssemblyName As New AssemblyName()
         myAssemblyName.Name = "TempAssembly"
         ' Create a dynamic assembly.
         myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly _
                                               (myAssemblyName, AssemblyBuilderAccess.Run)
         ' Create a dynamic module in the assembly.
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule", True)
         Dim myFieldInfo2 As FieldInfo = myModuleBuilder.DefineUninitializedData _
                                               ("myField", 2, FieldAttributes.Public)
         ' Create a type in the module.
         Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType _
                                                     ("TempClass", TypeAttributes.Public)
         Dim myGreetingField As FieldBuilder = myTypeBuilder.DefineField _
                                          ("Greeting", GetType(String), FieldAttributes.Public)
         Dim myConstructorArgs As Type() = {GetType(String)}
         ' Define a constructor of the dynamic class.
         Dim myConstructor As ConstructorBuilder = myTypeBuilder.DefineConstructor _
                           (MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs)
         ' Set the method implementation flags for the constructor.
         myConstructor.SetImplementationFlags(MethodImplAttributes.PreserveSig Or _
                                              MethodImplAttributes.Runtime)
         ' Get the method implementation flags for the constructor.
         Dim myMethodAttributes As MethodImplAttributes = myConstructor.GetMethodImplementationFlags()
         Dim myAttributeType As Type = GetType(MethodImplAttributes)
         Dim myAttribValue As Integer = CInt(myMethodAttributes)
         If Not myAttributeType.IsEnum Then
            Console.WriteLine("This is not an Enum")
         End If
         ' Display the field info names of the retrieved method implementation flags.
         Dim myFieldInfo As FieldInfo() = myAttributeType.GetFields(BindingFlags.Public Or _
                                                                    BindingFlags.Static)
         Console.WriteLine("The Field info names of the MethodImplAttributes for the constructor are:")
         Dim i As Integer
         For i = 0 To myFieldInfo.Length - 1
            Dim myFieldValue As Integer = CType(myFieldInfo(i).GetValue(Nothing), Int32)
            If(myFieldValue And myAttribValue) = myFieldValue Then
               Console.WriteLine("   " + myFieldInfo(i).Name)
            End If
         Next i