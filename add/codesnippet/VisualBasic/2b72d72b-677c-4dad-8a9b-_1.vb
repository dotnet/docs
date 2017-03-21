    Protected Overrides Sub OnSubscribeControlEvents(ByVal c As Control) 

        ' Call the base so the base events are connected.
        MyBase.OnSubscribeControlEvents(c)
        
        ' Cast the control to a MonthCalendar control.
        Dim monthCalendarControl As MonthCalendar = _
            CType(c, MonthCalendar)

        ' Add the event.
        AddHandler monthCalendarControl.DateChanged, _
            AddressOf HandleDateChanged
    
    End Sub