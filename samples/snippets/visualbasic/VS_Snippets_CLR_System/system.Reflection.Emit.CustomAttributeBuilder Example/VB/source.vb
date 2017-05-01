 ' <Snippet1>

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _


' We will apply this custom attribute to our dynamic type.
Public Class ClassCreator

   Inherits Attribute
   
   Private creator As String
   
   Public ReadOnly Property GetCreator() As String
      Get
         Return creator
      End Get
   End Property
   
   
   Public Sub New(name As String)
      Me.creator = name
   End Sub 'New

End Class 'ClassCreator
 _ 

' We will apply this dynamic attribute to our dynamic method.
Public Class DateLastUpdated

   Inherits Attribute
   
   Private dateUpdated As String
   
   Public ReadOnly Property GetDateUpdated() As String
      Get
         Return dateUpdated
      End Get
   End Property
   
   
   Public Sub New(theDate As String)
      Me.dateUpdated = theDate
   End Sub 'New

End Class 'DateLastUpdated
 _ 

Class MethodBuilderCustomAttributesDemo
   
   Public Shared Function BuildTypeWithCustomAttributesOnMethod() As Type
      
      Dim currentDomain As AppDomain = Thread.GetDomain()
      
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      
      Dim myAsmBuilder As AssemblyBuilder = currentDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      
      Dim myModBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule")
      
      ' First, we'll build a type with a custom attribute attached.
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType("MyType", _
							TypeAttributes.Public)
      
      Dim ctorParams() As Type = {GetType(String)}
      Dim classCtorInfo As ConstructorInfo = GetType(ClassCreator).GetConstructor(ctorParams)
      
      Dim myCABuilder As New CustomAttributeBuilder(classCtorInfo, _
						New Object() {"Joe Programmer"})
      
      myTypeBuilder.SetCustomAttribute(myCABuilder)
      
      ' Now, let's build a method and add a custom attribute to it.
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("HelloWorld", _
					MethodAttributes.Public, Nothing, New Type() {})
      
      ctorParams = New Type() {GetType(String)}
      classCtorInfo = GetType(DateLastUpdated).GetConstructor(ctorParams)
      
      Dim myCABuilder2 As New CustomAttributeBuilder(classCtorInfo, _
						New Object() {DateTime.Now.ToString()})
      
      myMethodBuilder.SetCustomAttribute(myCABuilder2)
      
      Dim myIL As ILGenerator = myMethodBuilder.GetILGenerator()
      
      myIL.EmitWriteLine("Hello, world!")
      myIL.Emit(OpCodes.Ret)
      
      Return myTypeBuilder.CreateType()

   End Function 'BuildTypeWithCustomAttributesOnMethod
    
   
   Public Shared Sub Main()
      
      Dim myType As Type = BuildTypeWithCustomAttributesOnMethod()
      
      Dim myInstance As Object = Activator.CreateInstance(myType)
      
      Dim customAttrs As Object() = myType.GetCustomAttributes(True)
      
      Console.WriteLine("Custom Attributes for Type 'MyType':")
      
      Dim attrVal As Object = Nothing
      
      Dim customAttr As Object
      For Each customAttr In  customAttrs
         attrVal = GetType(ClassCreator).InvokeMember("GetCreator", _
						BindingFlags.GetProperty, _
						Nothing, customAttr, New Object() {})
         Console.WriteLine("-- Attribute: [{0} = ""{1}""]", customAttr, attrVal)
      Next customAttr
      
      Console.WriteLine("Custom Attributes for Method 'HelloWorld()' in 'MyType':")
      
      customAttrs = myType.GetMember("HelloWorld")(0).GetCustomAttributes(True)
      
      For Each customAttr In  customAttrs
         attrVal = GetType(DateLastUpdated).InvokeMember("GetDateUpdated", _
						BindingFlags.GetProperty, _
						Nothing, customAttr, New Object() {})
         Console.WriteLine("-- Attribute: [{0} = ""{1}""]", customAttr, attrVal)
      Next customAttr
      
      Console.WriteLine("---")
      
      Console.WriteLine(myType.InvokeMember("HelloWorld", BindingFlags.InvokeMethod, _
						Nothing, myInstance, New Object() {}))
   End Sub 'Main

End Class 'MethodBuilderCustomAttributesDemo

' </Snippet1>