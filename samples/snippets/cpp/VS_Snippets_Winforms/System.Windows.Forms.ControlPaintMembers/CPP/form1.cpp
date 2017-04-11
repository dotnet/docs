

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;
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
      this->Button1->Location = System::Drawing::Point( 24, 32 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Button1";
      this->Button1->Paint += gcnew PaintEventHandler( this, &Form1::Button1_Paint );
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Paint += gcnew PaintEventHandler( this, &Form1::Form1_Paint );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // Handle the Button1 object's Paint Event to create a CaptionButton.
   void Button1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      
      // Draw a CaptionButton control using the ClientRectangle 
      // property of Button1. Make the button a Help button 
      // with a normal state.
      ControlPaint::DrawCaptionButton( e->Graphics, Button1->ClientRectangle, CaptionButton::Help, ButtonState::Normal );
   }
   //</snippet1>

   //<snippet2>
   // Handle the Form's Paint event to draw a 3D three-dimensional 
   // raised border just inside the border of the frame.
   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      Rectangle borderRectangle = this->ClientRectangle;
      borderRectangle.Inflate(  -10, -10 );
      ControlPaint::DrawBorder3D( e->Graphics, borderRectangle, Border3DStyle::Raised );
   }
   //</snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
