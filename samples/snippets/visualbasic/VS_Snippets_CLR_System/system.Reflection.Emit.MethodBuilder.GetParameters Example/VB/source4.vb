
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class MoreMethodBuilderSnippets
   
   
   
   Public Shared Sub ContainerMethod(myModBuilder As ModuleBuilder)
      
      ' <Snippet1>	
      Dim myType1 As TypeBuilder = myModBuilder.DefineType("MyMathFunctions", _
							TypeAttributes.Public)
      
      Dim myMthdBuilder As MethodBuilder = myType1.DefineMethod("AddToRefValue", _
				MethodAttributes.Public, Nothing, _
				New Type() {Type.GetType("System.Int32&"), GetType(Integer)})

      Dim myParam1 As ParameterBuilder = myMthdBuilder.DefineParameter(1, _
						ParameterAttributes.Out, "thePool")

      Dim myParam2 As ParameterBuilder = myMthdBuilder.DefineParameter(2, _
						ParameterAttributes.In, "addMeToPool")
      
      ' Create body via ILGenerator here, and complete the type.

      Dim myParams As ParameterInfo() = myMthdBuilder.GetParameters()
      
      Console.WriteLine("Method: {0}", myMthdBuilder.Name)
      
      Dim myParam As ParameterInfo
      For Each myParam In  myParams
         Console.WriteLine("------- Parameter: {0} {1} at pos {2}, with attribute {3}", _
				myParam.ParameterType, myParam.Name, myParam.Position, _
				myParam.Attributes.ToString())
      Next myParam

      ' </Snippet1>	

   End Sub 'ContainerMethod

End Class 'MoreMethodBuilderSnippets 

