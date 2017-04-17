

// System::Windows::Forms::TreeNode::Expand()
// System::Windows::Forms::TreeNode::Collapse()
// System::Windows::Forms::TreeNode::EnsureVisible()
// System::Windows::Forms::TreeNode::Clone()
/* The following program demonstrates 'Expand', 'Collapse',
'EnsureVisible' and 'Clone' methods of 'System::Windows::Forms::TreeNode'
class. It creates a TreeView, adds 10 TreeNode objects to it and
expands node1, collapses node1 and makes a clone to Node 9 and add it to Node7. */
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

namespace MyTreeNode
{
   // Define a Customer Class.
   public ref class Customer
   {
   public:
      String^ myCustomerName;
      ArrayList^ MyOrders;
      Customer( String^ name )
      {
         MyOrders = gcnew ArrayList;
         myCustomerName = name;
      }
   };


   // Define an Order Class which will be associated to a customer.
   public ref class Order
   {
   public:
      String^ myOrderName;
      Order( String^ name1 )
      {
         myOrderName = name1;
      }

   };

   public ref class Form1: public Form
   {
   private:
      TreeView^ treeView1;
      ArrayList^ myCustomerList;
      Button^ button1;
      Button^ button2;
      Button^ button3;
      Button^ button4;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         myCustomerList = gcnew ArrayList;
         components = nullptr;
         
         // Required for Windows Form Designer support.
         InitializeComponent();
         AddTreeNode();
      }

   protected:
      // Clean up any resources being used.
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:

      // Required method for Designer support.
      void InitializeComponent()
      {
         this->treeView1 = gcnew TreeView;
         this->button1 = gcnew Button;
         this->button2 = gcnew Button;
         this->button3 = gcnew Button;
         this->button4 = gcnew Button;
         this->SuspendLayout();
         this->treeView1->ImageIndex = -1;
         this->treeView1->Location = Point(32,48);
         this->treeView1->Name = "treeView1";
         this->treeView1->SelectedImageIndex = -1;
         this->treeView1->Size = System::Drawing::Size( 168, 96 );
         this->treeView1->TabIndex = 0;
         this->button1->Location = Point(40,160);
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 160, 23 );
         this->button1->TabIndex = 1;
         this->button1->Text = "Expand Customer1 Node";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         this->button2->Location = Point(40,185);
         this->button2->Name = "button2";
         this->button2->Size = System::Drawing::Size( 160, 23 );
         this->button2->TabIndex = 2;
         this->button2->Text = "Collapse Customer1 Node";
         this->button3->Location = Point(40,210);
         this->button3->Name = "button3";
         this->button3->Size = System::Drawing::Size( 160, 23 );
         this->button3->TabIndex = 3;
         this->button3->Text = "EnsureVisible Order7 Node";
         this->button3->Click += gcnew System::EventHandler( this, &Form1::button3_Click );
         this->button4->Location = Point(40,235);
         this->button4->Name = "button4";
         this->button4->Size = System::Drawing::Size( 160, 23 );
         this->button4->TabIndex = 4;
         this->button4->Text = "Clone Customer9 Node";
         this->button4->Click += gcnew System::EventHandler( this, &Form1::button4_Click );
         this->ClientSize = System::Drawing::Size( 240, 273 );
         array<Control^>^temp0 = {this->button4,this->button3,this->button2,this->button1,this->treeView1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Demonstrating TreeNode members";
         this->ResumeLayout( false );
      }

      // Add TreeNode to the TreeView.
      void AddTreeNode()
      {
         // Add customers to ArrayList of Customer objects.
         for ( int i = 1; i < 11; i++ )
         {
            myCustomerList->Add( gcnew Customer( String::Concat( "Customer ", i ) ) );

         }
         
         // Add orders to each Customer Object* in the ArrayList.
         int x = 1;
         IEnumerator^ myEnum = myCustomerList->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Customer^ Customer1 = safe_cast<Customer^>(myEnum->Current);
            Customer1->MyOrders->Add( gcnew Order( String::Concat( "Order ", x ) ) );
            x++;
         }

         
         // Prevent repainting of TreeView until all objects have been created.
         treeView1->BeginUpdate();
         
         // Clear the TreeView each time the method is called.
         treeView1->Nodes->Clear();
         
         // Add a root TreeNode for each Customer Object* in the ArrayList.
         while ( myEnum->MoveNext() )
         {
            Customer^ Customer2 = safe_cast<Customer^>(myEnum->Current);
            treeView1->Nodes->Add( gcnew TreeNode( Customer2->myCustomerName ) );
            
            // Add a child TreeNode to each Customer TreeNode.
            IEnumerator^ myEnum = Customer2->MyOrders->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               Order^ Order2 = safe_cast<Order^>(myEnum->Current);
               treeView1->Nodes[ myCustomerList->IndexOf( Customer2 ) ]->Nodes->Add( gcnew TreeNode( Order2->myOrderName ) );
            }
         }
      }

      // <Snippet1>
      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         if ( treeView1->SelectedNode->IsExpanded )
         {
            treeView1->SelectedNode->Collapse();
            MessageBox::Show( String::Concat( treeView1->SelectedNode->Text, " tree node collapsed." ) );
         }
         else
         {
            treeView1->SelectedNode->Expand();
            MessageBox::Show( String::Concat( treeView1->SelectedNode->Text, " tree node expanded." ) );
         }
      }
      // </Snippet1>

      // <Snippet2>
      void button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         TreeNode^ lastNode = treeView1->Nodes[ treeView1->Nodes->Count - 1 ]->Nodes[ treeView1->Nodes[ treeView1->Nodes->Count - 1 ]->Nodes->Count - 1 ];
         if (  !lastNode->IsVisible )
         {
            lastNode->EnsureVisible();
            MessageBox::Show( String::Concat( lastNode->Text, " tree node is visible." ) );
         }
      }
      // </Snippet2>

      // <Snippet3>
      void button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         TreeNode^ lastNode = treeView1->Nodes[ treeView1->Nodes->Count - 1 ]->Nodes[ treeView1->Nodes[ treeView1->Nodes->Count - 1 ]->Nodes->Count - 1 ];
         
         // Clone the last child node.
         TreeNode^ clonedNode = dynamic_cast<TreeNode^>(lastNode->Clone());
         
         // Insert the cloned node as the first root node.
         treeView1->Nodes->Insert( 0, clonedNode );
         MessageBox::Show( String::Concat( lastNode->Text, " tree node cloned and added to ", treeView1->Nodes[ 0 ]->Text ) );
      }

      // </Snippet3>
   };
}


// The main entry point for the application.
int main()
{
   Application::Run( gcnew MyTreeNode::Form1 );
}
