
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class MoreMethodBuilderSnippets
   
   
   
   Public Shared Sub ContainerMethod(myAsmBuilder As AssemblyBuilder)
      
      ' <Snippet1>

      Dim myModBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MathFunctions")
      
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType("MyMathFunctions", _
								TypeAttributes.Public)
      
      Dim myMthdBuilder As MethodBuilder = myTypeBuilder.DefineMethod("Adder", _
					MethodAttributes.Public, GetType(Integer), _
					New Type() {GetType(Integer), GetType(Integer)})
      
      ' Create body via ILGenerator here ...

      Dim myNewType As Type = myTypeBuilder.CreateType()
      
      Dim myModule As [Module] = myMthdBuilder.GetModule()
      
      Dim myModTypes As Type() = myModule.GetTypes()
      Console.WriteLine("Module: {0}", myModule.Name)
      Console.WriteLine("------- with path {0}", myModule.FullyQualifiedName)
      Console.WriteLine("------- in assembly {0}", myModule.Assembly.FullName)
      Dim myModType As Type
      For Each myModType In  myModTypes
         Console.WriteLine("------- has type {0}", myModType.FullName)
      Next myModType

      ' </Snippet1>

   End Sub 'ContainerMethod 

End Class 'MoreMethodBuilderSnippets
