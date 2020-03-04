// System::Windows::Forms::Control::BeginInvoke(Delegate*, Object[])
// System::Windows::Forms::Control::BeginInvoke(Delegate*)

/*
The following program demonstrates the 'BeginInvoke(Delegate*)' and BeginInvoke(Delegate*, Object[])
methods of 'Control' class.
A 'TextBox' and  two 'Button' controls are added to the form. When the first 'Button'
is clicked a delegate is called asynchronously using 'BeginInvoke' method of 'Control'
class and an array of objects is passed as an arguments to the delegator which adds
'Label' control to the form. When the second 'Button' control is
clicked a delegate is called asynchronously using 'BeginInvoke' which will display
a message in the 'TextBox'.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

public ref class MyForm: public Form
{
private:
   System::ComponentModel::Container^ components;
   TextBox^ myTextBox;
   Button^ myButton;
   Button^ invokeButton;

public:
   MyForm()
   {
      components = nullptr;
      
      // Required for Windows Form Designer support.
      InitializeComponent();
   }

protected:
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
      // Set 'myTextBox' properties.
      this->myTextBox = gcnew TextBox;
      myTextBox->Location = Point(90,16);
      myTextBox->Size = System::Drawing::Size( 160, 25 );
      
      // Set 'myButton' properties.
      this->myButton = gcnew Button;
      myButton->Text = "Add Label";
      myButton->Location = Point(45,50);
      myButton->Size = System::Drawing::Size( 70, 25 );
      myButton->Click += gcnew EventHandler( this, &MyForm::Button_Click );
      invokeButton = gcnew Button;
      invokeButton->Text = "Invoke Delegate";
      invokeButton->Location = Point(120,50);
      invokeButton->Size = System::Drawing::Size( 100, 25 );
      invokeButton->Click += gcnew EventHandler( this, &MyForm::Invoke_Click );
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->Name = "MyForm";
      this->Text = "Invoke example";
      this->Controls->Add( myTextBox );
      this->Controls->Add( myButton );
      this->Controls->Add( invokeButton );
   }

   // <Snippet1>
private:
   delegate void MyDelegate(
   Label^ myControl, String^ myArg2 );
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      array<Object^>^myArray = gcnew array<Object^>(2);
      myArray[ 0 ] = gcnew Label;
      myArray[ 1 ] = "Enter a Value";
      myTextBox->BeginInvoke( gcnew MyDelegate( this, &MyForm::DelegateMethod ), myArray );
   }

   void DelegateMethod( Label^ myControl, String^ myCaption )
   {
      myControl->Location = Point(16,16);
      myControl->Size = System::Drawing::Size( 80, 25 );
      myControl->Text = myCaption;
      this->Controls->Add( myControl );
   }

   delegate void InvokeDelegate();
   // </Snippet1>

   // <Snippet2>
private:
   void Invoke_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myTextBox->BeginInvoke( gcnew InvokeDelegate( this, &MyForm::InvokeMethod ) );
   }

   void InvokeMethod()
   {
      myTextBox->Text = "Executed the given delegate";
   }
   // </Snippet2>
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
