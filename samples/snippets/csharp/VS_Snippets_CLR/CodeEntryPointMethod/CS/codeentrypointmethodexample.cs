//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeEntryPointMethodExample
    {
        //<Snippet2>
        // Builds a Hello World Program Graph using System.CodeDom objects
        public static CodeCompileUnit BuildHelloWorldGraph()
        {            
            // Create a new CodeCompileUnit to contain the program graph
            CodeCompileUnit CompileUnit = new CodeCompileUnit();

            // Declare a new namespace object and name it
            CodeNamespace Samples = new CodeNamespace("Samples");
            // Add the namespace object to the compile unit
            CompileUnit.Namespaces.Add( Samples );

            // Add a new namespace import for the System namespace
            Samples.Imports.Add( new CodeNamespaceImport("System") );            

            // Declare a new type object and name it
            CodeTypeDeclaration Class1 = new CodeTypeDeclaration("Class1");
            // Add the new type to the namespace object's type collection
            Samples.Types.Add(Class1);            

            // Declare a new code entry point method
            CodeEntryPointMethod Start = new CodeEntryPointMethod();
            // Create a new method invoke expression
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression( 
                // Call the System.Console.WriteLine method
                new CodeTypeReferenceExpression("System.Console"), "WriteLine", 
                // Pass a primitive string parameter to the WriteLine method
                new CodePrimitiveExpression("Hello World!") );
            // Add the new method code statement
            Start.Statements.Add(new CodeExpressionStatement(cs1));        

            // Add the code entry point method to the type's members collection
            Class1.Members.Add( Start );

            return CompileUnit;
            //</Snippet2>
        }    
    }
}
//</Snippet1>