

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

public ref class ByteViewerForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::ComponentModel::Design::ByteViewer^ byteviewer;

public:
   ByteViewerForm()
   {
      // Initialize the controls other than the ByteViewer.
      InitializeForm();
      
      // Initialize the ByteViewer.
      byteviewer = gcnew ByteViewer;
      byteviewer->Location = Point(8,46);
      byteviewer->Size = System::Drawing::Size( 600, 338 );
      byteviewer->Anchor = static_cast<AnchorStyles>(AnchorStyles::Left | AnchorStyles::Bottom | AnchorStyles::Top);
      byteviewer->SetBytes( (array<Byte>^)Array::CreateInstance( Byte::typeid, 0 ) );
      this->Controls->Add( byteviewer );
   }

private:

   // Show a file selection dialog and cues the byte viewer to 
   // load the data in a selected file.
   void loadBytesFromFile( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      OpenFileDialog^ ofd = gcnew OpenFileDialog;
      if ( ofd->ShowDialog() != ::DialogResult::OK )
            return;

      byteviewer->SetFile( ofd->FileName );
   }

   // Clear the bytes in the byte viewer.
   void clearBytes( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      byteviewer->SetBytes( (array<Byte>^)Array::CreateInstance( Byte::typeid, 0 ) );
   }

   // Changes the display mode of the byte viewer according to the 
   // Text property of the RadioButton sender control.
   void changeByteMode( Object^ sender, EventArgs^ /*e*/ )
   {
      System::Windows::Forms::RadioButton^ rbutton = dynamic_cast<System::Windows::Forms::RadioButton^>(sender);
      DisplayMode mode;
      if ( rbutton->Text->Equals( "ANSI" ) )
      {
         mode = DisplayMode::Ansi;
      }
      else
      if ( rbutton->Text->Equals( "Hex" ) )
      {
         mode = DisplayMode::Hexdump;
      }
      else
      if ( rbutton->Text->Equals( "Unicode" ) )
      {
         mode = DisplayMode::Unicode;
      }
      else
      {
         mode = DisplayMode::Auto;
      }

      // Sets the display mode.
      byteviewer->SetDisplayMode( mode );
   }

   void InitializeForm()
   {
      this->SuspendLayout();
      this->ClientSize = System::Drawing::Size( 680, 440 );
      this->MinimumSize = System::Drawing::Size( 660, 400 );
      this->Size = System::Drawing::Size( 680, 440 );
      this->Name = "Byte Viewer Form";
      this->Text = "Byte Viewer Form";
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button1->Location = System::Drawing::Point( 8, 8 );
      this->button1->Size = System::Drawing::Size( 190, 23 );
      this->button1->Name = "button1";
      this->button1->Text = "Set Bytes From File...";
      this->button1->TabIndex = 0;
      this->button1->Click += gcnew EventHandler( this, &ByteViewerForm::loadBytesFromFile );
      this->Controls->Add( this->button1 );
      this->button2 = gcnew System::Windows::Forms::Button;
      this->button2->Location = System::Drawing::Point( 198, 8 );
      this->button2->Size = System::Drawing::Size( 190, 23 );
      this->button2->Name = "button2";
      this->button2->Text = "Clear Bytes";
      this->button2->Click += gcnew EventHandler( this, &ByteViewerForm::clearBytes );
      this->button2->TabIndex = 1;
      this->Controls->Add( this->button2 );
      System::Windows::Forms::GroupBox^ group = gcnew System::Windows::Forms::GroupBox;
      group->Location = Point(418,3);
      group->Size = System::Drawing::Size( 220, 36 );
      group->Text = "Display Mode";
      this->Controls->Add( group );
      System::Windows::Forms::RadioButton^ rbutton1 = gcnew System::Windows::Forms::RadioButton;
      rbutton1->Location = Point(6,15);
      rbutton1->Size = System::Drawing::Size( 46, 16 );
      rbutton1->Text = "Auto";
      rbutton1->Checked = true;
      rbutton1->Click += gcnew EventHandler( this, &ByteViewerForm::changeByteMode );
      group->Controls->Add( rbutton1 );
      System::Windows::Forms::RadioButton^ rbutton2 = gcnew System::Windows::Forms::RadioButton;
      rbutton2->Location = Point(54,15);
      rbutton2->Size = System::Drawing::Size( 50, 16 );
      rbutton2->Text = "ANSI";
      rbutton2->Click += gcnew EventHandler( this, &ByteViewerForm::changeByteMode );
      group->Controls->Add( rbutton2 );
      System::Windows::Forms::RadioButton^ rbutton3 = gcnew System::Windows::Forms::RadioButton;
      rbutton3->Location = Point(106,15);
      rbutton3->Size = System::Drawing::Size( 46, 16 );
      rbutton3->Text = "Hex";
      rbutton3->Click += gcnew EventHandler( this, &ByteViewerForm::changeByteMode );
      group->Controls->Add( rbutton3 );
      System::Windows::Forms::RadioButton^ rbutton4 = gcnew System::Windows::Forms::RadioButton;
      rbutton4->Location = Point(152,15);
      rbutton4->Size = System::Drawing::Size( 64, 16 );
      rbutton4->Text = "Unicode";
      rbutton4->Click += gcnew EventHandler( this, &ByteViewerForm::changeByteMode );
      group->Controls->Add( rbutton4 );
      this->ResumeLayout( false );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew ByteViewerForm );
}
//</Snippet1>
