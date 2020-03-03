

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Reflection;
using namespace System::Windows::Forms;

public ref class PowerStatusBrowserForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::ListBox^ listBox1;
   System::Windows::Forms::TextBox^ textBox1;

public:
   PowerStatusBrowserForm()
   {
      this->SuspendLayout();
      InitForm();

      //Add each property of the PowerStatus class to the list box.
      Type^ t = System::Windows::Forms::PowerStatus::typeid;
      array<PropertyInfo^>^pi = t->GetProperties();
      for ( int i = 0; i < pi->Length; i++ )
         listBox1->Items->Add( pi[ i ]->Name );
      textBox1->Text = String::Format( "The PowerStatus class has {0} properties.\r\n", pi->Length );

      // Configure the list item selected handler for the list box to invoke a 
      // method that displays the value of each property.           
      listBox1->SelectedIndexChanged += gcnew EventHandler( this, &PowerStatusBrowserForm::listBox1_SelectedIndexChanged );
      this->ResumeLayout( false );
   }

private:
   void listBox1_SelectedIndexChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Return if no item is selected.
      if ( listBox1->SelectedIndex == -1 )
            return;

      // Get the property name from the list item
      String^ propname = listBox1->Text;

      // Display the value of the selected property of the PowerStatus type.
      Type^ t = System::Windows::Forms::PowerStatus::typeid;
      array<PropertyInfo^>^pi = t->GetProperties();
      PropertyInfo^ prop = nullptr;
      for ( int i = 0; i < pi->Length; i++ )
         if ( pi[ i ]->Name == propname )
         {
            prop = pi[ i ];
            break;
         }

      Object^ propval = prop->GetValue( SystemInformation::PowerStatus, nullptr );
      textBox1->Text = String::Format( "{0}\r\nThe value of the {1} property is: {2}", textBox1->Text, propname, propval );
   }

   void InitForm()
   {
      // Initialize the form settings
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->listBox1->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
      this->listBox1->Location = System::Drawing::Point( 8, 16 );
      this->listBox1->Size = System::Drawing::Size( 172, 496 );
      this->listBox1->TabIndex = 0;
      this->textBox1->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
      this->textBox1->Location = System::Drawing::Point( 188, 16 );
      this->textBox1->Multiline = true;
      this->textBox1->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
      this->textBox1->Size = System::Drawing::Size( 420, 496 );
      this->textBox1->TabIndex = 1;
      this->ClientSize = System::Drawing::Size( 616, 525 );
      this->Controls->Add( this->textBox1 );
      this->Controls->Add( this->listBox1 );
      this->Text = "Select a PowerStatus property to get the value of";
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew PowerStatusBrowserForm );
}
//</Snippet1>
