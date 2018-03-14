#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace OwnerDrawnStatusBarPanel
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::StatusBar^ statusBar1;
      System::Windows::Forms::StatusBarPanel^ statusBarPanel1;
      System::Windows::Forms::StatusBarPanel^ statusBarPanel2;
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
         StatusBarPanel^ sbp = gcnew StatusBarPanel;
         sbp->Width = 100;
         sbp->Style = StatusBarPanelStyle::OwnerDraw;
         statusBar1->Panels->Add( sbp );
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
         this->statusBar1 = gcnew System::Windows::Forms::StatusBar;
         this->statusBarPanel1 = gcnew System::Windows::Forms::StatusBarPanel;
         this->statusBarPanel2 = gcnew System::Windows::Forms::StatusBarPanel;
         this->button1 = gcnew System::Windows::Forms::Button;
         ((System::ComponentModel::ISupportInitialize^)(this->statusBarPanel1))->BeginInit();
         ((System::ComponentModel::ISupportInitialize^)(this->statusBarPanel2))->BeginInit();
         this->SuspendLayout();

         //
         // statusBar1
         //
         this->statusBar1->Location = System::Drawing::Point( 0, 384 );
         this->statusBar1->Name = "statusBar1";
         array<System::Windows::Forms::StatusBarPanel^>^statusBar1panels = {this->statusBarPanel1,this->statusBarPanel2};
         this->statusBar1->Panels->AddRange( statusBar1panels );
         this->statusBar1->ShowPanels = true;
         this->statusBar1->Size = System::Drawing::Size( 536, 22 );
         this->statusBar1->TabIndex = 0;
         this->statusBar1->Text = "statusBar1";
         this->statusBar1->DrawItem += gcnew System::Windows::Forms::StatusBarDrawItemEventHandler( this, &Form1::DrawMyPanel );

         //
         // statusBarPanel1
         //
         this->statusBarPanel1->Text = "statusBarPanel1";

         //
         // statusBarPanel2
         //
         this->statusBarPanel2->Text = "statusBarPanel2";

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 336, 112 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 104, 32 );
         this->button1->TabIndex = 1;
         this->button1->Text = "button1";

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 536, 406 );
         array<System::Windows::Forms::Control^>^formControls = {this->button1,this->statusBar1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->statusBarPanel1))->EndInit();
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->statusBarPanel2))->EndInit();
         this->ResumeLayout( false );
      }

      //<Snippet1>
   private:
      void DrawMyPanel( Object^ /*sender*/, System::Windows::Forms::StatusBarDrawItemEventArgs^ sbdevent )
      {
         // Create a StringFormat object to align text in the panel.
         StringFormat^ sf = gcnew StringFormat;

         // Format the String of the StatusBarPanel to be centered.
         sf->Alignment = StringAlignment::Center;
         sf->LineAlignment = StringAlignment::Center;

         // Draw a back blackground in owner-drawn panel.
         sbdevent->Graphics->FillRectangle( Brushes::Black, sbdevent->Bounds );

         // Draw the current date (short date format) with white text in the control's font.
         sbdevent->Graphics->DrawString( DateTime::Today.ToShortDateString(), statusBar1->Font, Brushes::White, sbdevent->Bounds, sf );
      }
      //</Snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew OwnerDrawnStatusBarPanel::Form1 );
}
