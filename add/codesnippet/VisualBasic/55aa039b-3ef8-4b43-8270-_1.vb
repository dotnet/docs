    Protected Overrides Sub OnUnsubscribeControlEvents(ByVal c As Control)
        ' Call the base method so the basic events are unsubscribed.
        MyBase.OnUnsubscribeControlEvents(c)

        ' Cast the control to a MonthCalendar control.
        Dim monthCalendarControl As MonthCalendar = _
            CType(c, MonthCalendar)

        ' Remove the event.
        RemoveHandler monthCalendarControl.DateChanged, _
            AddressOf HandleDateChanged

    End Sub