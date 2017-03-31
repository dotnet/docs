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
        static CodeSnippetTypeMember snippetMethod;
        static void Main(string[] args)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider(providerName);

            // Create a code snippet to be used in the graph.
            GenCodeFromMember(provider, new CodeGeneratorOptions());

            LogMessage("Building CodeDOM graph...");

            CodeCompileUnit cu = new CodeCompileUnit();

            cu = BuildClass1();

            StringWriter sw = new StringWriter();

            LogMessage("Generating code...");
            provider.GenerateCodeFromCompileUnit(cu, sw, null);

            string output = sw.ToString();

            LogMessage("Dumping source...");
            LogMessage(output);

            LogMessage("Writing source to file...");
            Stream s = File.Open(sourceFileName, FileMode.Create);
            StreamWriter t = new StreamWriter(s);
            t.Write(output);
            t.Close();
            s.Close();

            CompilerParameters opt = new CompilerParameters(new string[]{
                                      "System.dll" });
            opt.GenerateExecutable = false;
            opt.OutputAssembly = "Sample.dll";

            CompilerResults results;

            LogMessage("Compiling with " + providerName);
            results = provider.CompileAssemblyFromFile(opt, sourceFileName);

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
        // Build a library program graph using 
        // System.CodeDom types.
        public static CodeCompileUnit BuildClass1()
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
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");

            // Add the new type to the namespace type collection.
            samples.Types.Add(class1);

            class1.Members.Add(snippetMethod);

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
        //<Snippet3>
        static void GenCodeFromMember(CodeDomProvider provider, CodeGeneratorOptions options)
        {
            options.BracingStyle = "C";
            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "ReturnString";
            method1.Attributes = MemberAttributes.Public;
            method1.ReturnType = new CodeTypeReference("System.String");
            method1.Parameters.Add(new CodeParameterDeclarationExpression("System.String", "text"));
            method1.Statements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("text")));
            StringWriter sw = new StringWriter();
            provider.GenerateCodeFromMember(method1, sw, options);
            snippetMethod = new CodeSnippetTypeMember(sw.ToString());
        }
        //</Snippet3>

    }
}
//</Snippet1>
