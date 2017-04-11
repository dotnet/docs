

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   TabControl^ tabControl1;
   TabPage^ tabPage1;
   Button^ button1;

public:
   Form1()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->button1 = gcnew Button;
      this->tabControl1->TabPages->Add( tabPage1 );
      this->tabControl1->Location = Point(25,25);
      this->tabControl1->Size = System::Drawing::Size( 250, 250 );
      
      // Gets the controls collection for tabPage1.
      // Adds button1 to this collection.
      this->tabPage1->Controls->Add( button1 );
      this->button1->Text = "button1";
      this->button1->Location = Point(25,25);
      this->ClientSize = System::Drawing::Size( 300, 300 );
      this->Controls->Add( tabControl1 );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
