' System.Reflection.Emit.FieldBuilder.SetCustomAttribute(ConstructorInfo,byte())
' System.Reflection.Emit.FieldBuilder.SetCustomAttribute(CustomAttributeBuilder)

'  The following program demonstrates 'SetCustomAttribute(ConstructorInfo,byte())'
'  and 'SetCustomAttribute(CustomAttributeBuilder)' methods of 'FieldBuilder' class.
'  A dynamic assembly is created. A new class of type 'MyClass' is created.
'  A 'Method' and a 'Field are defined in the class.Two 'CustomAttributes' are
'  set to the field.The method initializes a value to 'Field'.Value of the field
'  is displayed to console.Values of Attributes applied to field are retreived and
'  displayed to console.

' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

Namespace MySample
   <AttributeUsage(AttributeTargets.All, AllowMultiple:=False)> Public Class MyAttribute1
      Inherits Attribute
      Public myCustomAttributeValue As String

      Public Sub New(ByVal myString As String)
         myCustomAttributeValue = myString
      End Sub 'New
   End Class 'MyAttribute1
   <AttributeUsage(AttributeTargets.All, AllowMultiple:=False)> Public Class MyAttribute2
      Inherits Attribute
      Public myCustomAttributeValue As Boolean

      Public Sub New(ByVal myBool As Boolean)
         myCustomAttributeValue = myBool
      End Sub 'New
   End Class 'MyAttribute2

   Class FieldBuilder_Sample

      Private Shared Function CreateCallee(ByVal currentDomain As AppDomain) As Type
         ' Create a simple name for the assembly.
         Dim myAssemblyName As New AssemblyName()
         myAssemblyName.Name = "EmittedAssembly"
         ' Create the called dynamic assembly.
         Dim myAssemblyBuilder As AssemblyBuilder = _
                     currentDomain.DefineDynamicAssembly(myAssemblyName, _
                     AssemblyBuilderAccess.RunAndSave)
         Dim myModuleBuilder As ModuleBuilder = _
               myAssemblyBuilder.DefineDynamicModule("EmittedModule", _
                                                   "EmittedModule.mod")
         ' Define a public class named 'CustomClass' in the assembly.
         Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("CustomClass", _
                                                TypeAttributes.Public)
         ' Define a private String field named 'MyField' in the type.
         Dim myFieldBuilder As FieldBuilder = myTypeBuilder.DefineField("MyField", _
                                       GetType(String), FieldAttributes.Public)
         Dim myAttributeType1 As Type = GetType(MyAttribute1)
         ' Create a Constructorinfo object for attribute 'MyAttribute1'.
         Dim myConstructorInfo As ConstructorInfo = _
                     myAttributeType1.GetConstructor(New Type(0) {GetType(String)})
         ' Create the CustomAttribute instance of attribute of type 'MyAttribute1'.
         Dim attributeBuilder As _
         New CustomAttributeBuilder(myConstructorInfo, New Object(0) {"Test"})
         ' Set the CustomAttribute 'MyAttribute1' to the Field.
         myFieldBuilder.SetCustomAttribute(attributeBuilder)

         Dim myAttributeType2 As Type = GetType(MyAttribute2)
         ' Create a Constructorinfo object for attribute 'MyAttribute2'.
         Dim myConstructorInfo2 As ConstructorInfo = _
                  myAttributeType2.GetConstructor(New Type(0) {GetType(Boolean)})
         ' Set the CustomAttribute 'MyAttribute2' to the Field.
         myFieldBuilder.SetCustomAttribute(myConstructorInfo2, New Byte() {1, 0, 1, 0, 0})

         ' Create a method.
         Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("MyMethod", _
               MethodAttributes.Public, Nothing, New Type(1) {GetType(String), GetType(Integer)})
         Dim myILGenerator As ILGenerator = myMethodBuilder.GetILGenerator()
         myILGenerator.Emit(OpCodes.Ldarg_0)
         myILGenerator.Emit(OpCodes.Ldarg_1)
         myILGenerator.Emit(OpCodes.Stfld, myFieldBuilder)
         myILGenerator.EmitWriteLine("Value of the Field is :")
         myILGenerator.EmitWriteLine(myFieldBuilder)
         myILGenerator.Emit(OpCodes.Ret)

         Return myTypeBuilder.CreateType()
      End Function 'CreateCallee

      Public Shared Sub Main()
         Try
            Dim myCustomClass As Type = CreateCallee(Thread.GetDomain())
            ' Construct an instance of a type.
            Dim myObject As Object = Activator.CreateInstance(myCustomClass)
            Console.WriteLine("FieldBuilder Sample")
            ' Find a method in this type and call it on this object.
            Dim myMethodInfo As MethodInfo = myCustomClass.GetMethod("MyMethod")
            myMethodInfo.Invoke(myObject, New Object(1) {"Sample string", 3})
            ' Retrieve the values of Attributes applied to field and display to console.
            Dim myFieldInfo As FieldInfo() = myCustomClass.GetFields()
            Dim i As Integer
            For i = 0 To myFieldInfo.Length - 1
               Dim attributes As Object() = myFieldInfo(i).GetCustomAttributes(True)
               Dim index As Integer
               For index = 0 To attributes.Length - 1
                  If TypeOf attributes(index) Is MyAttribute1 Then
                     Dim myCustomAttribute As MyAttribute1 =  _
                                    CType(attributes(index), MyAttribute1)
                     Console.WriteLine("Attribute Value of (MyAttribute1): " _
                                    + myCustomAttribute.myCustomAttributeValue.ToString())
                  End If
                  If TypeOf attributes(index) Is MyAttribute2 Then
                     Dim myCustomAttribute As MyAttribute2 = _
                                    CType(attributes(index), MyAttribute2)
                     Console.WriteLine("Attribute Value of (MyAttribute2): " _
                                       + myCustomAttribute.myCustomAttributeValue.ToString())
                  End If
               Next index
            Next i
         Catch e as Exception
            Console.WriteLine("Exception Caught "+e.Message)
         End Try
      End Sub 'Main
   End Class 'FieldBuilder_Sample
End Namespace 'MySample
' </Snippet1>