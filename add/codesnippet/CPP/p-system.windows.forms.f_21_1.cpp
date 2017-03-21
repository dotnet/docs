private:
   void CreateMyOpaqueForm()
   {
      // Create a new form.
      Form^ form2 = gcnew Form;

      // Set the text displayed in the caption.
      form2->Text = "My Form";

      // Set the opacity to 75%.
      form2->Opacity = .75;

      // Size the form to be 300 pixels in height and width.
      form2->Size = System::Drawing::Size( 300, 300 );

      // Display the form in the center of the screen.
      form2->StartPosition = FormStartPosition::CenterScreen;

      // Display the form as a modal dialog box.
      form2->ShowDialog();
   }