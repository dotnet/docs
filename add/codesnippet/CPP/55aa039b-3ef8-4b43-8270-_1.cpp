   void OnUnsubscribeControlEvents( System::Windows::Forms::Control^ c )
   {
      
      // Call the base method so the basic events are unsubscribed.
      __super::OnUnsubscribeControlEvents( c );
      
      // Cast the control to a MonthCalendar control.
      MonthCalendar^ monthCalendarControl = (MonthCalendar^)c;
      
      // Remove the event.
      monthCalendarControl->DateChanged -= gcnew DateRangeEventHandler( this, &ToolStripMonthCalendar::HandleDateChanged );
   }