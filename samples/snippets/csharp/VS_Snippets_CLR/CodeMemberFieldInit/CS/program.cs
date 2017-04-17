//<Snippet1>
using System;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace SampleCodeDom
{
    /// <summary>
    /// This code example creates a graph using a CodeCompileUnit and  
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    class Sample
    {
        /// <summary>
        /// Define the compile unit to use for code generation. 
        /// </summary>
        CodeCompileUnit targetUnit;

        /// <summary>
        /// The only class in the compile unit. 
        /// </summary>
        CodeTypeDeclaration targetClass;

        /// <summary>
        /// The name of the file to contain the source code.
        /// </summary>
        private const string outputFileName = "SampleCode.cs";

        /// <summary>
        /// Define the class.
        /// </summary>
        public Sample()
        {
            targetUnit = new CodeCompileUnit();
            CodeNamespace samples = new CodeNamespace("CodeDOMSample");
            samples.Imports.Add(new CodeNamespaceImport("System"));
            targetClass = new CodeTypeDeclaration("CodeDOMCreatedClass");
            targetClass.IsClass = true;
            targetClass.TypeAttributes =
                TypeAttributes.Public | TypeAttributes.Sealed;
            samples.Types.Add(targetClass);
            targetUnit.Namespaces.Add(samples);
        }

        /// <summary>
        /// Adds a field to the class.
        /// </summary>
        public void AddField()
        {

            CodeMemberField testField = new CodeMemberField();
            testField.Name = "today";
            testField.Type = new CodeTypeReference(typeof(System.DateTime));
            testField.Attributes = MemberAttributes.Private | MemberAttributes.Static;
            testField.InitExpression =
                new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("System.DateTime"), "Today");

            targetClass.Members.Add(testField);

        }

        /// <summary>
        /// Add a constructor to the class.
        /// </summary>
        public void AddConstructor()
        {
            // Declare the constructor
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;

            targetClass.Members.Add(constructor);
        }

        /// <summary>
        /// Add an entry point to the class.
        /// </summary>
        public void AddEntryPoint()
        {
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeObjectCreateExpression objectCreate =
                new CodeObjectCreateExpression(
                new CodeTypeReference("CodeDOMCreatedClass"));
            // Add the statement:
            // "CodeDOMCreatedClass testClass = 
            //     new CodeDOMCreatedClass();"
            start.Statements.Add(new CodeVariableDeclarationStatement(
                new CodeTypeReference("CodeDOMCreatedClass"), "testClass",
                objectCreate));

            // Creat the expression:
            // "testClass.ToString()"
            CodeMethodInvokeExpression toStringInvoke =
                new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression("today"), "ToString");

            // Add a System.Console.WriteLine statement with the previous 
            // expression as a parameter.
            start.Statements.Add(new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", toStringInvoke));
            targetClass.Members.Add(start);
        }
        /// <summary>
        /// Generate CSharp source code from the compile unit.
        /// </summary>
        /// <param name="filename">Output file name</param>
        public void GenerateCSharpCode(string fileName)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromCompileUnit(
                    targetUnit, sourceWriter, options);
            }
        }

        /// <summary>
        /// Create the CodeDOM graph and generate the code.
        /// </summary>
        static void Main()
        {
            Sample sample = new Sample();
            sample.AddField();
            sample.AddConstructor();
            sample.AddEntryPoint();
            sample.GenerateCSharpCode(outputFileName);
        }
    }
}
// A C# code generator produces the following source code for the preceeding example code:
//namespace CodeDOMSample
//{
//    using System;


//    public sealed class CodeDOMCreatedClass
//    {

//        private static System.DateTime today = System.DateTime.Today;

//        public CodeDOMCreatedClass()
//        {
//        }

//        public static void Main()
//        {
//            CodeDOMCreatedClass testClass = new CodeDOMCreatedClass();
//            System.Console.WriteLine(today.ToString());
//        }
//    }
//}
//</Snippet1>