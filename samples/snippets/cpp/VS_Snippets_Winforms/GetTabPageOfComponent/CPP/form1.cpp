

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   TabControl^ tabControl1;
   TabPage^ tabPage1;
   TabPage^ tabPage2;
   Button^ button1;
   Button^ button2;
   void InitializeMyTabs()
   {
      tabControl1 = gcnew System::Windows::Forms::TabControl;
      tabPage1 = gcnew System::Windows::Forms::TabPage;
      tabPage2 = gcnew System::Windows::Forms::TabPage;
      button1 = gcnew System::Windows::Forms::Button;
      button2 = gcnew System::Windows::Forms::Button;
      array<System::Windows::Forms::Control^>^tabControls = {tabPage1,tabPage2};
      tabControl1->Controls->AddRange( tabControls );
      tabControl1->Location = System::Drawing::Point( 40, 24 );
      tabControl1->Size = System::Drawing::Size( 216, 216 );
      tabControl1->TabIndex = 0;
      array<System::Windows::Forms::Control^>^tabPage1Controls = {button1};
      tabPage1->Controls->AddRange( tabPage1Controls );
      tabPage1->TabIndex = 0;
      array<System::Windows::Forms::Control^>^tabPage2Controls = {button2};
      tabPage2->Controls->AddRange( tabPage2Controls );
      tabPage2->TabIndex = 1;
      button1->Location = System::Drawing::Point( 64, 72 );
      button2->Location = System::Drawing::Point( 64, 72 );
      button2->Text = "button2";
      ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^formControls = {tabControl1};
      Controls->AddRange( formControls );
      
      // Gets the index of the TabPage containing button2.
      // Selects the index of the TabPage containing button2.
      tabControl1->SelectedIndex = (TabPage::GetTabPageOfComponent( button2 ))->TabIndex;
   }


public:
   Form1()
   {
      InitializeMyTabs();
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
