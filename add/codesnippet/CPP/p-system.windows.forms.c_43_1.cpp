   void WhatIsChecked_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display in a message box all the items that are checked.
      // First show the index and check state of all selected items.
      IEnumerator^ myEnum1 = checkedListBox1->CheckedIndices->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         Int32 indexChecked =  *safe_cast<Int32^>(myEnum1->Current);
         
         // The indexChecked variable contains the index of the item.
         MessageBox::Show( String::Concat( "Index#: ", indexChecked, ", is checked. Checked state is: ", checkedListBox1->GetItemCheckState( indexChecked ), "." ) );
      }

      
      // Next show the Object* title and check state for each item selected.
      IEnumerator^ myEnum2 = checkedListBox1->CheckedItems->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         Object^ itemChecked = safe_cast<Object^>(myEnum2->Current);
         
         // Use the IndexOf method to get the index of an item.
         MessageBox::Show( String::Concat( "Item with title: \"", itemChecked, "\", is checked. Checked state is: ", checkedListBox1->GetItemCheckState( checkedListBox1->Items->IndexOf( itemChecked ) ), "." ) );
      }
   }

