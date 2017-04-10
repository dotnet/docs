

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   TreeView^ treeView1;
   Button^ showCheckedNodesButton;
   TreeViewCancelEventHandler^ checkForCheckedChildren;

public:
   Form1()
   {
      treeView1 = gcnew TreeView;
      showCheckedNodesButton = gcnew Button;
      checkForCheckedChildren = gcnew TreeViewCancelEventHandler( this, &Form1::CheckForCheckedChildrenHandler );
      this->SuspendLayout();
      
      // Initialize treeView1.
      treeView1->Location = Point(0,25);
      treeView1->Size = System::Drawing::Size( 292, 248 );
      treeView1->Anchor = static_cast<AnchorStyles>(AnchorStyles::Top | AnchorStyles::Left | AnchorStyles::Bottom | AnchorStyles::Right);
      treeView1->CheckBoxes = true;
      
      // Add nodes to treeView1.
      TreeNode^ node;
      for ( int x = 0; x < 3; ++x )
      {
         
         // Add a root node.
         node = treeView1->Nodes->Add( String::Format( "Node{0}", x * 4 ) );
         for ( int y = 1; y < 4; ++y )
         {
            
            // Add a node as a child of the previously added node.
            node = node->Nodes->Add( String::Format( "Node{0}", x * 4 + y ) );

         }

      }
      
      // Set the checked state of one of the nodes to
      // demonstrate the showCheckedNodesButton button behavior.
      treeView1->Nodes[ 1 ]->Nodes[ 0 ]->Nodes[ 0 ]->Checked = true;
      
      // Initialize showCheckedNodesButton.
      showCheckedNodesButton->Size = System::Drawing::Size( 144, 24 );
      showCheckedNodesButton->Text = "Show Checked Nodes";
      showCheckedNodesButton->Click += gcnew EventHandler( this, &Form1::showCheckedNodesButton_Click );
      
      // Initialize the form.
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^temp1 = {showCheckedNodesButton,treeView1};
      this->Controls->AddRange( temp1 );
      this->ResumeLayout( false );
   }

   //<Snippet2>
private:
   void showCheckedNodesButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Disable redrawing of treeView1 to prevent flickering 
      // while changes are made.
      treeView1->BeginUpdate();
      
      // Collapse all nodes of treeView1.
      treeView1->ExpandAll();
      
      // Add the checkForCheckedChildren event handler to the BeforeExpand event.
      treeView1->BeforeCollapse += checkForCheckedChildren;
      
      // Expand all nodes of treeView1. Nodes without checked children are 
      // prevented from expanding by the checkForCheckedChildren event handler.
      treeView1->CollapseAll();
      
      // Remove the checkForCheckedChildren event handler from the BeforeExpand 
      // event so manual node expansion will work correctly.
      treeView1->BeforeCollapse -= checkForCheckedChildren;
      
      // Enable redrawing of treeView1.
      treeView1->EndUpdate();
   }

   // Prevent collapse of a node that has checked child nodes.
   void CheckForCheckedChildrenHandler( Object^ /*sender*/, TreeViewCancelEventArgs^ e )
   {
      if ( HasCheckedChildNodes( e->Node ) )
            e->Cancel = true;
   }

   // Returns a value indicating whether the specified 
   // TreeNode has checked child nodes.
   bool HasCheckedChildNodes( TreeNode^ node )
   {
      if ( node->Nodes->Count == 0 )
            return false;

      System::Collections::IEnumerator^ myEnum = node->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ childNode = safe_cast<TreeNode^>(myEnum->Current);
         if ( childNode->Checked )
                  return true;

         // Recursively check the children of the current child node.
         if ( HasCheckedChildNodes( childNode ) )
                  return true;
      }

      return false;
   }
   //</Snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
