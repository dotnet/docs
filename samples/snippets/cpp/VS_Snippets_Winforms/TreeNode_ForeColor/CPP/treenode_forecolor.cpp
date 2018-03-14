

// System::Windows::Forms::TreeNode::ExpandAll()
// System::Windows::Forms::TreeNode::FirstNode
// System::Windows::Forms::TreeNode::ForeColor
// System::Windows::Forms::TreeNode::GetNodeCount(bool)
// System::Windows::Forms::TreeNode::IsEditing
// System::Windows::Forms::TreeNode::IsExpanded
// System::Windows::Forms::TreeNode::IsSelected
// System::Windows::Forms::TreeNode::FullPath
// System::Windows::Forms::TreeView::PathSeparator
/*
The following example demonstrates the  properties 'FirstNode',
'ForeColor', 'IsEditing', 'IsExpanded' and 'IsSelected', the methods
'ExpandAll' and 'GetNodeCount(bool)' of the 'TreeNode' class. In the
program, a form is created and to it 'TreeView', 'GroupBox',
and two 'CheckBox' controls are added. A 'TreeView' control is
associated with the class 'ContextMenu' so as to enable the user to change
the content of a 'TreeNode'. The 'TreeView' control displays a
hierarchical collection of 'Customer' objects which in turn contain
'Order' objects.
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

public ref class MyTreeNode_FirstNode: public Form
{
private:
   TreeView^ myTreeView;
   GroupBox^ myGroupBox;
   CheckBox^ myCheckBox;
   CheckBox^ myCheckBox2;
   Button^ myButton;
   System::Windows::Forms::ContextMenu^ myContextMenu;
   MenuItem^ myMenuItem;
   TreeNode^ mySelectedNode;

   // ArrayList object to hold the 'Customer' objects.
   ArrayList^ myCustomerArrayList;

public:
   MyTreeNode_FirstNode()
   {
      myCustomerArrayList = gcnew ArrayList;
      InitializeComponent();
      FillMyTreeView();
   }


private:
   void FillMyTreeView()
   {
      
      // Add customers to the ArrayList of 'Customer' objects.
      for ( int iIndex = 1; iIndex <= 10; iIndex++ )
      {
         myCustomerArrayList->Add( gcnew Customer( String::Concat( "Customer ", iIndex ) ) );

      }
      IEnumerator^ myEnum = myCustomerArrayList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Customer^ myCustomer1 = safe_cast<Customer^>(myEnum->Current);
         for ( int jIndex = 1; jIndex <= 5; jIndex++ )
         {
            myCustomer1->CustomerOrders->Add( gcnew Order( String::Concat( "Order ", jIndex ) ) );

         }
      }

      
      // Suppress repainting the TreeView until it is fully created.
      myTreeView->BeginUpdate();
      
      // Clear the TreeView each time the method is called.
      myTreeView->Nodes->Clear();
      TreeNode^ myMainNode = gcnew TreeNode( "CustomerList" );
      myTreeView->Nodes->Add( myMainNode );
      
      // Add a root treenode for each 'Customer' in the ArrayList.
      while ( myEnum->MoveNext() )
      {
         Customer^ myCustomer2 = safe_cast<Customer^>(myEnum->Current);
         TreeNode^ myTreeNode1 = gcnew TreeNode( myCustomer2->CustomerName );
         myTreeNode1->ForeColor = Color::Orange;
         myTreeView->Nodes[ 0 ]->Nodes->Add( myTreeNode1 );
         
         // Add a child for each 'Order' in the current 'Customer'.
         IEnumerator^ myEnum = myCustomer2->CustomerOrders->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Order^ myOrder1 = safe_cast<Order^>(myEnum->Current);
            myTreeView->Nodes[ 0 ]->Nodes[ myCustomerArrayList->IndexOf( myCustomer2 ) ]->Nodes->Add( gcnew TreeNode( myOrder1->OrderID ) );
         }
      }

      
      // Reset the cursor back to the default for all controls.
      ::Cursor::Current = Cursors::Default;
      
      // Begin repainting the TreeView.
      myTreeView->EndUpdate();
      if ( myTreeView->Nodes[ 0 ]->IsExpanded == false )
            myTreeView->Nodes[ 0 ]->Expand();
   }

   void InitializeComponent()
   {
      this->myMenuItem = gcnew MenuItem;
      this->myCheckBox = gcnew CheckBox;
      this->myButton = gcnew Button;
      this->myCheckBox2 = gcnew CheckBox;
      this->myTreeView = gcnew TreeView;
      this->myContextMenu = gcnew System::Windows::Forms::ContextMenu;
      this->myGroupBox = gcnew GroupBox;
      this->myGroupBox->SuspendLayout();
      this->SuspendLayout();
      this->myMenuItem->Checked = true;
      this->myMenuItem->DefaultItem = true;
      this->myMenuItem->Index = 0;
      this->myMenuItem->Text = "Edit";
      this->myMenuItem->Click += gcnew System::EventHandler( this, &MyTreeNode_FirstNode::MenuItem1_Click );
      this->myCheckBox->Location = System::Drawing::Point( 24, 24 );
      this->myCheckBox->Name = "myCheckBox";
      this->myCheckBox->TabIndex = 0;
      this->myCheckBox->Text = "Expand All";
      this->myCheckBox->CheckedChanged += gcnew System::EventHandler( this, &MyTreeNode_FirstNode::myCheckBox_CheckedChanged );
      this->myButton->Location = System::Drawing::Point( 136, 24 );
      this->myButton->Name = "myCheckBox2";
      this->myButton->TabIndex = 1;
      this->myButton->Text = "Child Nodes";
      this->myButton->Click += gcnew System::EventHandler( this, &MyTreeNode_FirstNode::myButton_Click );
      this->myTreeView->ContextMenu = this->myContextMenu;
      this->myTreeView->ImageIndex = -1;
      this->myTreeView->LabelEdit = true;
      this->myTreeView->Location = System::Drawing::Point( 8, 0 );
      this->myTreeView->Name = "myTreeView";
      this->myTreeView->SelectedImageIndex = -1;
      this->myTreeView->Size = System::Drawing::Size( 280, 152 );
      this->myTreeView->TabIndex = 0;
      this->myTreeView->MouseDown += gcnew MouseEventHandler( this, &MyTreeNode_FirstNode::TreeView1_MouseDown );
      this->myTreeView->AfterLabelEdit += gcnew NodeLabelEditEventHandler( this, &MyTreeNode_FirstNode::TreeView1_AfterLabelEdit );
      array<MenuItem^>^temp0 = {this->myMenuItem};
      this->myContextMenu->MenuItems->AddRange( temp0 );
      array<Control^>^temp1 = {this->myButton,this->myCheckBox};
      this->myGroupBox->Controls->AddRange( temp1 );
      this->myGroupBox->Location = System::Drawing::Point( 8, 168 );
      this->myGroupBox->Name = "myGroupBox";
      this->myGroupBox->Size = System::Drawing::Size( 272, 96 );
      this->myGroupBox->TabIndex = 1;
      this->myGroupBox->TabStop = false;
      this->myGroupBox->Text = "myGroupBox";
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^temp2 = {this->myGroupBox,this->myTreeView};
      this->Controls->AddRange( temp2 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->myGroupBox->ResumeLayout( false );
      this->ResumeLayout( false );
   }

   // <Snippet1>
   void myCheckBox_CheckedChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // If the check box is checked, expand all the tree nodes.
      if ( myCheckBox->Checked == true )
      {
         myTreeView->ExpandAll();
      }
      else
      {
         
         // If the check box is not cheked, collapse the first tree node.
         myTreeView->Nodes[ 0 ]->FirstNode->Collapse();
         MessageBox::Show( "The first and last  node of CutomerList root node is collapsed" );
      }
   }
   // </Snippet1>

   // <Snippet2>
   void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Set the tree view's PathSeparator property.
      myTreeView->PathSeparator = ".";
      
      // Get the count of the child tree nodes contained in the SelectedNode.
      int myNodeCount = myTreeView->SelectedNode->GetNodeCount( true );
      Decimal myChildPercentage = ((Decimal)myNodeCount / (Decimal)myTreeView->GetNodeCount( true )) * 100;
      
      // Display the tree node path and the number of child nodes it and the tree view have.
      MessageBox::Show( String::Concat( "The '", myTreeView->SelectedNode->FullPath, "' node has ", myNodeCount, " child nodes.\nThat is ", String::Format( "{0:###.##}", myChildPercentage ), "% of the total tree nodes in the tree view control." ) );
   }
   // </Snippet2>

   // Save the tree node under the mouse pointer.
   void TreeView1_MouseDown( Object^ /*sender*/, MouseEventArgs^ e )
   {
      mySelectedNode = myTreeView->GetNodeAt( e->X, e->Y );
   }

   void MenuItem1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( mySelectedNode != nullptr && mySelectedNode->Parent != nullptr )
      {
         myTreeView->SelectedNode = mySelectedNode;
         myTreeView->LabelEdit = true;
         mySelectedNode->BeginEdit();
         if ( mySelectedNode->IsEditing == true )
                  MessageBox::Show( String::Concat( "The name of node being edited: ", mySelectedNode->Text ) );
         mySelectedNode->BeginEdit();
      }
      else
      {
         MessageBox::Show( "No tree node selected or selected node is a root node. Editing of root nodes is not allowed. Invalid selection" );
      }
   }

   void TreeView1_AfterLabelEdit( Object^ /*sender*/, NodeLabelEditEventArgs^ e )
   {
      if ( e->Label != nullptr )
      {
         if ( e->Label->Length > 0 )
         {
            array<Char>^temp3 = {'@','->',',','!'};
            if ( e->Label->IndexOfAny( temp3 ) == -1 )
            {
               
               // Stop editing without cancelling the label change.
               e->Node->EndEdit( false );
            }
            else
            {
               
               // Cancel the label edit action, place it in edit mode.
               e->CancelEdit = true;
               MessageBox::Show( "Invalid tree node label.\n The invalid characters are: '@', '.', ', ', '!'", "Node Label Edit" );
               e->Node->BeginEdit();
            }
         }
         else
         {
            
            // Cancel the label edit action, place it in edit mode.
            e->CancelEdit = true;
            MessageBox::Show( "Invalid tree node label. The label cannot be blank", "Node Label Edit" );
            e->Node->BeginEdit();
         }
         this->myTreeView->LabelEdit = false;
      }
   }

};

int main()
{
   Application::Run( gcnew MyTreeNode_FirstNode );
}
