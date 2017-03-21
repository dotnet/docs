   private:
      void menuItemHelpAbout_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Create and display a modeless about dialog box.
         AboutDialog^ about = gcnew AboutDialog;
         about->Show();
         
         // Draw a blue square on the form.
         /* NOTE: This is not a persistent object, it will no longer be
                     * visible after the next call to OnPaint. To make it persistent,
                     * override the OnPaint method and draw the square there */
         Graphics^ g = about->CreateGraphics();
         g->FillRectangle( Brushes::Blue, 10, 10, 50, 50 );
      }