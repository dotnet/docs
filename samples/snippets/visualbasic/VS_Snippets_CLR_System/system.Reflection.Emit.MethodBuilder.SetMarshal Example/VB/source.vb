
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class VariousMethodBuilderSnippets
   
   
   Public Shared Sub ContainerMethod(myDynamicType As TypeBuilder)
      
      ' <Snippet1>
      Dim myMethod As MethodBuilder = myDynamicType.DefineMethod("MyMethodReturnsMarshal", _
					MethodAttributes.Public, GetType(System.UInt32), _
					New Type() {GetType(String)}) 
      
      ' We want the return value of our dynamic method to be marshalled as 
      ' an 64-bit (8-byte) signed integer, instead of the default 32-bit
      ' unsigned int as specified above. The UnmanagedMarshal class can perform
      ' the type conversion.

      Dim marshalMeAsI8 As UnmanagedMarshal = UnmanagedMarshal.DefineUnmanagedMarshal( _
					      System.Runtime.InteropServices.UnmanagedType.I8)
      
      myMethod.SetMarshal(marshalMeAsI8)

      ' </Snippet1>

   End Sub 'ContainerMethod 

End Class 'VariousMethodBuilderSnippets 
