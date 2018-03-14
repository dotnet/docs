 ' System.Reflection.Emit.FieldBuilder
' System.Reflection.Emit.FieldBuilder.Name
' System.Reflection.Emit.FieldBuilder.DeclaringType
' System.Reflection.Emit.FieldBuilder.FieldType
' System.Reflection.Emit.FieldBuilder.GetToken

'  The following example demonstrates 'Name','DeclaringType',
'  'FieldType' properties and 'GetToken' method of FieldBuilder class.
'  A new dynamic class 'MyType' is created. A Field and a method are defined in the class.
'  In the constructor of the class the field is initialized. Method of the class gets the
'  value of the Field.An instance of the class is created and method is invoked.

' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Class FieldBuilder_Sample
   Private Shared Function CreateType(currentDomain As AppDomain) As Type
' <Snippet2>

      ' Create an assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "DynamicAssembly"
      Dim myAssembly As AssemblyBuilder = currentDomain.DefineDynamicAssembly(myAssemblyName, _
                                                AssemblyBuilderAccess.Run)
      ' Create a dynamic module in Dynamic Assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssembly.DefineDynamicModule("MyModule")
      ' Define a public class named "MyClass" in the assembly.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("MyClass", _
                                          TypeAttributes.Public)
      ' Define a private String field named "MyField" in the type.
      Dim myFieldBuilder As FieldBuilder = myTypeBuilder.DefineField("MyField", _
                  GetType(String), FieldAttributes.Private Or FieldAttributes.Static)
      ' Create the constructor.
      Dim constructorArgs As Type() = {GetType(String)}
      Dim constructor As ConstructorBuilder = _
                  myTypeBuilder.DefineConstructor(MethodAttributes.Public, _
                           CallingConventions.Standard, constructorArgs)
      Dim constructorIL As ILGenerator = constructor.GetILGenerator()
      constructorIL.Emit(OpCodes.Ldarg_0)
      Dim superConstructor As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
      constructorIL.Emit(OpCodes.Call, superConstructor)
      constructorIL.Emit(OpCodes.Ldarg_0)
      constructorIL.Emit(OpCodes.Ldarg_1)
      constructorIL.Emit(OpCodes.Stfld, myFieldBuilder)
      constructorIL.Emit(OpCodes.Ret)

      ' Create the MyMethod method.
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("MyMethod",  _
                        MethodAttributes.Public, GetType(String), Nothing)
      Dim methodIL As ILGenerator = myMethodBuilder.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldfld, myFieldBuilder)
      methodIL.Emit(OpCodes.Ret)
      Console.WriteLine("Name               :" + myFieldBuilder.Name)
      Console.WriteLine("DeclaringType      :" + myFieldBuilder.DeclaringType.ToString())
      Console.WriteLine("Type               :" + myFieldBuilder.FieldType.ToString())
      Console.WriteLine("Token              :" + myFieldBuilder.GetToken().Token.ToString())
      Return myTypeBuilder.CreateType()
' </Snippet2>
   End Function 'CreateType

   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Try
         Dim myType As Type = CreateType(Thread.GetDomain())
         ' Create an instance of the "HelloWorld" class.
         Dim helloWorld As Object = Activator.CreateInstance(myType, New Object() {"HelloWorld"})
         ' Invoke the "MyMethod" method of the "MyClass" class.
         Dim myObject As Object = myType.InvokeMember("MyMethod", _
                     BindingFlags.InvokeMethod, Nothing, helloWorld, Nothing)
         Console.WriteLine("MyClass.MyMethod returned: " & Microsoft.VisualBasic.Chr(34) & myObject  & Microsoft.VisualBasic.Chr(34) )
     Catch e as Exception
            Console.WriteLine("Exception Caught "+e.Message)
     End Try
   End Sub 'Main
End Class 'FieldBuilder_Sample
' </Snippet1>