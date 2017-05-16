

// System::Windows::Forms::TreeNode::Checked
// System::Windows::Forms::TreeNode::BackColor
/*
The following example demonstrates the properties 'Checked' and
'BackColor' of the 'TreeNode' class. This example displays customer
information in a 'TreeView' control. The root tree nodes display
customer names, and the child tree nodes display the order numbers
assigned to each customer. It also displays selected nodes in a
messagebox.
*/
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::Windows::Forms;
public ref class Customer
{
public:
   ArrayList^ CustomerOrders;
   String^ CustomerName;
   Customer( String^ myName )
   {
      CustomerName = myName;
      CustomerOrders = gcnew ArrayList;
   }

};

public ref class Order
{
public:
   String^ OrderID;
   Order( String^ myOrderID )
   {
      this->OrderID = myOrderID;
   }

};

public ref class TreeNode_Bounds: public Form
{
private:
   TreeView^ myTreeView;
   Button^ myButton;

   // ArrayList Object* to hold the Customer objects.
   ArrayList^ customerArray;
   TreeNode^ rootNode;

public:
   TreeNode_Bounds()
   {
      customerArray = gcnew ArrayList;
      InitializeComponent();
      FillMyTreeView();
   }


private:
   void FillMyTreeView()
   {
      
      // Add customers to the ArrayList of 'Customer' objects.
      for ( int x = 1; x <= 5; x++ )
      {
         customerArray->Add( gcnew Customer( String::Concat( "Customer ", x ) ) );

      }
      
      // Add orders to each 'Customer' object in the ArrayList.
      IEnumerator^ myEnum = customerArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Customer^ customer1 = safe_cast<Customer^>(myEnum->Current);
         for ( int y = 1; y <= 5; y++ )
         {
            customer1->CustomerOrders->Add( gcnew Order( String::Concat( "Order ", y ) ) );

         }
      }

      myTreeView->BeginUpdate();
      
      // Clear the TreeView each time the method is called.
      myTreeView->Nodes->Clear();
      rootNode = gcnew TreeNode;
      rootNode->Text = "CustomerList";
      
      // Add a main root treenode.
      myTreeView->Nodes->Add( rootNode );
      myTreeView->CheckBoxes = true;
      
      // Add a root treenode for each 'Customer' object in the ArrayList.
      while ( myEnum->MoveNext() )
      {
         Customer^ myCustomer = safe_cast<Customer^>(myEnum->Current);
         
         // Add a child treenode for each 'Order' object.
         int countIndex = 0;
         array<TreeNode^>^myTreeNodeArray = gcnew array<TreeNode^>(5);
         IEnumerator^ myEnum = myCustomer->CustomerOrders->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Order^ myOrder = safe_cast<Order^>(myEnum->Current);
            myTreeNodeArray[ countIndex ] = gcnew TreeNode( myOrder->OrderID );
            countIndex++;
         }

         TreeNode^ customerNode = gcnew TreeNode( myCustomer->CustomerName,myTreeNodeArray );
         myTreeView->Nodes[ 0 ]->Nodes->Add( customerNode );
      }

      
      // Begin repainting the TreeView.
      myTreeView->EndUpdate();
   }



   // <Snippet1>
public:
   void HighlightCheckedNodes()
   {
      int countIndex = 0;
      String^ selectedNode = "Selected customer nodes are : ";
      IEnumerator^ myEnum = myTreeView->Nodes[ 0 ]->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ myNode = safe_cast<TreeNode^>(myEnum->Current);
         
         // Check whether the tree node is checked.
         if ( myNode->Checked )
         {
            
            // Set the node's backColor.
            myNode->BackColor = Color::Yellow;
            selectedNode = String::Concat( selectedNode, myNode->Text, " " );
            countIndex++;
         }
         else
                  myNode->BackColor = Color::White;
      }

      if ( countIndex > 0 )
            MessageBox::Show( selectedNode );
      else
            MessageBox::Show( "No nodes are selected" );
   }
   // </Snippet1>

private:
   void MyButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      HighlightCheckedNodes();
   }

   void InitializeComponent()
   {
      this->myTreeView = gcnew System::Windows::Forms::TreeView;
      this->SuspendLayout();
      this->myTreeView->ImageIndex = -1;
      this->myTreeView->Location = System::Drawing::Point( 8, 0 );
      this->myTreeView->Name = "myTreeView";
      this->myTreeView->SelectedImageIndex = -1;
      this->myTreeView->Size = System::Drawing::Size( 280, 152 );
      this->myTreeView->TabIndex = 0;
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->myButton = gcnew Button;
      array<System::Windows::Forms::Control^>^temp0 = {this->myButton,this->myTreeView};
      this->Controls->AddRange( temp0 );
      this->myButton->Location = Point(80,200);
      this->myButton->Size = System::Drawing::Size( 140, 25 );
      this->myButton->Text = "Display Selected Nodes";
      this->myButton->Click += gcnew EventHandler( this, &TreeNode_Bounds::MyButton_Click );
      this->Text = "TreeNode Example";
      this->ResumeLayout( false );
   }

};

int main()
{
   Application::Run( gcnew TreeNode_Bounds );
}
