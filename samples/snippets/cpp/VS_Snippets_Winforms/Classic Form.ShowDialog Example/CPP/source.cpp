

#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class Form2: public Form
{
protected:
   Button^ okay;
   Button^ cancel;

public:
   TextBox^ TextBox1;
   Form2()
   {
      this->okay = gcnew Button;
      this->okay->Location = Point(50,50);
      this->okay->Width = 50;
      this->okay->DialogResult = ::DialogResult::OK;
      this->okay->Text = "OK";
      this->cancel = gcnew Button;
      this->cancel->Location = Point(okay->Left + okay->Width + 10,50);
      this->cancel->Width = 50;
      this->cancel->DialogResult = ::DialogResult::Cancel;
      this->cancel->Text = "Cancel";
      this->TextBox1 = gcnew TextBox;
      this->TextBox1->Location = Point(50,100);
      this->TextBox1->Width = 110;
      this->TextBox1->Text = "Enter Text";
      array<Control^>^temp0 = {okay,cancel,TextBox1};
      this->Controls->AddRange( temp0 );
   }

};

public ref class Form1: public Form
{
protected:
   TextBox^ txtResult;
   Button^ showButton;

public:
   Form1()
   {
      this->txtResult = gcnew TextBox;
      this->showButton = gcnew Button;
      this->showButton->Width = 100;
      this->showButton->Text = "Show Dialog";
      this->showButton->Location = Point(0,txtResult->Height + 10);
      this->showButton->Click += gcnew EventHandler( this, &Form1::showButton_Click );
      array<Control^>^temp1 = {txtResult,showButton};
      this->Controls->AddRange( temp1 );
   }


   // <Snippet1>
   void ShowMyDialogBox()
   {
      Form2^ testDialog = gcnew Form2;
      
      // Show testDialog as a modal dialog and determine if DialogResult = OK.
      if ( testDialog->ShowDialog( this ) == ::DialogResult::OK )
      {
         
         // Read the contents of testDialog's TextBox.
         this->txtResult->Text = testDialog->TextBox1->Text;
      }
      else
      {
         this->txtResult->Text = "Cancelled";
      }

      delete testDialog;
   }
   // </Snippet1>


private:

   void showButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ShowMyDialogBox();
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
