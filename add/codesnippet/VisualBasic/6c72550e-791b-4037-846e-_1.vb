    Public Sub AddStringExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object.
        Dim myPath As New GraphicsPath

        ' Set up all the string parameters.
        Dim stringText As String = "Sample Text"
        Dim family As New FontFamily("Arial")
        Dim myfontStyle As Integer = CInt(FontStyle.Italic)
        Dim emSize As Integer = 26
        Dim origin As New Point(20, 20)
        Dim format As StringFormat = StringFormat.GenericDefault

        ' Add the string to the path.
        myPath.AddString(stringText, family, myfontStyle, emSize, _
        origin, format)

        'Draw the path to the screen.
        e.Graphics.FillPath(Brushes.Black, myPath)
    End Sub