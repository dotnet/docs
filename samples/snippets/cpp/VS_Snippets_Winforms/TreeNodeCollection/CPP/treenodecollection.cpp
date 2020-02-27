

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

namespace ToolBarStuff
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::TreeView^ treeView1;
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::TreeView^ treeView2;
      System::Windows::Forms::Button^ button2;

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
      /// Required method for Designer support; do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->treeView1 = gcnew System::Windows::Forms::TreeView;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->treeView2 = gcnew System::Windows::Forms::TreeView;
         this->button2 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();
         
         //
         // treeView1
         //
         this->treeView1->ImageIndex = -1;
         this->treeView1->Location = System::Drawing::Point( 8, 8 );
         this->treeView1->Name = "treeView1";
         array<System::Windows::Forms::TreeNode^>^temp0 = {gcnew System::Windows::Forms::TreeNode( "Node5" ),gcnew System::Windows::Forms::TreeNode( "Node6" ),gcnew System::Windows::Forms::TreeNode( "Node7" )};
         array<System::Windows::Forms::TreeNode^>^temp1 = {gcnew System::Windows::Forms::TreeNode( "Node8" ),gcnew System::Windows::Forms::TreeNode( "Node9" ),gcnew System::Windows::Forms::TreeNode( "Node10" )};
         array<System::Windows::Forms::TreeNode^>^temp2 = {gcnew System::Windows::Forms::TreeNode( "Node11" ),gcnew System::Windows::Forms::TreeNode( "Node12" ),gcnew System::Windows::Forms::TreeNode( "Node13" )};
         array<System::Windows::Forms::TreeNode^>^temp3 = {gcnew System::Windows::Forms::TreeNode( "Node15" )};
         array<System::Windows::Forms::TreeNode^>^temp4 = {gcnew System::Windows::Forms::TreeNode( "Node14",temp3 ),gcnew System::Windows::Forms::TreeNode( "Node16" ),gcnew System::Windows::Forms::TreeNode( "Node17" )};
         array<System::Windows::Forms::TreeNode^>^temp5 = {gcnew System::Windows::Forms::TreeNode( "Node21" )};
         array<System::Windows::Forms::TreeNode^>^temp6 = {gcnew System::Windows::Forms::TreeNode( "Node20",temp5 )};
         array<System::Windows::Forms::TreeNode^>^temp7 = {gcnew System::Windows::Forms::TreeNode( "Node19",temp6 )};
         array<System::Windows::Forms::TreeNode^>^temp8 = {gcnew System::Windows::Forms::TreeNode( "Node18",temp7 )};
         array<System::Windows::Forms::TreeNode^>^temp9 = {gcnew System::Windows::Forms::TreeNode( "Node0",temp0 ),gcnew System::Windows::Forms::TreeNode( "Node1",temp1 ),gcnew System::Windows::Forms::TreeNode( "Node2",temp2 ),gcnew System::Windows::Forms::TreeNode( "Node3",temp4 ),gcnew System::Windows::Forms::TreeNode( "Node4",temp8 )};
         this->treeView1->Nodes->AddRange( temp9 );
         this->treeView1->SelectedImageIndex = -1;
         this->treeView1->Size = System::Drawing::Size( 128, 224 );
         this->treeView1->TabIndex = 0;
         
         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 8, 240 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 1;
         this->button1->Text = "Move ->";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         
         //
         // treeView2
         //
         this->treeView2->ImageIndex = -1;
         this->treeView2->Location = System::Drawing::Point( 144, 8 );
         this->treeView2->Name = "treeView2";
         this->treeView2->SelectedImageIndex = -1;
         this->treeView2->Size = System::Drawing::Size( 144, 224 );
         this->treeView2->TabIndex = 2;
         
         //
         // button2
         //
         this->button2->Location = System::Drawing::Point( 192, 240 );
         this->button2->Name = "button2";
         this->button2->Size = System::Drawing::Size( 96, 23 );
         this->button2->TabIndex = 3;
         this->button2->Text = "Delete [0] Node";
         this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp10 = {this->button2,this->treeView2,this->button1,this->treeView1};
         this->Controls->AddRange( temp10 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      // <snippet1>
      void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // If neither TreeNodeCollection is read-only, move the
         // selected node from treeView1 to treeView2.
         if (  !treeView1->Nodes->IsReadOnly &&  !treeView2->Nodes->IsReadOnly )
         {
            if ( treeView1->SelectedNode != nullptr )
            {
               TreeNode^ tn = treeView1->SelectedNode;
               treeView1->Nodes->Remove( tn );
               treeView2->Nodes->Insert( treeView2->Nodes->Count, tn );
            }
         }
      }
      // </snippet1>

      // <snippet2>
      void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Delete the first TreeNode in the collection
         // if the Text property is S"Node0."
         if ( this->treeView1->Nodes[ 0 ]->Text->Equals( "Node0" ) )
         {
            this->treeView1->Nodes->RemoveAt( 0 );
         }
      }
      // </snippet2>
   };
}


/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew ToolBarStuff::Form1 );
}
