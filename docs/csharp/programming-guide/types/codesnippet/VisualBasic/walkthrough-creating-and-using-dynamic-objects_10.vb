        ' Set the current directory to the IronPython libraries.
        My.Computer.FileSystem.CurrentDirectory = 
           My.Computer.FileSystem.SpecialDirectories.ProgramFiles &
           "\IronPython 2.6 for .NET 4.0\Lib"

        ' Create an instance of the random.py IronPython library.
        Console.WriteLine("Loading random.py")
        Dim py = Python.CreateRuntime()
        Dim random As Object = py.UseFile("random.py")
        Console.WriteLine("random.py loaded.")