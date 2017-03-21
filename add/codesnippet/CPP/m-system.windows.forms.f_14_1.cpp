   void ShowMyDialogBox()
   {
      Form2^ testDialog = gcnew Form2;
      
      // Show testDialog as a modal dialog and determine if DialogResult = OK.
      if ( testDialog->ShowDialog( this ) == ::DialogResult::OK )
      {
         
         // Read the contents of testDialog's TextBox.
         this->txtResult->Text = testDialog->TextBox1->Text;
      }
      else
      {
         this->txtResult->Text = "Cancelled";
      }

      delete testDialog;
   }