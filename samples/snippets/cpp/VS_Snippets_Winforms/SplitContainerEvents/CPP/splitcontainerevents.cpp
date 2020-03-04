

// <snippet1>
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
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::SplitContainer^ splitContainer1;

public:

   // Create an empty Windows form.
   Form1()
   {
      InitializeComponent();
   }


private:
   void InitializeComponent()
   {
      splitContainer1 = gcnew System::Windows::Forms::SplitContainer;
      splitContainer1->SuspendLayout();
      SuspendLayout();
      
      // Place a basic SplitContainer control onto Form1.
      splitContainer1->Dock = System::Windows::Forms::DockStyle::Fill;
      splitContainer1->Location = System::Drawing::Point( 0, 0 );
      splitContainer1->Name = "splitContainer1";
      splitContainer1->Size = System::Drawing::Size( 292, 273 );
      splitContainer1->SplitterDistance = 52;
      splitContainer1->SplitterWidth = 6;
      splitContainer1->TabIndex = 0;
      splitContainer1->Text = "splitContainer1";
      
      // Add the event handler for the SplitterMoved event.
      splitContainer1->SplitterMoved += gcnew System::Windows::Forms::SplitterEventHandler( this, &Form1::splitContainer1_SplitterMoved );
      
      // Add the event handler for the SplitterMoving event.
      splitContainer1->SplitterMoving += gcnew System::Windows::Forms::SplitterCancelEventHandler( this, &Form1::splitContainer1_SplitterMoving );
      
      // This is the left panel of the vertical SplitContainer control.
      splitContainer1->Panel1->Name = "splitterPanel1";
      
      // This is the right panel of the vertical SplitContainer control.
      splitContainer1->Panel2->Name = "splitterPanel2";
      
      // Lay out the basic properties of the form.
      ClientSize = System::Drawing::Size( 292, 273 );
      Controls->Add( splitContainer1 );
      Name = "Form1";
      Text = "Form1";
      splitContainer1->ResumeLayout( false );
      ResumeLayout( false );
   }

   void splitContainer1_SplitterMoved( System::Object^ /*sender*/, System::Windows::Forms::SplitterEventArgs^ /*e*/ )
   {
      
      // Define what happens when the splitter is no longer moving.
      ::Cursor::Current = System::Windows::Forms::Cursors::Default;
   }

   void splitContainer1_SplitterMoving( System::Object^ /*sender*/, System::Windows::Forms::SplitterCancelEventArgs ^ /*e*/ )
   {
      
      // Define what happens while the splitter is moving.
      ::Cursor::Current = System::Windows::Forms::Cursors::NoMoveVert;
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
