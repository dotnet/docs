' Namespaces in Visual Basic
' cffac744-ab8c-4f1f-ba50-732c22ab4b88

' <snippet21>
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
' </snippet21>


' <snippet22>
Namespace Global.Magnetosphere

End Namespace


Namespace Global
    Namespace Magnetosphere

    End Namespace
End Namespace
' </snippet22>

