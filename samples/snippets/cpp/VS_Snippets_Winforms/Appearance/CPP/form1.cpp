

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
public:
   Form1()
   {
      array<String^>^tabText = {"tabPage1","tabPage2"};
      TabControl^ tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage( tabText[ 0 ] );
      TabPage^ tabPage2 = gcnew TabPage( tabText[ 1 ] );
      
      // Sets the tabs to appear as buttons.
      tabControl1->Appearance = TabAppearance::Buttons;
      array<TabPage^>^tabPageArray = {tabPage1,tabPage2};
      tabControl1->Controls->AddRange( tabPageArray );
      Controls->Add( tabControl1 );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
