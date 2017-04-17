
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class VariousMethodBuilderSnippets
   
   
   Public Shared Sub ContainerMethod(myDynamicType As TypeBuilder)
      
      ' <Snippet1>
      Dim myMethod As MethodBuilder = myDynamicType.DefineMethod("MyMethod", _
					 MethodAttributes.Public, GetType(Integer), _
					 New Type() {GetType(String)})
      
      ' A 128-bit key in hex form, represented as a byte array.
      Dim keyVal As Byte() =  {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
			       &H0, &H0, &H0, &H0, &H0, &H60, &HFF, &HFF}
      
      Dim encoder As New System.Text.ASCIIEncoding()
      Dim symFullName As Byte() = encoder.GetBytes("My Dynamic Method")
      
      myMethod.SetSymCustomAttribute("SymID", keyVal)
      myMethod.SetSymCustomAttribute("SymFullName", symFullName)

      ' </Snippet1>
   End Sub 'ContainerMethod 
End Class 'VariousMethodBuilderSnippets 
