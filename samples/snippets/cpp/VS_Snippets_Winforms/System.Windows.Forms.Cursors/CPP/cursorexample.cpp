

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace MCursor
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::ComboBox^ cursorSelectionComboBox;
      System::Windows::Forms::Panel^ testPanel;
      System::Windows::Forms::Label ^ label1;
      System::Windows::Forms::Label ^ label2;
      System::Windows::Forms::ListView^ cursorEventViewer;
      System::Windows::Forms::Label ^ label3;

   public:
      Form1()
      {
         this->cursorSelectionComboBox = gcnew System::Windows::Forms::ComboBox;
         this->testPanel = gcnew System::Windows::Forms::Panel;
         this->label1 = gcnew System::Windows::Forms::Label;
         this->label2 = gcnew System::Windows::Forms::Label;
         this->cursorEventViewer = gcnew System::Windows::Forms::ListView;
         this->label3 = gcnew System::Windows::Forms::Label;
         
         // Select Cursor Label
         this->label2->Location = System::Drawing::Point( 24, 16 );
         this->label2->Size = System::Drawing::Size( 80, 16 );
         this->label2->Text = "Select cursor:";
         
         // Cursor Testing Panel Label
         this->label1->Location = System::Drawing::Point( 24, 80 );
         this->label1->Size = System::Drawing::Size( 144, 23 );
         this->label1->Text = "Cursor testing panel:";
         
         // Cursor Changed Events Label
         this->label3->Location = System::Drawing::Point( 184, 16 );
         this->label3->Size = System::Drawing::Size( 128, 16 );
         this->label3->Text = "Cursor changed events:";
         
         // Cursor Selection ComboBox
         this->cursorSelectionComboBox->Location = System::Drawing::Point( 24, 40 );
         this->cursorSelectionComboBox->Size = System::Drawing::Size( 152, 21 );
         this->cursorSelectionComboBox->TabIndex = 0;
         this->cursorSelectionComboBox->SelectedIndexChanged += gcnew System::EventHandler( this, &Form1::cursorSelectionComboBox_SelectedIndexChanged );
         
         // Cursor Test Panel
         this->testPanel->BackColor = System::Drawing::SystemColors::ControlDark;
         this->testPanel->Location = System::Drawing::Point( 24, 104 );
         this->testPanel->Size = System::Drawing::Size( 152, 160 );
         this->testPanel->CursorChanged += gcnew System::EventHandler( this, &Form1::testPanel_CursorChanged );
         
         // Cursor Event ListView
         this->cursorEventViewer->Location = System::Drawing::Point( 184, 40 );
         this->cursorEventViewer->Size = System::Drawing::Size( 256, 224 );
         this->cursorEventViewer->TabIndex = 4;
         this->cursorEventViewer->View = System::Windows::Forms::View::List;
         
         // Set up how the form should be displayed and add the controls to the form.
         this->ClientSize = System::Drawing::Size( 456, 286 );
         array<System::Windows::Forms::Control^>^temp0 = {this->label3,this->cursorEventViewer,this->label2,this->label1,this->testPanel,this->cursorSelectionComboBox};
         this->Controls->AddRange( temp0 );
         this->Text = "Cursors Example";
         
         // Add all the cursor types to the combobox.
         System::Collections::IEnumerator^ myEnum = CursorList()->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            System::Windows::Forms::Cursor^ cursor = safe_cast<System::Windows::Forms::Cursor^>(myEnum->Current);
            cursorSelectionComboBox->Items->Add( cursor );
         }
      }


   private:
      array<System::Windows::Forms::Cursor^>^ CursorList()
      {
         
         // Make an array of all the types of cursors in Windows Forms.
         array<System::Windows::Forms::Cursor^>^temp1 = {Cursors::AppStarting,Cursors::Arrow,Cursors::Cross,Cursors::Default,Cursors::Hand,Cursors::Help,Cursors::HSplit,Cursors::IBeam,Cursors::No,Cursors::NoMove2D,Cursors::NoMoveHoriz,Cursors::NoMoveVert,Cursors::PanEast,Cursors::PanNE,Cursors::PanNorth,Cursors::PanNW,Cursors::PanSE,Cursors::PanSouth,Cursors::PanSW,Cursors::PanWest,Cursors::SizeAll,Cursors::SizeNESW,Cursors::SizeNS,Cursors::SizeNWSE,Cursors::SizeWE,Cursors::UpArrow,Cursors::VSplit,Cursors::WaitCursor};
         return temp1;
      }

      void cursorSelectionComboBox_SelectedIndexChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         
         // Set the cursor in the test panel to be the selected cursor style.
         testPanel->Cursor = dynamic_cast<System::Windows::Forms::Cursor^>(cursorSelectionComboBox->SelectedItem);
      }

      void testPanel_CursorChanged( Object^ sender, System::EventArgs^ /*e*/ )
      {
         
         // Build up a String* containing the type of Object* sending the event, and the event.
         String^ cursorEvent = String::Format( "[{0}]: {1}", sender->GetType(), "Cursor changed" );
         
         // Record this event in the list view.
         this->cursorEventViewer->Items->Add( cursorEvent );
      }

   };

}


[STAThread]
int main()
{
   Application::Run( gcnew MCursor::Form1 );
}

//</Snippet1>
