//<Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.JScript;

// This example demonstrates building a Hello World program graph 
// using System.CodeDom elements. It calls code generator and
// code compiler methods to build the program using CSharp, VB, or
// JScript.  A Windows Forms interface is included. Note: Code
// must be compiled and linked with the Microsoft.JScript assembly. 
namespace CodeDOMExample
{
    class CodeDomExample
    {
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
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
            // Add the new type to the namespace type collection.
            samples.Types.Add(class1);

            // Declare a new code entry point method.
            CodeEntryPointMethod start = new CodeEntryPointMethod();

            // Create a type reference for the System.Console class.
            CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");

            // Build a Console.WriteLine statement.
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Hello World!"));

            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1);

            // Build another Console.WriteLine statement.
            CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Press the Enter key to continue."));

            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2);

            // Build a call to System.Console.ReadLine.
            CodeMethodInvokeExpression csReadLine = new CodeMethodInvokeExpression(
                csSystemConsoleType, "ReadLine");

            // Add the ReadLine statement.
            start.Statements.Add(csReadLine);

            // Add the code entry point method to
            // the Members collection of the type.
            class1.Members.Add(start);

            return compileUnit;
        }
        //</Snippet2>

        //<Snippet3>
        public static void GenerateCode(CodeDomProvider provider,
            CodeCompileUnit compileunit)
        {
            // Build the source file name with the appropriate
            // language extension.
            String sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "TestGraph" + provider.FileExtension;
            }
            else
            {
                sourceFile = "TestGraph." + provider.FileExtension;
            }

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(sourceFile, false), "    ");
            // Generate source code using the code generator.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions());
            // Close the output file.
            tw.Close();
        }
        //</Snippet3>

        //<Snippet4>
        public static CompilerResults CompileCode(CodeDomProvider provider,
                                                  String sourceFile,
                                                  String exeFile)
        {
            // Configure a CompilerParameters that links System.dll
            // and produces the specified executable file.
            String[] referenceAssemblies = { "System.dll" };
            CompilerParameters cp = new CompilerParameters(referenceAssemblies,
                                                           exeFile, false);
            // Generate an executable rather than a DLL file.
            cp.GenerateExecutable = true;

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);
            // Return the results of compilation.
            return cr;
        }
        //</Snippet4>
    }

    public class CodeDomExampleForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button run_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button compile_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button generate_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.TextBox textBox1 = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.ComboBox comboBox1 = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();

        private void generate_button_Click(object sender, System.EventArgs e)
        {
            CodeDomProvider provider = GetCurrentProvider();
            CodeDomExample.GenerateCode(provider, CodeDomExample.BuildHelloWorldGraph());

            // Build the source file name with the appropriate
            // language extension.
            String sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "TestGraph" + provider.FileExtension;
            }
            else
            {
                sourceFile = "TestGraph." + provider.FileExtension;
            }

            // Read in the generated source file and
            // display the source text.
            StreamReader sr = new StreamReader(sourceFile);
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void compile_button_Click(object sender, System.EventArgs e)
        {
            CodeDomProvider provider = GetCurrentProvider();

            // Build the source file name with the appropriate
            // language extension.
            String sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "TestGraph" + provider.FileExtension;
            }
            else
            {
                sourceFile = "TestGraph." + provider.FileExtension;
            }

            // Compile the source file into an executable output file.
            CompilerResults cr = CodeDomExample.CompileCode(provider,
                                                            sourceFile,
                                                            "TestGraph.exe");

            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                textBox1.Text = "Errors encountered while building " +
                                sourceFile + " into " + cr.PathToAssembly + ": \r\n\n";
                foreach (CompilerError ce in cr.Errors)
                    textBox1.AppendText(ce.ToString() + "\r\n");
                run_button.Enabled = false;
            }
            else
            {
                textBox1.Text = "Source " + sourceFile + " built into " +
                                cr.PathToAssembly + " with no errors.";
                run_button.Enabled = true;
            }
        }

        private void run_button_Click(object sender,
            System.EventArgs e)
        {
            Process.Start("TestGraph.exe");
        }

        private CodeDomProvider GetCurrentProvider()
        {
            CodeDomProvider provider;
            switch ((string)this.comboBox1.SelectedItem)
            {
                case "CSharp":
                    provider = CodeDomProvider.CreateProvider("CSharp");
                    break;
                case "Visual Basic":
                    provider = CodeDomProvider.CreateProvider("VisualBasic");
                    break;
                case "JScript":
                    provider = CodeDomProvider.CreateProvider("JScript");
                    break;
                default:
                    provider = CodeDomProvider.CreateProvider("CSharp");
                    break;
            }
            return provider;
        }

        public CodeDomExampleForm()
        {
            this.SuspendLayout();
            // Set properties for label1
            this.label1.Location = new System.Drawing.Point(395, 20);
            this.label1.Size = new Size(180, 22);
            this.label1.Text = "Select a programming language:";
            // Set properties for comboBox1
            this.comboBox1.Location = new System.Drawing.Point(560, 16);
            this.comboBox1.Size = new Size(190, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Items.AddRange(new string[] { "CSharp", "Visual Basic", "JScript" });
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
                                    | System.Windows.Forms.AnchorStyles.Right
                                    | System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.SelectedIndex = 0;
            // Set properties for generate_button. 
            this.generate_button.Location = new System.Drawing.Point(8, 16);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(120, 23);
            this.generate_button.Text = "Generate Code";
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // Set properties for compile_button.
            this.compile_button.Location = new System.Drawing.Point(136, 16);
            this.compile_button.Name = "compile_button";
            this.compile_button.Size = new System.Drawing.Size(120, 23);
            this.compile_button.Text = "Compile";
            this.compile_button.Click += new System.EventHandler(this.compile_button_Click);
            // Set properties for run_button.
            this.run_button.Enabled = false;
            this.run_button.Location = new System.Drawing.Point(264, 16);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(120, 23);
            this.run_button.Text = "Run";
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // Set properties for textBox1.        
            this.textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top
                                     | System.Windows.Forms.AnchorStyles.Bottom
                                     | System.Windows.Forms.AnchorStyles.Left
                                     | System.Windows.Forms.AnchorStyles.Right);
            this.textBox1.Location = new System.Drawing.Point(8, 48);
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(744, 280);
            this.textBox1.Text = "";
            // Set properties for the CodeDomExampleForm.
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 340);
            this.MinimumSize = new System.Drawing.Size(750, 340);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.textBox1, 
                this.run_button, this.compile_button, this.generate_button,
                this.comboBox1, this.label1 });
            this.Name = "CodeDomExampleForm";
            this.Text = "CodeDom Hello World Example";
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new CodeDomExampleForm());
        }
    }
}
//</Snippet1>