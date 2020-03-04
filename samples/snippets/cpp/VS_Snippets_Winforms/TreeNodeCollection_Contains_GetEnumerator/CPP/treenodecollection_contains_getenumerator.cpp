

// System::Windows::Forms::TreeNodeCollection::Contains()
// System::Windows::Forms::TreeNodeCollection::GetEnumerator()

/*
The following program demonstrates 'Contains' and 'GetEnumerator'
methods of 'System::Windows::Forms::TreeNodeCollection' class. It
creates a TreeView with two TreeNodes and gets the collection of
TreeNodes. It checks for a TreeNode in the collection and also
gets an Enumerator to iterate through the collection.
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

public ref class MyForm: public Form
{
private:
   TreeView^ myTreeView;
   TreeNode^ myTreeNode1;
   TreeNode^ myTreeNode2;
   Label^ myLabel;
   System::ComponentModel::Container^ components;

public:
   MyForm()
   {
      components = nullptr;
      InitializeComponent();
   }

protected:
   ~MyForm()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      this->myTreeView = gcnew TreeView;
      this->myLabel = gcnew Label;
      this->SuspendLayout();
      
      //
      // myTreeView
      //
      this->myTreeView->ImageIndex = -1;
      this->myTreeView->Name = "treeView1";
      this->myTreeView->SelectedImageIndex = -1;
      this->myTreeView->TabIndex = 0;
      
      // Create TreeNodes.
      myTreeNode1 = gcnew TreeNode( "Node1" );
      myTreeNode2 = gcnew TreeNode( "Node2" );
      array<TreeNode^>^temp0 = {myTreeNode1,myTreeNode2};
      this->myTreeView->Nodes->AddRange( temp0 );
      
      //
      // myLabel
      //
      this->myLabel->Location = Point(8,136);
      this->myLabel->Name = "myLabel";
      this->myLabel->Size = System::Drawing::Size( 248, 112 );
      this->myLabel->TabIndex = 1;
      
      //
      // MyForm
      //
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^temp1 = {this->myLabel,this->myTreeView};
      this->Controls->AddRange( temp1 );
      this->Name = "MyForm";
      this->Text = "MyForm";
      this->Load += gcnew EventHandler( this, &MyForm::MyForm_Load );
      this->ResumeLayout( false );
   }

   void MyForm_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      EnumerateTreeNodes();
   }

   // <snippet2>
   // <snippet1>
   void EnumerateTreeNodes()
   {
      TreeNodeCollection^ myNodeCollection = myTreeView->Nodes;

      // Check for a node in the collection.
      if ( myNodeCollection->Contains( myTreeNode2 ) )
      {
         myLabel->Text = myLabel->Text + "Node2 is at index: " + myNodeCollection->IndexOf( myTreeNode2 );
      }

      myLabel->Text = myLabel->Text + "\n\nElements of the TreeNodeCollection:\n";

      // Create an enumerator for the collection.
      IEnumerator^ myEnumerator = myNodeCollection->GetEnumerator();
      while ( myEnumerator->MoveNext() )
      {
         myLabel->Text = myLabel->Text + (dynamic_cast<TreeNode^>(myEnumerator->Current))->Text + "\n";
      }
   }
   // </snippet1>
   // </snippet2>
};


[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
