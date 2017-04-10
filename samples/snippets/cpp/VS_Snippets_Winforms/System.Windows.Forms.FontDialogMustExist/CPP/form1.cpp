

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates using the FontDialog.MinSize, 
// FontDialog.MaxSize, and FontDialog.ShowEffects members, and 
// handling of Apply event.
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
   }

protected:

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

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::FontDialog^ FontDialog1;
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::TextBox^ TextBox1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->FontDialog1 = gcnew System::Windows::Forms::FontDialog;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();
      
      //
      //FontDialog1
      //
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 72, 136 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 144, 88 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click for Font Dialog";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //TextBox1
      //
      this->TextBox1->Location = System::Drawing::Point( 72, 48 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->Size = System::Drawing::Size( 152, 20 );
      this->TextBox1->TabIndex = 1;
      this->TextBox1->Text = "Here is some text.";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->TextBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   //<snippet1>
   void Button1_Click( System::Object^ sender, System::EventArgs^ e )
   {
      // Set FontMustExist to true, which causes message box error
      // if the user enters a font that does not exist. 
      FontDialog1->FontMustExist = true;
      
      // Associate the method handling the Apply event with the event.
      FontDialog1->Apply += gcnew System::EventHandler( this, &Form1::FontDialog1_Apply );
      
      // Set a minimum and maximum size to be
      // shown in the FontDialog.
      FontDialog1->MaxSize = 32;
      FontDialog1->MinSize = 18;
      
      // Show the Apply button in the dialog.
      FontDialog1->ShowApply = true;
      
      // Do not show effects such as Underline
      // and Bold.
      FontDialog1->ShowEffects = false;
      
      // Save the existing font.
      System::Drawing::Font^ oldFont = this->Font;
      
      //Show the dialog, and get the result
      System::Windows::Forms::DialogResult result = FontDialog1->ShowDialog();
      
      // If the OK button in the Font dialog box is clicked, 
      // set all the controls' fonts to the chosen font by calling
      // the FontDialog1_Apply method.
      if ( result == ::DialogResult::OK )
      {
         FontDialog1_Apply( this->Button1, gcnew System::EventArgs );
      }
      // If Cancel is clicked, set the font back to
      // the original font.
      else
      
      // If Cancel is clicked, set the font back to
      // the original font.
      if ( result == ::DialogResult::Cancel )
      {
         this->Font = oldFont;
         System::Collections::IEnumerator^ myEnum = this->Controls->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Control^ containedControl = safe_cast<Control^>(myEnum->Current);
            containedControl->Font = oldFont;
         }
      }
   }


   // Handle the Apply event by setting all controls' fonts to 
   // the chosen font. 
   void FontDialog1_Apply( Object^ sender, System::EventArgs^ e )
   {
      this->Font = FontDialog1->Font;
      System::Collections::IEnumerator^ myEnum1 = this->Controls->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         Control^ containedControl = safe_cast<Control^>(myEnum1->Current);
         containedControl->Font = FontDialog1->Font;
      }
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
