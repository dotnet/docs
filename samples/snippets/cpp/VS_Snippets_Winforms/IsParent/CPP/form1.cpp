#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace menuIsParent
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;

         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         CreateMyMainMenu();

         //
      }

   protected:

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         // 
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 276 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      }

      // <snippet1>
   public:
      void CreateMyMainMenu()
      {
         // Create two MenuItem objects and assign to array.
         MenuItem^ menuItem1 = gcnew MenuItem;
         MenuItem^ menuItem2 = gcnew MenuItem;
         menuItem1->Text = "&File";
         menuItem2->Text = "&Edit";

         // Create a MainMenu and assign MenuItem objects.
         array<MenuItem^>^menuMenu1Items = {menuItem1,menuItem2};
         MainMenu^ mainMenu1 = gcnew MainMenu( menuMenu1Items );

         // Determine whether mainMenu1 contains menu items.  
         if ( mainMenu1->IsParent )
         {
            // Set the RightToLeft property for mainMenu1.
            mainMenu1->RightToLeft = ::RightToLeft::Yes;
            
            // Bind the MainMenu to Form1.
            Menu = mainMenu1;
         }
      }
      // </snippet1>

   private:
      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew menuIsParent::Form1 );
}
