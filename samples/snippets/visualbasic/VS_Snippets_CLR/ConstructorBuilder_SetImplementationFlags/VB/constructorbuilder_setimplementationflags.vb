' System.Reflection.Emit.ConstructorBuilder.SetImplementationFlags()

' The following program demonstrates the 'SetImplementationFlags'
' method of ConstructorBuilder class. It creates an assembly in the
' current domain with a dynamic module in the assembly. Constructor
' builder is used in conjunction with the 'TypeBuilder' class to create
' constructor at run time. It then sets the method implementation flags
' for the constructor and displays the same.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Friend Class MyConstructorBuilder
   Private myType1 As Type
   Private myModuleBuilder As ModuleBuilder = Nothing
   Private myAssemblyBuilder As AssemblyBuilder = Nothing

   Friend Sub New()
      Try
' <Snippet1>
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
' </Snippet1>
         ' Add a method to the type.
         myMethodBuilder = myTypeBuilder.DefineMethod _
                                      ("HelloWorld", MethodAttributes.Public, Nothing, Nothing)
         ' Generate IL for the method.
         Dim myILGenerator2 As ILGenerator = myMethodBuilder.GetILGenerator()
         myILGenerator2.EmitWriteLine("Hello World from global")
         myILGenerator2.Emit(OpCodes.Ret)
         myModuleBuilder.CreateGlobalFunctions()
         myType1 = myTypeBuilder.CreateType()
      Catch ex As InvalidOperationException
         Console.WriteLine("The following exception has occured : " + ex.Message)
      Catch ex As Exception
         Console.WriteLine("The following exception has occured : " + ex.Message)
      End Try
   End Sub 'New

   Friend ReadOnly Property MyTypeProperty() As Type
      Get
         Return Me.myType1
      End Get
   End Property

   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myConstructorBuilder As New MyConstructorBuilder()
      Dim myType1 As Type = myConstructorBuilder.MyTypeProperty
      If Not Nothing Is myType1 Then
         Console.WriteLine("Instantiating the new type...")
         Dim myObject As Object() = {"hello"}
         Dim myObject1 As Object = Activator.CreateInstance(myType1, myObject, Nothing)
         Dim myMethodInfo As MethodInfo = myType1.GetMethod("HelloWorld")
         If Not Nothing Is myMethodInfo Then
            Console.WriteLine("Invoking dynamically created HelloWorld method...")
            myMethodInfo.Invoke(myObject1, Nothing)
         Else
            Console.WriteLine("Could not locate HelloWorld method")
         End If
      Else
         Console.WriteLine("Could not access Type.")
      End If
   End Sub 'Main
End Class 'MyConstructorBuilder