private:
   void CreateMyChildForm()
   {
      // Create a new form to represent the child form.
      Form^ child = gcnew Form;

      // Increment the private child count.
      childCount++;

      // Set the text of the child form using the count of child forms.
      String^ formText = String::Format( "Child {0}", childCount );
      child->Text = formText;

      // Make the new form a child form.
      child->MdiParent = this;

      // Display the child form.
      child->Show();
   }