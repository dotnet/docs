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