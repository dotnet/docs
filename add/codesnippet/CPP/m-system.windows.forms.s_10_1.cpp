private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Stream^ myStream;
      SaveFileDialog^ saveFileDialog1 = gcnew SaveFileDialog;
      saveFileDialog1->Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog1->FilterIndex = 2;
      saveFileDialog1->RestoreDirectory = true;
      if ( saveFileDialog1->ShowDialog() == ::DialogResult::OK )
      {
         if ( (myStream = saveFileDialog1->OpenFile()) != nullptr )
         {
            
            // Code to write the stream goes here.
            myStream->Close();
         }
      }
   }
