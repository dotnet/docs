         // Gets or sets the location for the curve legend.
         Point get()
         {
            return location;
         }

         void set( Point value )
         {
            location = value;
            chart->Invalidate();
            
            // Notifies the chart of the location change. This is used for
            // the accessibility information. AccessibleEvents::LocationChange
            // tells the chart the reason for the notification.
            chart->AccessibilityNotifyClients( AccessibleEvents::LocationChange, (dynamic_cast<CurveLegendAccessibleObject^>(AccessibilityObject))->ID );
         }

      }

      property String^ Name 
      {

         // Gets or sets the Name for the curve legend.
         String^ get()
         {
            return name;
         }

         void set( String^ value )
         {
            if ( name != value )
            {
               name = value;
               chart->Invalidate();
               
               // Notifies the chart of the name change. This is used for
               // the accessibility information. AccessibleEvents::NameChange
               // tells the chart the reason for the notification.
               chart->AccessibilityNotifyClients( AccessibleEvents::NameChange, (dynamic_cast<CurveLegendAccessibleObject^>(AccessibilityObject))->ID );
            }
         }

      }

      property bool Selected 
      {

         // Gets or sets the Selected state for the curve legend.
         bool get()
         {
            return selected;
         }

         void set( bool value )
         {
            if ( selected != value )
            {
               selected = value;
               chart->Invalidate();
               
               // Notifies the chart of the selection value change. This is used for
               // the accessibility information. The AccessibleEvents value depends upon
               // if the selection is true (AccessibleEvents::SelectionAdd) or
               // false (AccessibleEvents::SelectionRemove).
               chart->AccessibilityNotifyClients( selected ? AccessibleEvents::SelectionAdd : AccessibleEvents::SelectionRemove, (dynamic_cast<CurveLegendAccessibleObject^>(AccessibilityObject))->ID );
            }
         }