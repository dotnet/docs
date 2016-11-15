    Enum EggSizeEnum
        Jumbo
        ExtraLarge
        Large
        Medium
        Small
    End Enum

    Public Sub Iterate()
        Dim names = [Enum].GetNames(GetType(EggSizeEnum))
        For Each name In names
            Console.Write(name & " ")
        Next
        Console.WriteLine()
        ' Output: Jumbo ExtraLarge Large Medium Small 

        Dim values = [Enum].GetValues(GetType(EggSizeEnum))
        For Each value In values
            Console.Write(value & " ")
        Next
        Console.WriteLine()
        ' Output: 0 1 2 3 4 
    End Sub