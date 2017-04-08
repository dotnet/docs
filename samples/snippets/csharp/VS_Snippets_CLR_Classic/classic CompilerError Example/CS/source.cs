// <Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace CompilerError_Example
{
    public class Class1
    {		
        [STAThread]
        static void Main(string[] args)			
        {
            // Output some program information using Console.WriteLine.
            Console.WriteLine("This program compiles a CodeDOM program that incorrectly declares multiple data");
            Console.WriteLine("types to demonstrate handling compiler errors programmatically.");
            Console.WriteLine("");
                        
            // Compile the CodeCompileUnit retrieved from the GetCompileUnit() method.
            CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
                                               
            // Initialize a CompilerParameters with the options for compilation.
            string[] assemblies = new String[] {"System.dll"};
            CompilerParameters options = new CompilerParameters( assemblies, "output.exe");

            // Compile the CodeDOM graph and store the results in a CompilerResults.
            CompilerResults results = provider.CompileAssemblyFromDom(options, GetCompileUnit());
                                        
            // Compilation produces errors. Print out each error.
            Console.WriteLine("Listing errors from compilation: ");
            Console.WriteLine("");
                for( int i=0; i<results.Errors.Count; i++)
                Console.WriteLine(results.Errors[i].ToString());			
        }

        public static CodeCompileUnit GetCompileUnit()
        {
            // Create a compile unit to contain a CodeDOM graph.
            CodeCompileUnit cu = new CodeCompileUnit();

            // Create a namespace named TestSpace.
            CodeNamespace cn = new CodeNamespace("TestSpace");		
        
            // Declare a new type named TestClass.	
            CodeTypeDeclaration cd = new CodeTypeDeclaration("TestClass");

            // Declare a new member string field named TestField.
            CodeMemberField cmf = new CodeMemberField("System.String", "TestField");

            // Add the field to the type.
            cd.Members.Add(cmf);

            // Declare a new member method named TestMethod.
            CodeMemberMethod cm = new CodeMemberMethod();
            cm.Name = "TestMethod";

            // Declare a string variable named TestVariable.
            CodeVariableDeclarationStatement cvd = new CodeVariableDeclarationStatement("System.String1", "TestVariable");
            cm.Statements.Add(cvd);

            // Cast the TestField reference expression to string and assign it to the TestVariable.
            CodeAssignStatement ca = new CodeAssignStatement(new CodeVariableReferenceExpression("TestVariable"), 
                new CodeCastExpression("System.String2", new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "TestField")));

            // This code can be used to generate the following code in C#:
            //            TestVariable = ((string)(this.TestField));

            cm.Statements.Add(ca);
             
            // Add the TestMethod member to the TestClass type.
            cd.Members.Add(cm);
        
            // Add the TestClass type to the namespace.
            cn.Types.Add(cd);
            
            // Add the TestSpace namespace to the compile unit.
            cu.Namespaces.Add(cn);
            return cu;
        }
    }
}
// </Snippet1>