

// System::Windows::Forms::TreeNode::TreeNode()
// System::Windows::Forms::TreeNode::TreeNode(String*, TreeNode[])
// System::Windows::Forms::TreeNode::Bounds
// System::Windows::Forms::TreeNode::ForeColor
// System::Windows::Forms::TreeNode::NodeFont
// System::Windows::Forms::TreeNode::Text
// System::Windows::Forms::TreeNode::Tag
// System::Windows::Forms::TreeView::ItemHeight

/*
The following example demonstrates the constructors 'TreeNode()'
and 'TreeNode(String*, TreeNode[])' and the property 'Bounds' of the
'TreeNode' class. This example displays customer information in a
'TreeView' control. The root tree nodes display customer names, and
the child tree nodes display the order numbers assigned to each
customer.
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
   Label^ mylabel;
   ComboBox^ myComboBox;

   // ArrayList object to hold the 'Customer' objects.
   ArrayList^ customerArray;

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
      for ( int xIndex = 1; xIndex <= 5; xIndex++ )
      {
         customerArray->Add( gcnew Customer( String::Concat( "Customer ", xIndex ) ) );

      }
      
      // Add orders to each 'Customer' Object* in the ArrayList.
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
      AddRootNodes();
      
      // Begin repainting the TreeView.
      myTreeView->EndUpdate();
   }


public:

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
   // </Snippet1>

   // <Snippet2>
private:
   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myTreeView->ItemHeight = 5;
      myTreeView->SelectedNode->NodeFont = gcnew System::Drawing::Font( "Arial",5 );
      
      // Get the font size from combobox.
      String^ selectedString = myComboBox->SelectedItem->ToString();
      int myNodeFontSize = Int32::Parse( selectedString );
      
      // Set the font of root node.
      myTreeView->SelectedNode->NodeFont = gcnew System::Drawing::Font( "Arial",(float)myNodeFontSize );
      for ( int i = 0; i < myTreeView->Nodes[ 0 ]->Nodes->Count; i++ )
      {
         
         // Set the font of child nodes.
         myTreeView->Nodes[ 0 ]->Nodes[ i ]->NodeFont = gcnew System::Drawing::Font( "Arial",(float)myNodeFontSize );

      }
      
      // Get the bounds of the tree node.
      Rectangle myRectangle = myTreeView->SelectedNode->Bounds;
      int myNodeHeight = myRectangle.Height;
      if ( myNodeHeight < myNodeFontSize )
      {
         myNodeHeight = myNodeFontSize;
      }

      myTreeView->ItemHeight = myNodeHeight + 4;
   }
   // </Snippet2>

   void InitializeComponent()
   {
      this->myTreeView = gcnew System::Windows::Forms::TreeView;
      this->myButton = gcnew System::Windows::Forms::Button;
      this->myComboBox = gcnew System::Windows::Forms::ComboBox;
      this->mylabel = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      this->myTreeView->ImageIndex = -1;
      this->myTreeView->Location = System::Drawing::Point( 8, 0 );
      this->myTreeView->Name = "myTreeView";
      this->myTreeView->SelectedImageIndex = -1;
      this->myTreeView->Size = System::Drawing::Size( 280, 152 );
      this->myTreeView->TabIndex = 0;
      this->myButton->Location = System::Drawing::Point( 104, 232 );
      this->myButton->Name = "myButton";
      this->myButton->TabIndex = 2;
      this->myButton->Text = "Submit";
      this->myButton->Click += gcnew System::EventHandler( this, &TreeNode_Bounds::Button1_Click );
      this->myComboBox->DropDownWidth = 121;
      array<Object^>^temp0 = {"6","7","8","10","12","16","18","22"};
      this->myComboBox->Items->AddRange( temp0 );
      this->myComboBox->Location = System::Drawing::Point( 112, 184 );
      this->myComboBox->Name = "myComboBox";
      this->myComboBox->Size = System::Drawing::Size( 121, 21 );
      this->myComboBox->TabIndex = 1;
      this->myComboBox->SelectedIndex = 0;
      this->myComboBox->DropDownStyle = ComboBoxStyle::DropDownList;
      this->mylabel->Location = System::Drawing::Point( 0, 184 );
      this->mylabel->Name = "mylabel";
      this->mylabel->TabIndex = 3;
      this->mylabel->Text = "Select a Height for TreeNode";
      this->mylabel->Size = System::Drawing::Size( 100, 50 );
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^temp1 = {this->mylabel,this->myButton,this->myComboBox,this->myTreeView};
      this->Controls->AddRange( temp1 );
      this->Text = "TreeNode Example";
      this->ResumeLayout( false );
   }

};

int main()
{
   Application::Run( gcnew TreeNode_Bounds );
}
