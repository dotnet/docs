    Public Class BaseClass
        Public Event BaseEvent(ByVal i As Integer)
        ' Place methods and properties here.
    End Class

    Public Class DerivedClass
        Inherits BaseClass
        Sub EventHandler(ByVal x As Integer) Handles MyBase.BaseEvent
            ' Place code to handle events from BaseClass here.
        End Sub
    End Class