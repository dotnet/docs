//<Snippet1>
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
namespace System.CodeDom
{
    class CodeDirectiveDemo
    {
        static void Main()
        {
            try
            {
                DemonstrateCodeDirectives("cs", "ChecksumPragma.cs", "ChecksumPragmaCS.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Exception:" + e.ToString());
            }
        }

        // Create and compile code containing code directives.
        static void DemonstrateCodeDirectives(string providerName, string sourceFileName, string assemblyName)
        {

            CodeDomProvider provider = CodeDomProvider.CreateProvider(providerName);

            Console.WriteLine("Building the CodeDOM graph...");

            CodeCompileUnit cu = new CodeCompileUnit();

            CreateGraph(cu);

            StringWriter sw = new StringWriter();

            Console.WriteLine("Generating code...");
            provider.GenerateCodeFromCompileUnit(cu, sw, null);

            string output = sw.ToString();
            output = Regex.Replace(output, "Runtime Version:[^\r\n]*",
                "Runtime Version omitted for demo");

            Console.WriteLine("Dumping source code...");
            Console.WriteLine(output);

            Console.WriteLine("Writing source code to file...");
            Stream s = File.Open(sourceFileName, FileMode.Create);
            StreamWriter t = new StreamWriter(s);
            t.Write(output);
            t.Close();
            s.Close();

            CompilerParameters opt = new CompilerParameters(new string[]{
                                      "System.dll", 
                                      "System.Xml.dll",
                                      "System.Windows.Forms.dll",
                                      "System.Data.dll",
                                      "System.Drawing.dll"});
            opt.GenerateExecutable = false;
            opt.TreatWarningsAsErrors = true;
            opt.IncludeDebugInformation = true;
            opt.GenerateInMemory = true;

            CompilerResults results;

            Console.WriteLine("Compiling with " + providerName);
            results = provider.CompileAssemblyFromFile(opt, sourceFileName);

            OutputResults(results);
            if (results.NativeCompilerReturnValue != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Compilation failed.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Demo complete.");
            }
            File.Delete(sourceFileName);
        }

        private static Guid HashMD5 = new Guid(0x406ea660, 0x64cf, 0x4c82, 0xb6, 0xf0, 0x42, 0xd4, 0x81, 0x72, 0xa7, 0x99);
        private static Guid HashSHA1 = new Guid(0xff1816ec, 0xaa5e, 0x4d10, 0x87, 0xf7, 0x6f, 0x49, 0x63, 0x83, 0x34, 0x60);

        // Create a CodeDOM graph.
        static void CreateGraph( CodeCompileUnit cu)
        {
            //<Snippet2>
            cu.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start,
                "Compile Unit Region"));
            //</Snippet2>
            //<Snippet3>
            cu.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End,
                string.Empty));
            //</Snippet3>
            //<Snippet4>
            CodeChecksumPragma pragma1 = new CodeChecksumPragma();
            //</Snippet4>
            //<Snippet5>
            pragma1.FileName = "c:\\temp\\test\\OuterLinePragma.txt";
            //</Snippet5>
            //<Snippet6>
            pragma1.ChecksumAlgorithmId = HashMD5;
            //</Snippet6>
            //<Snippet7>
            pragma1.ChecksumData = new byte[] { 0xAA, 0xAA };
            //</Snippet7>
            cu.StartDirectives.Add(pragma1);
            //<Snippet8>
            CodeChecksumPragma pragma2 = new CodeChecksumPragma("test.txt", HashSHA1, new byte[] { 0xBB, 0xBB, 0xBB });
            //</Snippet8>
            cu.StartDirectives.Add(pragma2);

            CodeNamespace ns = new CodeNamespace("Namespace1");
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.IO"));
            cu.Namespaces.Add(ns);
            ns.Comments.Add(new CodeCommentStatement("Namespace Comment"));
            CodeTypeDeclaration cd = new CodeTypeDeclaration("Class1");
            ns.Types.Add(cd);

            cd.Comments.Add(new CodeCommentStatement("Outer Type Comment"));
            cd.LinePragma = new CodeLinePragma("c:\\temp\\test\\OuterLinePragma.txt", 300);

            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "Method1";
            method1.Attributes = (method1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;


            CodeMemberMethod method2 = new CodeMemberMethod();
            method2.Name = "Method2";
            method2.Attributes = (method2.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            method2.Comments.Add(new CodeCommentStatement("Method 2 Comment"));

            cd.Members.Add(method1);
            cd.Members.Add(method2);

            cd.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start,
                "Outer Type Region"));

            cd.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End,
                string.Empty));

            CodeMemberField field1 = new CodeMemberField(typeof(String), "field1");
            cd.Members.Add(field1);
            field1.Comments.Add(new CodeCommentStatement("Field 1 Comment"));

            //<Snippet9>
            CodeRegionDirective codeRegionDirective1 = new CodeRegionDirective(CodeRegionMode.Start,
                "Field Region");
            //</Snippet9>
            //<Snippet10>
            field1.StartDirectives.Add(codeRegionDirective1);
            //</Snippet10>
            CodeRegionDirective codeRegionDirective2 = new CodeRegionDirective(CodeRegionMode.End,
                "");
            //<Snippet11>
            codeRegionDirective2.RegionMode = CodeRegionMode.End;
            //</Snippet11>
            //<Snippet12>
            codeRegionDirective2.RegionText = string.Empty;
            //</Snippet12>
            //<Snippet13>
            field1.EndDirectives.Add(codeRegionDirective2);
            //</Snippet13>

            //<Snippet16>
            CodeSnippetStatement snippet1 = new CodeSnippetStatement();
            snippet1.Value = "            Console.WriteLine(field1);";

            CodeRegionDirective regionStart = new CodeRegionDirective(CodeRegionMode.End, "");
            regionStart.RegionText = "Snippet Region";
            regionStart.RegionMode = CodeRegionMode.Start;
            snippet1.StartDirectives.Add(regionStart);
            snippet1.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
            //</Snippet16>

            // CodeStatement example
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = (constructor1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            CodeStatement codeAssignStatement1 = new CodeAssignStatement(
                                        new CodeFieldReferenceExpression(
                                            new CodeThisReferenceExpression(),
                                            "field1"),
                                        new CodePrimitiveExpression("value1"));
            //<Snippet14>
            codeAssignStatement1.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Statements Region"));
            //</Snippet14>
            cd.Members.Add(constructor1);
            //<Snippet15>
            codeAssignStatement1.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
            //</Snippet15>
            method2.Statements.Add(codeAssignStatement1);
            method2.Statements.Add(snippet1);

        }

        static void OutputResults(CompilerResults results)
        {
            Console.WriteLine("NativeCompilerReturnValue=" +
                results.NativeCompilerReturnValue.ToString());
            foreach (string s in results.Output)
            {
                Console.WriteLine(s);
            }
        }

    }
}
//</Snippet1>

