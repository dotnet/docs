

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

public:
   Form1()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->tabPage2 = gcnew TabPage;
      
      // Sizes the tabs of tabControl1.
      this->tabControl1->ItemSize = System::Drawing::Size( 90, 50 );
      
      // Makes the tab width definable. 
      this->tabControl1->SizeMode = TabSizeMode::Fixed;
      array<Control^>^tabControl1Controls = {tabPage1,tabPage2};
      this->tabControl1->Controls->AddRange( tabControl1Controls );
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
