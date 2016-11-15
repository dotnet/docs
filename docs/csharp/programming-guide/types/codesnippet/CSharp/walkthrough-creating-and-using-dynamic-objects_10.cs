            // Set the current directory to the IronPython libraries.
            System.IO.Directory.SetCurrentDirectory(
               Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + 
               @"\IronPython 2.6 for .NET 4.0\Lib");

            // Create an instance of the random.py IronPython library.
            Console.WriteLine("Loading random.py");
            ScriptRuntime py = Python.CreateRuntime();
            dynamic random = py.UseFile("random.py");
            Console.WriteLine("random.py loaded.");