

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

namespace TN_Checked
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::TreeView^ treeView1;
      System::Windows::Forms::Button^ button1;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;
         InitializeComponent();
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
      void InitializeComponent()
      {
         this->treeView1 = gcnew System::Windows::Forms::TreeView;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();
         
         //
         // treeView1
         //
         this->treeView1->CheckBoxes = true;
         this->treeView1->ImageIndex = -1;
         this->treeView1->Location = System::Drawing::Point( 8, 8 );
         this->treeView1->Name = "treeView1";
         array<System::Windows::Forms::TreeNode^>^temp0 = {gcnew System::Windows::Forms::TreeNode( "Node3" )};
         array<System::Windows::Forms::TreeNode^>^temp1 = {gcnew System::Windows::Forms::TreeNode( "Node2",temp0 ),gcnew System::Windows::Forms::TreeNode( "Node5" )};
         array<System::Windows::Forms::TreeNode^>^temp4 = {gcnew System::Windows::Forms::TreeNode( "Node1",temp1 )};
         array<System::Windows::Forms::TreeNode^>^temp3 = {gcnew System::Windows::Forms::TreeNode( "Node0",temp4 )};
         this->treeView1->Nodes->AddRange( temp3 );
         this->treeView1->SelectedImageIndex = -1;
         this->treeView1->TabIndex = 0;
         this->treeView1->AfterCheck += gcnew System::Windows::Forms::TreeViewEventHandler( this, &Form1::node_AfterCheck );
         this->treeView1->BeforeCheck += gcnew System::Windows::Forms::TreeViewCancelEventHandler( this, &Form1::treeView1_BeforeCheck );
         
         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 24, 128 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 72, 24 );
         this->button1->TabIndex = 1;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 200, 229 );
         array<System::Windows::Forms::Control^>^temp5 = {this->button1,this->treeView1};
         this->Controls->AddRange( temp5 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      //<snippet1>
      // Updates all child tree nodes recursively.
      void CheckAllChildNodes( TreeNode^ treeNode, bool nodeChecked )
      {
         IEnumerator^ myEnum = treeNode->Nodes->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            TreeNode^ node = safe_cast<TreeNode^>(myEnum->Current);
            node->Checked = nodeChecked;
            if ( node->Nodes->Count > 0 )
            {
               
               // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
               this->CheckAllChildNodes( node, nodeChecked );
            }
         }
      }

      // NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
      // After a tree node's Checked property is changed, all its child nodes are updated to the same value.
      void node_AfterCheck( Object^ /*sender*/, TreeViewEventArgs^ e )
      {
         // The code only executes if the user caused the checked state to change.
         if ( e->Action != TreeViewAction::Unknown )
         {
            if ( e->Node->Nodes->Count > 0 )
            {
               /* Calls the CheckAllChildNodes method, passing in the current
                   Checked value of the TreeNode whose checked state changed. */
               this->CheckAllChildNodes( e->Node, e->Node->Checked );
            }
         }
      }
      //</snippet1>

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->treeView1->Nodes[ 0 ]->Nodes[ 0 ]->Checked = true;
      }

      void treeView1_BeforeCheck( Object^ /*sender*/, System::Windows::Forms::TreeViewCancelEventArgs^ e )
      {
         MessageBox::Show( String::Concat( e->Node, "\n ", e->Action, "BeforeCheck" ) );
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew TN_Checked::Form1 );
}
