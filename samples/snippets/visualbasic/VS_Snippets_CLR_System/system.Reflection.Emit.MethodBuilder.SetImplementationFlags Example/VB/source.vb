
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class MethodBuilderAssortedMembersDemo
   
   Public Shared Sub MemberSnippets(myTypeBuilder As TypeBuilder)
      
      ' <Snippet1>
      Dim myMthdBuilder As MethodBuilder = myTypeBuilder.DefineMethod("MyMethod", _
					   MethodAttributes.Public, _
					   CallingConventions.HasThis, _
					   GetType(Integer), _
					   New Type() {GetType(Integer), GetType(Integer)})
      
      ' Specifies that the dynamic method declared above has a an MSIL implementation,
      ' is managed, synchronized (single-threaded) through the body, and that it 
      ' cannot be inlined.

      myMthdBuilder.SetImplementationFlags((MethodImplAttributes.IL Or _
					    MethodImplAttributes.Managed Or _
					    MethodImplAttributes.Synchronized Or _
					    MethodImplAttributes.NoInlining))

      ' Create an ILGenerator for the MethodBuilder and emit MSIL here ...
      ' </Snippet1>

   End Sub 'MemberSnippets

End Class 'MethodBuilderAssortedMembersDemo

