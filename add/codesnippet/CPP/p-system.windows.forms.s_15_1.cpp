      // Basic SplitContainer properties.
      // This is a horizontal splitter whose top and bottom panels are ListView controls. The top panel is fixed.
      splitContainer2->Dock = System::Windows::Forms::DockStyle::Fill;
      
      // The top panel remains the same size when the form is resized.
      splitContainer2->FixedPanel = System::Windows::Forms::FixedPanel::Panel1;
      splitContainer2->Location = System::Drawing::Point( 0, 0 );
      splitContainer2->Name = "splitContainer2";
      
      // Create the horizontal splitter.
      splitContainer2->Orientation = System::Windows::Forms::Orientation::Horizontal;
      splitContainer2->Size = System::Drawing::Size( 207, 273 );
      splitContainer2->SplitterDistance = 125;
      splitContainer2->SplitterWidth = 6;
      
      // splitContainer2 is the third control in the tab order.
      splitContainer2->TabIndex = 2;
      splitContainer2->Text = "splitContainer2";
      