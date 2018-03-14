

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace VStyles
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;

   public:
      Form1()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->button1->Location = System::Drawing::Point( 24, 16 );
         this->button1->Size = System::Drawing::Size( 120, 100 );
         this->button1->FlatStyle = FlatStyle::System;
         this->button1->Text = "I am themed.";
         
         // Sets up how the form should be displayed and adds the controls to the form.
         this->ClientSize = System::Drawing::Size( 300, 286 );
         this->Controls->Add( this->button1 );
         this->Text = "Application::EnableVisualStyles Example";
      }

   };

}


[STAThread]
int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew VStyles::Form1 );
}

//</Snippet1>
