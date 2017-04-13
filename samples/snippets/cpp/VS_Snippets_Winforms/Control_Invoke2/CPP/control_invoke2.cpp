// System::Windows::Forms::Control::Invoke(Delegate*);
// <Snippet1>
/*
The following example demonstrates the 'Invoke(Delegate*)' method of 'Control class.
A 'ListBox' and a 'Button' control are added to a form, containing a delegate
which encapsulates a method that adds items to the listbox.This function is executed
on the thread that owns the underlying handle of the form. When user clicks on button
the above delegate is executed using 'Invoke' method.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Threading;

public ref class MyFormControl: public Form
{
public:
   delegate void AddListItem();
   AddListItem^ myDelegate;

private:
   Button^ myButton;
   Thread^ myThread;
   ListBox^ myListBox;

public:
   MyFormControl();
   void AddListItemMethod()
   {
      String^ myItem;
      for ( int i = 1; i < 6; i++ )
      {
         myItem = "MyListItem {0}",i;
         myListBox->Items->Add( myItem );
         myListBox->Update();
         Thread::Sleep( 300 );
      }
   }

private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myThread = gcnew Thread( gcnew ThreadStart( this, &MyFormControl::ThreadFunction ) );
      myThread->Start();
   }

   void ThreadFunction();
};


// The following code assumes a 'ListBox' and a 'Button' control are added to a form,
// containing a delegate which encapsulates a method that adds items to the listbox.
public ref class MyThreadClass
{
private:
   MyFormControl^ myFormControl1;

public:
   MyThreadClass( MyFormControl^ myForm )
   {
      myFormControl1 = myForm;
   }

   void Run()
   {
      // Execute the specified delegate on the thread that owns
      // 'myFormControl1' control's underlying window handle.
      myFormControl1->Invoke( myFormControl1->myDelegate );
   }
};


MyFormControl::MyFormControl()
{
   myButton = gcnew Button;
   myListBox = gcnew ListBox;
   myButton->Location = Point( 72, 160 );
   myButton->Size = System::Drawing::Size( 152, 32 );
   myButton->TabIndex = 1;
   myButton->Text = "Add items in list box";
   myButton->Click += gcnew EventHandler( this, &MyFormControl::Button_Click );
   myListBox->Location = Point( 48, 32 );
   myListBox->Name = "myListBox";
   myListBox->Size = System::Drawing::Size( 200, 95 );
   myListBox->TabIndex = 2;
   ClientSize = System::Drawing::Size( 292, 273 );
   array<Control^>^ temp0 = {myListBox,myButton};
   Controls->AddRange( temp0 );
   Text = " 'Control_Invoke' example";
   myDelegate = gcnew AddListItem( this, &MyFormControl::AddListItemMethod );
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