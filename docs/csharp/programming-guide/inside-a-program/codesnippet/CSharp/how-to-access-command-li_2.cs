    class CommandLine2
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Number of command line parameters = {0}", args.Length);

            foreach (string s in args)
            {
                System.Console.WriteLine(s);
            }
        }
    }
    /* Output:
        Number of command line parameters = 3
        John
        Paul
        Mary
    */