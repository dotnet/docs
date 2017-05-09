

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   TabControl^ tabControl1;
   TabPage^ tabPage1;

public:
   void MyTabs()
   {
      this->tabControl1 = gcnew TabControl;
      
      // Invokes the TabPage() constructor to create the tabPage1.
      this->tabPage1 = gcnew System::Windows::Forms::TabPage;
      this->tabControl1->Controls->Add( tabPage1 );
      this->Controls->Add( tabControl1 );
   }

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
