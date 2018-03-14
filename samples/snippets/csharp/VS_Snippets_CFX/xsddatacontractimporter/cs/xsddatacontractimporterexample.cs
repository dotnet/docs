//<snippet0>
using System;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Globalization;

namespace XsdContractImporterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlSchemaSet schemas = Export();
                CodeCompileUnit ccu = Import(schemas);
                CompileCode(ccu, "Person.cs");
                CompileCode(ccu, "Person.vb");
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press <Enter> to end....");
                Console.ReadLine();
            }

        }

        static XmlSchemaSet Export()
        {
            XsdDataContractExporter ex = new XsdDataContractExporter();
            ex.Export(typeof(Person));
            return ex.Schemas;
        }
        //<snippet2>
        //<snippet3>
        static CodeCompileUnit Import(XmlSchemaSet schemas)
        {

            XsdDataContractImporter imp = new XsdDataContractImporter();

            // The EnableDataBinding option adds a RaisePropertyChanged method to
            // the generated code. The GenerateInternal causes code access to be
            // set to internal.
            ImportOptions iOptions = new ImportOptions();
            iOptions.EnableDataBinding = true;
            iOptions.GenerateInternal = true;
            imp.Options = iOptions;


            if (imp.CanImport(schemas))
            {
                imp.Import(schemas);
                return imp.CodeCompileUnit;
            }
            else
                return null;
        }
        //</snippet2>
        //</snippet3>
        //<snippet1>
        static void CompileCode(CodeCompileUnit ccu, string sourceName)
        {
            CodeDomProvider provider = null;
            FileInfo sourceFile = new FileInfo(sourceName);
            // Select the code provider based on the input file extension, either C# or Visual Basic.
            if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".CS")
            {
                provider = new Microsoft.CSharp.CSharpCodeProvider();
            }
            else if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".VB")
            {
                provider = new Microsoft.VisualBasic.VBCodeProvider();
            }
            else
            {
                Console.WriteLine("Source file must have a .cs or .vb extension");
            }
            if (provider != null)
            {
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                // Set code formatting options to your preference.
                options.BlankLinesBetweenMembers = true;
                options.BracingStyle = "C";

                StreamWriter sw = new StreamWriter(sourceName);
                provider.GenerateCodeFromCompileUnit(ccu, sw, options);
                sw.Close();
            }
        }
        //</snippet1>
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        public Person(string newFName, string newLName)
        {
            FirstName = newFName;
            LastName = newLName;
        }
    }
}
//</snippet0>