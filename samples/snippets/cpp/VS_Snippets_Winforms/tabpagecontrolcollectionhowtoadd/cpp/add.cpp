#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:

public:
   Form1()
   {
      TabPage^ tabPage1;
      tabPage1 = gcnew TabPage;
      
      // <snippet1>
	  tabPage1->Controls->Add(gcnew Button);
	  // </snippet1>
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

