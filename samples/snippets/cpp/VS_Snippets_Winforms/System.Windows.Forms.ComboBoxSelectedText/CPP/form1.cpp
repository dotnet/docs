

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitalizeComboBoxAndTextBoxes();
      this->comboBox1->SelectionChangeCommitted += gcnew EventHandler( this, &Form1::comboBox1_SelectionChangeCommitted );
      
      //Add any initialization after the InitializeComponent() call
   }


public:

   //Destructor cleans up the component list.
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->SuspendLayout();
      
      //
      //ComboBox1
      //
      //
      //TextBox1
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


internal:
   System::Windows::Forms::ComboBox^ comboBox1;
   System::Windows::Forms::TextBox^ textbox1;

private:
   void InitalizeComboBoxAndTextBoxes()
   {
      this->comboBox1 = gcnew System::Windows::Forms::ComboBox;
      this->comboBox1->Location = Point(25,150);
      this->comboBox1->Width = 160;
      this->textbox1 = gcnew System::Windows::Forms::TextBox;
      textbox1->Location = Point(25,50);
      textbox1->Name = "selectedTextBox";
      textbox1->Size = System::Drawing::Size( 25, 15 );
      array<String^>^namespaces = {"System.Windows.Forms","System.Net","System.Reflection","System.Drawing"};
      System::Collections::IEnumerator^ myEnum = namespaces->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         String^ aNamespace = safe_cast<String^>(myEnum->Current);
         comboBox1->Items->Add( String::Concat( aNamespace, ", ", (aNamespace->Length + 4) ) );
      }

      this->Controls->Add( this->textbox1 );
      this->Controls->Add( this->comboBox1 );
   }


   // The following code example demonstrates the handling of the 
   // SelectionChangeCommitted event.  This example uses the 
   // SelectionLength property to set the width of a text box that 
   // displays the SelectedText. Since the SelectionLength and
   // SelectedText properties reflect the currently selected 
   // (not newly selected) text, they will lag behind what is currently
   // displayed in the text portion of the ComboBox control. To run  
   // this example,paste the following code into a form that contains 
   // a ComboBox named comboBox1 and is populated with strings. 
   // The form should also contain a TextBox named textbox1.  
   // Ensure the SelectionChangedEvent is associated with the  
   // event-handling method in this example.
   //<snippet1>
   void comboBox1_SelectionChangeCommitted( Object^ sender, EventArgs^ /*e*/ )
   {
      ComboBox^ senderComboBox = dynamic_cast<ComboBox^>(sender);
      
      // Change the length of the text box depending on what the user has 
      // selected and committed using the SelectionLength property.
      if ( senderComboBox->SelectionLength > 0 )
      {
		  textbox1->Width = 
			  senderComboBox->SelectedItem->ToString()->Length * 
			  ((int)this->textbox1->Font->SizeInPoints);
		  textbox1->Text = senderComboBox->SelectedItem->ToString();				
      }
   }
   //</snippet1>
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
