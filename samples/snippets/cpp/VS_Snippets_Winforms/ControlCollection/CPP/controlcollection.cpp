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

namespace Controls
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ addButton;
      System::Windows::Forms::Button^ removeButton;
      System::Windows::Forms::Button^ clearButton;
      System::Windows::Forms::Button^ addRangeButton;
      System::Windows::Forms::Panel^ panel1;
      System::Windows::Forms::Button^ removeAtButton;

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
         this->panel1 = gcnew System::Windows::Forms::Panel;
         this->addRangeButton = gcnew System::Windows::Forms::Button;
         this->removeAtButton = gcnew System::Windows::Forms::Button;
         this->addButton = gcnew System::Windows::Forms::Button;
         this->removeButton = gcnew System::Windows::Forms::Button;
         this->clearButton = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         // 
         // panel1
         // 
         this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
         this->panel1->Location = System::Drawing::Point( 8, 8 );
         this->panel1->Name = "panel1";
         this->panel1->Size = System::Drawing::Size( 168, 112 );
         this->panel1->TabIndex = 5;

         // 
         // addRangeButton
         //
         this->addRangeButton->Location = System::Drawing::Point( 8, 168 );
         this->addRangeButton->Name = "addRangeButton";
         this->addRangeButton->TabIndex = 4;
         this->addRangeButton->Text = "AddRange";
         this->addRangeButton->Click += gcnew System::EventHandler( this, &Form1::addRangeButton_Click );

         // 
         // removeAtButton
         //
         this->removeAtButton->Location = System::Drawing::Point( 96, 168 );
         this->removeAtButton->Name = "removeAtButton";
         this->removeAtButton->TabIndex = 6;
         this->removeAtButton->Text = "RemoveAt";
         this->removeAtButton->Click += gcnew System::EventHandler( this, &Form1::removeAtButton_Click );

         // 
         // addButton
         //
         this->addButton->Location = System::Drawing::Point( 8, 136 );
         this->addButton->Name = "addButton";
         this->addButton->TabIndex = 0;
         this->addButton->Text = "Add";
         this->addButton->Click += gcnew System::EventHandler( this, &Form1::addButton_Click );

         // 
         // removeButton
         //
         this->removeButton->Location = System::Drawing::Point( 96, 136 );
         this->removeButton->Name = "removeButton";
         this->removeButton->TabIndex = 2;
         this->removeButton->Text = "Remove";
         this->removeButton->Click += gcnew System::EventHandler( this, &Form1::removeButton_Click );

         // 
         // clearButton
         //
         this->clearButton->Location = System::Drawing::Point( 96, 200 );
         this->clearButton->Name = "clearButton";
         this->clearButton->TabIndex = 3;
         this->clearButton->Text = "Clear";
         this->clearButton->Click += gcnew System::EventHandler( this, &Form1::clearButton_Click );

         // 
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 184, 229 );
         array<System::Windows::Forms::Control^>^formControlsArray = {this->removeAtButton,this->panel1,this->addRangeButton,this->clearButton,this->removeButton,this->addButton};
         this->Controls->AddRange( formControlsArray );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      //<snippet3>        
      // Create two RadioButtons to add to the Panel.
   private:
      RadioButton^ radioAddButton;
      RadioButton^ radioRemoveButton;

      // Add controls to the Panel using the AddRange method.
      void addRangeButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         radioAddButton = gcnew RadioButton;
         radioRemoveButton = gcnew RadioButton;
         
         // Set the Text the RadioButtons will display.
         radioAddButton->Text = "radioAddButton";
         radioRemoveButton->Text = "radioRemoveButton";
         
         // Set the appropriate location of radioRemoveButton.
         radioRemoveButton->Location = System::Drawing::Point( radioAddButton->Location.X, radioAddButton->Location.Y + radioAddButton->Height );
         
         //Add the controls to the Panel.
         array<Control^>^controlArray = {radioAddButton,radioRemoveButton};
         panel1->Controls->AddRange( controlArray );
      }
      //</snippet3>

      //<snippet2>
      // Create a TextBox to add to the Panel.
   private:
      TextBox^ textBox1;

      // Add controls to the Panel using the Add method.
      void addButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         textBox1 = gcnew TextBox;
         panel1->Controls->Add( textBox1 );
      }
      //</snippet2>

      //<snippet1>
      // Clear all the controls in the Panel.
   private:
      void clearButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         panel1->Controls->Clear();
      }
      //</snippet1>

      //<snippet5>
      // Remove the first control in the collection.
   private:
      void removeAtButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( panel1->Controls->Count > 0 )
         {
            panel1->Controls->RemoveAt( 0 );
         }
      }
      //</snippet5>

      //<snippet4>    
      // Remove the RadioButton control if it exists.
   private:
      void removeButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( panel1->Controls->Contains( removeButton ) )
         {
            panel1->Controls->Remove( removeButton );
         }
      }
      //</snippet4>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
void main()
{
   Application::Run( gcnew Controls::Form1 );
}
