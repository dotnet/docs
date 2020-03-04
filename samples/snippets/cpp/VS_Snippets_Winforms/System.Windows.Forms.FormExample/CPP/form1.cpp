

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates the result of setting 
// the desktop bounds and desktop location. It also demonstrates
// the Form.MaximumSize property.
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{

   //<snippet3>
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Set the maximum size, so if user maximizes form, it 
      //will not cover entire desktop.  
      this->MaximumSize = System::Drawing::Size( 500, 500 );
   }
   //</snippet3>

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
   System::Windows::Forms::Button^ Button2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Button2 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 96, 48 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 96, 40 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click me to see the form move";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //Button2
      //
      this->Button2->Location = System::Drawing::Point( 96, 120 );
      this->Button2->Name = "Button2";
      this->Button2->Size = System::Drawing::Size( 96, 48 );
      this->Button2->TabIndex = 1;
      this->Button2->Text = "Click me to see form shrink (and move)";
      this->Button2->Click += gcnew System::EventHandler( this, &Form1::Button2_Click );
      
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button2 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   //<snippet1>
   void Button1_Click( System::Object^ sender, System::EventArgs^ e )
   {
      for ( int i = 0; i <= 25; i++ )
      {
         
         // With each loop through the code, the form's desktop 
         // location is adjusted right and down by 10 pixels. 
         this->SetDesktopLocation( this->Location.X + 10, this->Location.Y + 10 );
         
         // Call Sleep to give the effect of the form walking 
         // across the screen. 
         System::Threading::Thread::Sleep( 250 );

      }
      
      // Set the location back to the upper left-hand corner of 
      // the screen.
      this->SetDesktopLocation( 10, 10 );
   }
   //</snippet1>

   //<snippet2>
   void Button2_Click( System::Object^ sender, System::EventArgs^ e )
   {
      for ( int i = 0; i <= 20; i++ )
      {
         
         // With each loop through the code, the form's 
         // desktop location is adjusted right and down
         //  by 10 pixels and its height and width are each
         // decreased by 10 pixels. 
         this->SetDesktopBounds( this->Location.X + 10, this->Location.Y + 10, this->Width - 10, this->Height - 10 );
         
         // Call Sleep to show the form gradually shrinking.
         System::Threading::Thread::Sleep( 50 );

      }
   }
   //</snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
