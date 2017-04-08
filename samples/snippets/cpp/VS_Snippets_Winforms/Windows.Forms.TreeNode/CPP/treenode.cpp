

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace Foo
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::TreeView^ treeView1;
      System::Windows::Forms::StatusBar^ statusBar1;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
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
         this->statusBar1 = gcnew System::Windows::Forms::StatusBar;
         this->SuspendLayout();

         //
         // treeView1
         //
         this->treeView1->ImageIndex = -1;
         this->treeView1->Location = System::Drawing::Point( 8, 8 );
         this->treeView1->Name = "treeView1";
         array<System::Windows::Forms::TreeNode^>^temp0 = {gcnew System::Windows::Forms::TreeNode( "Node5" )};
         array<System::Windows::Forms::TreeNode^>^temp1 = {gcnew System::Windows::Forms::TreeNode( "Node4",temp0 )};
         array<System::Windows::Forms::TreeNode^>^temp2 = {gcnew System::Windows::Forms::TreeNode( "Node3",temp1 )};
         array<System::Windows::Forms::TreeNode^>^temp3 = {gcnew System::Windows::Forms::TreeNode( "Node8" )};
         array<System::Windows::Forms::TreeNode^>^temp4 = {gcnew System::Windows::Forms::TreeNode( "Node7",temp3 )};
         array<System::Windows::Forms::TreeNode^>^temp5 = {gcnew System::Windows::Forms::TreeNode( "Node6",temp4 )};
         array<System::Windows::Forms::TreeNode^>^temp6 = {gcnew System::Windows::Forms::TreeNode( "Node11" )};
         array<System::Windows::Forms::TreeNode^>^temp7 = {gcnew System::Windows::Forms::TreeNode( "Node10",temp6 )};
         array<System::Windows::Forms::TreeNode^>^temp8 = {gcnew System::Windows::Forms::TreeNode( "Node9",temp7 )};
         array<System::Windows::Forms::TreeNode^>^temp9 = {gcnew System::Windows::Forms::TreeNode( "Node0",temp2 ),gcnew System::Windows::Forms::TreeNode( "Node1",temp5 ),gcnew System::Windows::Forms::TreeNode( "Node2",temp8 )};
         this->treeView1->Nodes->AddRange( temp9 );
         this->treeView1->SelectedImageIndex = -1;
         this->treeView1->Size = System::Drawing::Size( 128, 144 );
         this->treeView1->TabIndex = 0;
         this->treeView1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::treeView1_MouseDown );
         this->treeView1->AfterCollapse += gcnew System::Windows::Forms::TreeViewEventHandler( this, &Form1::treeView1_AfterCollapse );
         this->treeView1->AfterSelect += gcnew System::Windows::Forms::TreeViewEventHandler( this, &Form1::treeView1_AfterSelect );

         //
         // statusBar1
         //
         this->statusBar1->Location = System::Drawing::Point( 0, 247 );
         this->statusBar1->Name = "statusBar1";
         this->statusBar1->Size = System::Drawing::Size( 256, 22 );
         this->statusBar1->TabIndex = 2;
         this->statusBar1->Text = "statusBar1";

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 256, 269 );
         array<System::Windows::Forms::Control^>^temp10 = {this->statusBar1,this->treeView1};
         this->Controls->AddRange( temp10 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      // <snippet1>
   private:
      void treeView1_MouseDown( Object^ /*sender*/, MouseEventArgs^ e )
      {
         switch ( e->Button )
         {
            // Remove the TreeNode under the mouse cursor
            // if the right mouse button was clicked.
            case ::MouseButtons::Right:
               treeView1->GetNodeAt( e->X, e->Y )->Remove();
               break;

            // Toggle the TreeNode under the mouse cursor
            // if the middle mouse button (mouse wheel) was clicked.
            case ::MouseButtons::Middle:
               treeView1->GetNodeAt( e->X, e->Y )->Toggle();
               break;
         }
      }
      // </snippet1>

      //<snippet2>
   private:
      void treeView1_AfterSelect( Object^ /*sender*/, TreeViewEventArgs^ e )
      {
         /* Display the Text and Index of the
               * selected tree node's Parent. */
         if ( e->Node->Parent != nullptr && e->Node->Parent->GetType() == TreeNode::typeid )
         {
            statusBar1->Text = String::Format( "Parent: {0}\n Index Position: {1}", e->Node->Parent->Text, e->Node->Parent->Index );
         }
         else
         {
            statusBar1->Text = "No parent node.";
         }
      }
      // </snippet2>

      // <snippet3>
   private:
      void treeView1_AfterCollapse( Object^ /*sender*/, TreeViewEventArgs^ e )
      {
         // Create a copy of the e.Node from its Handle.
         TreeNode^ tn = TreeNode::FromHandle( e->Node->TreeView, e->Node->Handle );
         tn->Text = String::Concat( tn->Text, "Copy" );

         // Remove the e.Node so it can be replaced with tn.
         e->Node->Remove();

         // Add tn to the TreeNodeCollection.
         treeView1->Nodes->Add( tn );
      }
      // </snippet3>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew Foo::Form1 );
}
