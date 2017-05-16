' System.Reflection.Emit.TypeBuilder.FullName
' System.Reflection.Emit.TypeBuilder.GetConstructors
' System.Reflection.Emit.TypeBuilder.DefineTypeInitializer

' The following program demonstrates DefineTypeInitializer and 'GetConstructors' methods and
' the 'FullName' property of 'TypeBuilder' class. It builds an assembly by defining 'HelloWorld'
' type. It also defines a constructor for 'HelloWorld' type. Then it displays the
' full name of type and its constructors to the console.

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

' <Snippet1>
' <Snippet2>
' <Snippet3>
Public Class MyApplication

   Public Shared Sub Main()
      ' Create the "HelloWorld" class
      Dim helloWorldClass As TypeBuilder = CreateCallee(Thread.GetDomain())
      Console.WriteLine("Full Name : " + helloWorldClass.FullName)
      Console.WriteLine("Constructors :")
      Dim info As ConstructorInfo() = helloWorldClass.GetConstructors(BindingFlags.Public Or _
                                                                     BindingFlags.Instance)
      Dim index As Integer
      For index = 0 To info.Length - 1
         Console.WriteLine(info(index).ToString())
      Next index
   End Sub 'Main

   ' Create the callee transient dynamic assembly.
   Private Shared Function CreateCallee(myDomain As AppDomain) As TypeBuilder
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"

      ' Create the callee dynamic assembly.
      Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAssemblyName, _
                                                               AssemblyBuilderAccess.Run)
      ' Create a dynamic module named "CalleeModule" in the callee assembly.
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")

      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldClass As TypeBuilder = myModule.DefineType("HelloWorld", TypeAttributes.Public)
      ' Define a private String field named "Greeting" in the type.
      Dim greetingField As FieldBuilder = helloWorldClass.DefineField("Greeting", GetType(String), _
                                                                     FieldAttributes.Private)

      ' Create the constructor.
      Dim constructor As ConstructorBuilder = helloWorldClass.DefineTypeInitializer()

      ' Generate IL for the method. The constructor calls its base class
      ' constructor. The constructor stores its argument in the private field.
      Dim constructorIL As ILGenerator = constructor.GetILGenerator()
      constructorIL.Emit(OpCodes.Ldarg_0)
      Dim superConstructor As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
      constructorIL.Emit(OpCodes.Call, superConstructor)
      constructorIL.Emit(OpCodes.Ldarg_0)
      constructorIL.Emit(OpCodes.Ldarg_1)
      constructorIL.Emit(OpCodes.Stfld, greetingField)
      constructorIL.Emit(OpCodes.Ret)

      helloWorldClass.CreateType()
      Return helloWorldClass
   End Function 'CreateCallee
End Class 'MyApplication
' </Snippet3>
' </Snippet2>
' </Snippet1>