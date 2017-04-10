// <Snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.AddIn.Hosting;
using CalcHVAs;

namespace MathHost
{
    class Program
    {
        static void Main()
        {

// <Snippet2>
// Get path for the pipeline root.
// Assumes that the current directory is the  
// pipeline directory structure root directory. 
String pipeRoot = Environment.CurrentDirectory;

// <Snippet3>
// Update the cache files of the
// pipeline segments and add-ins.
string[] warnings = AddInStore.Update(pipeRoot);

foreach (string warning in warnings)
{
    Console.WriteLine(warning);
}
// </Snippet3>

// <Snippet4>
// Search for add-ins of type Calculator (the host view of the add-in)
// specifying the host's application base, instead of a path,
// for the FindAddIns method.

Collection<AddInToken> tokens = 
            AddInStore.FindAddIns(typeof(Calculator),PipelineStoreLocation.ApplicationBase);
// </Snippet4>
// </Snippet2>

// <Snippet5>
//Ask the user which add-in they would like to use.
AddInToken selectedToken = ChooseAddIn(tokens);

//Activate the selected AddInToken in a new
//application domain with the Internet trust level.
Calculator CalcAddIn = selectedToken.Activate<Calculator>(AddInSecurityLevel.Internet);
            
//Run the add-in using a custom method.
RunCalculator(CalcAddIn);
// </Snippet5>

// <Snippet6>
// Find a specific add-in.

// Construct the path to the add-in.
string addInFilePath = pipeRoot + @"\AddIns\P3AddIn2\P3AddIn2.dll";

// The fourth parameter, addinTypeName, takes the full name 
// of the type qualified by its namespace. Same as AddInToken.AddInFullName.
Collection<AddInToken> tokenColl = AddInStore.FindAddIn(typeof(Calculator),
    pipeRoot, addInFilePath, "CalcAddIns.P3AddIn2");
Console.WriteLine("Found {0}", tokenColl[0].Name);
// </Snippet6>

// <Snippet8>
// Get the AddInController of a 
// currently actived add-in (CalcAddIn).
AddInController aiController = AddInController.GetAddInController(CalcAddIn);

// Select another token.
AddInToken selectedToken2 = ChooseAddIn(tokens);

// Activate a second add-in, CalcAddIn2, in the same
// appliation domain and process as the first add-in by passing
// the first add-in's AddInEnvironment object to the Activate method.
AddInEnvironment aiEnvironment = aiController.AddInEnvironment;
Calculator CalcAddIn2 =
	selectedToken2.Activate<Calculator>(aiEnvironment);

// Get the AddInController for the second add-in to compare environments.
AddInController aiController2 = AddInController.GetAddInController(CalcAddIn2);
Console.WriteLine("Add-ins in same application domain: {0}", aiController.AppDomain.Equals(aiController2.AppDomain));
Console.WriteLine("Add-ins in same process: {0}", aiEnvironment.Process.Equals(aiController2.AddInEnvironment.Process));
// </Snippet8>


// <Snippet9>
// Get the application domain
// of an existing add-in (CalcAddIn).
AddInController aiCtrl = AddInController.GetAddInController(CalcAddIn);
AppDomain AddInAppDom = aiCtrl.AppDomain;

// Activate another add-in in the same application domain.
Calculator CalcAddIn3 =
	selectedToken2.Activate<Calculator>(AddInAppDom);

// Show that CalcAddIn3 was loaded
// into CalcAddIn's application domain.
AddInController aic = AddInController.GetAddInController(CalcAddIn3);
Console.WriteLine("Add-in loaded into existing application domain: {0}",
	aic.AppDomain.Equals(AddInAppDom));
// </Snippet9>

// <Snippet10>
// Create an external process.
AddInProcess pExternal = new AddInProcess();

// Activate an add-in in the external process
// with a full trust security level.
Calculator CalcAddIn4 =
	selectedToken.Activate<Calculator>(pExternal,
	AddInSecurityLevel.FullTrust);

// Show that the add-in is an an external process
// by verifying that it is not in the current (host's) process.
AddInController AddinCtl = AddInController.GetAddInController(CalcAddIn4);
Console.WriteLine("Add-in in host's process: {0}",
	AddinCtl.AddInEnvironment.Process.IsCurrentProcess);
// </Snippet10>
// <Snippet11>
// Use qualification data to control 
// how an add-in should be activated.

if (selectedToken.QualificationData[AddInSegmentType.AddIn]["Isolation"].Equals("NewProcess"))
{
	// Create an external process.
	AddInProcess external = new AddInProcess();

    // Activate an add-in in the new process
    // with the full trust security level.
    Calculator CalcAddIn5 =
		selectedToken.Activate<Calculator>(external,
		AddInSecurityLevel.FullTrust);
	Console.WriteLine("Add-in activated per qualification data.");
}
else
	Console.WriteLine("This add-in is not designated to be activated in a new process.");
// </Snippet11>

// <Snippet12>
// Show the qualification data for each
// token in an AddInToken collection.
foreach (AddInToken token in tokens)
{
    foreach (QualificationDataItem qdi in token)
    {
        Console.WriteLine("{0} {1}\n\t QD Name: {2}, QD Value: {3}",
            token.Name,
            qdi.Segment, 
            qdi.Name, 
            qdi.Value);
    }
}

// </Snippet12>
    
 }

// <Snippet13>
// Method to select a token by 
// enumeratng the AddInToken collection.
private static AddInToken ChooseAddIn(Collection<AddInToken> tokens)
{
    if (tokens.Count == 0)
    {
        Console.WriteLine("No add-ins are available");
        return null;
    }

    Console.WriteLine("Available add-ins: ");

	// <Snippet7>
	// Show the token properties for each token 
	// in the AddInToken collection (tokens),
	// preceded by the add-in number in [] brackets.
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
	// </Snippet7>

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
    return ChooseAddIn(tokens);
}
// </Snippet13>

        private static void RunCalculator(Calculator calc)
        {
            
            if (calc == null)
            {
                //No calculators were found, read a line and exit.
                Console.ReadLine();
            }
            Console.WriteLine("Available operations: " + calc.Operations);
            Console.WriteLine("Type \"exit\" to exit");
            String line = Console.ReadLine();
            while (!line.Equals("exit"))
            {
                // The Parser class parses the user's input.
                try
                {
                    Parser c = new Parser(line);
                    Console.WriteLine(calc.Operate(c.Action, c.A, c.B));
                }
                catch
                {
                    Console.WriteLine("Invalid command: {0}. Commands must be formated: [number] [operation] [number]", line);
                    Console.WriteLine("Available operations: " + calc.Operations);
                }
                
                line = Console.ReadLine();
            }
        }
    }


    internal class Parser
    {
        internal Parser(String line)
        {
            String[] parts = line.Trim().Split(' ');
            a = Double.Parse(parts[0]);
            action = parts[1];
            b = Double.Parse(parts[2]);
        }

        double a;

        public double A
        {
            get { return a; }
        }
        double b;

        public double B
        {
            get { return b; }
        }
        String action;

        public String Action
        {
            get { return action; }
        }
    }
}
// </Snippet1>