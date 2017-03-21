protected:
   DomainUpDown^ domainUpDown1;

private:
   void MySub()
   {
      // Create and initialize the DomainUpDown control.
      domainUpDown1 = gcnew System::Windows::Forms::DomainUpDown;
      
      // Add the DomainUpDown control to the form.
      Controls->Add( domainUpDown1 );
   }

   void button1_Click( System::Object^ sender,
     System::EventArgs^ e )
   {
      // Add the text box contents and initial location in the collection
      // to the DomainUpDown control.
      domainUpDown1->Items->Add( String::Concat(
         (textBox1->Text->Trim()), " - ", myCounter.ToString() ) );
      
      // Increment the counter variable.
      myCounter = myCounter + 1;
      
      // Clear the TextBox.
      textBox1->Text = "";
   }

   void checkBox1_Click( Object^ sender, EventArgs^ e )
   {
      // If Sorted is set to true, set it to false; 
      // otherwise set it to true.
      if ( domainUpDown1->Sorted )
      {
         domainUpDown1->Sorted = false;
      }
      else
      {
         domainUpDown1->Sorted = true;
      }
   }

   void domainUpDown1_SelectedItemChanged( Object^ sender, EventArgs^ e )
   {
      // Display the SelectedIndex and SelectedItem property values in a MessageBox.
      MessageBox::Show( String::Concat( "SelectedIndex: ",
      domainUpDown1->SelectedIndex.ToString(), "\n", "SelectedItem: ",
      domainUpDown1->SelectedItem->ToString() ) );
   }