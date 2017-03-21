    <ConditionalAttribute("CONDITION1")> _
    Shared Sub Method1(x As Integer)
        Console.WriteLine("CONDITION1 is defined")
    End Sub
    
    <ConditionalAttribute("CONDITION1"), ConditionalAttribute("CONDITION2")> _
    Shared Sub Method2()
        Console.WriteLine("CONDITION1 or CONDITIOIN2 is defined")
    End Sub