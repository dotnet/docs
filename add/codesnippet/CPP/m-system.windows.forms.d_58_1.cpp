private:
   void GetMyFormatInfomation()
   {
      // Creates a DataFormats.Format for the Unicode data format.
      DataFormats::Format^ myFormat = DataFormats::GetFormat(
         DataFormats::UnicodeText );
      
      // Displays the contents of myFormat.
      textBox1->Text = String::Format( "ID value: {0}\nFormat name: {1}",
         myFormat->Id, myFormat->Name );
   }