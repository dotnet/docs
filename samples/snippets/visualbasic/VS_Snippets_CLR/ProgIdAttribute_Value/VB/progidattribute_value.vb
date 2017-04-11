'  System.Runtime.InteropServices.ProgIdAttribute.Value
   
'  The program shows MyClass as a COM class with prog id 'InteropSample.MyClass'.
'  It get all attributes of MyClass by calling GetAttributes method of TypeDescriptor
'  then prints the 'Value' property of 'ProgIdAttribute' class.

Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices


Namespace InteropSample

' <Snippet1>
   <ClassInterface(ClassInterfaceType.AutoDispatch), ProgId("InteropSample.MyClass")>  _
   Public Class [MyClass]
      
      Public Sub New()
      End Sub 'New
   End Class '[MyClass]

   Class TestApplication
      
      Public Shared Sub Main()
         Try
            Dim attributes As AttributeCollection
            attributes = TypeDescriptor.GetAttributes(GetType([MyClass]))
            Dim progIdAttributeObj As ProgIdAttribute = CType(attributes(GetType(ProgIdAttribute)), ProgIdAttribute)
            Console.WriteLine(("ProgIdAttribute's value is set to : " + progIdAttributeObj.Value))
         Catch e As Exception
            Console.WriteLine(("Exception : " + e.Message.ToString()))
         End Try
      End Sub 'Main
   End Class 'TestApplication
End Namespace 'InteropSample 
' </Snippet1>