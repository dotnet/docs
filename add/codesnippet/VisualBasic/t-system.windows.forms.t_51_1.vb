'Declare a class that inherits from ToolStripControlHost.

Public Class ToolStripMonthCalendar
    Inherits ToolStripControlHost
    
    ' Call the base constructor passing in a MonthCalendar instance.
    Public Sub New() 
        MyBase.New(New MonthCalendar())
    
    End Sub

    Public ReadOnly Property MonthCalendarControl() As MonthCalendar 
        Get
            Return CType(Control, MonthCalendar)
        End Get
    End Property

    ' Expose the MonthCalendar.FirstDayOfWeek as a property.
    Public Property FirstDayOfWeek() As Day 
        Get
            Return MonthCalendarControl.FirstDayOfWeek
        End Get
        Set
            MonthCalendarControl.FirstDayOfWeek = value
        End Set
    End Property
     
    ' Expose the AddBoldedDate method.
    Public Sub AddBoldedDate(ByVal dateToBold As DateTime) 
        MonthCalendarControl.AddBoldedDate(dateToBold)
    
    End Sub

    ' Subscribe and unsubscribe the control events you wish to expose.
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

    ' Declare the DateChanged event.
    Public Event DateChanged As DateRangeEventHandler

    ' Raise the DateChanged event.
    Private Sub HandleDateChanged(ByVal sender As Object, _
        ByVal e As DateRangeEventArgs)

        RaiseEvent DateChanged(Me, e)
    End Sub
End Class