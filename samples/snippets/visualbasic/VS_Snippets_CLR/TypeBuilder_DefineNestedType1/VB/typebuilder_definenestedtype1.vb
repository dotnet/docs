' System.Reflection.Emit.TypeBuilder.DefineNestedType(string, TypeAttributes, Type, Type[])
' System.Reflection.Emit.TypeBuilder.DefineMethodOverride(MethodInfo, MethodInfo)
' System.Reflection.Emit.TypeBuilder.DefineMethod(string, MethodAttributes,Type,Type[])
'
' The following program demonstrates the 'DefineNestedType', 'DefineMethodOverride' and
' 'DefineMethod' methods of 'TypeBuilder' class. It builds an assembly by defining
' 'MyHelloWorld' type. 'MyHelloWorld' class has a nested class 'MyNestedClass' which extends 
' 'Example' and implements 'IMyInterface' interface. Then it creates and instance of
' 'MyNestedClass' type and calls the 'HelloMethod' using 'IMyInterface' object and
' results are displayed to the console.
' <Snippet1>
' <Snippet2>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Interface IMyInterface
   Function HelloMethod(parameter As String) As String
End Interface 'IMyInterface

Public Class Example
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myNestedClassType As Type = CreateCallee(Thread.GetDomain())
      ' Create an instance of 'MyNestedClass'.
      Dim myInterface As IMyInterface = _
            CType(Activator.CreateInstance(myNestedClassType), IMyInterface)
      Console.WriteLine(myInterface.HelloMethod("Bill"))
   End Sub 'Main

   ' Create the callee transient dynamic assembly.
   Private Shared Function CreateCallee(myAppDomain As AppDomain) As Type
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "Example"
      ' Create the callee dynamic assembly.
      Dim myAssembly As AssemblyBuilder = _
               myAppDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)
      ' Create a dynamic module in the callee assembly.
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")
      ' Define a public class named "MyHelloWorld".
      Dim myHelloWorldType As TypeBuilder = _
               myModule.DefineType("MyHelloWorld", TypeAttributes.Public)
      ' Define a public nested class named 'MyNestedClass'.
      Dim myNestedClassType As TypeBuilder = _
               myHelloWorldType.DefineNestedType("MyNestedClass", TypeAttributes.NestedPublic, _
               GetType(Example), New Type() {GetType(IMyInterface)})
      ' Implement 'IMyInterface' interface.
      myNestedClassType.AddInterfaceImplementation(GetType(IMyInterface))
      ' Define 'HelloMethod' of 'IMyInterface'.
      Dim myHelloMethod As MethodBuilder = _
               myNestedClassType.DefineMethod("HelloMethod", MethodAttributes.Public Or _
               MethodAttributes.Virtual, GetType(String), New Type() {GetType(String)})
      ' Generate IL for 'GetGreeting' method.
      Dim myMethodIL As ILGenerator = myHelloMethod.GetILGenerator()
      myMethodIL.Emit(OpCodes.Ldstr, "Hi! ")
      myMethodIL.Emit(OpCodes.Ldarg_1)
      Dim infoMethod As MethodInfo = _
               GetType(String).GetMethod("Concat", New Type() {GetType(String), GetType(String)})
      myMethodIL.Emit(OpCodes.Call, infoMethod)
      myMethodIL.Emit(OpCodes.Ret)

      Dim myHelloMethodInfo As MethodInfo = GetType(IMyInterface).GetMethod("HelloMethod")
      ' Implement 'HelloMethod' of 'IMyInterface'.
      myNestedClassType.DefineMethodOverride(myHelloMethod, myHelloMethodInfo)
      ' Create 'MyHelloWorld' type.
      Dim myType As Type = myHelloWorldType.CreateType()
      ' Create 'MyNestedClass' type.
      Return myNestedClassType.CreateType()
   End Function 'CreateCallee
End Class 'Example
' </Snippet2>
' </Snippet1>