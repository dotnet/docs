        Dim message, title, defaultValue As String
        Dim myValue As Object
        ' Set prompt.
        message = "Enter a value between 1 and 3"
        ' Set title.
        title = "InputBox Demo"
        defaultValue = "1"   ' Set default value.

        ' Display message, title, and default value.
        myValue = InputBox(message, title, defaultValue)
        ' If user has clicked Cancel, set myValue to defaultValue
        If myValue Is "" Then myValue = defaultValue

        ' Display dialog box at position 100, 100.
        myValue = InputBox(message, title, defaultValue, 100, 100)
        ' If user has clicked Cancel, set myValue to defaultValue
        If myValue Is "" Then myValue = defaultValue