    Public Class BaseClass
        ' Declare an event.
        Event Ev1()
    End Class
    Class DerivedClass
        Inherits BaseClass
        Sub TestEvents() Handles MyBase.Ev1
            ' Add code to handle this event.
        End Sub
    End Class