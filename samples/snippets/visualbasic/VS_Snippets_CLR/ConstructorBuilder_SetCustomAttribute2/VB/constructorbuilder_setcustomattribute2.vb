' System.Reflection.Emit.ConstructorBuilder.SetCustomAttribute(ConstructorInfo, byte())

' The following program demonstrates the 'SetCustomAttribute(ConstructorInfo, byte())'
' method of 'ConstructorBuilder' class. It defines a 'MyAttribute' class which is derived
' from 'Attribute' class. It builds a constructor by setting 'MyAttribute' custom attribute
' and defines 'Helloworld' type. Then it gets the custom attributes of 'HelloWorld' type
' and displays its contents to the console.

' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

<AttributeUsage(AttributeTargets.All, AllowMultiple := False)>  _
Public Class MyAttribute
   Inherits Attribute
   Public myBoolean As Boolean

   Public Sub New(myBoolean As Boolean)
      Me.myBoolean = myBoolean
   End Sub 'New
End Class 'MyAttribute

Public Class MyConstructorBuilder

   Public Shared Sub Main()
      Dim myHelloworld As Type = MyCreateCallee(Thread.GetDomain())
      Dim myConstructor As ConstructorInfo = myHelloworld.GetConstructor(New Type() _
                                                                        {GetType(String)})
      Dim myAttributes1 As Object() = myConstructor.GetCustomAttributes(True)
      Console.WriteLine("MyAttribute custom attribute contains  ")
      Dim index As Integer
      For index = 0 To myAttributes1.Length - 1
         If TypeOf myAttributes1(index) Is MyAttribute Then
            Console.WriteLine("myBoolean : " + _
                               CType(myAttributes1(index), MyAttribute).myBoolean.ToString())
         End If
      Next index
   End Sub 'Main

   Private Shared Function MyCreateCallee(domain As AppDomain) As Type
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"
      ' Define a dynamic assembly in the current application domain.
      Dim myAssembly As AssemblyBuilder = domain.DefineDynamicAssembly _
                                       (myAssemblyName, AssemblyBuilderAccess.Run)
      ' Define a dynamic module in this assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")
      ' Construct a 'TypeBuilder' given the name and attributes.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType _
                                                       ("HelloWorld", TypeAttributes.Public)
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = myTypeBuilder.DefineConstructor _
                (MethodAttributes.Public, CallingConventions.Standard, New Type() {GetType(String)})
      Dim myILGenerator As ILGenerator = myConstructor.GetILGenerator()
      myILGenerator.Emit(OpCodes.Ldstr, "Constructor is invoked")
      myILGenerator.Emit(OpCodes.Ldarg_1)
      Dim myMethodInfo As MethodInfo = GetType(Console).GetMethod("WriteLine", New Type() _
                                                                          {GetType(String)})
      myILGenerator.Emit(OpCodes.Call, myMethodInfo)
      myILGenerator.Emit(OpCodes.Ret)
      Dim myType As Type = GetType(MyAttribute)
      Dim myConstructorInfo As ConstructorInfo = myType.GetConstructor(New Type() {GetType(Boolean)})
      Try
         myConstructor.SetCustomAttribute(myConstructorInfo, New Byte() {1, 0, 1})
      Catch ex As ArgumentNullException
         Console.WriteLine("The following exception has occured : " + ex.Message)
      Catch ex As Exception
         Console.WriteLine("The following exception has occured : " + ex.Message)
      End Try
      Return myTypeBuilder.CreateType()
   End Function 'MyCreateCallee
End Class 'MyConstructorBuilder
' </Snippet1>