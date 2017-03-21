<AttributeUsage(AttributeTargets.All, AllowMultiple := False)>  _
Public Class MyAttribute
   Inherits Attribute
   Public s As String
   Public x As Integer

   Public Sub New(s As String, x As Integer)
      Me.s = s
      Me.x = x
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
            Console.WriteLine("s : " + CType(attributes(index), MyAttribute).s)
            Console.WriteLine("x : " + CType(attributes(index), MyAttribute).x.ToString())
            Exit For
         End If
      Next index
   End Sub 'Main

   Private Shared Function CreateCallee(domain As AppDomain) As Type
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"
      Dim myAssembly As AssemblyBuilder = _
                     domain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)
      Dim myType As Type = GetType(MyAttribute)
      Dim infoConstructor As ConstructorInfo = _
                     myType.GetConstructor(New Type(1) {GetType(String), GetType(Integer)})
      Dim attributeBuilder As New CustomAttributeBuilder(infoConstructor, New Object(1) {"Hello", 2})
      myAssembly.SetCustomAttribute(attributeBuilder)
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")
      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldClass As TypeBuilder = myModule.DefineType("HelloWorld", TypeAttributes.Public)
      Return helloWorldClass.CreateType()
   End Function 'CreateCallee
End Class 'MyApplication