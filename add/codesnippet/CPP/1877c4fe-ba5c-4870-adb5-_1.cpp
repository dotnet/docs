   private:
      void DrawMyPanel( Object^ /*sender*/, System::Windows::Forms::StatusBarDrawItemEventArgs^ sbdevent )
      {
         // Create a StringFormat object to align text in the panel.
         StringFormat^ sf = gcnew StringFormat;

         // Format the String of the StatusBarPanel to be centered.
         sf->Alignment = StringAlignment::Center;
         sf->LineAlignment = StringAlignment::Center;

         // Draw a back blackground in owner-drawn panel.
         sbdevent->Graphics->FillRectangle( Brushes::Black, sbdevent->Bounds );

         // Draw the current date (short date format) with white text in the control's font.
         sbdevent->Graphics->DrawString( DateTime::Today.ToShortDateString(), statusBar1->Font, Brushes::White, sbdevent->Bounds, sf );
      }