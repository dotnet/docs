

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

   // Declares tabPage1 as a TabPage type.
   System::Windows::Forms::TabPage^ tabPage1;
   void MyTabs()
   {
      this->tabControl1 = gcnew TabControl;
      
      // Invokes the TabPage() constructor to create the tabPage1.
      this->tabPage1 = gcnew System::Windows::Forms::TabPage;
      array<Control^>^tabControls = {this->tabPage1};
      this->tabControl1->Controls->AddRange( tabControls );
      this->tabControl1->Location = Point(25,25);
      this->tabControl1->Size = System::Drawing::Size( 250, 250 );
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
