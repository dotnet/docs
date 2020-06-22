Module Module1

    Sub Main()

        '<Snippet1>
        MsgBox("The current date is " & DateString)
        '</Snippet1>

        '<Snippet2>
        MsgBox("The current time is " & TimeString)
        '</Snippet2>

        '<Snippet3>
        Dim currentTime As Date
        currentTime = TimeOfDay
        '</Snippet3>
        MsgBox(currentTime)

        '<Snippet4>
        Dim ThisMoment As Date
        ' The following statement calls the Get procedure of the Visual Basic Now property.
        ThisMoment = Now
        '</Snippet4>
        MsgBox(ThisMoment)

        '<Snippet5>
        Dim thisDate As Date
        thisDate = Today
        '</Snippet5>
        MsgBox(thisDate)
    End Sub

End Module
