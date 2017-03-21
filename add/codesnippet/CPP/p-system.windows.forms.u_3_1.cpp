   void numericUpDown1_Leave( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      /* If the entered value is greater than Minimum or Maximum,
            select the text and open a message box. */
      if ( (System::Convert::ToInt32( numericUpDown1->Text ) > numericUpDown1->Maximum) || (System::Convert::ToInt32( numericUpDown1->Text ) < numericUpDown1->Minimum) )
      {
         MessageBox::Show( "The value entered was not between the Minimum andMaximum allowable values.\nPlease re-enter." );
         numericUpDown1->Focus();
         numericUpDown1->Select(0,numericUpDown1->Text->Length);
      }
   }

   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      int varPrefHeight1;
      
      /* Capture the PreferredHeight before and after the Font
            is changed, and display the results in a message box. */
      varPrefHeight1 = numericUpDown1->PreferredHeight;
      numericUpDown1->Font = gcnew System::Drawing::Font( "Microsoft Sans Serif",12.0,System::Drawing::FontStyle::Bold );
      MessageBox::Show( String::Format( "Before Font Change: {0}\nAfter Font Change: {1}", varPrefHeight1, numericUpDown1->PreferredHeight ) );
   }