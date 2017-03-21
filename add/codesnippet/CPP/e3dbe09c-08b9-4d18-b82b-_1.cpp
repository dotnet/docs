   // Open the Help file for the Character Map topic and 
   // display the Index page.
   void Button2_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Help::ShowHelp( TextBox1, "file://c:\\charmap.chm", HelpNavigator::Index );
   }