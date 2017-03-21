   // Copy the ToolboxItemCollection to the specified array.
   array<ToolboxItem^>^items = gcnew array<ToolboxItem^>(collection->Count);
   collection->CopyTo( items, 0 );