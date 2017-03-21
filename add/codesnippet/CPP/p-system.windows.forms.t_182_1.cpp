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


   void AddRootNodes()
   {
      
      // Add a root node to assign the customer nodes to.
      TreeNode^ rootNode = gcnew TreeNode;
      rootNode->Text = "CustomerList";
      
      // Add a main root treenode.
      myTreeView->Nodes->Add( rootNode );
      
      // Add a root treenode for each 'Customer' object in the ArrayList.
      IEnumerator^ myEnum = customerArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Customer^ myCustomer = safe_cast<Customer^>(myEnum->Current);
         
         // Add a child treenode for each Order object.
         int i = 0;
         array<TreeNode^>^myTreeNodeArray = gcnew array<TreeNode^>(5);
         IEnumerator^ myEnum = myCustomer->CustomerOrders->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Order^ myOrder = safe_cast<Order^>(myEnum->Current);
            myTreeNodeArray[ i ] = gcnew TreeNode( myOrder->OrderID );
            i++;
         }
         TreeNode^ customerNode = gcnew TreeNode( myCustomer->CustomerName,myTreeNodeArray );
         
         // Display the customer names with and Orange font.
         customerNode->ForeColor = Color::Orange;
         
         // Store the Customer Object* in the Tag property of the TreeNode.
         customerNode->Tag = myCustomer;
         myTreeView->Nodes[ 0 ]->Nodes->Add( customerNode );
      }
   }