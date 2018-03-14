

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
public:
   Form1()
   {
      TabControl^ tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      TabPage^ tabPage2 = gcnew TabPage;
      Label^ label1 = gcnew Label;
      
      // Determines if the tabControl1 controls collection is read-only.
      if ( tabControl1->TabPages->IsReadOnly == true )
            label1->Text = "The tabControl1 controls collection is read-only.";
      else
            label1->Text = "The tabControl1 controls collection is not read-only.";

      array<TabPage^>^tabPages = {tabPage1,tabPage2};
      tabControl1->TabPages->AddRange( tabPages );
      tabControl1->Location = Point(25,75);
      tabControl1->Size = System::Drawing::Size( 250, 200 );
      label1->Location = Point(25,25);
      label1->Size = System::Drawing::Size( 250, 25 );
      this->ClientSize = System::Drawing::Size( 300, 300 );
      array<Control^>^formControls = {tabControl1,label1};
      this->Controls->AddRange( formControls );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
