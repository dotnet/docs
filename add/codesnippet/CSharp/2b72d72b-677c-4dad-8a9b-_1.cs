		protected override void OnSubscribeControlEvents(Control c)
		{
			// Call the base so the base events are connected.
			base.OnSubscribeControlEvents(c);

			// Cast the control to a MonthCalendar control.
			MonthCalendar monthCalendarControl = (MonthCalendar) c;

			// Add the event.
			monthCalendarControl.DateChanged +=
				new DateRangeEventHandler(OnDateChanged);
		}