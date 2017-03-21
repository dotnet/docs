private:
   Timer^ time;

   // Call this method from the constructor of the form.
   void InitializeMyTimer()
   {
      // Set the interval for the timer.
      time->Interval = 250;

      // Connect the Tick event of the timer to its event handler.
      time->Tick += gcnew EventHandler( this, &Form1::IncreaseProgressBar );

      // Start the timer.
      time->Start();
   }

   void IncreaseProgressBar( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Increment the value of the ProgressBar a value of one each time.
      progressBar1->Increment( 1 );

      // Display the textual value of the ProgressBar in the StatusBar control's first panel.
      statusBarPanel1->Text = String::Concat( progressBar1->Value, "% Completed" );

      // Determine if we have completed by comparing the value of the Value property to the Maximum value.
      if ( progressBar1->Value == progressBar1->Maximum )

      // Stop the timer.
      time->Stop();
   }