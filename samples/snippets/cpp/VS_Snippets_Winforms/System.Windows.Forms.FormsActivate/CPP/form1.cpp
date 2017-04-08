

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates another use of the 
// Form.SetDesktopLocation and Form.Activate members, 
// and demonstrates handling the Form.Load and Form.Activate 
// events.
using namespace System;
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
   System::Windows::Forms::Label ^ Label1;
   System::Windows::Forms::Label ^ Label2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->Label2 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 104, 80 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 96, 56 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click me for an new inactivated form.";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //Label1
      //
      this->Label1->Location = System::Drawing::Point( 104, 160 );
      this->Label1->Name = "Label1";
      this->Label1->TabIndex = 1;
      this->Label1->Text = "Label1";
      
      //
      //Label2
      //
      this->Label2->Location = System::Drawing::Point( 104, 208 );
      this->Label2->Name = "Label2";
      this->Label2->Size = System::Drawing::Size( 40, 40 );
      this->Label2->TabIndex = 2;
      this->Label2->Text = "Label2";
      this->Label2->AutoSize = true;
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label2 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Activated += gcnew System::EventHandler( this, &Form1::Form1_Activated );
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->Closed += gcnew System::EventHandler( this, &Form1::Form1_Closed );
      this->ResumeLayout( false );
   }

   // <snippet1>
   static int x = 200;
   static int y = 200;
   void Button1_Click( System::Object^ sender, System::EventArgs^ e )
   {
      
      // Create a new Form1 and set its Visible property to true.
      Form1^ form2 = gcnew Form1;
      form2->Visible = true;
      
      // Set the new form's desktop location so it  
      // appears below and to the right of the current form.
      form2->SetDesktopLocation( x, y );
      x += 30;
      y += 30;
      
      // Keep the current form active by calling the Activate
      // method.
      this->Activate();
      this->Button1->Enabled = false;
   }


   // Updates the label text to reflect the current values of x 
   // and y, which was were incremented in the Button1 control's 
   // click event.
   void Form1_Activated( Object^ sender, System::EventArgs^ e )
   {
      Label1->Text = String::Format( "x: {0} y: {1}", x, y );
      Label2->Text = String::Format( "Number of forms currently open: {0}", count );
   }

   static int count = 0;
   void Form1_Closed( Object^ sender, System::EventArgs^ e )
   {
      count -= 1;
   }

   void Form1_Load( Object^ sender, System::EventArgs^ e )
   {
      count += 1;
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
