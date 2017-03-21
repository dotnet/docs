		protected override void OnUnsubscribeControlEvents(Control c)
		{
			// Call the base method so the basic events are unsubscribed.
			base.OnUnsubscribeControlEvents(c);

			// Cast the control to a MonthCalendar control.
			MonthCalendar monthCalendarControl = (MonthCalendar) c;

			// Remove the event.
			monthCalendarControl.DateChanged -=
				new DateRangeEventHandler(OnDateChanged);
		}