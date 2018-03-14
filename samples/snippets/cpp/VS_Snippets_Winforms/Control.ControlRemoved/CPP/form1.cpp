#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
   }


public:

   /// <summary>
   /// Clean up any resources being used.
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
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 288, 32 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::addControl_Click );
      
      //
      // button2
      //
      this->button2->Location = System::Drawing::Point( 288, 72 );
      this->button2->Name = "button2";
      this->button2->TabIndex = 1;
      this->button2->Text = "button2";
      this->button2->Click += gcnew System::EventHandler( this, &Form1::removeControl_Click );
      
      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 376, 334 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button2,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   //<Snippet1>
   // This example demonstrates the use of the ControlAdded and
   // ControlRemoved events. This example assumes that two Button controls
   // are added to the form and connected to the addControl_Click and
   // removeControl_Click event-handler methods.
private:
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Connect the ControlRemoved and ControlAdded event handlers
      // to the event-handler methods.
      // ControlRemoved and ControlAdded are not available at design time.
      this->ControlRemoved += gcnew System::Windows::Forms::ControlEventHandler( this, &Form1::Control_Removed );
      this->ControlAdded += gcnew System::Windows::Forms::ControlEventHandler( this, &Form1::Control_Added );
   }

   void Control_Added( Object^ /*sender*/, System::Windows::Forms::ControlEventArgs^ e )
   {
      MessageBox::Show( String::Format( "The control named {0} has been added to the form.", e->Control->Name ) );
   }

   void Control_Removed( Object^ /*sender*/, System::Windows::Forms::ControlEventArgs^ e )
   {
      MessageBox::Show( String::Format( "The control named {0} has been removed from the form.", e->Control->Name ) );
   }

   // Click event handler for a Button control. Adds a TextBox to the form.
   void addControl_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create a new TextBox control and add it to the form.
      TextBox^ textBox1 = gcnew TextBox;
      textBox1->Size = System::Drawing::Size( 100, 10 );
      textBox1->Location = Point(10,10);

      // Name the control in order to remove it later. The name must be specified
      // if a control is added at run time.
      textBox1->Name = "textBox1";

      // Add the control to the form's control collection.
      this->Controls->Add( textBox1 );
   }

   // Click event handler for a Button control.
   // Removes the previously added TextBox from the form.
   void removeControl_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Loop through all controls in the form's control collection.
      IEnumerator^ myEnum = this->Controls->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Control^ tempCtrl = safe_cast<Control^>(myEnum->Current);
         
         // Determine whether the control is textBox1,
         // and if it is, remove it.
         if ( tempCtrl->Name->Equals( "textBox1" ) )
         {
            this->Controls->Remove( tempCtrl );
         }
      }
   }
   //</Snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
