#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   ref class myKeyPressClass
   {
   internal:
      void myKeyCounter( Object^ sender, KeyPressEventArgs^ ex ){}
   };

   TextBox^ textBox1;

   // <Snippet2>
public:
   myKeyPressClass^ myKeyPressHandler;

   Form1()
   {
      myKeyPressHandler = gcnew myKeyPressClass;

      InitializeComponent();

      textBox1->KeyPress += gcnew KeyPressEventHandler(
         myKeyPressHandler, &myKeyPressClass::myKeyCounter );
   }
   // </Snippet2>

private:
   void InitializeComponent(){}
};
