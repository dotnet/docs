

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
   void MyTabs()
   {
      this->tabControl1 = gcnew TabControl;
      System::String^ tabPageName = "myTabPage";
      
      // Constructs a TabPage with a TabPage::Text value.
      this->tabPage1 = gcnew TabPage( tabPageName );
      this->tabControl1->Controls->Add( tabPage1 );
      this->tabControl1->Location = Point(25,25);
      this->tabControl1->Size = System::Drawing::Size( 250, 250 );
      this->ClientSize = System::Drawing::Size( 300, 300 );
      this->Controls->Add( tabControl1 );
   }


public:
   Form1()
   {
      MyTabs();
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
