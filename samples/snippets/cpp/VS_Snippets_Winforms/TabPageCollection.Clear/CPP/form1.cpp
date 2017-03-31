

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
      this->tabPage1 = gcnew TabPage( "tabPage1" );
      this->tabPage2 = gcnew TabPage( "tabPage2" );
      this->tabPage3 = gcnew TabPage( "tabPage3" );
      
      // Populates the tabControl1 with three tab pages.
      array<TabPage^>^tabPages = {tabPage1,tabPage2,tabPage3};
      this->tabControl1->TabPages->AddRange( tabPages );
      
      // Removes all the tab pages from tabControl1.
      this->tabControl1->TabPages->Clear();
      
      // Adds the tabPage1 back to tabControl1.
      this->tabControl1->TabPages->Add( tabPage2 );
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
