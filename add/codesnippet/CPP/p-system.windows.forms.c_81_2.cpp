   // The event handler on Form2.
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Get the Name property of the Parent.
      String^ s = ParentForm->Name;

      // Display the name in a message box.
      MessageBox::Show( String::Concat( "My Parent is ", s, "." ) );
   }