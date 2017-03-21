private:
   void CreateMyFormat2()
   {
      DataFormats::Format^ myFormat = gcnew DataFormats::Format(
         "AnotherNewFormat", 20916 );
      
      // Displays the contents of myFormat.
      textBox1->Text = String::Format( "ID value: {0}\nFormat name: {1}",
         myFormat->Id, myFormat->Name );
   }