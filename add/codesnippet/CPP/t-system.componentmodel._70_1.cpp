   // This event handler deals with the results of the
   // background operation.
   void backgroundWorker1_RunWorkerCompleted( Object^ /*sender*/, RunWorkerCompletedEventArgs^ e )
   {
      // First, handle the case where an exception was thrown.
      if ( e->Error != nullptr )
      {
         MessageBox::Show( e->Error->Message );
      }
      else
      if ( e->Cancelled )
      {
         // Next, handle the case where the user cancelled 
         // the operation.
         // Note that due to a race condition in 
         // the DoWork event handler, the Cancelled
         // flag may not have been set, even though
         // CancelAsync was called.
         resultLabel->Text = "Cancelled";
      }
      else
      {
         // Finally, handle the case where the operation 
         // succeeded.
         resultLabel->Text = e->Result->ToString();
      }

      // Enable the UpDown control.
      this->numericUpDown1->Enabled = true;

      // Enable the Start button.
      startAsyncButton->Enabled = true;

      // Disable the Cancel button.
      cancelAsyncButton->Enabled = false;
   }