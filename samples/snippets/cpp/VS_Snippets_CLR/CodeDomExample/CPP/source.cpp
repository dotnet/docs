/*
// CodeDOMExample_CPP.cpp : main project file.

#include "stdafx.h"

using namespace System;

int main(array<System::String ^> ^args)
{
    Console::WriteLine(L"Hello World");
    return 0;
}
*/

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <Microsoft.JScript.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Diagnostics;
using namespace System::Drawing;
using namespace System::IO;
using namespace System::Windows::Forms;
using namespace Microsoft::CSharp;
using namespace Microsoft::VisualBasic;
using namespace Microsoft::JScript;
using namespace System::Security::Permissions;

// This example demonstrates building a Hello World program graph 
// using System.CodeDom elements. It calls code generator and
// code compiler methods to build the program using CSharp, VB, or
// JScript.  A Windows Forms interface is included. Note: Code
// must be compiled and linked with the Microsoft.JScript assembly. 
namespace CodeDOMExample
{
    [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
    public ref class CodeDomExample
    {
    public:
        //<Snippet2>
        // Build a Hello World program graph using 
        // System::CodeDom types.
        static CodeCompileUnit^ BuildHelloWorldGraph()
        {
            // Create a new CodeCompileUnit to contain 
            // the program graph.
            CodeCompileUnit^ compileUnit = gcnew CodeCompileUnit;

            // Declare a new namespace called Samples.
            CodeNamespace^ samples = gcnew CodeNamespace( "Samples" );

            // Add the new namespace to the compile unit.
            compileUnit->Namespaces->Add( samples );

            // Add the new namespace import for the System namespace.
            samples->Imports->Add( gcnew CodeNamespaceImport( "System" ) );

            // Declare a new type called Class1.
            CodeTypeDeclaration^ class1 = gcnew CodeTypeDeclaration( "Class1" );

            // Add the new type to the namespace's type collection.
            samples->Types->Add( class1 );

            // Declare a new code entry point method.
            CodeEntryPointMethod^ start = gcnew CodeEntryPointMethod;

            // Create a type reference for the System::Console class.
            CodeTypeReferenceExpression^ csSystemConsoleType = gcnew CodeTypeReferenceExpression( "System.Console" );

            // Build a Console::WriteLine statement.
            CodeMethodInvokeExpression^ cs1 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine", gcnew CodePrimitiveExpression("Hello World!") );

            // Add the WriteLine call to the statement collection.
            start->Statements->Add( cs1 );

            // Build another Console::WriteLine statement.
            CodeMethodInvokeExpression^ cs2 = gcnew CodeMethodInvokeExpression( csSystemConsoleType,"WriteLine", gcnew CodePrimitiveExpression( "Press the Enter key to continue." ) );

            // Add the WriteLine call to the statement collection.
            start->Statements->Add( cs2 );

            // Build a call to System::Console::ReadLine.
            CodeMethodReferenceExpression^ csReadLine = gcnew CodeMethodReferenceExpression( csSystemConsoleType, "ReadLine" );
            CodeMethodInvokeExpression^ cs3 = gcnew CodeMethodInvokeExpression( csReadLine, gcnew array<CodeExpression^>(0) );

            // Add the ReadLine statement.
            start->Statements->Add( cs3 );

            // Add the code entry point method to
            // the Members collection of the type.
            class1->Members->Add( start );
            return compileUnit;
        }
        //</Snippet2>

        //<Snippet3>
        static void GenerateCode( CodeDomProvider^ provider, CodeCompileUnit^ compileunit )
        {
            // Build the source file name with the appropriate
            // language extension.
            String^ sourceFile;
            if ( provider->FileExtension->StartsWith( "." ) )
            {
                sourceFile = String::Concat( "TestGraph", provider->FileExtension );
            }
            else
            {
                sourceFile = String::Concat( "TestGraph.", provider->FileExtension );
            }

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            IndentedTextWriter^ tw = gcnew IndentedTextWriter( gcnew StreamWriter( sourceFile,false ),"    " );

            // Generate source code using the code generator.
            provider->GenerateCodeFromCompileUnit( compileunit, tw, gcnew CodeGeneratorOptions );

            // Close the output file.
            tw->Close();
        }
        //</Snippet3>

        //<Snippet4>
        static CompilerResults^ CompileCode( CodeDomProvider^ provider, String^ sourceFile, String^ exeFile )
        {
            // Configure a CompilerParameters that links System.dll
            // and produces the specified executable file.
            array<String^>^referenceAssemblies = {"System.dll"};
            CompilerParameters^ cp = gcnew CompilerParameters( referenceAssemblies,exeFile,false );

            // Generate an executable rather than a DLL file.
            cp->GenerateExecutable = true;

            // Invoke compilation.
            CompilerResults^ cr = provider->CompileAssemblyFromFile( cp, sourceFile );

            // Return the results of compilation.
            return cr;
        }
        //</Snippet4>
    };

    public ref class CodeDomExampleForm: public System::Windows::Forms::Form
    {
    private:
        static System::Windows::Forms::Button^ run_button = gcnew System::Windows::Forms::Button;
        static System::Windows::Forms::Button^ compile_button = gcnew System::Windows::Forms::Button;
        static System::Windows::Forms::Button^ generate_button = gcnew System::Windows::Forms::Button;
        static System::Windows::Forms::TextBox^ textBox1 = gcnew System::Windows::Forms::TextBox;
        static System::Windows::Forms::ComboBox^ comboBox1 = gcnew System::Windows::Forms::ComboBox;
        static System::Windows::Forms::Label^ label1 = gcnew System::Windows::Forms::Label;
        void generate_button_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
        {
            CodeDomProvider^ provider = GetCurrentProvider();
            CodeDomExample::GenerateCode( provider, CodeDomExample::BuildHelloWorldGraph() );

            // Build the source file name with the appropriate
            // language extension.
            String^ sourceFile;
            if ( provider->FileExtension->StartsWith( "." ) )
            {
                sourceFile = String::Concat( "TestGraph", provider->FileExtension );
            }
            else
            {
                sourceFile = String::Concat( "TestGraph.", provider->FileExtension );
            }


            // Read in the generated source file and
            // display the source text.
            StreamReader^ sr = gcnew StreamReader( sourceFile );
            textBox1->Text = sr->ReadToEnd();
            sr->Close();
        }

        CodeDomProvider^ GetCurrentProvider()
        {
            CodeDomProvider^ provider;
            if ( String::Compare( dynamic_cast<String^>(this->comboBox1->SelectedItem), "CSharp" ) == 0 )
                provider = CodeDomProvider::CreateProvider("CSharp");
            else
                if ( String::Compare( dynamic_cast<String^>(this->comboBox1->SelectedItem), "Visual Basic" ) == 0 )
                    provider = CodeDomProvider::CreateProvider("VisualBasic");
                else
                    if ( String::Compare( dynamic_cast<String^>(this->comboBox1->SelectedItem), "JScript" ) == 0 )
                        provider = CodeDomProvider::CreateProvider("JScript");
                    else
                        provider = CodeDomProvider::CreateProvider("CSharp");

            return provider;
        }

        void compile_button_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
        {
            CodeDomProvider^ provider = GetCurrentProvider();

            // Build the source file name with the appropriate
            // language extension.
            String^ sourceFile = String::Concat( "TestGraph.", provider->FileExtension );

            // Compile the source file into an executable output file.
            CompilerResults^ cr = CodeDomExample::CompileCode( provider, sourceFile, "TestGraph.exe" );
            if ( cr->Errors->Count > 0 )
            {
                // Display compilation errors.
                textBox1->Text = String::Concat( "Errors encountered while building ", sourceFile, " into ", cr->PathToAssembly, ": \r\n\n" );
                System::CodeDom::Compiler::CompilerError^ ce;
                for ( int i = 0; i < cr->Errors->Count; i++ )
                {
                    ce = cr->Errors[i];
                    textBox1->AppendText( String::Concat( ce->ToString(), "\r\n" ) );

                }
                run_button->Enabled = false;
            }
            else
            {
                textBox1->Text = String::Concat( "Source ", sourceFile, " built into ", cr->PathToAssembly, " with no errors." );
                run_button->Enabled = true;
            }
        }

        void run_button_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
        {
            Process::Start( "TestGraph.exe" );
        }

    public:
        CodeDomExampleForm()
        {
            this->SuspendLayout();

            // Set properties for label1.
            this->label1->Location = System::Drawing::Point( 395, 20 );
            this->label1->Size = System::Drawing::Size( 180, 22 );
            this->label1->Text = "Select a programming language:";

            // Set properties for comboBox1.
            this->comboBox1->Location = System::Drawing::Point( 560, 16 );
            this->comboBox1->Size = System::Drawing::Size( 190, 23 );
            this->comboBox1->Name = "comboBox1";
            array<String^>^temp1 = {"CSharp","Visual Basic","JScript"};
            this->comboBox1->Items->AddRange( temp1 );
            this->comboBox1->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right | System::Windows::Forms::AnchorStyles::Top);
            this->comboBox1->SelectedIndex = 0;

            // Set properties for generate_button.
            this->generate_button->Location = System::Drawing::Point( 8, 16 );
            this->generate_button->Name = "generate_button";
            this->generate_button->Size = System::Drawing::Size( 120, 23 );
            this->generate_button->Text = "Generate Code";
            this->generate_button->Click += gcnew System::EventHandler( this, &CodeDomExampleForm::generate_button_Click );

            // Set properties for compile_button.
            this->compile_button->Location = System::Drawing::Point( 136, 16 );
            this->compile_button->Name = "compile_button";
            this->compile_button->Size = System::Drawing::Size( 120, 23 );
            this->compile_button->Text = "Compile";
            this->compile_button->Click += gcnew System::EventHandler( this, &CodeDomExampleForm::compile_button_Click );

            // Set properties for run_button.
            this->run_button->Enabled = false;
            this->run_button->Location = System::Drawing::Point( 264, 16 );
            this->run_button->Name = "run_button";
            this->run_button->Size = System::Drawing::Size( 120, 23 );
            this->run_button->Text = "Run";
            this->run_button->Click += gcnew System::EventHandler( this, &CodeDomExampleForm::run_button_Click );

            // Set properties for textBox1.
            this->textBox1->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
            this->textBox1->Location = System::Drawing::Point( 8, 48 );
            this->textBox1->Multiline = true;
            this->textBox1->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
            this->textBox1->Name = "textBox1";
            this->textBox1->Size = System::Drawing::Size( 744, 280 );
            this->textBox1->Text = "";

            // Set properties for the CodeDomExampleForm.
            this->AutoScaleBaseSize = System::Drawing::Size( 5, 13 );
            this->ClientSize = System::Drawing::Size( 768, 340 );
            this->MinimumSize = System::Drawing::Size( 750, 340 );
            array<System::Windows::Forms::Control^>^myControl = {this->textBox1,this->run_button,this->compile_button,this->generate_button,this->comboBox1,this->label1};
            this->Controls->AddRange( myControl );
            this->Name = "CodeDomExampleForm";
            this->Text = "CodeDom Hello World Example";
            this->ResumeLayout( false );
        }

    public:
        ~CodeDomExampleForm()
        {
        }
    };

}

[STAThread]
int main()
{
    Application::Run( gcnew CodeDOMExample::CodeDomExampleForm );
}
//</Snippet1>
