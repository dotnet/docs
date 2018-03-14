' FxCop Exception:
' This sample generates FxCop violation SecureLateBindingMethods for 
' Activator.CreateInstance, Type.GetType, etc.. 
' The violation can be ignored, because:
' (1) None of the dangerous methods appear in snippets.
' (2) The types used are all dynamic types created in this example.
' (3) No user input is passed to any member that calls a dangerous method.

' System.Reflection.Emit.TypeBuilder.DefineField()
' System.Reflection.Emit.TypeBuilder.DefineConstructor()
' System.Reflection.Emit.TypeBuilder.AddInterfaceImplementation()
' System.Reflection.Emit.TypeBuilder.BaseType

' The following program demonstrates the property 'BaseType' and methods 
' 'DefineField','DefineConstructor','AddInterfaceImplementation' of the
' class 'TypeBuilder'. 
' The program creates a dynamic assembly and a type within it called as 
' 'HelloWorld' This defines a field and implements an interface.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading
Imports System.Security.Permissions

Public Class MyTypeBuilder
   
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Console.WriteLine("TypeBuilder Sample")
      Console.WriteLine("----------------------")
      ' Create 'helloWorldType' .
      Dim helloWorldType As Type = CreateDynamicAssembly(Thread.GetDomain(), _
                                                      AssemblyBuilderAccess.RunAndSave)
      ' Create an instance of 'HelloWorld' class.
      Dim helloWorld As Object = Activator.CreateInstance(helloWorldType, New Object() _
                                                                  {"Called HelloWorld"})
      ' Invoke 'SayHello' method.
      helloWorldType.InvokeMember("SayHello", BindingFlags.Default Or BindingFlags.InvokeMethod, _
                                                                  Nothing, helloWorld, Nothing)
      ' Get defined field in the class.
      Console.WriteLine("Defined Field: " + helloWorldType.GetField("myGreeting").Name)
      Dim myAssemblyBuilder As AssemblyBuilder = CType(helloWorldType.Assembly, AssemblyBuilder)
      myAssemblyBuilder.Save("EmittedAssembly.dll")
   End Sub 'Main

   ' Declare the interface.
   Public Interface IHello
      Sub SayHello()
   End Interface 'IHello
   
   ' Create the transient dynamic assembly.
   Private Shared Function CreateDynamicAssembly(myAppDomain As AppDomain, myAccess As _
                                                         AssemblyBuilderAccess) As Type
      ' Create a simple name for assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"
      ' Create the dynamic assembly.
      Dim myAssemblyBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, _
                                                                                    myAccess)
      ' Create a dynamic module named 'CalleeModule' in the assembly.
      Dim myModuleBuilder As ModuleBuilder
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule", "EmittedModule.mod")
' <Snippet1>
' <Snippet4>
      ' Define a public class named 'myHelloWorld' in the assembly.
      Dim helloWorldTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("HelloWorld", _
                                                                           TypeAttributes.Public)
      
      ' Get base type.
      Console.WriteLine("Base Type: " + helloWorldTypeBuilder.BaseType.Name)
' </Snippet4>
      ' Define 'myGreetingField' field.
      Dim myGreetingField As FieldBuilder = helloWorldTypeBuilder.DefineField("myGreeting", _
                                                   GetType(String), FieldAttributes.Public)
' </Snippet1>
' <Snippet2>
      ' Define the constructor.
      Dim constructorArgs As Type() = {GetType(String)}
      Dim myConstructorBuilder As ConstructorBuilder = helloWorldTypeBuilder.DefineConstructor _
                           (MethodAttributes.Public, CallingConventions.Standard, constructorArgs)
      ' Generate IL for the method.The constructor stores its argument in the private field.
      Dim myConstructorIL As ILGenerator = myConstructorBuilder.GetILGenerator()
      myConstructorIL.Emit(OpCodes.Ldarg_0)
      myConstructorIL.Emit(OpCodes.Ldarg_1)
      myConstructorIL.Emit(OpCodes.Stfld, myGreetingField)
      myConstructorIL.Emit(OpCodes.Ret)
' </Snippet2>
' <Snippet3>
      ' Mark the class as implementing 'IHello' interface.
      helloWorldTypeBuilder.AddInterfaceImplementation(GetType(IHello))
      Dim myMethodBuilder As MethodBuilder = helloWorldTypeBuilder.DefineMethod("SayHello", _
                           MethodAttributes.Public Or MethodAttributes.Virtual, Nothing, Nothing)
      ' Generate IL for 'SayHello' method.
      Dim myMethodIL As ILGenerator = myMethodBuilder.GetILGenerator()
      myMethodIL.EmitWriteLine(myGreetingField)
      myMethodIL.Emit(OpCodes.Ret)
      Dim sayHelloMethod As MethodInfo = GetType(IHello).GetMethod("SayHello")
      helloWorldTypeBuilder.DefineMethodOverride(myMethodBuilder, sayHelloMethod)
' </Snippet3>
      Return helloWorldTypeBuilder.CreateType()
   End Function 'CreateDynamicAssembly
End Class 'MyTypeBuilder