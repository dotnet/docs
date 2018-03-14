

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
public:
   Form1()
   {
      TabControl^ tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      TabPage^ tabPage2 = gcnew TabPage;
      TabPage^ tabPage3 = gcnew TabPage;
      TabPage^ tabPage4 = gcnew TabPage;
      TabPage^ tabPage5 = gcnew TabPage;
      Label^ label1 = gcnew Label;
      tabControl1->Multiline = true;
      tabControl1->SizeMode = TabSizeMode::FillToRight;
      tabControl1->Padding = Point(15,5);
      array<Control^>^tabControls = {tabPage1,tabPage2,tabPage3,tabPage4,tabPage5};
      tabControl1->Controls->AddRange( tabControls );
      tabControl1->Location = Point(35,65);
      tabControl1->Size = System::Drawing::Size( 220, 180 );
      
      // Gets the number of tabs currently in the tabControl1 tab strip.
      // Assigns int value to the tabsInTabStrip variable.
      int tabsInTabStrip = tabControl1->TabCount;
      label1->Text = System::String::Concat( "There are ", tabsInTabStrip, " tabs in the tabControl1 tab strip." );
      label1->Location = Point(35,25);
      label1->Size = System::Drawing::Size( 220, 30 );
      Size = System::Drawing::Size( 300, 300 );
      array<Control^>^formControls = {label1,tabControl1};
      Controls->AddRange( formControls );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
