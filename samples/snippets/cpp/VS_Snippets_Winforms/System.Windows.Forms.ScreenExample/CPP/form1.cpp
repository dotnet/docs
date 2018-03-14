

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
   System::Windows::Forms::Button^ Button1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 112, 32 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Resize form";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // This method will adjust the size of the form to utilize 
   // the working area of the screen.
private:
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Retrieve the working rectangle from the Screen class
      // using the PrimaryScreen and the WorkingArea properties.
      System::Drawing::Rectangle workingRectangle = Screen::PrimaryScreen->WorkingArea;
      
      // Set the size of the form slightly less than size of 
      // working rectangle.
      this->Size = System::Drawing::Size( workingRectangle.Width - 10, workingRectangle.Height - 10 );
      
      // Set the location so the entire form is visible.
      this->Location = System::Drawing::Point( 5, 5 );
   }
   //</snippet1>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
