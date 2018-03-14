

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
   void MyTabs()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->tabPage2 = gcnew TabPage;
      this->tabPage3 = gcnew TabPage;
      
      // Positions tabs on the left side of tabControl1.
      this->tabControl1->Alignment = System::Windows::Forms::TabAlignment::Left;
      array<Control^>^tabControls = {this->tabPage1,this->tabPage2,this->tabPage3};
      this->tabControl1->Controls->AddRange( tabControls );
      this->tabControl1->Location = Point(16,24);
      this->tabControl1->SelectedIndex = 0;
      this->tabControl1->Size = System::Drawing::Size( 248, 232 );
      this->tabControl1->TabIndex = 0;
      this->tabPage1->TabIndex = 0;
      this->tabPage2->TabIndex = 1;
      this->tabPage3->TabIndex = 2;
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
