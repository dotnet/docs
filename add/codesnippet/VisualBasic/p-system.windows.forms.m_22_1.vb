    ' Declare the MainMenu control.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    ' Declare MenuItem2 as With-Events because it will be user drawn.
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem


    Private Sub InitializeMenu()

        ' Create MenuItem1, which will be drawn by the operating system.
        Dim MenuItem1 As New MenuItem("Regular Menu Item")

        ' Create MenuItem2.
        MenuItem2 = New MenuItem("Custom Menu Item")

        ' Set OwnerDraw property to true. This requires handling the
        ' DrawItem event for this menu item.
        MenuItem2.OwnerDraw = True

        'Add the event-handler delegate to handle the DrawItem event.
        AddHandler MenuItem2.DrawItem, New DrawItemEventHandler(AddressOf DrawCustomMenuItem)

        ' Add the items to the menu.
        MainMenu1 = New MainMenu(New MenuItem() {MenuItem1, MenuItem2})

        ' Add the menu to the form.
        Me.Menu = Me.MainMenu1
    End Sub

    ' Draw the custom menu item.
    Private Sub DrawCustomMenuItem(ByVal sender As Object, ByVal e As _
            System.Windows.Forms.DrawItemEventArgs)

        ' Cast the sender to MenuItem so you can access text property.
        Dim customItem As MenuItem = CType(sender, MenuItem)

        ' Create a Brush and a Font to draw the MenuItem.
        Dim aBrush As System.Drawing.Brush = System.Drawing.Brushes.DarkMagenta
        Dim aFont As New Font("Garamond", 10, FontStyle.Italic, _
            GraphicsUnit.Point)

        ' Get the size of the text to use later to draw an ellipse
        ' around the item.
        Dim stringSize As SizeF = e.Graphics.MeasureString( _
            customItem.Text, aFont)

        ' Draw the item and then draw the ellipse.
        e.Graphics.DrawString(customItem.Text, aFont, _
            aBrush, e.Bounds.X, e.Bounds.Y)
        e.Graphics.DrawEllipse(New Pen(System.Drawing.Color.Black, 2), _
            New Rectangle(e.Bounds.X, e.Bounds.Y, CInt(stringSize.Width), _
            CInt(stringSize.Height)))
    End Sub