

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::Button^ button3;
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;
      InitializeComponent();
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
   void InitializeComponent()
   {
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->button3 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 40, 48 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      
      // 
      // button2
      // 
      this->button2->Location = System::Drawing::Point( 40, 112 );
      this->button2->Name = "button2";
      this->button2->TabIndex = 1;
      this->button2->Text = "button2";
      this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );
      
      // 
      // button3
      // 
      this->button3->Location = System::Drawing::Point( 40, 184 );
      this->button3->Name = "button3";
      this->button3->TabIndex = 2;
      this->button3->Text = "button3";
      this->button3->Click += gcnew System::EventHandler( this, &Form1::button3_Click );
      
      // 
      // Form1
      // 
      this->AutoScroll = true;
      this->ClientSize = System::Drawing::Size( 368, 325 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button3,this->button2,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->SizeControls();
   }

   // Control.Size/Control.ClientSize/Control.SetClientSizeCore
   // <snippet3>
private:
   void SizeControls()
   {
      // Resize the buttons two different ways.
      button1->Size = System::Drawing::Size( 75, 25 );
      button2->ClientSize = System::Drawing::Size( 100, 50 );
      
      // Resize the form.
      this->SetClientSizeCore( 300, 300 );
   }
   // </snippet3>

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->ResizeForm();
   }

   /* Control.ClientRectangle/Control.Bounds/Rectangle.Inflate/
       * Control.ScrollControlIntoView/Control.AutoScroll */
   // <snippet2>
private:
   void ResizeForm()
   {
      
      // Enable auto-scrolling for the form.
      this->AutoScroll = true;
      
      // Resize the form.
      Rectangle r = this->ClientRectangle;
      
      // Subtract 100 pixels from each side of the Rectangle.
      r.Inflate(  -100, -100 );
      this->Bounds = this->RectangleToScreen( r );
      
      // Make sure button2 is visible.
      this->ScrollControlIntoView( button2 );
   }
   // </snippet2>

   void button2_Click( Object^ sender, System::EventArgs^ /*e*/ )
   {
      this->AutoSizeControl( dynamic_cast<Control^>(sender), 5 );
   }

   /* Control.CreateGraphics/Control.Text/Control.Font/
       * Control.Height/Control.Width/Control.ClientSize */
   // <snippet1>
private:
   void AutoSizeControl( Control^ control, int textPadding )
   {
      
      // Create a Graphics object for the Control.
      Graphics^ g = control->CreateGraphics();
      
      // Get the Size needed to accommodate the formatted Text.
      System::Drawing::Size preferredSize = g->MeasureString( control->Text, control->Font ).ToSize();
      
      // Pad the text and resize the control.
      control->ClientSize = System::Drawing::Size( preferredSize.Width + (textPadding * 2), preferredSize.Height + (textPadding * 2) );
      
      // Clean up the Graphics object.
      delete g;
   }
   // </snippet1>
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
