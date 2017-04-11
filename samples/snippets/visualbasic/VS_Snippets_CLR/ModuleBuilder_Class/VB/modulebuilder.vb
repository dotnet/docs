' System.Reflection.Emit.ModuleBuilder

' The following example demonstrates the 'ModuleBuilder' class. 
'  A dynamic assembly with a module in it is created in 'CodeGenerator' class. 
' A run time class having a method and a field is created using the 'ModuleBuilder'
' class and created class is called from the 'TestClass'.

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Class CodeGenerator
   Private myAssemblyBuilder As AssemblyBuilder

   Public Sub New()
      ' Get the current application domain for the current thread.
      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"

      ' Define a dynamic assembly in the current application domain.
      myAssemblyBuilder = _
               myCurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)

      ' Define a dynamic module in this assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")

      ' Define a runtime class with specified name and attributes.
      Dim myTypeBuilder As TypeBuilder = _
               myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)

      ' Add 'Greeting' field to the class, with the specified attribute and type.
      Dim greetingField As FieldBuilder = _
               myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
      Dim myMethodArgs As Type() = {GetType(String)}

      ' Add 'MyMethod' method to the class, with the specified attribute and signature.
      Dim myMethod As MethodBuilder = _
               myTypeBuilder.DefineMethod("MyMethod", MethodAttributes.Public, _
               CallingConventions.Standard, Nothing, myMethodArgs)

      Dim methodIL As ILGenerator = myMethod.GetILGenerator()
      methodIL.EmitWriteLine("In the method...")
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Stfld, greetingField)
      methodIL.Emit(OpCodes.Ret)
      myTypeBuilder.CreateType()
   End Sub 'New

   Public ReadOnly Property MyAssembly() As AssemblyBuilder
      Get
         Return Me.myAssemblyBuilder
      End Get
   End Property
End Class 'CodeGenerator

Public Class TestClass
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myCodeGenerator As New CodeGenerator()
      ' Get the assembly builder for 'myCodeGenerator' object.
      Dim myAssemblyBuilder As AssemblyBuilder = myCodeGenerator.MyAssembly
      ' Get the module builder for the above assembly builder object .
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.GetDynamicModule("TempModule")
      Console.WriteLine("The fully qualified name and path to this " + _
                        "module is :" + myModuleBuilder.FullyQualifiedName)
      Dim myType As Type = myModuleBuilder.GetType("TempClass")
      Dim myMethodInfo As MethodInfo = myType.GetMethod("MyMethod")
      ' Get the token used to identify the method within this module.
      Dim myMethodToken As MethodToken = myModuleBuilder.GetMethodToken(myMethodInfo)
      Console.WriteLine("Token used to identify the method of 'myType'" + _
                        " within the module is {0:x}", myMethodToken.Token)
      Dim args As Object() = {"Hello."}
      Dim myObject As Object = Activator.CreateInstance(myType, Nothing, Nothing)
      myMethodInfo.Invoke(myObject, args)
   End Sub 'Main
End Class 'TestClass
' </Snippet1>