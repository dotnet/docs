

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
   Label^ label1;

public:
   Form1()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->tabPage2 = gcnew TabPage;
      this->tabPage3 = gcnew TabPage;
      this->label1 = gcnew Label;
      array<TabPage^>^tabPages = {tabPage1,tabPage2,tabPage3};
      this->tabControl1->TabPages->AddRange( tabPages );
      this->tabControl1->Location = Point(25,75);
      this->tabControl1->Size = System::Drawing::Size( 250, 200 );
      
      // Gets the number of TabPage objects in the tabControl1 controls collection.  
      int tabCount = tabControl1->TabPages->Count;
      this->label1->Location = Point(25,25);
      this->label1->Size = System::Drawing::Size( 250, 25 );
      this->label1->Text = System::String::Concat( "The TabControl below has ", tabCount, " TabPage objects in its controls collection." );
      this->ClientSize = System::Drawing::Size( 300, 300 );
      array<Control^>^formControls = {tabControl1,label1};
      this->Controls->AddRange( formControls );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
