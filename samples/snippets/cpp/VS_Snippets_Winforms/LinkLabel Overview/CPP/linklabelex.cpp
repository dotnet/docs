#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
///        Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   ///        Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

   // <Snippet1>
   // Create a new LinkLabel control.
private:
   LinkLabel^ linkLabel1;

public:
   void InitializeMyLinkLabel()
   {
      // Set the control to autosize based on the text content.
      linkLabel1->AutoSize = true;

      // Position and size the control on the form.
      linkLabel1->Location = System::Drawing::Point( 8, 16 );
      linkLabel1->Size = System::Drawing::Size( 135, 13 );

      // Set the text to display in the label.
      linkLabel1->Text = "Click here to get more info.";

      // Create a new link using the Add method of the LinkCollection class.
      linkLabel1->Links->Add( 6, 4, "www.microsoft.com" );

      // Create an event handler for the LinkClicked event.
      linkLabel1->LinkClicked += gcnew System::Windows::Forms::LinkLabelLinkClickedEventHandler( this, &Form1::linkLabel1_LinkClicked );

      // Add the control to the form.
      this->Controls->Add( linkLabel1 );
   }

private:
   void linkLabel1_LinkClicked( Object^ /*sender*/, System::Windows::Forms::LinkLabelLinkClickedEventArgs^ e )
   {
      // Determine which link was clicked within the LinkLabel.
      linkLabel1->Links[ linkLabel1->Links->IndexOf( e->Link ) ]->Visited = true;

      // Display the appropriate link based on the value of the LinkData property of the Link object.
      System::Diagnostics::Process::Start( e->Link->LinkData->ToString() );
   }
   // </Snippet1>

public:
   Form1()
   {
      linkLabel1 = gcnew LinkLabel;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      InitializeMyLinkLabel();
   }

public:

   /// <summary>
   ///        Clean up any resources being used.
   /// </summary>
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   ///        Required method for Designer support - do not modify
   ///        the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }
};

/// <summary>
///     The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
