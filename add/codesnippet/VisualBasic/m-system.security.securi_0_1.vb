    Public Function SearchForTextOfTag(ByVal tag As String) As String
        Dim element As SecurityElement = MyClass.SearchForChildByTag(tag)
        Return element.Text
    End Function