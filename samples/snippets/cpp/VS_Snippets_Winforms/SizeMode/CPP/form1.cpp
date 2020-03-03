

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   TabControl^ tabControl1;

public:
   Form1()
   {
      this->tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      TabPage^ tabPage2 = gcnew TabPage;
      TabPage^ tabPage3 = gcnew TabPage;
      TabPage^ tabPage4 = gcnew TabPage;
      TabPage^ tabPage5 = gcnew TabPage;
      array<TabPage^>^tabPages = {tabPage1,tabPage2,tabPage3,tabPage4,tabPage5};
      
      // Sizes the tabs so that each row fills the entire width of tabControl1.
      this->tabControl1->SizeMode = TabSizeMode::FillToRight;
      this->tabControl1->Multiline = true;
      this->tabControl1->Padding = Point(15,5);
      array<Control^>^temp0 = {tabPage1,tabPage2,tabPage3,tabPage4,tabPage5};
      this->tabControl1->Controls->AddRange( temp0 );
      this->tabControl1->Location = Point(35,25);
      this->tabControl1->Size = System::Drawing::Size( 220, 220 );
      this->Size = System::Drawing::Size( 300, 300 );
      this->Controls->Add( tabControl1 );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
