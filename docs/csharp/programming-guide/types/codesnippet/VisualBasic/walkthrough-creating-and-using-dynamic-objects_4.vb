    ' Store the path to the file and the initial line count value.
    Private p_filePath As String

    ' Public constructor. Verify that file exists and store the path in 
    ' the private variable.
    Public Sub New(ByVal filePath As String)
        If Not File.Exists(filePath) Then
            Throw New Exception("File path does not exist.")
        End If

        p_filePath = filePath
    End Sub