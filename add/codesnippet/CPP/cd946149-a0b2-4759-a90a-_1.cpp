   // Creates a Hashtable object with one entry for each unique
   // subitem value (or initial letter for the parent item)
   // in the specified column.
private:
   Hashtable^ CreateGroupsTable(int column)
   {
      // Create a Hashtable object.
      Hashtable^ groups = gcnew Hashtable();

      // Iterate through the items in myListView.
      IEnumerator^ myEnum1 = myListView->Items->GetEnumerator();
      while (myEnum1->MoveNext())
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum1->Current);
         // Retrieve the text value for the column.
         String^ subItemText = item->SubItems[column]->Text;

         // Use the initial letter instead if it is the first column.
         if (column == 0) 
         {
            subItemText = subItemText->Substring(0, 1);
         }

         // If the groups table does not already contain a group
         // for the subItemText value, add a new group using the 
         // subItemText value for the group header and Hashtable key.
         if (!groups->Contains(subItemText))
         {
            groups->Add( subItemText, gcnew ListViewGroup(subItemText, 
               HorizontalAlignment::Left) );
         }
      }

      // Return the Hashtable object.
      return groups;
   }