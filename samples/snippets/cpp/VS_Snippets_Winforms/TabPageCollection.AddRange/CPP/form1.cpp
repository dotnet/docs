

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
   TabPage^ tabPage2;
   TabPage^ tabPage3;

public:
   Form1()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->tabPage2 = gcnew TabPage;
      this->tabPage3 = gcnew TabPage;
      array<TabPage^>^tabPages = {tabPage1,tabPage2,tabPage3};
      
      // Gets the controls collection for tabControl1.
      // Adds an array of tab pages to this collection.
      this->tabControl1->Controls->AddRange( tabPages );
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
