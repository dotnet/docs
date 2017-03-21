    ' Receive the file name stored by GetInitializer and store it in a 
    ' member variable for this specific instance.
    Public Overrides Sub Initialize(initializer As Object)
        m_filename = CStr(initializer)
    End Sub