//<Snippet1>
//<Snippet3>

using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

class ProcessInformation
{
    [STAThread]
    static void Main(string[] args)
    {
        string fileName = "";
        string arguments = "";
        string verbToUse = "";
        int i = 0;
        ProcessStartInfo startInfo = new ProcessStartInfo();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        openFileDialog1.InitialDirectory = "c:\\";
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((fileName = openFileDialog1.FileName) != null)
            {
                //<Snippet4>
                startInfo = new ProcessStartInfo(fileName);

                if (File.Exists(fileName))
                {
                    i = 0;
                    foreach (String verb in startInfo.Verbs)
                    {
                        // Display the possible verbs.
                        Console.WriteLine("  {0}. {1}", i.ToString(), verb);
                        i++;
                    }
                }
            }

            Console.WriteLine("Select the index of the verb.");
            string index = Console.ReadLine();
            if (Convert.ToInt32(index) < i)
                verbToUse = startInfo.Verbs[Convert.ToInt32(index)];
            else
                return;
            startInfo.Verb = verbToUse;
            if (verbToUse.ToLower().IndexOf("printto") >= 0)
            {
                // printto implies a specific printer.  Ask for the network address.
                // The address must be in the form \\server\printer.
                // The printer address is passed as the Arguments property.
                Console.WriteLine("Enter the network address of the target printer:");
                arguments = Console.ReadLine();
                startInfo.Arguments = arguments;
            }
            //</Snippet4>

            Process newProcess = new Process();
            newProcess.StartInfo = startInfo;

            try
            {
                newProcess.Start();

                Console.WriteLine(
                    "{0} for file {1} started successfully with verb \"{2}\"!",
                    newProcess.ProcessName, fileName, startInfo.Verb);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Console.WriteLine("  Win32Exception caught!");
                Console.WriteLine("  Win32 error = {0}",
                    e.Message);
            }
            catch (System.InvalidOperationException)
            {
                // Catch this exception if the process exits quickly, 
                // and the properties are not accessible.
                Console.WriteLine("File {0} started with verb {1}",
                    fileName, verbToUse);
            }
        }
    }
}
// </Snippet3>
//</Snippet1>
