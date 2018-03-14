

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
      this->tabControl1->Controls->Add( tabPage1 );
      this->tabControl1->Location = Point(25,25);
      this->tabControl1->Size = System::Drawing::Size( 250, 250 );
      this->tabControl1->ShowToolTips = true;
      this->tabPage1->Text = "myTabPage1";
      
      // Creates a string showing the Text value for tabPage1. 
      // Then assigns the string to ToolTipText.  
      this->tabPage1->ToolTipText = tabPage1->ToString();
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
