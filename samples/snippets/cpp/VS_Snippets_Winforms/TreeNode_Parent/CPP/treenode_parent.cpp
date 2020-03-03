

// System::Windows::Forms::TreeNode::PrevVisibleNode
// System::Windows::Forms::TreeNode::PrevNode
// System::Windows::Forms::TreeNode::NextVisibleNode
// System::Windows::Forms::TreeNode::NextNode
// System::Windows::Forms::TreeNode::LastNode
// System::Windows::Forms::TreeNode::FirstNode
// System::Windows::Forms::TreeNode::TreeView
// System::Windows::Forms::TreeNode::IsSelected
/*
The following program demonstrates the 'NodeFont', 'Parent', 'Text' and 'PrevVisibleNode'
properties of the 'TreeNode' class. It creates a TreeView consisting of customer nodes
and 'order' as its child nodes. It also provides option for the user to change the font
and text of the node.
*/
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
public ref class MyCustomerClass
{
public:
   ArrayList^ CustomerOrders;
   String^ CustomerName;
   MyCustomerClass( String^ name )
   {
      CustomerName = name;
      CustomerOrders = gcnew ArrayList;
   }

};

public ref class MyOrder
{
public:
   String^ OrderID;
   MyOrder( String^ orderID )
   {
      this->OrderID = orderID;
   }

};

