

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

public:
   Form1()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      
      // Gets the controls collection for tabControl1.
      // Adds the tabPage1 to this collection.
      this->tabControl1->TabPages->Add( tabPage1 );
      this->tabControl1->Location = Point(25,25);
      this->tabControl1->Size = System::Drawing::Size( 250, 250 );
      this->ClientSize = System::Drawing::Size( 300, 300 );
      this->Controls->Add( tabControl1 );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
