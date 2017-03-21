private:
   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Display the hand cursor when the mouse pointer
      // is over the combo box drop-down button.
      comboBox1->Cursor = Cursors::Hand;
      
      // Fill the combo box with all the logical
      // drives available to the user.
      try
      {
         IEnumerator^ myEnum = Environment::GetLogicalDrives()->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ logicalDrive = safe_cast<String^>(myEnum->Current);
            comboBox1->Items->Add( logicalDrive );
         }
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }