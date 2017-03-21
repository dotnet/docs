protected:
   DomainUpDown^ domainUpDown1;

private:
   void InitializeMyDomainUpDown()
   {
      // Create and initialize the DomainUpDown control.
      domainUpDown1 = gcnew DomainUpDown;
      
      // Add the DomainUpDown control to the form.
      Controls->Add( domainUpDown1 );
   }

   void button1_Click( Object^ sender,
      EventArgs^ e )
   {
      // Add the text box contents and initial location in the collection
      // to the DomainUpDown control.
      domainUpDown1->Items->Add( String::Concat(
         (textBox1->Text->Trim()), " - ", myCounter ) );
      
      // Increment the counter variable.
      myCounter = myCounter + 1;
      
      // Clear the TextBox.
      textBox1->Text = "";
   }

   void checkBox1_Click( Object^ sender,
      EventArgs^ e )
   {
      
      // If Sorted is set to true, set it to false; 
      // otherwise set it to true.
      domainUpDown1->Sorted =  !domainUpDown1->Sorted;
   }

   void domainUpDown1_SelectedItemChanged( Object^ sender,
      EventArgs^ e )
   {
      
      // Display the SelectedIndex and 
      // SelectedItem property values in a MessageBox.
      MessageBox::Show( String::Concat( "SelectedIndex: ", domainUpDown1->SelectedIndex,
         "\nSelectedItem: ", domainUpDown1->SelectedItem ) );
   }