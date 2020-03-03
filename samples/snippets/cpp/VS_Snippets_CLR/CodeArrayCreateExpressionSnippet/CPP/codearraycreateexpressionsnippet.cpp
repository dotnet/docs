// <Snippet3>
#using <Microsoft.JScript.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::IO;
using namespace Microsoft::CSharp;
using namespace Microsoft::VisualBasic;
using namespace Microsoft::JScript;

/// <summary>
/// Provides a wrapper for CodeDOM samples.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::CodeDom::CodeCompileUnit^ cu;
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::GroupBox^ groupBox1;
   System::Windows::Forms::RadioButton^ radioButton1;
   System::Windows::Forms::RadioButton^ radioButton2;
   System::Windows::Forms::RadioButton^ radioButton3;
   int language;
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      language = 1; // 1 = Csharp 2 = VB 3 = JScript
      components = nullptr;
      InitializeComponent();
      cu = CreateGraph();
   }

   // <Snippet2>
public:
   CodeCompileUnit^ CreateGraph()
   {
      // Create a compile unit to contain a CodeDOM graph
      CodeCompileUnit^ cu = gcnew CodeCompileUnit;

      // Create a namespace named "TestSpace"
      CodeNamespace^ cn = gcnew CodeNamespace( "TestSpace" );

      // Create a new type named "TestClass"    
      CodeTypeDeclaration^ cd = gcnew CodeTypeDeclaration( "TestClass" );

      // Create a new entry point method
      CodeEntryPointMethod^ cm = gcnew CodeEntryPointMethod;

      // <Snippet1>            
      // Create an initialization expression for a new array of type Int32 with 10 indices
      CodeArrayCreateExpression^ ca1 = gcnew CodeArrayCreateExpression( "System.Int32",10 );

      // Declare an array of type Int32, using the CodeArrayCreateExpression ca1 as the initialization expression
      CodeVariableDeclarationStatement^ cv1 = gcnew CodeVariableDeclarationStatement( "System.Int32[]","x",ca1 );

      // A C# code generator produces the following source code for the preceeding example code:
      // int[] x = new int[10];
      // </Snippet1>

      // Add the variable declaration and initialization statement to the entry point method
      cm->Statements->Add( cv1 );

      // Add the entry point method to the "TestClass" type
      cd->Members->Add( cm );

      // Add the "TestClass" type to the namespace
      cn->Types->Add( cd );

      // Add the "TestSpace" namespace to the compile unit
      cu->Namespaces->Add( cn );
      return cu;
   }
   // </Snippet2>

private:
   void OutputGraph()
   {
      // Create string writer to output to textbox
      StringWriter^ sw = gcnew StringWriter;

      // Create appropriate CodeProvider
      System::CodeDom::Compiler::CodeDomProvider^ cp;
      switch ( language )
      {
         case 2:
            // VB
            cp = CodeDomProvider::CreateProvider("VisualBasic");
            break;

         case 3:
            // JScript
            cp = CodeDomProvider::CreateProvider("JScript");
            break;

         default:
            // CSharp
            cp = CodeDomProvider::CreateProvider("CSharp");
            break;
      }

      // Create a code generator that will output to the string writer
      ICodeGenerator^ cg = cp->CreateGenerator( sw );

      // Generate code from the compile unit and outputs it to the string writer
      cg->GenerateCodeFromCompileUnit( cu, sw, gcnew CodeGeneratorOptions );

      // Output the contents of the string writer to the textbox    
      this->textBox1->Text = sw->ToString();
   }

