private:
   void treeView1_MouseUp( Object^ /*sender*/, MouseEventArgs^ e )
   {
      // If the right mouse button was clicked and released,
      // display the shortcut menu assigned to the TreeView.
      if ( e->Button == ::MouseButtons::Right )
      {
         treeView1->ContextMenu->Show( treeView1, Point(e->X,e->Y) );
      }
   }