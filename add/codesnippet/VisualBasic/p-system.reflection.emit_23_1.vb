      Dim myMethodBuilder As MethodBuilder = Nothing

      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      ' Create assembly in current CurrentDomain
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Create a dynamic assembly
      myAssemblyBuilder = _
            myCurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave)
      ' Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      Dim myFieldInfo As FieldInfo = _
          myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public)
      ' Create a type in the module
      Dim myTypeBuilder As TypeBuilder = _
          myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = _
         myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
      Dim myConstructorArgs As Type() = {GetType(String)}
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = _
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _
                                          myConstructorArgs)
      Dim myPset As New PermissionSet(PermissionState.Unrestricted)
      ' Add declarative security to the constructor.
      Console.WriteLine("Adding declarative security to the constructor.....")
      Console.WriteLine("The Security action to be taken is ""DENY"" and" + _
                        " Permission set is ""UNRESTRICTED"".")
      myConstructor.AddDeclarativeSecurity(SecurityAction.Deny, myPset)
      Dim myMethodAttributes As MethodAttributes = myConstructor.Attributes
      Dim myAttributeType As Type = GetType(MethodAttributes)
      Dim myAttribValue As Integer = CInt(myMethodAttributes)
      If Not myAttributeType.IsEnum Then
         Console.WriteLine("This is not an Enum")
      End If
      Dim myFieldInfo1 As FieldInfo() = myAttributeType.GetFields(BindingFlags.Public Or _
                                                                   BindingFlags.Static)
      Console.WriteLine("The Field info names of the Attributes for the constructor are:")
      Dim i As Integer
      For i = 0 To myFieldInfo1.Length - 1
         Dim myFieldValue As Integer = CType(myFieldInfo1(i).GetValue(Nothing), Int32)
         If(myFieldValue And myAttribValue) = myFieldValue Then
            Console.WriteLine("   " + myFieldInfo1(i).Name)
         End If
      Next i

      Dim myType2 As Type = myConstructor.DeclaringType
      Console.WriteLine("The declaring type is : " + myType2.ToString())