public:
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->groupBox1 = gcnew System::Windows::Forms::GroupBox;
      this->radioButton1 = gcnew System::Windows::Forms::RadioButton;
      this->radioButton2 = gcnew System::Windows::Forms::RadioButton;
      this->radioButton3 = gcnew System::Windows::Forms::RadioButton;
      this->groupBox1->SuspendLayout();
      this->SuspendLayout();

      // 
      // textBox1
      // 
      this->textBox1->Location = System::Drawing::Point( 16, 112 );
      this->textBox1->Multiline = true;
      this->textBox1->Name = "textBox1";
      this->textBox1->ScrollBars = System::Windows::Forms::ScrollBars::Both;
      this->textBox1->Size = System::Drawing::Size( 664, 248 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "";
      this->textBox1->WordWrap = false;

      // 
      // button1
      // 
      this->button1->BackColor = System::Drawing::Color::Aquamarine;
      this->button1->Location = System::Drawing::Point( 16, 16 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "Generate";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // button2
      // 
      this->button2->BackColor = System::Drawing::Color::MediumTurquoise;
      this->button2->Location = System::Drawing::Point( 112, 16 );
      this->button2->Name = "button2";
      this->button2->TabIndex = 2;
      this->button2->Text = "Show Code";
      this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );

      // 
      // groupBox1
      // 
      array<System::Windows::Forms::Control^>^temp0 = {this->radioButton3,this->radioButton2,this->radioButton1};
      this->groupBox1->Controls->AddRange( temp0 );
      this->groupBox1->Location = System::Drawing::Point( 16, 48 );
      this->groupBox1->Name = "groupBox1";
      this->groupBox1->Size = System::Drawing::Size( 384, 56 );
      this->groupBox1->TabIndex = 3;
      this->groupBox1->TabStop = false;
      this->groupBox1->Text = "Language selection";

      // 
      // radioButton1
      // 
      this->radioButton1->Checked = true;
      this->radioButton1->Location = System::Drawing::Point( 16, 24 );
      this->radioButton1->Name = "radioButton1";
      this->radioButton1->TabIndex = 0;
      this->radioButton1->TabStop = true;
      this->radioButton1->Text = "CSharp";
      this->radioButton1->Click += gcnew System::EventHandler( this, &Form1::radioButton1_CheckedChanged );

      // 
      // radioButton2
      // 
      this->radioButton2->Location = System::Drawing::Point( 144, 24 );
      this->radioButton2->Name = "radioButton2";
      this->radioButton2->TabIndex = 1;
      this->radioButton2->Text = "Visual Basic";
      this->radioButton2->Click += gcnew System::EventHandler( this, &Form1::radioButton2_CheckedChanged );

      // 
      // radioButton3
      // 
      this->radioButton3->Location = System::Drawing::Point( 272, 24 );
      this->radioButton3->Name = "radioButton3";
      this->radioButton3->TabIndex = 2;
      this->radioButton3->Text = "JScript";
      this->radioButton3->Click += gcnew System::EventHandler( this, &Form1::radioButton3_CheckedChanged );

      // 
      // Form1
      // 
      this->AutoScaleBaseSize = System::Drawing::Size( 5, 13 );
      this->ClientSize = System::Drawing::Size( 714, 367 );
      array<System::Windows::Forms::Control^>^temp1 = {this->groupBox1,this->button2,this->button1,this->textBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "CodeDOM Samples Framework";
      this->groupBox1->ResumeLayout( false );
      this->ResumeLayout( false );
   }

   void ShowCode()
   {
      this->textBox1->Text = "";
   }

   // Show code button
   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ShowCode();
   }

   // Generate and show code button
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      OutputGraph();
   }

   // Csharp language selection button
   void radioButton1_CheckedChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      radioButton1->Checked = true;
      radioButton2->Checked = false;
      radioButton3->Checked = false;
      language = 1;
   }

   // Visual Basic language selection button
   void radioButton2_CheckedChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      radioButton1->Checked = false;
      radioButton2->Checked = true;
      radioButton3->Checked = false;
      language = 2;
   }

   // JScript language selection button
   void radioButton3_CheckedChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      radioButton1->Checked = false;
      radioButton2->Checked = false;
      radioButton3->Checked = true;
      language = 3;
   }

};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
// </Snippet3>
