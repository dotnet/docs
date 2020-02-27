// <Snippet1>
// <Snippet3>
using System;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

class ProcessInformation
{
    [STAThread]
    static void Main()
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        openFileDialog1.InitialDirectory = "c:\\";
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;
        openFileDialog1.CheckFileExists = true;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            var fileName = openFileDialog1.FileName;

            // <Snippet4>
            int i = 0;
            var startInfo = new ProcessStartInfo(fileName);

            // Display the possible verbs.
            foreach (var verb in startInfo.Verbs)
            {
                Console.WriteLine($"  {i++}. {verb}");
            }

            Console.Write("Select the index of the verb: ");
            var indexInput = Console.ReadLine();
            int index;
            if (Int32.TryParse(indexInput, out index))
            {
                if (index < 0 || index >= i)
                {
                    Console.WriteLine("Invalid index value.");
                    return;
                }

                var verbToUse = startInfo.Verbs[index];

                startInfo.Verb = verbToUse;
                if (verbToUse.ToLower().IndexOf("printto") >= 0)
                {
                    // printto implies a specific printer.  Ask for the network address.
                    // The address must be in the form \\server\printer.
                    // The printer address is passed as the Arguments property.
                    Console.Write("Enter the network address of the target printer: ");
                    var arguments = Console.ReadLine();
                    startInfo.Arguments = arguments;
                }
                // </Snippet4>

                try
                {
                    using (var newProcess = new Process())
                    {
                        newProcess.StartInfo = startInfo;
                        newProcess.Start();

                        Console.WriteLine($"{newProcess.ProcessName} for file {fileName} " +
                                          $"started successfully with verb '{startInfo.Verb}'!");
                    }
                }
                catch (Win32Exception e)
                {
                    Console.WriteLine("  Win32Exception caught!");
                    Console.WriteLine($"  Win32 error = {e.Message}");
                }
                catch (InvalidOperationException)
                {
                    // Catch this exception if the process exits quickly, 
                    // and the properties are not accessible.
                    Console.WriteLine($"Unable to start '{fileName}' with verb {verbToUse}");
                }
            }
        }
        else
        {
            {
                Console.WriteLine("You did not enter a number.");
            }
        }
    }
}
// </Snippet3>
// </Snippet1>
