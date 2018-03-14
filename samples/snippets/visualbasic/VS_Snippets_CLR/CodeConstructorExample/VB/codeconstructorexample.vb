'<Snippet1>
Imports System
Imports System.CodeDom
Imports System.Reflection

Namespace CodeDomSamples
    
   Public Class CodeConstructorExample
      
      Public Sub New()
         '<Snippet2>
         ' This example declares two types, one of which inherits from another,
         ' and creates a set of different styles of constructors using CodeConstructor.

         ' Creates a new CodeCompileUnit to contain the program graph.
         Dim CompileUnit As New CodeCompileUnit()
         ' Declares a new namespace object and names it.
         Dim Samples As New CodeNamespace("Samples")
         ' Adds the namespace object to the compile unit.
         CompileUnit.Namespaces.Add(Samples)
         ' Adds a new namespace import for the System namespace.
         Samples.Imports.Add(New CodeNamespaceImport("System"))
         
         ' Declares a new type and names it.
         Dim BaseType As New CodeTypeDeclaration("BaseType")
         ' Adds the new type to the namespace object's type collection.
         Samples.Types.Add(BaseType)
         
         ' Declares a default constructor that takes no arguments.
         Dim defaultConstructor As New CodeConstructor()
         defaultConstructor.Attributes = MemberAttributes.Public
         ' Adds the constructor to the Members collection of the BaseType.
         BaseType.Members.Add(defaultConstructor)
         
         ' Declares a constructor that takes a string argument.
         Dim stringConstructor As New CodeConstructor()
         stringConstructor.Attributes = MemberAttributes.Public
         ' Declares a parameter of type string named "TestStringParameter".
         stringConstructor.Parameters.Add(New CodeParameterDeclarationExpression("System.String", "TestStringParameter"))
         ' Adds the constructor to the Members collection of the BaseType.
         BaseType.Members.Add(stringConstructor)
         
         ' Declares a type that derives from BaseType and names it.
         Dim DerivedType As New CodeTypeDeclaration("DerivedType")
         ' The DerivedType class inherits from the BaseType class.
         DerivedType.BaseTypes.Add(New CodeTypeReference("BaseType"))
         ' Adds the new type to the namespace object's type collection.
         Samples.Types.Add(DerivedType)
         
         ' Declare a constructor that takes a string argument and calls the base class constructor with it.
         Dim baseStringConstructor As New CodeConstructor()
         baseStringConstructor.Attributes = MemberAttributes.Public
         ' Declares a parameter of type string named "TestStringParameter".	
         baseStringConstructor.Parameters.Add(New CodeParameterDeclarationExpression("System.String", "TestStringParameter"))
         ' Calls a base class constructor with the TestStringParameter parameter.
         baseStringConstructor.BaseConstructorArgs.Add(New CodeVariableReferenceExpression("TestStringParameter"))
         ' Adds the constructor to the Members collection of the DerivedType.
         DerivedType.Members.Add(baseStringConstructor)
         
         ' Declares a constructor overload that calls another constructor for the type with a predefined argument.
         Dim overloadConstructor As New CodeConstructor()
         overloadConstructor.Attributes = MemberAttributes.Public
         ' Sets the argument to pass to a base constructor method.
         overloadConstructor.ChainedConstructorArgs.Add(New CodePrimitiveExpression("Test"))
         ' Adds the constructor to the Members collection of the DerivedType.
         DerivedType.Members.Add(overloadConstructor)

         ' Declares a constructor overload that calls another constructor for the type.
         Dim overloadConstructor2 As New CodeConstructor()
         overloadConstructor2.Attributes = MemberAttributes.Public
         overloadConstructor2.Parameters.Add( New CodeParameterDeclarationExpression("System.Int32", "TestIntParameter") )
         ' Sets the argument to pass to a base constructor method.
         overloadConstructor2.ChainedConstructorArgs.Add(New CodeSnippetExpression(""))
         ' Adds the constructor to the Members collection of the DerivedType.
         DerivedType.Members.Add(overloadConstructor2)

        ' A Visual Basic code generator produces the following source code for the preceeding example code:
        
        ' Public Class BaseType
        '     
        '     Public Sub New()
        '         MyBase.New
        '     End Sub
        '        
        '     Public Sub New(ByVal TestStringParameter As String)
        '         MyBase.New
        '     End Sub
        ' End Class
        '    
        ' Public Class DerivedType
        '     Inherits BaseType
        '        
        '     Public Sub New(ByVal TestStringParameter As String)
        '         MyBase.New(TestStringParameter)
        '     End Sub
        '     
        '     Public Sub New()
        '         Me.New("Test")
        '     End Sub
        '
        '     Public Sub New(ByVal TestIntParameter As Integer)
        '         Me.New()
        '     End Sub
        ' End Class


        '</Snippet2>
      End Sub 'New 

   End Class 'CodeConstructorExample

End Namespace 'CodeDomSamples 

'</Snippet1>