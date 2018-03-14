' System.Reflection.Emit.SetCustomAttribute(ConstructorInfo, byte())

' The following program demonstrates the 'SetCustomAttribute(ConstructorInfo, byte())'
' method of 'AssemblyBuilder' class. It defines a 'MyAttribute' class which is derived
' from 'Attribute' class. It builds an assembly by setting 'MyAttribute' custom attribute
' and defines 'HelloWorld' type. Then it gets the custom attributes of 'HelloWorld' type
' and displays its contents to the console.
' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit


<AttributeUsage(AttributeTargets.All, AllowMultiple := False)>  _
Public Class MyAttribute
   Inherits Attribute
   Public s As Boolean
   
   Public Sub New(s As Boolean)
      Me.s = s
   End Sub 'New
End Class 'MyAttribute

Class MyApplication
   
   Public Shared Sub Main()
      Dim customAttribute As Type = CreateCallee(Thread.GetDomain())
      Dim attributes As Object() = customAttribute.Assembly.GetCustomAttributes(True)
      Console.WriteLine("MyAttribute custom attribute contains : ")
      Dim index As Integer
      For index = 0 To attributes.Length - 1
         If TypeOf attributes(index) Is MyAttribute Then
            Console.WriteLine("s : " + CType(attributes(index), MyAttribute).s.ToString())
            Exit For
         End If
      Next index
   End Sub 'Main
   
   Private Shared Function CreateCallee(domain As AppDomain) As Type
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"
      Dim myAssembly As AssemblyBuilder = domain.DefineDynamicAssembly(myAssemblyName, _
                                                            AssemblyBuilderAccess.Run)
      Dim myType As Type = GetType(MyAttribute)
      Dim infoConstructor As ConstructorInfo = myType.GetConstructor(New Type() {GetType(Boolean)})
      myAssembly.SetCustomAttribute(infoConstructor, New Byte() {01, 00, 01})
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")
      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldClass As TypeBuilder = myModule.DefineType("HelloWorld", TypeAttributes.Public)
      
      Return helloWorldClass.CreateType()
   End Function 'CreateCallee
End Class 'MyApplication
' </Snippet1>