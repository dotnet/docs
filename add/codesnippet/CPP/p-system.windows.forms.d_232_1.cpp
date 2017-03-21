      // Draw a custom background and text if the ToolTip is for button2.
      else
      
      // Draw a custom background and text if the ToolTip is for button2.
      if ( e->AssociatedControl == button2 )
      {
         // Draw the custom background.
         e->Graphics->FillRectangle( SystemBrushes::ActiveCaption, e->Bounds );
         
         // Draw the standard border.
         e->DrawBorder();
         
         // Draw the custom text.
         // The using block will dispose the StringFormat automatically.
         StringFormat^ sf = gcnew StringFormat;
         try
         {
            sf->Alignment = StringAlignment::Center;
            sf->LineAlignment = StringAlignment::Center;
            sf->HotkeyPrefix = System::Drawing::Text::HotkeyPrefix::None;
            sf->FormatFlags = StringFormatFlags::NoWrap;
            System::Drawing::Font^ f = gcnew System::Drawing::Font( "Tahoma",9 );
            try
            {
               e->Graphics->DrawString( e->ToolTipText, f, SystemBrushes::ActiveCaptionText, e->Bounds, sf );
            }
            finally
            {
               if ( f )
                  delete safe_cast<IDisposable^>(f);
            }

         }
         finally
         {
            if ( sf )
               delete safe_cast<IDisposable^>(sf);
         }
      }