

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
   TabPage^ tabPage4;
   void MyTabs()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->tabPage2 = gcnew TabPage;
      this->tabPage3 = gcnew TabPage;
      this->tabPage4 = gcnew TabPage;
      
      // Allows more than one row of tabs.
      this->tabControl1->Multiline = true;
      this->tabControl1->Padding = Point(22,5);
      array<Control^>^tabControls = {this->tabPage1,this->tabPage2,this->tabPage3,this->tabPage4};
      this->tabControl1->Controls->AddRange( tabControls );
      this->tabControl1->Location = Point(35,25);
      this->tabControl1->Size = System::Drawing::Size( 220, 220 );
      this->tabPage1->Text = "myTabPage1";
      this->tabPage2->Text = "myTabPage2";
      this->tabPage3->Text = "myTabPage3";
      this->tabPage4->Text = "myTabPage4";
      this->Size = System::Drawing::Size( 300, 300 );
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
