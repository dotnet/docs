' Walkthrough: Declaring and Raising Events
'   8ffb3be8-097d-4d3c-b71e-04555ebda2a2
'<snippet2>
Imports Microsoft.VisualBasic.DateAndTime
'</snippet2>

Public Class Widget
    '<snippet1>
    Public Event PercentDone(ByVal Percent As Single,
                             ByRef Cancel As Boolean)
    '</snippet1>

    '<snippet3>
    Public Sub LongTask(ByVal Duration As Single,
                        ByVal MinimumInterval As Single)
        Dim Threshold As Single
        Dim Start As Single
        Dim blnCancel As Boolean

        ' The Timer property of the DateAndTime object returns the seconds
        ' and milliseconds that have passed since midnight.
        Start = CSng(Timer)
        Threshold = MinimumInterval

        Do While CSng(Timer) < (Start + Duration)
            ' In a real application, some unit of work would
            ' be done here each time through the loop.
            If CSng(Timer) > (Start + Threshold) Then
                RaiseEvent PercentDone(
                Threshold / Duration, blnCancel)
                ' Check to see if the operation was canceled.
                If blnCancel Then Exit Sub
                Threshold = Threshold + MinimumInterval
            End If
        Loop
    End Sub
    '</snippet3>
End Class
