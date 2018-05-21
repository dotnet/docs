Module Module1
    Sub Main()
        Dim encoding As New System.Text.TitanEncoding

        ' If the namespace defined below is System.Text
        ' instead of Global.System.Text, then this statement
        ' causes a compile-time error.
        Dim sb As New System.Text.StringBuilder
    End Sub
End Module

Namespace Global.System.Text
    Class TitanEncoding

    End Class
End Namespace