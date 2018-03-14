 '<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeEntryPointMethodExample
      
      '<Snippet2>
      ' Builds a Hello World Program Graph using System.CodeDom objects
      Public Shared Function BuildHelloWorldGraph() As CodeCompileUnit
         ' Create a new CodeCompileUnit to contain the program graph
         Dim CompileUnit As New CodeCompileUnit()
         
         ' Declare a new namespace object and name it
         Dim Samples As New CodeNamespace("Samples")
         ' Add the namespace object to the compile unit
         CompileUnit.Namespaces.Add(Samples)
         
         ' Add a new namespace import for the System namespace
         Samples.Imports.Add(New CodeNamespaceImport("System"))
         
         ' Declare a new type object and name it
         Dim Class1 As New CodeTypeDeclaration("Class1")
         ' Add the new type to the namespace object's type collection
         Samples.Types.Add(Class1)
         
         ' Declare a new code entry point method
         Dim Start As New CodeEntryPointMethod()
         ' Create a new method invoke expression
         Dim cs1 As New CodeMethodInvokeExpression(New CodeTypeReferenceExpression("System.Console"), "WriteLine", New CodePrimitiveExpression("Hello World!"))
         ' Call the System.Console.WriteLine method
         ' Pass a primitive string parameter to the WriteLine method
         ' Add the new method code statement
         Start.Statements.Add(New CodeExpressionStatement(cs1))
         
         ' Add the code entry point method to the type's members collection
         Class1.Members.Add(Start)
         
         Return CompileUnit

      End Function 'BuildHelloWorldGraph 		
      '</Snippet2>

   End Class 'CodeEntryPointMethodExample

End Namespace 'CodeDomSamples
'</Snippet1>