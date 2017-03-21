   private:
      void DisplayHScroll()
      {
         // Make sure no items are displayed partially.
         listBox1->IntegralHeight = true;

         // Add items that are wide to the ListBox.
         for ( int x = 0; x < 10; x++ )
         {
            listBox1->Items->Add( String::Format( "Item {0} is a very large value that requires scroll bars", x ) );

         }

         // Display a horizontal scroll bar.
         listBox1->HorizontalScrollbar = true;

         // Create a Graphics object to use when determining the size of the largest item in the ListBox.
         Graphics^ g = listBox1->CreateGraphics();

         // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
         int hzSize = (int)g->MeasureString( dynamic_cast<String^>(listBox1->Items[ listBox1->Items->Count - 1 ]), listBox1->Font ).Width;

         // Set the HorizontalExtent property.
         listBox1->HorizontalExtent = hzSize;
      }