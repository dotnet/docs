   void comboBox1_SelectionChangeCommitted( Object^ sender, EventArgs^ /*e*/ )
   {
      ComboBox^ senderComboBox = dynamic_cast<ComboBox^>(sender);
      
      // Change the length of the text box depending on what the user has 
      // selected and committed using the SelectionLength property.
      if ( senderComboBox->SelectionLength > 0 )
      {
		  textbox1->Width = 
			  senderComboBox->SelectedItem->ToString()->Length * 
			  ((int)this->textbox1->Font->SizeInPoints);
		  textbox1->Text = senderComboBox->SelectedItem->ToString();				
      }
   }