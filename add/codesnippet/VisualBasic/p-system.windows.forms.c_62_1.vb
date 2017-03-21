Public Class FunButton
    Inherits Button

    Protected Overrides Sub OnMouseHover(ByVal e As System.EventArgs)

        ' Get the font size in Points, add one to the
        ' size, and reset the button's font to the larger
        ' size.
        Dim fontSize As Single = Font.SizeInPoints
        fontSize += 1
        Dim buttonSize As System.Drawing.Size = Size
        Me.Font = New System.Drawing.Font _
            (Font.FontFamily, fontSize, Font.Style)

        ' Increase the size width and height of the button 
        ' by 5 points each.
        Size = New System.Drawing.Size _
            (Size.Width + 5, Size.Height + 5)

        ' Call myBase.OnMouseHover to activate the delegate.
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

        ' Make the cursor the Hand cursor when the mouse moves 
        ' over the button.
        Cursor = Cursors.Hand

        ' Call MyBase.OnMouseMove to activate the delegate.
        MyBase.OnMouseMove(e)
    End Sub