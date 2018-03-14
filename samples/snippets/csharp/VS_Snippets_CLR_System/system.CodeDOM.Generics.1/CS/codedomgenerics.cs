//<Snippet1>
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
namespace System.CodeDom
{
    class CodeDomGenericsDemo
    {
        static void Main()
        {
            try
            {
                CreateGenericsCode("cs", "Generic.cs", "GenericCS.exe");
            }
            catch (Exception e)
            {
                LogMessage("Unexpected Exception:" + e.ToString());
            }
        }

        static void CreateGenericsCode(string providerName, string sourceFileName, string assemblyName)
        {

            CodeDomProvider provider = CodeDomProvider.CreateProvider(providerName);

            LogMessage("Building CodeDOM graph...");

            CodeCompileUnit cu = new CodeCompileUnit();

            CreateGraph(provider, cu);

            StringWriter sw = new StringWriter();

            LogMessage("Generating code...");
            provider.GenerateCodeFromCompileUnit(cu, sw, null);

            string output = sw.ToString();
            output = Regex.Replace(output, "Runtime Version:[^\r\n]*",
                "Runtime Version omitted for demo");

            LogMessage("Dumping source...");
            LogMessage(output);

            LogMessage("Writing source to file...");
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

        // Create a CodeDOM graph.
        static void CreateGraph(CodeDomProvider provider, CodeCompileUnit cu)
        {
            //<Snippet8>
            if (!provider.Supports(GeneratorSupport.GenericTypeReference |
               GeneratorSupport.GenericTypeDeclaration))
            {
                // Return if the generator does not support generics.
                return;
            }
            //</Snippet8>

            CodeNamespace ns = new CodeNamespace("DemoNamespace");
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            cu.Namespaces.Add(ns);

            // Declare a generic class.
            CodeTypeDeclaration class1 = new CodeTypeDeclaration();
            class1.Name = "MyDictionary";
            class1.BaseTypes.Add(new CodeTypeReference("Dictionary",
                                      new CodeTypeReference[] {
                                          new CodeTypeReference("TKey"),    
                                          new CodeTypeReference("TValue"),    
                                     }));
            //<Snippet2>
            //<Snippet10>
            CodeTypeParameter kType = new CodeTypeParameter("TKey");
            //</Snippet2>
            //<Snippet3>
            kType.HasConstructorConstraint = true;
            //</Snippet3>
            //<Snippet4>
            kType.Constraints.Add(new CodeTypeReference(typeof(IComparable)));
            //</Snippet4>
            //<Snippet5>
            kType.CustomAttributes.Add(new CodeAttributeDeclaration(
                "System.ComponentModel.DescriptionAttribute",
                    new CodeAttributeArgument(new CodePrimitiveExpression("KeyType"))));
            //</Snippet5>

            CodeTypeReference iComparableT = new CodeTypeReference("IComparable");
            iComparableT.TypeArguments.Add(new CodeTypeReference(kType));

            kType.Constraints.Add(iComparableT);

            CodeTypeParameter vType = new CodeTypeParameter("TValue");
            vType.Constraints.Add(new CodeTypeReference(typeof(IList<System.String>)));
            vType.CustomAttributes.Add(new CodeAttributeDeclaration(
                "System.ComponentModel.DescriptionAttribute",
                    new CodeAttributeArgument(new CodePrimitiveExpression("ValueType"))));

            class1.TypeParameters.Add(kType);
            class1.TypeParameters.Add(vType);
            //</Snippet10>

            ns.Types.Add(class1);

            //<Snippet6>
            // Declare a generic method.
            CodeMemberMethod printMethod = new CodeMemberMethod();
            CodeTypeParameter sType = new CodeTypeParameter("S");
            sType.HasConstructorConstraint = true;
            CodeTypeParameter tType = new CodeTypeParameter("T");
            sType.HasConstructorConstraint = true;

            printMethod.Name = "Print";
            printMethod.TypeParameters.Add(sType);
            printMethod.TypeParameters.Add(tType);

            //</Snippet6>
            //<Snippet7>
            printMethod.Statements.Add(ConsoleWriteLineStatement(
                new CodeDefaultValueExpression(new CodeTypeReference("T"))));
            printMethod.Statements.Add(ConsoleWriteLineStatement(
                new CodeDefaultValueExpression(new CodeTypeReference("S"))));
            //</Snippet7>

            printMethod.Attributes = MemberAttributes.Public;
            class1.Members.Add(printMethod);

            CodeTypeDeclaration class2 = new CodeTypeDeclaration();
            class2.Name = "Demo";

            CodeEntryPointMethod methodMain = new CodeEntryPointMethod();

            CodeTypeReference myClass = new CodeTypeReference(
                "MyDictionary",
                new CodeTypeReference[] {
                    new CodeTypeReference(typeof(int)),
                    new CodeTypeReference("List", 
                       new CodeTypeReference[] 
                            {new CodeTypeReference("System.String") })});

            methodMain.Statements.Add(
                  new CodeVariableDeclarationStatement(myClass,
                      "dict",
                          new CodeObjectCreateExpression(myClass)));

            methodMain.Statements.Add(ConsoleWriteLineStatement(
                new CodePropertyReferenceExpression(
                      new CodeVariableReferenceExpression("dict"),
                            "Count")));

//<Snippet9>
            methodMain.Statements.Add(new CodeExpressionStatement(
                 new CodeMethodInvokeExpression(
                      new CodeMethodReferenceExpression(
                         new CodeVariableReferenceExpression("dict"),
                             "Print",
                                 new CodeTypeReference[] {
                                    new CodeTypeReference("System.Decimal"),
                                       new CodeTypeReference("System.Int32"),}),
                                           new CodeExpression[0])));

//</Snippet9>
            string dictionaryTypeName = typeof(System.Collections.Generic.Dictionary<int,
                System.Collections.Generic.List<string>>[]).FullName;

            CodeTypeReference dictionaryType = new CodeTypeReference(dictionaryTypeName);
            methodMain.Statements.Add(
                  new CodeVariableDeclarationStatement(dictionaryType, "dict2",
                     new CodeArrayCreateExpression(dictionaryType, new CodeExpression[1] { new CodePrimitiveExpression(null) })));

            methodMain.Statements.Add(ConsoleWriteLineStatement(
                           new CodePropertyReferenceExpression(
                                new CodeVariableReferenceExpression("dict2"),
                                        "Length")));

            class2.Members.Add(methodMain);
            ns.Types.Add(class2);

        }

        static CodeStatement ConsoleWriteLineStatement(CodeExpression exp)
        {
            return new CodeExpressionStatement(
                new CodeMethodInvokeExpression(
                   new CodeMethodReferenceExpression(
                       new CodeTypeReferenceExpression(new CodeTypeReference("Console")),
                           "WriteLine"),
                               new CodeExpression[]{
                                   exp,
                                     }));
        }

        static CodeStatement ConsoleWriteLineStatement(string text)
        {
            return ConsoleWriteLineStatement(new CodePrimitiveExpression(text));
        }
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
// This example generates the following code:
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version omitted for demo
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//namespace DemoNamespace
//{
//    using System;
//    using System.Collections.Generic;


//    public class MyDictionary<[System.ComponentModel.DescriptionAttribute("KeyType")]  TKey,
//          [System.ComponentModel.DescriptionAttribute("ValueType")]  TValue> : Dictionary<TKey, TValue>
//        where TKey : System.IComparable, IComparable<TKey>, new()
//        where TValue : System.Collections.Generic.IList<string>
//    {

//        public virtual void Print<S, T>()
//            where S : new()
//        {
//            Console.WriteLine(default(T));
//            Console.WriteLine(default(S));
//        }
//    }

//    public class Demo
//    {

//        public static void Main()
//        {
//            MyDictionary<int, List<string>> dict = new MyDictionary<int, List<string>>();
//            Console.WriteLine(dict.Count);
//            dict.Print<decimal, int>();
//            System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>>[] dict2 =
//              new System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>>[] { null };
//            Console.WriteLine(dict2.Length);
//        }
//    }
//}

//</Snippet1>

