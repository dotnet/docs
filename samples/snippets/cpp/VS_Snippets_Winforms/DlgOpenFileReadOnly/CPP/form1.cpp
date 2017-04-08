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
using namespace System::IO;

namespace DlgOpenFileReadOnly_CS
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
         // TODO: Add any constructor code after InitializeComponent call
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
         this->ClientSize = System::Drawing::Size( 292, 273 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      }

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         OpenFile();
      }

      //<snippet1>
   private:
      FileStream^ OpenFile()
      {
         // Displays an OpenFileDialog and shows the read/only files.
         OpenFileDialog^ dlgOpenFile = gcnew OpenFileDialog;
         dlgOpenFile->ShowReadOnly = true;
         if ( dlgOpenFile->ShowDialog() == ::DialogResult::OK )
         {
            // If ReadOnlyChecked is true, uses the OpenFile method to
            // open the file with read/only access.
            if ( dlgOpenFile->ReadOnlyChecked == true )
            {
               return dynamic_cast<FileStream^>(dlgOpenFile->OpenFile());
            }
            // Otherwise, opens the file with read/write access.
            else
            {
               String^ path = dlgOpenFile->FileName;
               return gcnew FileStream( path,System::IO::FileMode::Open,System::IO::FileAccess::ReadWrite );
            }
         }

         return nullptr;
      }
      //</snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew DlgOpenFileReadOnly_CS::Form1 );
}
