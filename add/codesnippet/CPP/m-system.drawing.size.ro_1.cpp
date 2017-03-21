   void TruncateAndRoundSizes()
   {
      // Create a SizeF.
      SizeF theSize = SizeF(75.9F,75.9F);
      
      // Round the Size.
      System::Drawing::Size roundedSize = ::Size::Round( theSize );
      
      // Truncate the Size.
      System::Drawing::Size truncatedSize = ::Size::Truncate( theSize );
      
      //Print out the values on two labels.
      Label1->Text = String::Format( "Rounded size = {0}", roundedSize );
      Label2->Text = String::Format( "Truncated size = {0}", truncatedSize );
   }