

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   TabControl^ tabControl1;
   TabPage^ tabPage1;
   TabPage^ tabPage2;
   void MyTabs()
   {
      this->tabControl1 = gcnew TabControl;
      this->tabPage1 = gcnew TabPage;
      this->tabPage2 = gcnew TabPage;
      array<Control^>^tabControls = {this->tabPage1,this->tabPage2};
      this->tabControl1->Controls->AddRange( tabControls );
      this->tabControl1->Padding = Point(15,10);
      this->tabControl1->Location = Point(35,25);
      this->tabControl1->Size = System::Drawing::Size( 220, 220 );
      
      // Selects tabPage2 using SelectedIndex.
      this->tabControl1->SelectedIndex = 1;
      this->tabPage1->Text = "myTabPage1";
      this->tabPage1->TabIndex = 0;
      this->tabPage2->Text = "myTabPage2";
      this->tabPage2->TabIndex = 1;
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
