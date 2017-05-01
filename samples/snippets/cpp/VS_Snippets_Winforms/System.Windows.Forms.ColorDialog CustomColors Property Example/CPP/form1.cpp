

#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace WindowsApplication1
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         
         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

   public:

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
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 144, 72 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }


   protected:

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         //<snippet1>
         System::Windows::Forms::ColorDialog^ MyDialog = gcnew ColorDialog;

         // Allows the user to select or edit a custom color.
         MyDialog->AllowFullOpen = true;

         // Assigns an array of custom colors to the CustomColors property
         array<int>^temp0 = {6916092,15195440,16107657,1836924,3758726,12566463,7526079,7405793,6945974,241502,2296476,5130294,3102017,7324121,14993507,11730944};
         MyDialog->CustomColors = temp0;

         // Allows the user to get help. (The default is false.)
         MyDialog->ShowHelp = true;

         // Sets the initial color select to the current text color,
         // so that if the user cancels out, the original color is restored.
         MyDialog->Color = this->BackColor;
         MyDialog->ShowDialog();
         this->BackColor = MyDialog->Color;
         //</snippet1>

         // Print the custom colors if the user has changed them.
         PrintCustomColors( MyDialog->CustomColors );
      }

   private:
      void PrintCustomColors( array<int>^clrs )
      {
         TextWriter^ writer = gcnew StreamWriter( "colors.txt" );
         {
            IEnumerator^ myEnum = clrs->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               int i = safe_cast<int>(myEnum->Current);
               writer->WriteLine( i );
            }
         }
         writer->Close();
      }

      //      private:
      // int AddCustomColors() __gc[]
      // {
      //         return new int[] {6916092,
      //                            15195440,
      //                            16107657,
      //                            1836924,
      //                            3758726,
      //                            12566463,
      //                            7526079,
      //                            7405793,
      //                            6945974,
      //                            241502,
      //                            2296476,
      //                            5130294,
      //                            3102017,
      //                            7324121,
      //                            14993507,
      //                            11730944,
      //         };
      //      }
   };
}


[STAThread]
int main()
{
   Application::Run( gcnew WindowsApplication1::Form1 );
}
