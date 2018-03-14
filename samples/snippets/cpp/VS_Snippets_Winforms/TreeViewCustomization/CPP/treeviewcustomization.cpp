

//<Snippet1>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

//<Snippet2>
public ref class CustomizedTreeView: public TreeView
{
public:
   CustomizedTreeView()
   {

      // Customize the TreeView control by setting various properties.
      BackColor = System::Drawing::Color::CadetBlue;
      FullRowSelect = true;
      HotTracking = true;
      Indent = 34;
      ShowPlusMinus = false;

      // The ShowLines property must be false for the FullRowSelect
      // property to work.
      ShowLines = false;
   }

protected:
   virtual void OnAfterSelect( TreeViewEventArgs^ e ) override
   {
      // Confirm that the user initiated the selection.
      // This prevents the first node from expanding when it is
      // automatically selected during the initialization of
      // the TreeView control.
      if ( e->Action != TreeViewAction::Unknown )
      {
         if ( e->Node->IsExpanded )
         {
            e->Node->Collapse();
         }
         else
         {
            e->Node->Expand();
         }
      }

      
      // Remove the selection. This allows the same node to be
      // clicked twice in succession to toggle the expansion state.
      SelectedNode = nullptr;
   }
};
//</Snippet2>

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
   {
      // Initialize myTreeView.
      CustomizedTreeView^ myTreeView = gcnew CustomizedTreeView;
      myTreeView->Dock = DockStyle::Fill;
      
      // Add nodes to myTreeView.
      TreeNode^ node;
      for ( int x = 0; x < 3; ++x )
      {
         // Add a root node.
         node = myTreeView->Nodes->Add( String::Format( "Node{0}", x * 4 ) );
         for ( int y = 1; y < 4; ++y )
         {
            // Add a node as a child of the previously added node.
            node = node->Nodes->Add( String::Format( "Node{0}", x * 4 + y ) );

         }
      }
      
      // Add myTreeView to the form.
      this->Controls->Add( myTreeView );
   }
};

int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
