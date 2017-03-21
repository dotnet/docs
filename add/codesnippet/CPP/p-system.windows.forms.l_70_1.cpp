   // Sets myListView to the groups created for the specified column.
private:
   void SetGroups(int column)
   {
      // Remove the current groups.
      myListView->Groups->Clear();

      // Retrieve the hash table corresponding to the column.
      Hashtable^ groups = dynamic_cast<Hashtable^>(groupTables[column]);

      // Copy the groups for the column to an array.
      array<ListViewGroup^>^ groupsArray = gcnew array<ListViewGroup^>(groups->Count);
      groups->Values->CopyTo(groupsArray, 0);

      // Sort the groups and add them to myListView.
      Array::Sort(groupsArray, gcnew ListViewGroupSorter(myListView->Sorting));
      myListView->Groups->AddRange(groupsArray);

      // Iterate through the items in myListView, assigning each 
      // one to the appropriate group.
      IEnumerator^ myEnum = myListView->Items->GetEnumerator();
      while (myEnum->MoveNext())
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum->Current);
         // Retrieve the subitem text corresponding to the column.
         String^ subItemText = item->SubItems[column]->Text;

         // For the Title column, use only the first letter.
         if (column == 0) 
         {
            subItemText = subItemText->Substring(0, 1);
         }

         // Assign the item to the matching group.
         item->Group = dynamic_cast<ListViewGroup^>(groups[subItemText]);
      }
   }