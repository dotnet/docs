

// System::Windows::Forms::TreeNodeCollection::Clear
// System::Windows::Forms::TreeNodeCollection::AddRange
/*
The following program demonstrates the 'Clear' and 'AddRange' methods of
the 'TreeNodeCollection' class. It creates two 'TreeView' objects, the first
Object* contains the customer list and the second Object* is empty. The user
is provided with the option to add or remove a 'TreeNode'.

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

public ref class myTreeNodeCollectionForm: public Form
{
private:
   Button^ myButtonAddAll;
   Button^ myButtonAdd;
   TreeView^ myTreeViewBase;
   TreeView^ myTreeViewCustom;
   Button^ myButtonRemoveAll;

public:
   myTreeNodeCollectionForm()
   {
      InitializeComponent();
      FillMyTreeView();
      myButtonAddAll->Click += gcnew EventHandler( this, &myTreeNodeCollectionForm::MyButtonAddAllClick );
      myButtonAdd->Click += gcnew EventHandler( this, &myTreeNodeCollectionForm::MyButtonAddClick );
      myButtonRemoveAll->Click += gcnew EventHandler( this, &myTreeNodeCollectionForm::MyButtonRemoveAllClick );
   }

   // <Snippet2>
   // <Snippet1>
private:
   void MyButtonAddAllClick( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Get the 'myTreeNodeCollection' from the 'myTreeViewBase' TreeView.
      TreeNodeCollection^ myTreeNodeCollection = myTreeViewBase->Nodes;
      
      // Create an array of 'TreeNodes'.
      array<TreeNode^>^myTreeNodeArray = gcnew array<TreeNode^>(myTreeViewBase->Nodes->Count);
      
      // Copy the tree nodes to the 'myTreeNodeArray' array.
      myTreeViewBase->Nodes->CopyTo( myTreeNodeArray, 0 );
      
      // Remove all the tree nodes from the 'myTreeViewBase' TreeView.
      myTreeViewBase->Nodes->Clear();
      
      // Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
      myTreeViewCustom->Nodes->AddRange( myTreeNodeArray );
   }
   // </Snippet1>
   // </Snippet2>

   void MyButtonRemoveAllClick( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Get the 'myTreeNodeCollection' from the 'myTreeViewCustom' TreeView.
      TreeNodeCollection^ myTreeNodeCollection = myTreeViewCustom->Nodes;
      
      // Create an array of 'TreeNodes'.
      array<TreeNode^>^myTreeNodeArray = gcnew array<TreeNode^>(myTreeViewCustom->Nodes->Count);
      
      // Copy the tree nodes to the 'myTreeNodeArray' array.
      myTreeViewCustom->Nodes->CopyTo( myTreeNodeArray, 0 );
      
      // Remove all the tree nodes from the 'myTreeViewCustom' TreeView.
      myTreeViewCustom->Nodes->Clear();
      
      // Add the 'myTreeNodeArray' to the 'myTreeViewBase' TreeView.
      myTreeViewBase->Nodes->AddRange( myTreeNodeArray );
   }

   void MyButtonAddClick( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      TreeNodeCollection^ myTreeNodeCollection = myTreeViewBase->Nodes;
      IEnumerator^ myEnum = myTreeNodeCollection->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ myTreeNode = safe_cast<TreeNode^>(myEnum->Current);
         if ( myTreeNode->IsSelected == true )
         {
            
            // Remove the selected node from the 'myTreeViewBase' TreeView.
            myTreeViewBase->Nodes->Remove( myTreeNode );
            
            // Add the selected node to the 'myTreeViewCustom' TreeView.
            myTreeViewCustom->Nodes->Add( myTreeNode );
         }
      }
   }

   void FillMyTreeView()
   {
      ArrayList^ customerArray = gcnew ArrayList;
      
      // Add customers to the ArrayList of 'MyCustomerClass' objects.
      for ( int x = 1; x <= 10; x++ )
      {
         customerArray->Add( gcnew MyCustomerClass( String::Concat( "Customer ", x ) ) );

      }
      
      // Add orders to each 'MyCustomerClass' Object* in the ArrayList.
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
      myTreeViewBase->BeginUpdate();
      
      // Clear the 'TreeView' each time the method is called.
      myTreeViewBase->Nodes->Clear();
      TreeNodeCollection^ myTreeNodeCollectionCustomer = myTreeViewBase->Nodes;
      
      // Add a root treenode for each 'MyCustomerClass' object in the ArrayList.
      while ( myEnum->MoveNext() )
      {
         MyCustomerClass^ myCustomerClass2 = safe_cast<MyCustomerClass^>(myEnum->Current);
         myTreeNodeCollectionCustomer->Add( gcnew TreeNode( myCustomerClass2->CustomerName ) );
         TreeNodeCollection^ myTreeNodeCollectionOrders = myTreeNodeCollectionCustomer[ customerArray->IndexOf( myCustomerClass2 ) ]->Nodes;
         
         // Add a child treenode for each 'MyOrder' object.
         IEnumerator^ myEnum = myCustomerClass2->CustomerOrders->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            MyOrder^ myOrder1 = safe_cast<MyOrder^>(myEnum->Current);
            myTreeNodeCollectionOrders->Add( gcnew TreeNode( myOrder1->OrderID ) );
            TreeNode^ myTreeNodeOrder = myTreeNodeCollectionOrders[ myCustomerClass2->CustomerOrders->IndexOf( myOrder1 ) ];
         }
      }

      myTreeViewBase->SelectedImageIndex = 0;
      
      // Begin repainting the 'TreeView'.
      myTreeViewBase->EndUpdate();
   }

   void InitializeComponent()
   {
      this->myTreeViewBase = gcnew TreeView;
      this->myButtonAddAll = gcnew Button;
      this->myButtonAdd = gcnew Button;
      this->myTreeViewCustom = gcnew TreeView;
      this->myButtonRemoveAll = gcnew Button;
      this->SuspendLayout();
      this->myTreeViewBase->ImageIndex = -1;
      this->myTreeViewBase->Location = Point(64,16);
      this->myTreeViewBase->Name = "myTreeViewBase";
      this->myTreeViewBase->SelectedImageIndex = -1;
      this->myTreeViewBase->Size = System::Drawing::Size( 160, 192 );
      this->myTreeViewBase->TabIndex = 0;
      this->myButtonAddAll->Location = Point(248,112);
      this->myButtonAddAll->Name = "myButtonAddAll";
      this->myButtonAddAll->Size = System::Drawing::Size( 96, 23 );
      this->myButtonAddAll->TabIndex = 2;
      this->myButtonAddAll->Text = "Add   >>";
      this->myButtonAdd->Location = Point(248,48);
      this->myButtonAdd->Name = "myButtonAdd";
      this->myButtonAdd->Size = System::Drawing::Size( 96, 23 );
      this->myButtonAdd->TabIndex = 3;
      this->myButtonAdd->Text = "Add     >";
      this->myTreeViewCustom->ImageIndex = -1;
      this->myTreeViewCustom->Location = Point(376,16);
      this->myTreeViewCustom->Name = "myTreeViewCustom";
      this->myTreeViewCustom->SelectedImageIndex = -1;
      this->myTreeViewCustom->Size = System::Drawing::Size( 168, 192 );
      this->myTreeViewCustom->TabIndex = 1;
      this->myButtonRemoveAll->Location = Point(248,176);
      this->myButtonRemoveAll->Name = "myButtonRemoveAll";
      this->myButtonRemoveAll->Size = System::Drawing::Size( 96, 23 );
      this->myButtonRemoveAll->TabIndex = 4;
      this->myButtonRemoveAll->Text = "<<   Remove ";
      this->ClientSize = System::Drawing::Size( 616, 273 );
      this->Controls->Add( this->myButtonRemoveAll );
      this->Controls->Add( this->myButtonAdd );
      this->Controls->Add( this->myButtonAddAll );
      this->Controls->Add( this->myTreeViewCustom );
      this->Controls->Add( this->myTreeViewBase );
      this->Name = "myTreeNodeCollectionForm";
      this->Text = "TreeNodeCollection class Sample";
      this->ResumeLayout( false );
   }
};

int main()
{
   Application::Run( gcnew myTreeNodeCollectionForm );
}
