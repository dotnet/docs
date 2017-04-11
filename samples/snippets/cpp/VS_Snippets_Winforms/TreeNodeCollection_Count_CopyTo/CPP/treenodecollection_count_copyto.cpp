

// System::Windows::Forms::TreeNodeCollection::Count
// System::Windows::Forms::TreeNodeCollection::CopyTo()
/*
The following program demonstrates 'Count' property and 'CopyTo'
method of 'System::Windows::Forms::TreeNodeCollection' class. It
creates a TreeView with two TreeNodes and gets the collection of
TreeNodes. It copies the collection into an array
and displays the count of the collection and the elements of the
array.
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
      
      // Add TreeNodes.
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
      CopyTreeNodes();
   }

   // <Snippet2>
   // <Snippet1>
   void CopyTreeNodes()
   {
      // Get the collection of TreeNodes.
      TreeNodeCollection^ myNodeCollection = myTreeView->Nodes;
      int myCount = myNodeCollection->Count;
      myLabel->Text = String::Concat( myLabel->Text, "Number of nodes in the collection : ", myCount );
      myLabel->Text = String::Concat( myLabel->Text, "\n\nElements of the Array after Copying from the collection :\n" );
      
      // Create an Object array.
      array<Object^>^myArray = gcnew array<Object^>(myCount);
      
      // Copy the collection into an array.
      myNodeCollection->CopyTo( myArray, 0 );
      for ( int i = 0; i < myArray->Length; i++ )
      {
         myLabel->Text = myLabel->Text + (dynamic_cast<TreeNode^>(myArray[ i ]))->Text + "\n";

      }
   }
   // </Snippet1>
   // </Snippet2>
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
