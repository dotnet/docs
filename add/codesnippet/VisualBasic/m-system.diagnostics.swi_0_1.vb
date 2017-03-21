        Dim switches As SwitchAttribute() = SwitchAttribute.GetAll(GetType(TraceTest).Assembly)
        Dim i As Integer
        For i = 0 To switches.Length - 1
            Console.WriteLine("Switch name = " + switches(i).SwitchName.ToString())
            Console.WriteLine("Switch type = " + switches(i).SwitchType.ToString())
        Next i