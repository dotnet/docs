Imports System.Reflection
Imports System.Reflection.Emit

Public Module FieldBuilder_Sample
   Private Function CreateType() As Type
      ' Create an assembly.
      Dim assemName As New AssemblyName()
      assemName.Name = "DynamicAssembly"
      Dim assemBuilder As AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemName,
                                                AssemblyBuilderAccess.Run)
      ' Create a dynamic module in Dynamic Assembly.
      Dim modBuilder As ModuleBuilder = assemBuilder.DefineDynamicModule("DynamicModule")
      ' Define a public class named "DynamicClass" in the assembly.
      Dim typBuilder As TypeBuilder = modBuilder.DefineType("DynamicClass", 
                                          TypeAttributes.Public)
      ' Define a private String field named "DynamicField" in the type.
      Dim fldBuilder As FieldBuilder = typBuilder.DefineField("DynamicField",
                  GetType(String), FieldAttributes.Private Or FieldAttributes.Static)
      ' Create the constructor.
      Dim constructorArgs As Type() = {GetType(String)}
      Dim constructor As ConstructorBuilder = 
                  typBuilder.DefineConstructor(MethodAttributes.Public, 
                           CallingConventions.Standard, constructorArgs)
      Dim constructorIL As ILGenerator = constructor.GetILGenerator()
      constructorIL.Emit(OpCodes.Ldarg_0)
      Dim superConstructor As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
      constructorIL.Emit(OpCodes.Call, superConstructor)
      constructorIL.Emit(OpCodes.Ldarg_0)
      constructorIL.Emit(OpCodes.Ldarg_1)
      constructorIL.Emit(OpCodes.Stfld, fldBuilder)
      constructorIL.Emit(OpCodes.Ret)

      ' Create the DynamicMethod method.
      Dim methBuilder As MethodBuilder = typBuilder.DefineMethod("DynamicMethod", 
                        MethodAttributes.Public, GetType(String), Nothing)
      Dim methodIL As ILGenerator = methBuilder.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldfld, fldBuilder)
      methodIL.Emit(OpCodes.Ret)

      Console.WriteLine($"Name               : {fldBuilder.Name}")
      Console.WriteLine($"DeclaringType      : {fldBuilder.DeclaringType}")
      Console.WriteLine($"Type               : {fldBuilder.FieldType}")
      Return typBuilder.CreateType()
   End Function 

   Public Sub Main()
      Dim dynType As Type = CreateType()
      Try  
        ' Create an instance of the "HelloWorld" class.
         Dim helloWorld As Object = Activator.CreateInstance(dynType, New Object() {"HelloWorld"})
         ' Invoke the "DynamicMethod" method of the "DynamicClass" class.
         Dim obj As Object = dynType.InvokeMember("DynamicMethod", 
                  BindingFlags.InvokeMethod, Nothing, helloWorld, Nothing)
         Console.WriteLine($"DynamicClass.DynamicMethod returned: ""{obj}""")
      Catch e As MethodAccessException
            Console.WriteLine($"{e.GetType().Name}: {e.Message}")
      End Try
   End Sub 
End Module
