    class CommandLine
    { 
        static void Main(string[] args)
        {
            // The Length property provides the number of array elements
            System.Console.WriteLine("parameter count = {0}", args.Length);

            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }
        }
    }
    /* Output (assumes 3 cmd line args): 
        parameter count = 3
        Arg[0] = [a]
        Arg[1] = [b]
        Arg[2] = [c]
    */