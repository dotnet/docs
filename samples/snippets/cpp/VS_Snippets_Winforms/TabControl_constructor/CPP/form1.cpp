

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
      
      // Invokes the TabControl() constructor to create the tabControl1 object.
      this->tabControl1 = gcnew System::Windows::Forms::TabControl;
      
      // Creates a new tab page and adds it to the tab control
      this->tabPage1 = gcnew TabPage;
      this->tabControl1->TabPages->Add( tabPage1 );
      
      // Adds the tab control to the form
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
