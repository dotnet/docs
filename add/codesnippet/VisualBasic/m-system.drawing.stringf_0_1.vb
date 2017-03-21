    Public Sub GetSetTabStopsExample2(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Tools used for drawing, painting.
        Dim redPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))

        ' Layout and format for text.
        Dim myFont As New Font("Times New Roman", 12)
        Dim myStringFormat As New StringFormat
        Dim enclosingRectangle As New Rectangle(20, 20, 500, 100)
        Dim tabStops As Single() = {150.0F, 100.0F, 100.0F}

        ' Text with tabbed columns.
        Dim myString As String = "Name" & ControlChars.Tab & "Tab 1" _
        & ControlChars.Tab & "Tab 2" & ControlChars.Tab & "Tab 3" _
        & ControlChars.Cr & "George Brown" & ControlChars.Tab & "One" _
        & ControlChars.Tab & "Two" & ControlChars.Tab & "Three"

        ' Set the tab stops, paint the text specified by myString,
        ' and draw rectangle that encloses the text.
        myStringFormat.SetTabStops(0.0F, tabStops)
        g.DrawString(myString, myFont, blueBrush, _
        RectangleF.op_Implicit(enclosingRectangle), myStringFormat)
        g.DrawRectangle(redPen, enclosingRectangle)

        ' Get the tab stops.
        Dim firstTabOffset As Single
        Dim tabStopsObtained As Single() = _
        myStringFormat.GetTabStops(firstTabOffset)
        Dim j As Integer
        For j = 0 To tabStopsObtained.Length - 1

            ' Inspect or use the value in tabStopsObtained[j].
            Console.WriteLine(ControlChars.Cr & "  Tab stop {0} = {1}", _
            j, tabStopsObtained(j))
        Next j
    End Sub