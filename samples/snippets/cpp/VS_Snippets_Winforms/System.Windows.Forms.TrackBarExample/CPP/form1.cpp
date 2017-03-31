

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeTrackBar();
      
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
   System::Windows::Forms::TextBox^ TextBox1;
   System::Windows::Forms::Label ^ Label1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      
      //
      //TextBox1
      //
      this->TextBox1->Location = System::Drawing::Point( 112, 88 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->ReadOnly = true;
      this->TextBox1->Size = System::Drawing::Size( 72, 20 );
      this->TextBox1->TabIndex = 0;
      this->TextBox1->Text = "";
      
      //
      //Label1
      //
      this->Label1->Location = System::Drawing::Point( 48, 80 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 56, 32 );
      this->Label1->TabIndex = 1;
      this->Label1->Text = "Number of teams:";
      this->Label1->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->TextBox1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   //Declare a new TrackBar object.
internal:
   System::Windows::Forms::TrackBar^ TrackBar1;

   // Initalize the TrackBar and add it to the form.
private:
   void InitializeTrackBar()
   {
      this->TrackBar1 = gcnew System::Windows::Forms::TrackBar;
      TrackBar1->Location = System::Drawing::Point( 75, 30 );
      
      // Set the TickStyle property so there are ticks on both sides
      // of the TrackBar.
      TrackBar1->TickStyle = TickStyle::Both;
      
      // Set the minimum and maximum number of ticks.
      TrackBar1->Minimum = 10;
      TrackBar1->Maximum = 100;
      
      // Set the tick frequency to one tick every ten units.
      TrackBar1->TickFrequency = 10;
      
      // Associate the event-handling method with the 
      // ValueChanged event.
      TrackBar1->ValueChanged += gcnew System::EventHandler( this, &Form1::TrackBar1_ValueChanged );
      this->Controls->Add( this->TrackBar1 );
   }

   // Handle the TrackBar.ValueChanged event by calculating a value for
   // TextBox1 based on the TrackBar value.  
   void TrackBar1_ValueChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      TextBox1->Text = (System::Math::Round( TrackBar1->Value / 10.0 )).ToString();
   }
   //</snippet1>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
