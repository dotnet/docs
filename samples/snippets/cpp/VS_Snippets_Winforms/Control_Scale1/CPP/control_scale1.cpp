// System::Windows::Forms::Control::Scale(float)
// System::Windows::Forms::Control::SizeChanged

/*
The following example demonstrates the 'Scale(float)' method
and 'SizeChanged' event of the 'Control' class. An instance of 
a 'Button' control has been provided that can be scaled both 
horizontally and vertically. A 'NumericUpDown' instance has been 
provided that is used to provide for the horizontal and vertical 
scale value. The 'Button' instance named 'OK' is used to set the 
scale values for the 'Button' control instance. Whenever the size
of the control changes the event handler associated with the 
'SizeChanged' event of the control is called. This event handler 
displays a message box indicating that the size of the control has 
changed. 
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class MyForm: public Form
{
private:
   Label^ myLabel1;
   NumericUpDown^ myNumericUpDown1;
   Button^ myButton1;
   Button^ myButton2;
   System::ComponentModel::Container^ components;

public:
   MyForm()
   {
      components = nullptr;
      InitializeComponent();
   }

public:
   ~MyForm()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      this->myLabel1 = gcnew System::Windows::Forms::Label;
      this->myButton1 = gcnew System::Windows::Forms::Button;
      this->myButton2 = gcnew System::Windows::Forms::Button;
      this->myNumericUpDown1 = gcnew System::Windows::Forms::NumericUpDown;
      (static_cast<System::ComponentModel::ISupportInitialize^>(this->myNumericUpDown1))->BeginInit();
      this->SuspendLayout();

      // Set the properties for 'myLabel1'.
      this->myLabel1->Font = gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
      this->myLabel1->Location = System::Drawing::Point( 16, 168 );
      this->myLabel1->Name = "myLabel1";
      this->myLabel1->Size = System::Drawing::Size( 152, 24 );
      this->myLabel1->TabIndex = 1;
      this->myLabel1->Text = "Scale (Horizontal & Vertical):";
      this->myLabel1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;

      // Set the properties for 'myButton1'.
      this->myButton1->Location = System::Drawing::Point( 56, 32 );
      this->myButton1->Name = "myButton1";
      this->myButton1->Size = System::Drawing::Size( 184, 80 );
      this->myButton1->TabIndex = 0;
      this->myButton1->Text = "Scaleable Control";
      RegisterEventHandler();

      // Set the properties for 'myButton2'.
      this->myButton2->Font = gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
      this->myButton2->Location = System::Drawing::Point( 48, 216 );
      this->myButton2->Name = "myButton2";
      this->myButton2->Size = System::Drawing::Size( 200, 32 );
      this->myButton2->TabIndex = 7;
      this->myButton2->Text = "OK";
      this->myButton2->Click += gcnew System::EventHandler( this, &MyForm::MyButton2_Click );

      // Set the properties for 'myNumericUpDown1'.
      this->myNumericUpDown1->DecimalPlaces = 1;
      this->myNumericUpDown1->Increment = System::Decimal( 0.1 );
      this->myNumericUpDown1->Location = System::Drawing::Point( 192, 168 );
      this->myNumericUpDown1->Maximum = System::Decimal( 10 );
      this->myNumericUpDown1->Minimum = System::Decimal( 0 );
      this->myNumericUpDown1->Name = "myNumericUpDown1";
      this->myNumericUpDown1->Size = System::Drawing::Size( 88, 20 );
      this->myNumericUpDown1->TabIndex = 5;

      // Set the properties for 'MyForm'.
      this->ClientSize = System::Drawing::Size( 292, 261 );
      array<System::Windows::Forms::Control^>^myFormControls = {this->myButton2,this->myNumericUpDown1,this->myLabel1,this->myButton1};
      this->Controls->AddRange( myFormControls );
      this->Name = "MyForm";
      this->Text = "MyForm";
      (static_cast<System::ComponentModel::ISupportInitialize^>(this->myNumericUpDown1))->EndInit();
      this->ResumeLayout( false );
   }

   // <Snippet2>
private:
   void RegisterEventHandler()
   {
      myButton1->SizeChanged += gcnew EventHandler( this, &MyForm::MyButton1_SizeChanged );
   }

   void MyButton2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // <Snippet1>
      // Set the scale for the control to the value provided.
      float scale = (float)myNumericUpDown1->Value;
      myButton1->Scale( scale );
      // </Snippet1>
   }

   void MyButton1_SizeChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "The size of the 'Button' control has changed" );
   }
   // </Snippet2>
};


[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
