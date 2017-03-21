   void OnSubscribeControlEvents( System::Windows::Forms::Control^ c )
   {
      // Call the base so the base events are connected.
      __super::OnSubscribeControlEvents( c );
      
      // Cast the control to a MonthCalendar control.
      MonthCalendar^ monthCalendarControl = (MonthCalendar^)c;
      
      // Add the event.
      monthCalendarControl->DateChanged += gcnew DateRangeEventHandler( this, &ToolStripMonthCalendar::HandleDateChanged );
   }