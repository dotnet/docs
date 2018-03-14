

// System::Windows::Forms::Control::Invoke(Delegate*, Object[]);
/*
The following example demonstrates the 'Invoke(Delegate*, Object[])'
method of 'Control' class.
A 'ListBox' and a 'Button' control are added to a form, containing a delegate
which encapsulates a method that adds items to the listbox.This function is executed
on the thread that owns the underlying handle of the form .When user clicks on button
the above delegate is executed using 'Invoke' method.
*/
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <Snippet1>
using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Threading;
ref class MyFormControl: public Form
{
public:
   delegate void AddListItem( String^ myString );
   AddListItem^ myDelegate;

private:
   Button^ myButton;
   Thread^ myThread;
   ListBox^ myListBox;

public:
   MyFormControl();
   void AddListItemMethod( String^ myString );

private:
   void Button_Click( Object^ sender, EventArgs^ e );
   void ThreadFunction();
};

ref class MyThreadClass
{
private:
   MyFormControl^ myFormControl1;

public:
   MyThreadClass( MyFormControl^ myForm )
   {
      myFormControl1 = myForm;
   }

   String^ myString;
   void Run()
   {
      for ( int i = 1; i <= 5; i++ )
      {
         myString = String::Concat( "Step number ", i, " executed" );
         Thread::Sleep( 400 );
         
         // Execute the specified delegate on the thread that owns
         // 'myFormControl1' control's underlying window handle with
         // the specified list of arguments.
         array<Object^>^myStringArray = {myString};
         myFormControl1->Invoke( myFormControl1->myDelegate, myStringArray );

      }
   }

};

MyFormControl::MyFormControl()
{
   myButton = gcnew Button;
   myListBox = gcnew ListBox;
   myButton->Location = Point(72,160);
   myButton->Size = System::Drawing::Size( 152, 32 );
   myButton->TabIndex = 1;
   myButton->Text = "Add items in list box";
   myButton->Click += gcnew EventHandler( this, &MyFormControl::Button_Click );
   myListBox->Location = Point(48,32);
   myListBox->Name = "myListBox";
   myListBox->Size = System::Drawing::Size( 200, 95 );
   myListBox->TabIndex = 2;
   ClientSize = System::Drawing::Size( 292, 273 );
   array<Control^>^formControls = {myListBox,myButton};
   Controls->AddRange( formControls );
   Text = " 'Control_Invoke' example ";
   myDelegate = gcnew AddListItem( this, &MyFormControl::AddListItemMethod );
}

void MyFormControl::AddListItemMethod( String^ myString )
{
   myListBox->Items->Add( myString );
}

void MyFormControl::Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
{
   myThread = gcnew Thread( gcnew ThreadStart( this, &MyFormControl::ThreadFunction ) );
   myThread->Start();
}

void MyFormControl::ThreadFunction()
{
   MyThreadClass^ myThreadClassObject = gcnew MyThreadClass( this );
   myThreadClassObject->Run();
}

int main()
{
   MyFormControl^ myForm = gcnew MyFormControl;
   myForm->ShowDialog();
}

// </Snippet1>
