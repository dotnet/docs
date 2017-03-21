private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Stream^ myStream;
      OpenFileDialog^ openFileDialog1 = gcnew OpenFileDialog;

      openFileDialog1->InitialDirectory = "c:\\";
      openFileDialog1->Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      openFileDialog1->FilterIndex = 2;
      openFileDialog1->RestoreDirectory = true;

      if ( openFileDialog1->ShowDialog() == System::Windows::Forms::DialogResult::OK )
      {
         if ( (myStream = openFileDialog1->OpenFile()) != nullptr )
         {
            // Insert code to read the stream here.
            myStream->Close();
         }
      }
   }