

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
      this->tabPage1 = gcnew TabPage;
      array<Control^>^tabControl1Controls = {this->tabPage1};
      this->tabControl1->Controls->AddRange( tabControl1Controls );
      this->tabControl1->Location = Point(25,25);
      this->tabControl1->Size = System::Drawing::Size( 250, 250 );
      
      // Displays a string, myTabPage, on tabPage1.
      this->tabPage1->Text = "myTabPage";
      this->ClientSize = System::Drawing::Size( 300, 300 );
      array<Control^>^formControls = {this->tabControl1};
      this->Controls->AddRange( formControls );
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
