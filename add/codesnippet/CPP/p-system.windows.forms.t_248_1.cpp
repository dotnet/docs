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