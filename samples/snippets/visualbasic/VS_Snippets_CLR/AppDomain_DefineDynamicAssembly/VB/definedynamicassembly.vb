' <Snippet1>

Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Module Test
   
   Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      
      InstantiateMyDynamicType(currentDomain)   'Failed!
      
      AddHandler currentDomain.AssemblyResolve, AddressOf MyResolveEventHandler
      
      InstantiateMyDynamicType(currentDomain)   'OK!
   End Sub 'Main
   
   Sub InstantiateMyDynamicType(domain As AppDomain)
      Try
         ' You must supply a valid fully qualified assembly name here.
         domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyDynamicType")
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'InstantiateMyDynamicType
   
   Function MyResolveEventHandler(sender As Object, args As ResolveEventArgs) As System.Reflection.Assembly
      Return DefineDynamicAssembly(DirectCast(sender, AppDomain))
   End Function 'MyResolveEventHandler
   
   Function DefineDynamicAssembly(domain As AppDomain) As System.Reflection.Assembly
      ' Build a dynamic assembly using Reflection Emit API.

      Dim assemblyName As New AssemblyName()
      assemblyName.Name = "MyDynamicAssembly"
      
      Dim assemblyBuilder As AssemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run)
      Dim moduleBuilder As ModuleBuilder = assemblyBuilder.DefineDynamicModule("MyDynamicModule")
      Dim typeBuilder As TypeBuilder = moduleBuilder.DefineType("MyDynamicType", TypeAttributes.Public)
      Dim constructorBuilder As ConstructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Nothing)
      Dim ilGenerator As ILGenerator = constructorBuilder.GetILGenerator()
      
      ilGenerator.EmitWriteLine("MyDynamicType instantiated!")
      ilGenerator.Emit(OpCodes.Ret)
      
      typeBuilder.CreateType()
      
      Return assemblyBuilder
   End Function 'DefineDynamicAssembly

End Module 'Test 
' </Snippet1>