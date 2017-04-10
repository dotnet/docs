// <Snippet3>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.JScript;

namespace CodeDOMSamples
{
    /// <summary>
    /// Provides a wrapper for CodeDOM samples.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {    
        private System.CodeDom.CodeCompileUnit cu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private int language = 1;    // 1 = Csharp 2 = VB 3 = JScript
        private System.ComponentModel.Container components = null;

        public Form1()
        {            
            InitializeComponent();                    
            
            cu = CreateGraph();
        }

        // <Snippet2>
        public CodeCompileUnit CreateGraph()
        {
            // Create a compile unit to contain a CodeDOM graph
            CodeCompileUnit cu = new CodeCompileUnit();

            // Create a namespace named "TestSpace"
            CodeNamespace cn = new CodeNamespace("TestSpace");        
            
            // Create a new type named "TestClass"    
            CodeTypeDeclaration cd = new CodeTypeDeclaration("TestClass");

            // Create an entry point method
            CodeEntryPointMethod cm = new CodeEntryPointMethod();
                                            
            // Create the initialization expression for an array of type Int32 with 10 indices
            CodeArrayCreateExpression ca1 = new CodeArrayCreateExpression("System.Int32", 10);                        
            
            // Declare an array of type Int32, using the CodeArrayCreateExpression ca1 as the initialization expression
            CodeVariableDeclarationStatement cv1 = new CodeVariableDeclarationStatement("System.Int32[]", "x", ca1);

            // Add the array declaration and initialization statement to the entry point method class member
            cm.Statements.Add(cv1);            
            
            // <Snippet1>
            // Create an array indexer expression that references index 5 of array "x"
            CodeArrayIndexerExpression ci1 = new CodeArrayIndexerExpression(new CodeVariableReferenceExpression("x"), new CodePrimitiveExpression(5));

            // A C# code generator produces the following source code for the preceeding example code:

            // x[5]
            // </Snippet1>

            // Declare a variable of type Int32 and adds it to the entry point method
            CodeVariableDeclarationStatement cv2 = new CodeVariableDeclarationStatement("System.Int32", "y");
            cm.Statements.Add(cv2);

            // Assign the value of the array indexer ci1 to variable "y"
            CodeAssignStatement as1 = new CodeAssignStatement(new CodeVariableReferenceExpression("y"), ci1);
            
            // Add the assignment statement to the entry point method
            cm.Statements.Add(as1);            

            // Add the entry point method to the "TestClass" type
            cd.Members.Add(cm);
            
            // Add the "TestClass" type to the namespace
            cn.Types.Add(cd);

            // Add the "TestSpace" namespace to the compile unit
            cu.Namespaces.Add(cn);

            return cu;
        }
        // </Snippet2>

        private void OutputGraph()
        {
            // Create string writer to output to textbox
            StringWriter sw = new StringWriter();

            // Create appropriate CodeProvider
            System.CodeDom.Compiler.CodeDomProvider cp;
            switch(language)
            {
                case 2: // VB
                    cp = CodeDomProvider.CreateProvider("VisualBasic");
                    break;
                case 3: // JScript
                    cp = CodeDomProvider.CreateProvider("JScript");
                    break;
                default:    // CSharp
                    cp = CodeDomProvider.CreateProvider("CSharp");
                    break;                
            }
            
            // Create a code generator that will output to the string writer
            ICodeGenerator cg = cp.CreateGenerator(sw);        
            
            // Generate code from the compile unit and outputs it to the string writer
            cg.GenerateCodeFromCompileUnit(cu, sw, new CodeGeneratorOptions());

            // Output the contents of the string writer to the textbox    
            this.textBox1.Text = sw.ToString();            
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 112);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(664, 248);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            this.textBox1.WordWrap = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aquamarine;
            this.button1.Location = new System.Drawing.Point(16, 16);
            this.button1.Name = "button1";
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button2.Location = new System.Drawing.Point(112, 16);
            this.button2.Name = "button2";
            this.button2.TabIndex = 2;
            this.button2.Text = "Show Code";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    this.radioButton3,
                                                                                    this.radioButton2,
                                                                                    this.radioButton1});
            this.groupBox1.Location = new System.Drawing.Point(16, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language selection";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "CSharp";
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(144, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Visual Basic";
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(272, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "JScript";
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 367);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.groupBox1,
                                                                          this.button2,
                                                                          this.button1,
                                                                          this.textBox1});
            this.Name = "Form1";
            this.Text = "CodeDOM Samples Framework";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void ShowCode()
        {
            this.textBox1.Text="";
        }

        // Show code button
        private void button2_Click(object sender, System.EventArgs e)
        {
            ShowCode();
        }

        // Generate and show code button
        private void button1_Click(object sender, System.EventArgs e)
        {        
            OutputGraph();
        }

        // Csharp language selection button
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            radioButton1.Checked=true;
            radioButton2.Checked=false;
            radioButton3.Checked=false;

            language=1;
        }

        // Visual Basic language selection button
        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            radioButton1.Checked=false;
            radioButton2.Checked=true;
            radioButton3.Checked=false;

            language=2;
        }

        // JScript language selection button
        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {            
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            radioButton3.Checked=true;

            language=3;
        }            

    }
}
// </Snippet3>