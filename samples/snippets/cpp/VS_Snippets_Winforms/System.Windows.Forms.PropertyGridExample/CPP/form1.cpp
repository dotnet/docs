

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following example combines some controls on 
// a form with using a CheckedListBox and PropertyGrid.  
// This method demonstrates the using the PropertyGrid.PropertySort, 
// PropertyGrid.SelectedObjects, CheckedListBox.SelectionMode, 
// and CheckListBox.ThreeDCheckBoxes, and CheckedListBox.CheckOnClick members.

//<snippet3>
// This form combines uses a CheckedListBox and PropertyGrid to 
// combine some controls.  CheckedListBox1 is populated with itself
// and the other controls on the form. The user can then click Button1
// to see the PropertyGrid for the selected controls.

using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

public ref class Form1: public System::Windows::Forms::Form
{
internal:
   System::Windows::Forms::TextBox^ TextBox1;
   System::Windows::Forms::Label ^ Label1;
   System::Windows::Forms::Button^ Button1;

public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->TextBox1->Location = System::Drawing::Point( 40, 20 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->TabIndex = 0;
      this->TextBox1->Text = "TextBox1";
      this->Label1->Location = System::Drawing::Point( 40, 60 );
      this->Label1->Name = "Label1";
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Label1";
      this->Button1->Location = System::Drawing::Point( 40, 200 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 4;
      this->Button1->Size = System::Drawing::Size( 100, 50 );
      this->Button1->Text = "Show properties for selected control(s)";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      this->ClientSize = System::Drawing::Size( 350, 350 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->TextBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      InitializeCheckedListBox();
      InitializePropertyGrid();
   }

   //<snippet1>
   // This method initializes CheckedListBox1 with a list of all 
   // the controls on the form. It sets the selection mode
   // to single selection and allows selection with a single click.
   // It adds itself to the list before adding itself to the form.
internal:
   System::Windows::Forms::CheckedListBox^ CheckedListBox1;

private:
   void InitializeCheckedListBox()
   {
      this->CheckedListBox1 = gcnew CheckedListBox;
      this->CheckedListBox1->Location = System::Drawing::Point( 40, 90 );
      this->CheckedListBox1->CheckOnClick = true;
      this->CheckedListBox1->Name = "CheckedListBox1";
      this->CheckedListBox1->Size = System::Drawing::Size( 120, 94 );
      this->CheckedListBox1->TabIndex = 1;
      this->CheckedListBox1->SelectionMode = SelectionMode::One;
      this->CheckedListBox1->ThreeDCheckBoxes = true;
      System::Collections::IEnumerator^ myEnum = this->Controls->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Control^ aControl = safe_cast<Control^>(myEnum->Current);
         this->CheckedListBox1->Items->Add( aControl, false );
      }

      this->CheckedListBox1->DisplayMember = "Name";
      this->CheckedListBox1->Items->Add( CheckedListBox1 );
      this->Controls->Add( this->CheckedListBox1 );
   }
   //</snippet1>

   //<snippet2>
   // Declare a propertyGrid.
internal:
   PropertyGrid^ propertyGrid1;

private:

   // Initialize propertyGrid1.
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void InitializePropertyGrid()
   {
      propertyGrid1 = gcnew PropertyGrid;
      propertyGrid1->Name = "PropertyGrid1";
      propertyGrid1->Location = System::Drawing::Point( 185, 20 );
      propertyGrid1->Size = System::Drawing::Size( 150, 300 );
      propertyGrid1->TabIndex = 5;
      
      // Set the sort to alphabetical and set Toolbar visible
      // to false, so the user cannot change the sort.
      propertyGrid1->PropertySort = PropertySort::Alphabetical;
      propertyGrid1->ToolbarVisible = false;
      propertyGrid1->Text = "Property Grid";
      
      // Add the PropertyGrid to the form, but set its
      // visibility to False so it will not appear when the form loads.
      propertyGrid1->Visible = false;
      this->Controls->Add( propertyGrid1 );
   }
   //</snippet2>

   // Sets the SelectedObjects property of PropertyGrid1's 
   // SelectedObjects to the controls the user has selected in 
   // CheckedListBox1.
   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      propertyGrid1->Visible = true;
      array<Control^>^selectedControls = gcnew array<Control^>(CheckedListBox1->CheckedItems->Count);
      for ( int counter = 0; counter < CheckedListBox1->CheckedItems->Count; counter++ )
      {
         selectedControls[ counter ] = dynamic_cast<Control^>(CheckedListBox1->CheckedItems[ counter ]);

      }
      propertyGrid1->SelectedObjects = selectedControls;
   }
   //</snippet3>
};

int main()
{
   Application::Run( gcnew Form1 );
}
