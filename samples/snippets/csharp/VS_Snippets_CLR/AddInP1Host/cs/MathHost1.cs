// <Snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.AddIn.Hosting;
using CalcHVAs;

namespace MathHost
{
    class Program
    {
        static void Main()
        {
            // Assume that the current directory is the application folder, 
            // and that it contains the pipeline folder structure.
            String addInRoot = Environment.CurrentDirectory + "\\Pipeline";
            
            // Update the cache files of the pipeline segments and add-ins.
            string[] warnings = AddInStore.Update(addInRoot);
            foreach (string warning in warnings)
            {
                Console.WriteLine(warning);
            }
            
            // Search for add-ins of type ICalculator (the host view of the add-in).
            Collection<AddInToken> tokens = 
                AddInStore.FindAddIns(typeof(ICalculator), addInRoot);
            
            // Ask the user which add-in they would like to use.
            AddInToken calcToken = ChooseCalculator(tokens);

            // Activate the selected AddInToken in a new application domain 
            // with the Internet trust level.
            ICalculator calc = 
                calcToken.Activate<ICalculator>(AddInSecurityLevel.Internet);
            
            // Run the add-in.
            RunCalculator(calc);
        }

        private static AddInToken ChooseCalculator(Collection<AddInToken> tokens)
        {
            if (tokens.Count == 0)
            {
                Console.WriteLine("No calculators are available");
                return null;
            }
            Console.WriteLine("Available Calculators: ");
            // Show the token properties for each token in the AddInToken collection 
            // (tokens), preceded by the add-in number in [] brackets.
            int tokNumber = 1;
            foreach (AddInToken tok in tokens)
            {
                Console.WriteLine(String.Format("\t[{0}]: {1} - {2}\n\t{3}\n\t\t {4}\n\t\t {5} - {6}",
                    tokNumber.ToString(),
                    tok.Name,
                    tok.AddInFullName,
                    tok.AssemblyName,
                    tok.Description,
                    tok.Version,
                    tok.Publisher));
                tokNumber++;
            }
            Console.WriteLine("Which calculator do you want to use?");
            String line = Console.ReadLine();
            int selection;
            if (Int32.TryParse(line, out selection))
            {
                if (selection <= tokens.Count)
                {
                    return tokens[selection - 1];
                }
            }
            Console.WriteLine("Invalid selection: {0}. Please choose again.", line);
            return ChooseCalculator(tokens);
        }

        private static void RunCalculator(ICalculator calc)
        {
            
            if (calc == null)
            {
                //No calculators were found; read a line and exit.
                Console.ReadLine();
            }
            Console.WriteLine("Available operations: +, -, *, /");
            Console.WriteLine("Request a calculation , such as: 2 + 2");
            Console.WriteLine("Type \"exit\" to exit");
            String line = Console.ReadLine();
            while (!line.Equals("exit"))
            {
                // The Parser class parses the user's input.
                try
                {
                    Parser c = new Parser(line);
                    switch (c.Action)
                    {
                        case "+":
                            Console.WriteLine(calc.Add(c.A, c.B));
                            break;
                        case "-":
                            Console.WriteLine(calc.Subtract(c.A, c.B));
                            break;
                        case "*":
                            Console.WriteLine(calc.Multiply(c.A, c.B));
                            break;
                        case "/":
                            Console.WriteLine(calc.Divide(c.A, c.B));
                            break;
                        default:
                            Console.WriteLine("{0} is an invalid command. Valid commands are +,-,*,/", c.Action);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid command: {0}. Commands must be formated: [number] [operation] [number]", line);
                }
                
                line = Console.ReadLine();
            }
        }
    }

    internal class Parser
    {
        double a;
        double b;
        string action;

        internal Parser(string line)
        {
            string[] parts = line.Split(' ');
            a = double.Parse(parts[0]);
            action = parts[1];
            b = double.Parse(parts[2]);
        }

        public double A
        {
            get { return a; }
        }

        public double B
        {
            get { return b; }
        }

        public string Action
        {
            get { return action; }
        }
    }
}
// </Snippet1>