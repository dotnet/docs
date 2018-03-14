Module Converting
    Sub Main(ByVal args As String())
        Cast.Cast()
    End Sub
End Module

Module Cast
    ' <Snippet1>
    Class Plant
        Public Property Name As String
    End Class

    Class CarnivorousPlant
        Inherits Plant
        Public Property TrapType As String
    End Class

    Sub Cast()

        Dim plants() As Plant = { 
            New CarnivorousPlant With {.Name = "Venus Fly Trap", .TrapType = "Snap Trap"}, 
            New CarnivorousPlant With {.Name = "Pitcher Plant", .TrapType = "Pitfall Trap"}, 
            New CarnivorousPlant With {.Name = "Sundew", .TrapType = "Flypaper Trap"}, 
            New CarnivorousPlant With {.Name = "Waterwheel Plant", .TrapType = "Snap Trap"}}

        Dim query = From plant As CarnivorousPlant In plants 
                    Where plant.TrapType = "Snap Trap" 
                    Select plant

        Dim sb As New System.Text.StringBuilder()
        For Each plant In query
            sb.AppendLine(plant.Name)
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' Venus Fly Trap
        ' Waterwheel Plant

    End Sub
    ' </Snippet1>
End Module