

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      ChangeTheLookOfTheTabControl();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::TabControl^ TabControl1;
   System::Windows::Forms::TabPage^ TabPage1;
   System::Windows::Forms::TabPage^ TabPage2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->TabControl1 = gcnew System::Windows::Forms::TabControl;
      this->TabPage1 = gcnew System::Windows::Forms::TabPage;
      this->TabPage2 = gcnew System::Windows::Forms::TabPage;
      this->TabControl1->SuspendLayout();
      this->SuspendLayout();
      
      //
      //TabControl1
      //
      this->TabControl1->Controls->Add( this->TabPage1 );
      this->TabControl1->Controls->Add( this->TabPage2 );
      this->TabControl1->Location = System::Drawing::Point( 0, 0 );
      this->TabControl1->Name = "TabControl1";
      this->TabControl1->SelectedIndex = 0;
      this->TabControl1->TabIndex = 0;
      
      //
      //TabPage1
      //
      this->TabPage1->Location = System::Drawing::Point( 4, 22 );
      this->TabPage1->Name = "TabPage1";
      this->TabPage1->Size = System::Drawing::Size( 192, 74 );
      this->TabPage1->TabIndex = 0;
      this->TabPage1->Text = "Errors";
      
      //
      //TabPage2
      //
      this->TabPage2->Location = System::Drawing::Point( 4, 22 );
      this->TabPage2->Name = "TabPage2";
      this->TabPage2->Size = System::Drawing::Size( 192, 74 );
      this->TabPage2->TabIndex = 1;
      this->TabPage2->Text = "Failures";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 296, 294 );
      this->Controls->Add( this->TabControl1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->TabControl1->ResumeLayout( false );
      this->ResumeLayout( false );
   }

   //<snippet1>
private:
   void ChangeTheLookOfTheTabControl()
   {
      // Set the size and location of the TabControl.
      this->TabControl1->Location = System::Drawing::Point( 20, 20 );
      TabControl1->Size = System::Drawing::Size( 250, 250 );
      
      // Align the tabs along the bottom of the control.
      TabControl1->Alignment = TabAlignment::Bottom;
      
      // Change the tabs to flat buttons.
      TabControl1->Appearance = TabAppearance::FlatButtons;
   }
   //</snippet1>
};


[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
