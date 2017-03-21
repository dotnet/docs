private:
   void DisplayMyScrollableForm()
   {
      // Create a new form.
      Form^ form2 = gcnew Form;

      // Create a button to add to the new form.
      Button^ button1 = gcnew Button;

      // Set text for the button.
      button1->Text = "Scrolled Button";

      // Set the size of the button.
      button1->Size = System::Drawing::Size( 100, 30 );

      // Set the location of the button to be outside the form's client area.
      button1->Location = Point(form2->Size.Width + 200,form2->Size.Height + 200);

      // Add the button control to the new form.
      form2->Controls->Add( button1 );

      // Set the AutoScroll property to true to provide scrollbars.
      form2->AutoScroll = true;

      // Display the new form as a dialog box.
      form2->ShowDialog();
   }