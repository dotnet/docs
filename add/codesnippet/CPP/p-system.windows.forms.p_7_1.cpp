private:
   void CopyWithProgress( array<String^>^filenames )
   {
      // Display the ProgressBar control.
      pBar1->Visible = true;

      // Set Minimum to 1 to represent the first file being copied.
      pBar1->Minimum = 1;

      // Set Maximum to the total number of files to copy.
      pBar1->Maximum = filenames->Length;

      // Set the initial value of the ProgressBar.
      pBar1->Value = 1;

      // Set the Step property to a value of 1 to represent each file being copied.
      pBar1->Step = 1;

      // Loop through all files to copy.
      for ( int x = 1; x <= filenames->Length; x++ )
      {
         // Copy the file and increment the ProgressBar if successful.
         if ( CopyFile( filenames[ x - 1 ] ) == true )
         {
            // Perform the increment on the ProgressBar.
            pBar1->PerformStep();
         }
      }
   }