

#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

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
      this->tabControl1->Multiline = true;
      array<Control^>^temp0 = {this->tabPage1,this->tabPage2};
      this->tabControl1->Controls->AddRange( temp0 );
      this->tabControl1->Location = Point(35,25);
      this->tabControl1->Size = System::Drawing::Size( 220, 220 );
      
      // Creates a cushion of 22 pixels around TabPage.Text strings.
      this->tabControl1->Padding = System::Drawing::Point( 22, 22 );
      this->tabPage1->Text = "myTabPage1";
      this->tabPage2->Text = "myTabPage2";
      this->Size = System::Drawing::Size( 300, 300 );
      array<Control^>^temp1 = {this->tabControl1};
      this->Controls->AddRange( temp1 );
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
