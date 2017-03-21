   // The following method displays the default font, 
   // background color and foreground color values for the ListBox  
   // control. The values are displayed in the ListBox, itself.
   void Populate_ListBox()
   {
      ListBox1->Dock = DockStyle::Bottom;
      
      // Display the values in the read-only properties 
      // DefaultBackColor, DefaultFont, DefaultForecolor.
      ListBox1->Items->Add( String::Format( "Default BackColor: {0}", ListBox::DefaultBackColor ) );
      ListBox1->Items->Add( String::Format( "Default Font: {0}", ListBox::DefaultFont ) );
      ListBox1->Items->Add( String::Format( "Default ForeColor:{0}", ListBox::DefaultForeColor ) );
   }