private:
   void button1_Click( Object^ sender, EventArgs^ e )
   {
      // Set the SelectionRange with start and end dates from text boxes.
      try
      {
         monthCalendar1->SelectionRange = gcnew SelectionRange(
            DateTime::Parse( textBox1->Text ),
            DateTime::Parse( textBox2->Text ) );
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }