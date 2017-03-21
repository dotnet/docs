    ' Derive from the WebControlAdapter class,
    ' provide a CreateCustomChtmlTextWriter
    ' method to attach the custom writer.
    Public Class ChtmlCustomPageAdapter
        Inherits WebControlAdapter

        Protected Friend Function CreateCustomChtmlTextWriter( _
         ByVal writer As TextWriter) As ChtmlTextWriter

            Return New CustomChtmlTextWriter(writer)

        End Function
    End Class