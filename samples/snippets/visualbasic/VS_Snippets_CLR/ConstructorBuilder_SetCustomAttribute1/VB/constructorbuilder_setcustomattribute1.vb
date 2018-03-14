' System.Reflection.Emit.ConstructorBuilder.SetCustomAttribute(CustomAttributeBuilder)

' The following program demonstrates the 'SetCustomAttribute(CustomAttributeBuilder)'
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
   Public myString As String
   Public myInteger As Integer
   
   Public Sub New(myString As String, myInteger As Integer)
      Me.myString = myString
      Me.myInteger = myInteger
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
            Console.WriteLine("The value of myString is : " + CType(myAttributes1(index), _ 
                                                                       MyAttribute).myString)
            Console.WriteLine("The value of myInteger is : " + CType(myAttributes1(index), _ 
                                                            MyAttribute).myInteger.ToString())
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
      Dim myConstructorInfo As ConstructorInfo = myType.GetConstructor(New Type(1) _ 
                                                           {GetType(String), GetType(Integer)})
      Dim attributeBuilder As New CustomAttributeBuilder _ 
                                  (myConstructorInfo, New Object(1) {"Hello", 2})
      Try
         myConstructor.SetCustomAttribute(attributeBuilder)
      Catch ex As ArgumentNullException
         Console.WriteLine("The following exception has occured : " + ex.Message)
      Catch ex As Exception
         Console.WriteLine("The following exception has occured : " + ex.Message)
      End Try
      Return myTypeBuilder.CreateType()
   End Function 'MyCreateCallee
End Class 'MyConstructorBuilder
' </Snippet1>