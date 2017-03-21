private:
   void CreateMyTopMostForm()
   {
      // Create lower form to display.
      Form^ bottomForm = gcnew Form;

      // Display the lower form Maximized to demonstrate effect of TopMost property.
      bottomForm->WindowState = FormWindowState::Maximized;

      // Display the bottom form.
      bottomForm->Show();

      // Create the top most form.
      Form^ topMostForm = gcnew Form;

      // Set the size of the form larger than the default size.
      topMostForm->Size = System::Drawing::Size( 300, 300 );

      // Set the position of the top most form to center of screen.
      topMostForm->StartPosition = FormStartPosition::CenterScreen;

      // Display the form as top most form.
      topMostForm->TopMost = true;
      topMostForm->Show();
   }