

//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::CheckedListBox^ checkedListBox1;
   System::Windows::Forms::Button^ WhatIsChecked;
   System::Windows::Forms::Button^ CheckEveryOther;
   bool insideCheckEveryOther;

public:
   Form1()
   {
      
      // Required for Windows Form Designer support
      InitializeComponent();
   }


private:

   /// Required method for Designer support.
   void InitializeComponent()
   {
      this->checkedListBox1 = gcnew System::Windows::Forms::CheckedListBox;
      this->WhatIsChecked = gcnew System::Windows::Forms::Button;
      this->CheckEveryOther = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      // checkedListBox1
      array<Object^>^objectArray = {"one","two","three","four","five","six","seven","eight","nine","ten"};
      this->checkedListBox1->Items->AddRange( objectArray );
      this->checkedListBox1->Location = System::Drawing::Point( 10, 25 );
      this->checkedListBox1->Name = "checkedListBox1";
      this->checkedListBox1->Size = System::Drawing::Size( 158, 139 );
      this->checkedListBox1->TabIndex = 0;
      this->checkedListBox1->ItemCheck += gcnew System::Windows::Forms::ItemCheckEventHandler( this, &Form1::checkedListBox1_ItemCheck );
      
      // WhatIsChecked* this->WhatIsChecked::Location = new System::Drawing::Point(178, 27);
      this->WhatIsChecked->Name = "WhatIsChecked";
      this->WhatIsChecked->Size = System::Drawing::Size( 106, 23 );
      this->WhatIsChecked->TabIndex = 1;
      this->WhatIsChecked->Text = "What is checked?";
      this->WhatIsChecked->Click += gcnew System::EventHandler( this, &Form1::WhatIsChecked_Click );
      
      // CheckEveryOther* this->CheckEveryOther::Location = new System::Drawing::Point(178, 59);
      this->CheckEveryOther->Name = "CheckEveryOther";
      this->CheckEveryOther->Size = System::Drawing::Size( 106, 23 );
      this->CheckEveryOther->TabIndex = 2;
      this->CheckEveryOther->Text = "Check every other";
      this->CheckEveryOther->Click += gcnew System::EventHandler( this, &Form1::CheckEveryOther_Click );
      
      this->ClientSize = System::Drawing::Size( 303, 182 );
      array<Control^>^controlArray = {this->CheckEveryOther,this->WhatIsChecked,this->checkedListBox1};
      this->Controls->AddRange( controlArray );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   //<Snippet2>
   void WhatIsChecked_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display in a message box all the items that are checked.
      // First show the index and check state of all selected items.
      IEnumerator^ myEnum1 = checkedListBox1->CheckedIndices->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         Int32 indexChecked =  *safe_cast<Int32^>(myEnum1->Current);
         
         // The indexChecked variable contains the index of the item.
         MessageBox::Show( String::Concat( "Index#: ", indexChecked, ", is checked. Checked state is: ", checkedListBox1->GetItemCheckState( indexChecked ), "." ) );
      }

      
      // Next show the Object* title and check state for each item selected.
      IEnumerator^ myEnum2 = checkedListBox1->CheckedItems->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         Object^ itemChecked = safe_cast<Object^>(myEnum2->Current);
         
         // Use the IndexOf method to get the index of an item.
         MessageBox::Show( String::Concat( "Item with title: \"", itemChecked, "\", is checked. Checked state is: ", checkedListBox1->GetItemCheckState( checkedListBox1->Items->IndexOf( itemChecked ) ), "." ) );
      }
   }


   //</Snippet2>
   //<Snippet4>
   //<Snippet3>
   void CheckEveryOther_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Cycle through every item and check every other.
      // Set flag to true to know when this code is being executed. Used in the ItemCheck
      // event handler.
      insideCheckEveryOther = true;
      for ( int i = 0; i < checkedListBox1->Items->Count; i++ )
      {
         
         // For every other item in the list, set as checked.
         if ( (i % 2) == 0 )
         {
            
            // But for each other item that is to be checked, set as being in an
            // indeterminate checked state.
            if ( (i % 4) == 0 )
                        checkedListBox1->SetItemCheckState( i, CheckState::Indeterminate );
            else
                        checkedListBox1->SetItemChecked( i, true );
         }

      }
      insideCheckEveryOther = false;
   }


   //</Snippet3>
   void checkedListBox1_ItemCheck( Object^ /*sender*/, ItemCheckEventArgs^ e )
   {
      
      // An item in the CheckedListBox is being checked or unchecked.
      // Set the NewValue based upon the CurrentValue to allow for a tri-state checking.
      // If the ItemCheck event is due to the code in CheckEveryOther, 
      // then exit the function.
      if ( insideCheckEveryOther )
            return;

      if ( e->CurrentValue == CheckState::Unchecked )
            e->NewValue = CheckState::Indeterminate;
      else
      if ( e->CurrentValue == CheckState::Indeterminate )
            e->NewValue = CheckState::Checked;
      else
      if ( e->CurrentValue == CheckState::Checked )
            e->NewValue = CheckState::Unchecked;
   }

   //</Snippet4>
};


// The main entry point for the application.

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
