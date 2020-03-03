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
using namespace System::Text;

namespace ListViewAfterLabelEditEx
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::ListView^ listView1;

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
         array<System::Windows::Forms::ListViewItem::ListViewSubItem^>^temp1 = {gcnew System::Windows::Forms::ListViewItem::ListViewSubItem( nullptr,"Item A",System::Drawing::SystemColors::WindowText,System::Drawing::SystemColors::Window,gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Regular,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) ) )};
         System::Windows::Forms::ListViewItem^ listViewItem1 = gcnew System::Windows::Forms::ListViewItem( temp1,-1 );
         array<System::Windows::Forms::ListViewItem::ListViewSubItem^>^temp2 = {gcnew System::Windows::Forms::ListViewItem::ListViewSubItem( nullptr,"Item B",System::Drawing::SystemColors::WindowText,System::Drawing::SystemColors::Window,gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Regular,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) ) )};
         System::Windows::Forms::ListViewItem^ listViewItem2 = gcnew System::Windows::Forms::ListViewItem( temp2,-1 );
         array<System::Windows::Forms::ListViewItem::ListViewSubItem^>^temp3 = {gcnew System::Windows::Forms::ListViewItem::ListViewSubItem( nullptr,"Item C",System::Drawing::SystemColors::WindowText,System::Drawing::SystemColors::Window,gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Regular,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) ) )};
         System::Windows::Forms::ListViewItem^ listViewItem3 = gcnew System::Windows::Forms::ListViewItem( temp3,-1 );
         array<System::Windows::Forms::ListViewItem::ListViewSubItem^>^temp4 = {gcnew System::Windows::Forms::ListViewItem::ListViewSubItem( nullptr,"Item D",System::Drawing::SystemColors::WindowText,System::Drawing::SystemColors::Window,gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Regular,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) ) )};
         System::Windows::Forms::ListViewItem^ listViewItem4 = gcnew System::Windows::Forms::ListViewItem( temp4,-1 );
         this->listView1 = gcnew System::Windows::Forms::ListView;
         this->SuspendLayout();

         //
         // listView1
         //
         array<System::Windows::Forms::ListViewItem^>^temp0 = {listViewItem1,listViewItem2,listViewItem3,listViewItem4};
         this->listView1->Items->AddRange( temp0 );
         this->listView1->LabelEdit = true;
         this->listView1->Location = System::Drawing::Point( 16, 24 );
         this->listView1->Name = "listView1";
         this->listView1->Size = System::Drawing::Size( 424, 328 );
         this->listView1->TabIndex = 0;
         this->listView1->AfterLabelEdit += gcnew System::Windows::Forms::LabelEditEventHandler( this, &Form1::MyListView_AfterLabelEdit );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 464, 422 );
         array<System::Windows::Forms::Control^>^temp5 = {this->listView1};
         this->Controls->AddRange(temp5);
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      //<Snippet1>
   private:
      void MyListView_AfterLabelEdit( Object^ /*sender*/, System::Windows::Forms::LabelEditEventArgs^ e )
      {
         // Determine if label is changed by checking for 0.
         if ( e->Label == nullptr )
                  return;

         // ASCIIEncoding is used to determine if a number character has been entered.
         ASCIIEncoding^ AE = gcnew ASCIIEncoding;

         // Convert the new label to a character array.
         array<Char>^temp = e->Label->ToCharArray();

         // Check each character in the new label to determine if it is a number.
         for ( int x = 0; x < temp->Length; x++ )
         {
            // Encode the character from the character array to its ASCII code.
            array<Byte>^bc = AE->GetBytes( temp[ x ].ToString() );

            // Determine if the ASCII code is within the valid range of numerical values.
            if ( bc[ 0 ] > 47 && bc[ 0 ] < 58 )
            {
               // Cancel the event and return the lable to its original state.
               e->CancelEdit = true;

               // Display a MessageBox alerting the user that numbers are not allowed.
               MessageBox::Show( "The text for the item cannot contain numerical values." );

               // Break out of the loop and exit.
               return;
            }
         }
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
   Application::Run( gcnew ListViewAfterLabelEditEx::Form1 );
}
