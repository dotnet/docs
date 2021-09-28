//<Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text.RegularExpressions;

namespace BasicCodeDomApp
{
    class Program
    {
        static string providerName = "cs";
        static string sourceFileName = "test.cs";
        static void Main(string[] args)
        {
            CodeDomProvider provider =
                CodeDomProvider.CreateProvider(providerName);

            LogMessage("Building CodeDOM graph...");

            CodeCompileUnit cu = new CodeCompileUnit();

            cu = BuildHelloWorldGraph();

            //<Snippet5>
            StreamWriter sourceFile = new StreamWriter(sourceFileName);
            provider.GenerateCodeFromCompileUnit(cu, sourceFile, null);
            sourceFile.Close();
            //</Snippet5>

            //<Snippet6>
            CompilerParameters opt = new CompilerParameters(new string[]{
                                      "System.dll" });
            opt.GenerateExecutable = true;
            opt.OutputAssembly = "HelloWorld.exe";
            opt.TreatWarningsAsErrors = true;
            opt.IncludeDebugInformation = true;
            opt.GenerateInMemory = true;
            opt.CompilerOptions = "/doc:HelloWorldDoc.xml";

            CompilerResults results;

            LogMessage("Compiling with " + providerName);
            results = provider.CompileAssemblyFromFile(opt, sourceFileName);
            //</Snippet6>

            OutputResults(results);
            if (results.NativeCompilerReturnValue != 0)
            {
                LogMessage("");
                LogMessage("Compilation failed.");
            }
            else
            {
                LogMessage("");
                LogMessage("Demo completed successfully.");
            }
            File.Delete(sourceFileName);
        }

        //<Snippet2>
        // Build a Hello World program graph using
        // System.CodeDom types.
        public static CodeCompileUnit BuildHelloWorldGraph()
        {
            // Create a new CodeCompileUnit to contain
            // the program graph.
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // Declare a new namespace called Samples.
            CodeNamespace samples = new CodeNamespace("Samples");
            // Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add(samples);

            // Add the new namespace import for the System namespace.
            samples.Imports.Add(new CodeNamespaceImport("System"));

            // Declare a new type called Class1.
            //<Snippet4>
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");

            class1.Comments.Add(new CodeCommentStatement("<summary>", true));
            class1.Comments.Add(new CodeCommentStatement(
                "Create a Hello World application.", true));
            class1.Comments.Add(new CodeCommentStatement("</summary>", true));
            class1.Comments.Add(new CodeCommentStatement(
                @"<seealso cref=" + '"' + "Class1.Main" + '"' + "/>", true));

            // Add the new type to the namespace type collection.
            samples.Types.Add(class1);

            //<Snippet3>
            // Declare a new code entry point method.
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            start.Comments.Add(new CodeCommentStatement("<summary>", true));
            start.Comments.Add(new CodeCommentStatement(
                "Main method for HelloWorld application.", true));
            start.Comments.Add(new CodeCommentStatement(
                @"<para>Add a new paragraph to the description.</para>", true));
            start.Comments.Add(new CodeCommentStatement("</summary>", true));
            //</Snippet3>
            //</Snippet4>

            // Create a type reference for the System.Console class.
            CodeTypeReferenceExpression csSystemConsoleType =
                new CodeTypeReferenceExpression("System.Console");

            // Build a Console.WriteLine statement.
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Hello World!"));

            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1);

            // Build another Console.WriteLine statement.
            CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine", new CodePrimitiveExpression(
                "Press the ENTER key to continue."));

            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2);

            // Build a call to System.Console.ReadLine.
            CodeMethodInvokeExpression csReadLine =
                new CodeMethodInvokeExpression(csSystemConsoleType, "ReadLine");

            // Add the ReadLine statement.
            start.Statements.Add(csReadLine);

            // Add the code entry point method to
            // the Members collection of the type.
            class1.Members.Add(start);

            return compileUnit;
        }
        //</Snippet2>
        static void LogMessage(string text)
        {
            Console.WriteLine(text);
        }

        static void OutputResults(CompilerResults results)
        {
            LogMessage("NativeCompilerReturnValue=" +
                results.NativeCompilerReturnValue.ToString());
            foreach (string s in results.Output)
            {
                LogMessage(s);
            }
        }
    }
}
//</Snippet1>
