   // The event handler on Form1.
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create an instance of Form2.
      Form1^ f2 = gcnew Form2;

      // Make this form the parent of f2.
      f2->MdiParent = this;

      // Display the form.
      f2->Show();
   }