public ref class MyTreeNodeForm: public System::Windows::Forms::Form
{
private:
   TreeView^ myTreeView;
   Button^ myButton;
   ComboBox^ myComboBox;
   Label^ myLabel1;
   Label^ myLabel3;
   Label^ myLabel4;
   TextBox^ myTextBox;

public:
   MyTreeNodeForm()
   {
      InitializeComponent();
      myButton->Click += gcnew EventHandler( this, &MyTreeNodeForm::MyButtonClick );
      FillMyTreeView();
   }


private:
   void MyButtonClick( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      TreeNode^ selectedNode = nullptr;
      IEnumerator^ myEnum = this->myTreeView->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ node = safe_cast<TreeNode^>(myEnum->Current);
         
         // See if the root tree node is selected.
         if ( node->IsSelected )
         {
            selectedNode = node;
            break;
         }

         
         // Recurse through the TreeNodeCollection.
         selectedNode = GetSelectedNode( node );
         if ( selectedNode != nullptr )
         {
            break;
         }
      }

      
      // Display the previous visible node.
      if ( selectedNode != nullptr )
      {
         SelectNode( selectedNode );
      }
   }


   // <Snippet1>
   void SelectNode( TreeNode^ node )
   {
      if ( node->IsSelected )
      {
         
         // Determine which TreeNode to select.
         String^ str = myComboBox->Text;
         if ( str->Equals( "Previous" ) )
                  node->TreeView->SelectedNode = node->PrevNode;
         else
         if ( str->Equals( "PreviousVisible" ) )
                  node->TreeView->SelectedNode = node->PrevVisibleNode;
         else
         if ( str->Equals( "Next" ) )
                  node->TreeView->SelectedNode = node->NextNode;
         else
         if ( str->Equals( "NextVisible" ) )
                  node->TreeView->SelectedNode = node->NextVisibleNode;
         else
         if ( str->Equals( "First" ) )
                  node->TreeView->SelectedNode = node->FirstNode;
         else
         if ( str->Equals( "Last" ) )
                  node->TreeView->SelectedNode = node->LastNode;
      }

      node->TreeView->Focus();
   }
   // </Snippet1>

   TreeNode^ GetSelectedNode( TreeNode^ treeNode )
   {
      
      // Check each node recursively.
      IEnumerator^ myEnum = treeNode->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ node = safe_cast<TreeNode^>(myEnum->Current);
         if ( node->IsSelected )
         {
            
            // Return the TreeNode if it is selected.
            return node;
         }
      }

      return nullptr;
   }


   // ArrayList object to hold the 'MyCustomerClass' objects.
   void FillMyTreeView()
   {
      ArrayList^ customerArray = gcnew ArrayList;
      
      // Add customers to the ArrayList of 'MyCustomerClass' objects.
      for ( int x = 1; x <= 10; x++ )
      {
         customerArray->Add( gcnew MyCustomerClass( String::Concat( "Customer ", x ) ) );

      }
      
      // Add orders to each 'MyCustomerClass' object in the ArrayList.
      IEnumerator^ myEnum = customerArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         MyCustomerClass^ myCustomerClass1 = safe_cast<MyCustomerClass^>(myEnum->Current);
         for ( int y = 1; y <= 5; y++ )
         {
            myCustomerClass1->CustomerOrders->Add( gcnew MyOrder( String::Concat( "Order ", y ) ) );

         }
      }

      
      // Supress repainting until all the objects have been created.
      myTreeView->BeginUpdate();
      
      // Clear the 'TreeView' each time the method is called.
      myTreeView->Nodes->Clear();
      TreeNodeCollection^ myTreeNodeCollectionCustomer = myTreeView->Nodes;
      
      // Add a root treenode for each 'MyCustomerClass' object in the ArrayList.
      while ( myEnum->MoveNext() )
      {
         MyCustomerClass^ myCustomerClass2 = safe_cast<MyCustomerClass^>(myEnum->Current);
         myTreeNodeCollectionCustomer->Add( gcnew TreeNode( myCustomerClass2->CustomerName ) );
         TreeNodeCollection^ myTreeNodeCollectionOrders = myTreeNodeCollectionCustomer[ customerArray->IndexOf( myCustomerClass2 ) ]->Nodes;
         
         // Add a child treenode for each MyOrder object.
         IEnumerator^ myEnum = myCustomerClass2->CustomerOrders->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            MyOrder^ myOrder1 = safe_cast<MyOrder^>(myEnum->Current);
            myTreeNodeCollectionOrders->Add( gcnew TreeNode( myOrder1->OrderID ) );
            TreeNode^ myTreeNodeOrder = myTreeNodeCollectionOrders[ myCustomerClass2->CustomerOrders->IndexOf( myOrder1 ) ];
         }
      }

      myTreeView->SelectedImageIndex = 0;
      
      // Begin repainting the 'TreeView'.
      myTreeView->EndUpdate();
   }

   void InitializeComponent()
   {
      this->myTreeView = gcnew System::Windows::Forms::TreeView;
      this->myTextBox = gcnew System::Windows::Forms::TextBox;
      this->myComboBox = gcnew System::Windows::Forms::ComboBox;
      this->myLabel4 = gcnew System::Windows::Forms::Label;
      this->myButton = gcnew System::Windows::Forms::Button;
      this->myLabel1 = gcnew System::Windows::Forms::Label;
      this->myLabel3 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      
      //
      // myTreeView
      //
      this->myTreeView->ImageIndex = -1;
      this->myTreeView->Location = System::Drawing::Point( 8, 16 );
      this->myTreeView->Name = "myTreeView";
      this->myTreeView->SelectedImageIndex = -1;
      this->myTreeView->Size = System::Drawing::Size( 136, 328 );
      this->myTreeView->TabIndex = 0;
      
      //
      // myTextBox
      //
      this->myTextBox->Location = System::Drawing::Point( 368, 96 );
      this->myTextBox->Name = "myTextBox";
      this->myTextBox->Size = System::Drawing::Size( 128, 20 );
      this->myTextBox->TabIndex = 9;
      this->myTextBox->Text = "TestNode";
      
      //
      // myComboBox
      //
      this->myComboBox->DropDownWidth = 121;
      array<Object^>^temp0 = {"PreviousVisible","NextVisible","Previous","Next","First","Last"};
      this->myComboBox->Items->AddRange( temp0 );
      this->myComboBox->Location = System::Drawing::Point( 368, 24 );
      this->myComboBox->Name = "myComboBox";
      this->myComboBox->Size = System::Drawing::Size( 128, 21 );
      this->myComboBox->TabIndex = 1;
      
      //
      // myLabel4
      //
      this->myLabel4->Location = System::Drawing::Point( 152, 96 );
      this->myLabel4->Name = "myLabel4";
      this->myLabel4->Size = System::Drawing::Size( 192, 16 );
      this->myLabel4->TabIndex = 7;
      this->myLabel4->Text = "Change text of selected TreeNode to";
      
      //
      // myButton
      //
      this->myButton->Location = System::Drawing::Point( 368, 152 );
      this->myButton->Name = "myButton";
      this->myButton->Size = System::Drawing::Size( 128, 23 );
      this->myButton->TabIndex = 2;
      this->myButton->Text = "Apply";
      
      //
      // myLabel1
      //
      this->myLabel1->Location = System::Drawing::Point( 152, 216 );
      this->myLabel1->Name = "myLabel1";
      this->myLabel1->Size = System::Drawing::Size( 408, 120 );
      this->myLabel1->TabIndex = 4;
      
      //
      // myLabel3
      //
      this->myLabel3->Location = System::Drawing::Point( 152, 32 );
      this->myLabel3->Name = "myLabel3";
      this->myLabel3->Size = System::Drawing::Size( 128, 16 );
      this->myLabel3->TabIndex = 6;
      this->myLabel3->Text = "Select Font";
      
      //
      // MyTreeNodeForm
      //
      this->ClientSize = System::Drawing::Size( 624, 365 );
      array<System::Windows::Forms::Control^>^temp1 = {this->myTextBox,this->myLabel4,this->myLabel3,this->myLabel1,this->myComboBox,this->myButton,this->myTreeView};
      this->Controls->AddRange( temp1 );
      this->Name = "MyTreeNodeForm";
      this->Text = "TreeNode class sample";
      this->ResumeLayout( false );
   }

};

int main()
{
   Application::Run( gcnew MyTreeNodeForm );
}
