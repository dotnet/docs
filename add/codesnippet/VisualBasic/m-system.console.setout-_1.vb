        Console.WriteLine("Hello World")
        Dim fs As New FileStream("Test.txt", FileMode.Create)
        ' First, save the standard output.
        Dim tmp as TextWriter = Console.Out
        Dim sw As New StreamWriter(fs)
        Console.SetOut(sw)
        Console.WriteLine("Hello file")
        Console.SetOut(tmp)
        Console.WriteLine("Hello World")
        sw.Close()