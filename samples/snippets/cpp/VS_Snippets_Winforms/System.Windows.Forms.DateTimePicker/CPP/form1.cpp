

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// This example demonstrates using the read-only fields DateTimePicker.MaxDateTime
// and DateTimePicker.MinDateTime.
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeDateTimePicker();
      
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
   System::Windows::Forms::ToolTip^ ToolTip1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->ToolTip1 = gcnew System::Windows::Forms::ToolTip( this->components );
      this->SuspendLayout();
      
      //
      //DateTimePicker1
      //
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
internal:
   // Declare the DateTimePicker.
   System::Windows::Forms::DateTimePicker^ DateTimePicker1;

private:
   void InitializeDateTimePicker()
   {
      // Construct the DateTimePicker.
      this->DateTimePicker1 = gcnew System::Windows::Forms::DateTimePicker;
      
      //Set size and location.
      this->DateTimePicker1->Location = System::Drawing::Point( 40, 88 );
      this->DateTimePicker1->Size = System::Drawing::Size( 160, 21 );
      
      // Set the alignment of the drop-down MonthCalendar to right.
      this->DateTimePicker1->DropDownAlign = LeftRightAlignment::Right;
      
      // Set the Value property to 50 years before today.
      DateTimePicker1->Value = System::DateTime::Now.AddYears(  -50 );
      
      //Set a custom format containing the string "of the year"
      DateTimePicker1->Format = DateTimePickerFormat::Custom;
      DateTimePicker1->CustomFormat = "MMM dd, 'of the year' yyyy ";
      
      // Add the DateTimePicker to the form.
      this->Controls->Add( this->DateTimePicker1 );
   }
   //</snippet1>

   //<snippet2>
   // When the calendar drops down, display a MessageBox indicating 
   // that DateTimePicker will not accept dates before MinDateTime or 
   // after MaxDateTime. Use a StringBuilder object to build the string
   // for efficiency.
   void DateTimePicker1_DropDown( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      System::Text::StringBuilder^ messageBuilder = gcnew System::Text::StringBuilder;
      messageBuilder->Append( "Choose a date after: " );
      messageBuilder->Append( DateTimePicker::MinDateTime.ToShortDateString() );
      messageBuilder->Append( " and a date before: " );
      messageBuilder->Append( DateTimePicker::MaxDateTime.ToShortDateString() );
      MessageBox::Show( messageBuilder->ToString() );
   }
   //</snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
