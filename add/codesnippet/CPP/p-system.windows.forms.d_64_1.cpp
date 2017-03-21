      // Draw the ToolTip using default values if the ToolTip is for button3.
      else if ( e->AssociatedControl == button3 )
      {
         e->DrawBackground();
         e->DrawBorder();
         e->DrawText();
      }