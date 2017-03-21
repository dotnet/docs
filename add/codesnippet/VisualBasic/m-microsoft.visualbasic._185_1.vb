    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Interaction.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function