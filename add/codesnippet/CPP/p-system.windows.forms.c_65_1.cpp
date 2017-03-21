   private:
      void treeView1_KeyDown( Object^ /*sender*/, KeyEventArgs^ e )
      {
         /* If the 'Alt' and 'E' keys are pressed,
            * allow the user to edit the TreeNode label. */
         if ( e->Alt && e->KeyCode == Keys::E )
         {
            treeView1->LabelEdit = true;
            
            // If there is a TreeNode under the mose cursor, begin editing.
            TreeNode^ editNode = treeView1->GetNodeAt( treeView1->PointToClient( Control::MousePosition ) );
            if ( editNode != nullptr )
            {
               editNode->BeginEdit();
            }
         }
      }

      void treeView1_AfterLabelEdit( Object^ /*sender*/, NodeLabelEditEventArgs^ /*e*/ )
      {
         // Disable the ability to edit the TreeNode labels.
         treeView1->LabelEdit = false;
      }