

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

public:
   Form1()
   {
      treeView1 = gcnew TreeView;
      this->SuspendLayout();
      
      // Initialize treeView1.
      treeView1->AllowDrop = true;
      treeView1->Dock = DockStyle::Fill;
      
      // Add nodes to treeView1.
      TreeNode^ node;
      for ( int x = 0; x < 3; ++x )
      {
         
         // Add a root node to treeView1.
         node = treeView1->Nodes->Add( String::Format( "Node{0}", x * 4 ) );
         for ( int y = 1; y < 4; ++y )
         {
            
            // Add a child node to the previously added node.
            node = node->Nodes->Add( String::Format( "Node{0}", x * 4 + y ) );

         }
      }
      
      // Add event handlers for the required drag events.
      treeView1->ItemDrag += gcnew ItemDragEventHandler( this, &Form1::treeView1_ItemDrag );
      treeView1->DragEnter += gcnew DragEventHandler( this, &Form1::treeView1_DragEnter );
      treeView1->DragOver += gcnew DragEventHandler( this, &Form1::treeView1_DragOver );
      treeView1->DragDrop += gcnew DragEventHandler( this, &Form1::treeView1_DragDrop );
      
      // Initialize the form.
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->Controls->Add( treeView1 );
      this->ResumeLayout( false );
   }

   //<Snippet2>
private:
   void treeView1_ItemDrag( Object^ /*sender*/, ItemDragEventArgs^ e )
   {
      
      // Move the dragged node when the left mouse button is used.
      if ( e->Button == ::MouseButtons::Left )
      {
         DoDragDrop( e->Item, DragDropEffects::Move );
      }
      // Copy the dragged node when the right mouse button is used.
      else
      
      // Copy the dragged node when the right mouse button is used.
      if ( e->Button == ::MouseButtons::Right )
      {
         DoDragDrop( e->Item, DragDropEffects::Copy );
      }
   }
   //</Snippet2>

   // Set the target drop effect to the effect 
   // specified in the ItemDrag event handler.
   void treeView1_DragEnter( Object^ /*sender*/, DragEventArgs^ e )
   {
      e->Effect = e->AllowedEffect;
   }

   // Select the node under the mouse pointer to indicate the 
   // expected drop location.
   void treeView1_DragOver( Object^ /*sender*/, DragEventArgs^ e )
   {
      // Retrieve the client coordinates of the mouse position.
      Point targetPoint = treeView1->PointToClient( Point(e->X,e->Y) );
      
      // Select the node at the mouse position.
      treeView1->SelectedNode = treeView1->GetNodeAt( targetPoint );
   }

   void treeView1_DragDrop( Object^ /*sender*/, DragEventArgs^ e )
   {
      // Retrieve the client coordinates of the drop location.
      Point targetPoint = treeView1->PointToClient( Point(e->X,e->Y) );
      
      // Retrieve the node at the drop location.
      TreeNode^ targetNode = treeView1->GetNodeAt( targetPoint );
      
      // Retrieve the node that was dragged.
      TreeNode^ draggedNode = dynamic_cast<TreeNode^>(e->Data->GetData( TreeNode::typeid ));
      
      // Confirm that the node at the drop location is not 
      // the dragged node or a descendant of the dragged node.
      if (  !draggedNode->Equals( targetNode ) &&  !ContainsNode( draggedNode, targetNode ) )
      {
         
         // If it is a move operation, remove the node from its current 
         // location and add it to the node at the drop location.
         if ( e->Effect == DragDropEffects::Move )
         {
            draggedNode->Remove();
            targetNode->Nodes->Add( draggedNode );
         }
         // If it is a copy operation, clone the dragged node 
         // and add it to the node at the drop location.
         else
         
         // If it is a copy operation, clone the dragged node 
         // and add it to the node at the drop location.
         if ( e->Effect == DragDropEffects::Copy )
         {
            targetNode->Nodes->Add( dynamic_cast<TreeNode^>(draggedNode->Clone()) );
         }
         
         // Expand the node at the location 
         // to show the dropped node.
         targetNode->Expand();
      }
   }

   // Determine whether one node is a parent 
   // or ancestor of a second node.
   bool ContainsNode( TreeNode^ node1, TreeNode^ node2 )
   {
      // Check the parent node of the second node.
      if ( node2->Parent == nullptr )
            return false;

      if ( node2->Parent->Equals( node1 ) )
            return true;
      
      // If the parent node is not null or equal to the first node, 
      // call the ContainsNode method recursively using the parent of 
      // the second node.
      return ContainsNode( node1, node2->Parent );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
