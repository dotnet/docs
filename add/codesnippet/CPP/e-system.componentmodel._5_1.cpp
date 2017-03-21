   // This event handler updates the progress bar.
   void backgroundWorker1_ProgressChanged( Object^ /*sender*/, ProgressChangedEventArgs^ e )
   {
      this->progressBar1->Value = e->ProgressPercentage;
   }