

// System::Windows::Forms::TreeNode.ImageIndex
// System::Windows::Forms::TreeNode.SelectedImageIndex
// System::Windows::Forms::TreeView.ImageIndex
// System::Windows::Forms::TreeView::SelectedImageIndex
// System::Windows::Forms::TreeView::ImageList
// System::Windows::Forms::TreeNode::TreeNode(String*, int, int)
// System::Windows::Forms::TreeNode::TreeNode(String*, int, int, TreeNode[])
/*
The following example demonstrates the constructors
'TreeNode(String*, int, int)' and 'TreeNode(String*, int, int, TreeNode[])' of
the 'TreeNode' class. This example displays customerinformation in a
'TreeView' control. The root tree nodes display customer names, and the
child tree nodes display the order numbers assigned to each customer.
*/
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::Windows::Forms;


public ref class TreeNode_Checked: public Form
{
private:
   int rootImageIndex;
   int selectedCustomerImageIndex;
   int unselectedCustomerImageIndex;
   int selectedOrderImageIndex;
   int unselectedOrderImageIndex;
   TreeView^ myTreeView;

   // ArrayList object to hold the 'Customer' objects.
   ArrayList^ customerArray;

public:
   TreeNode_Checked()
   {
      customerArray = gcnew ArrayList;
      InitializeComponent();
      FillMyTreeView();
   }


private:
   void FillMyTreeView()
   {
      
      // Add customers to the ArrayList of 'Customer' objects.
      for ( int xIndex = 1; xIndex <= 5; xIndex++ )
      {
         customerArray->Add( gcnew Customer( String::Concat( "Customer ", xIndex ) ) );

      }
      
      // Add orders to each 'Customer' object in the ArrayList.
      IEnumerator^ myEnum = customerArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Customer^ customer1 = safe_cast<Customer^>(myEnum->Current);
         for ( int yIndex = 1; yIndex <= 5; yIndex++ )
         {
            customer1->CustomerOrders->Add( gcnew Order( String::Concat( "Order ", yIndex ) ) );

         }
      }

      myTreeView->BeginUpdate();
      
      // Clear the TreeView each time the method is called.
      myTreeView->Nodes->Clear();
      FillTreeView();
      
      // Begin repainting the TreeView.
      myTreeView->EndUpdate();
   }

   // <Snippet1>
ref class Customer
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

ref class Order
{
public:
   String^ OrderID;
   Order( String^ myOrderID )
   {
      this->OrderID = myOrderID;
   }

};

   void FillTreeView()
   {
      
      // Load the images in an ImageList.
      ImageList^ myImageList = gcnew ImageList;
      myImageList->Images->Add( Image::FromFile( "Default.gif" ) );
      myImageList->Images->Add( Image::FromFile( "SelectedDefault.gif" ) );
      myImageList->Images->Add( Image::FromFile( "Root.gif" ) );
      myImageList->Images->Add( Image::FromFile( "UnselectedCustomer.gif" ) );
      myImageList->Images->Add( Image::FromFile( "SelectedCustomer.gif" ) );
      myImageList->Images->Add( Image::FromFile( "UnselectedOrder.gif" ) );
      myImageList->Images->Add( Image::FromFile( "SelectedOrder.gif" ) );
      
      // Assign the ImageList to the TreeView.
      myTreeView->ImageList = myImageList;
      
      // Set the TreeView control's default image and selected image indexes.
      myTreeView->ImageIndex = 0;
      myTreeView->SelectedImageIndex = 1;
      
      /* Set the index of image from the
        ImageList for selected and unselected tree nodes.*/
      this->rootImageIndex = 2;
      this->selectedCustomerImageIndex = 3;
      this->unselectedCustomerImageIndex = 4;
      this->selectedOrderImageIndex = 5;
      this->unselectedOrderImageIndex = 6;
      
      // Create the root tree node.
      TreeNode^ rootNode = gcnew TreeNode( "CustomerList" );
      rootNode->ImageIndex = rootImageIndex;
      rootNode->SelectedImageIndex = rootImageIndex;
      
      // Add a main root tree node.
      myTreeView->Nodes->Add( rootNode );
      
      // Add a root tree node for each Customer object in the ArrayList.
      IEnumerator^ myEnum = customerArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Customer^ myCustomer = safe_cast<Customer^>(myEnum->Current);
         
         // Add a child tree node for each Order object.
         int countIndex = 0;
         array<TreeNode^>^myTreeNodeArray = gcnew array<TreeNode^>(myCustomer->CustomerOrders->Count);
         IEnumerator^ myEnum = myCustomer->CustomerOrders->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Order^ myOrder = safe_cast<Order^>(myEnum->Current);
            
            // Add the Order tree node to the array.
            myTreeNodeArray[ countIndex ] = gcnew TreeNode( myOrder->OrderID,unselectedOrderImageIndex,selectedOrderImageIndex );
            countIndex++;
         }
         TreeNode^ customerNode = gcnew TreeNode( myCustomer->CustomerName,unselectedCustomerImageIndex,selectedCustomerImageIndex,myTreeNodeArray );
         myTreeView->Nodes[ 0 ]->Nodes->Add( customerNode );
      }
   }
   // </Snippet1>

   void InitializeComponent()
   {
      this->myTreeView = gcnew TreeView;
      this->SuspendLayout();
      this->myTreeView->ImageIndex = -1;
      this->myTreeView->Location = Point(8,0);
      this->myTreeView->Name = "myTreeView";
      this->myTreeView->SelectedImageIndex = -1;
      this->myTreeView->Size = System::Drawing::Size( 280, 152 );
      this->myTreeView->TabIndex = 0;
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->Controls->Add( this->myTreeView );
      this->Name = "Form1";
      this->Text = "TreeNode Example";
      this->ResumeLayout( true );
   }
};

int main()
{
   Application::Run( gcnew TreeNode_Checked );
}
