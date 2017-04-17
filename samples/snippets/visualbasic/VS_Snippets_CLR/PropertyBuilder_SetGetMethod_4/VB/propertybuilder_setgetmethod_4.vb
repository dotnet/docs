' System.Reflection.Emit.PropertyBuilder.SetGetMethod
' System.Reflection.Emit.PropertyBuilder.SetSetMethod
' System.Reflection.Emit.PropertyBuilder.AddOtherMethod
' System.Reflection.Emit.PropertyBuilder

' This following program demonstrates methods 'SetGetMethod','SetSetMethod' and
' 'AddOtherMethod' of class 'PropertyBuilder'.

' A dynamic assembly is generated with  a class having a property 'Greeting'.
' Its 'get' and 'set' method are created by returning and setting a string respectively.
' This property value is reset with default string using othermethod.

' <Snippet4>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Class App

   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      ' Create the "HelloWorld" type in an assembly with mode 'RunAndSave'.
      Dim helloWorldType As Type = CreateCallee(Thread.GetDomain(), AssemblyBuilderAccess.RunAndSave)

      ' Create an instance of the "HelloWorld" class.
      Dim helloWorld As Object = Activator.CreateInstance(helloWorldType, New Object() {"HelloWorld"})
      Dim returnValue As Object = helloWorldType.InvokeMember("Greeting", _
                     BindingFlags.Default Or BindingFlags.GetProperty, Nothing, helloWorld, Nothing)
      Console.WriteLine("HelloWorld.GetGreeting returned: """ + returnValue + """")

      ' Set 'Greeting' property with 'NewMessage!!!'.
      helloWorldType.InvokeMember("Greeting", BindingFlags.Default Or BindingFlags.SetProperty, _
                                       Nothing, helloWorld, New Object() {"New Message !!!"})
      returnValue = helloWorldType.InvokeMember("Greeting", BindingFlags.Default Or _
                                       BindingFlags.GetProperty, Nothing, helloWorld, Nothing)
      Console.WriteLine("After Set operation HelloWorld.GetGreeting returned: """ + returnValue + """")

      ' Reset 'Greeting' property to 'Default String'.
      helloWorldType.InvokeMember("reset_Greeting", BindingFlags.Default Or _
                                       BindingFlags.InvokeMethod, Nothing, helloWorld, Nothing)
      returnValue = helloWorldType.InvokeMember("Greeting", BindingFlags.Default Or _
                                       BindingFlags.GetProperty, Nothing, helloWorld, Nothing)
      Console.WriteLine("After Reset operation HelloWorld.GetGreeting returned: """ + _
                                                                        returnValue + """")

      Dim myAssembly As AssemblyBuilder = CType(helloWorldType.Assembly, AssemblyBuilder)
      ' Save to disk.
      myAssembly.Save("EmittedAssembly.dll")
   End Sub 'Main


   ' Create the callee transient dynamic assembly.
   Private Shared Function CreateCallee(myAppDomain As AppDomain, access As AssemblyBuilderAccess) As _
                                                                                             Type
      ' Create a simple name for the callee assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"
      ' Create the callee dynamic assembly.
      Dim myAssemblyBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, _
                                                                                 access)

      ' Create a dynamic module named "EmittedModule" in the callee assembly.
      Dim myModule As ModuleBuilder
      If access = AssemblyBuilderAccess.Run Then
         myModule = myAssemblyBuilder.DefineDynamicModule("EmittedModule")
      Else
         myModule = myAssemblyBuilder.DefineDynamicModule("EmittedModule", "EmittedModule.mod")
      End If
' <Snippet2>
      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldTypeBuilder As TypeBuilder = myModule.DefineType("HelloWorld", _
                                                                           TypeAttributes.Public)
      ' Define a private String field named "m_greeting" in "HelloWorld" class.
      Dim greetingFieldBuilder As FieldBuilder = helloWorldTypeBuilder.DefineField _
                                       ("m_greeting", GetType(String), FieldAttributes.Private)
      ' Create constructor args and define constructor.
      Dim constructorArgs As Type() = {GetType(String)}
      Dim constructor As ConstructorBuilder = helloWorldTypeBuilder.DefineConstructor _
                           (MethodAttributes.Public, CallingConventions.Standard, constructorArgs)

      ' Generate IL code for the method.The constructor stores its argument in the private field.
      Dim constructorIL As ILGenerator = constructor.GetILGenerator()
      constructorIL.Emit(OpCodes.Ldarg_0)
      constructorIL.Emit(OpCodes.Ldarg_1)
      constructorIL.Emit(OpCodes.Stfld, greetingFieldBuilder)
      constructorIL.Emit(OpCodes.Ret)
' <Snippet1>
      ' Define property Greeting.
      Dim greetingPropertyBuilder As PropertyBuilder = helloWorldTypeBuilder.DefineProperty _
                                 ("Greeting", PropertyAttributes.None, GetType(String), Nothing)

      ' Define the 'get_Greeting' method.
      Dim getGreetingMethod As MethodBuilder = helloWorldTypeBuilder.DefineMethod("get_Greeting", _
                              MethodAttributes.Public Or MethodAttributes.HideBySig Or _
                              MethodAttributes.SpecialName, GetType(String), Nothing)
      ' Generate IL code for 'get_Greeting' method.
      Dim methodIL As ILGenerator = getGreetingMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldfld, greetingFieldBuilder)
      methodIL.Emit(OpCodes.Ret)
      greetingPropertyBuilder.SetGetMethod(getGreetingMethod)
' </Snippet1>

      ' Define the set_Greeting method.
      Dim methodArgs As Type() = {GetType(String)}
      Dim setGreetingMethod As MethodBuilder = helloWorldTypeBuilder.DefineMethod _
            ("set_Greeting", MethodAttributes.Public Or MethodAttributes.HideBySig Or _
                                    MethodAttributes.SpecialName, Nothing, methodArgs)

      ' Generate IL code for set_Greeting method.
      methodIL = setGreetingMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Stfld, greetingFieldBuilder)
      methodIL.Emit(OpCodes.Ret)
      greetingPropertyBuilder.SetSetMethod(setGreetingMethod)
' </Snippet2>
' <Snippet3>
      ' Define the reset_Greeting method.
      Dim otherGreetingMethod As MethodBuilder = helloWorldTypeBuilder.DefineMethod _
                  ("reset_Greeting", MethodAttributes.Public Or MethodAttributes.HideBySig, _
                                                               Nothing, Nothing)
      ' Generate IL code for reset_Greeting method.
      methodIL = otherGreetingMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_0)
      methodIL.Emit(OpCodes.Ldstr, "Default String.")
      methodIL.Emit(OpCodes.Stfld, greetingFieldBuilder)
      methodIL.Emit(OpCodes.Ret)
      greetingPropertyBuilder.AddOtherMethod(otherGreetingMethod)
' </Snippet3>
      ' Create the class HelloWorld.
      Return helloWorldTypeBuilder.CreateType()
   End Function 'CreateCallee
End Class 'App
' </Snippet4>