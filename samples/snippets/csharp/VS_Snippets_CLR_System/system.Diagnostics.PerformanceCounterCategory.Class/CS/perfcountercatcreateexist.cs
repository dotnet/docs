//<snippet27>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatCreateExistMod
{

    //<snippet28>
    //<snippet4>
    public static void Main(string[] args)
    {
        string categoryName = "";
        //</snippet4>
        string counterName = "";
        //</snippet28>
        //<snippet6>
        string instanceName = "";
        //<snippet5>
        string machineName = "";
        //</snippet5>
        //</snippet6>
        //<snippet3>
        string categoryHelp = "";
        string counterHelp = "";
        //</snippet3>
        //<snippet7>
        //<snippet8>
        bool objectExists = false;
        //</snippet8>
        PerformanceCounterCategory pcc;
        //</snippet7>
        bool createCategory = false;
        //<snippet9>
        //<Snippet10>

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            //</Snippet10>
            counterName = args[1];
            //</snippet9>
            //<Snippet11>
            instanceName = args[2];
            //<Snippet12>
            machineName = args[3]=="."? "": args[3];
            //</Snippet12>
            //</Snippet11>
            //<Snippet13>
            categoryHelp = args[4];
            counterHelp = args[5];
            //<Snippet14>
            //<Snippet15>
            //<Snippet16>
        }
        catch(Exception ex)
        {
            // Ignore the exception from non-supplied arguments.
        }

        // Verify that the category name is not blank.
        if (categoryName.Length==0)
        {
            Console.WriteLine("Category name cannot be blank.");
            return;
        }

        //</Snippet13>
        // Check whether the specified category exists.
        //</Snippet16>
        if (machineName.Length==0)
            //<Snippet17>
        {
            objectExists = PerformanceCounterCategory.Exists(categoryName);

            //</Snippet17>
        }
        else
        {
            // Handle the exception that is thrown if the computer 
            // cannot be found.
            try
            {
                objectExists = PerformanceCounterCategory.Exists(categoryName, machineName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error checking for existence of " +
                    "category \"{0}\" on computer \"{1}\":"+"\n" +ex.Message, categoryName, machineName);
                return;
            }
        }

        //</Snippet15>
        // Tell the user whether the specified category exists.
        Console.WriteLine("Category \"{0}\" "+ (objectExists? "exists on ": "does not exist on ")+
            (machineName.Length>0? "computer \"{1}\".": "this computer."), categoryName, machineName);
        //</Snippet14>

        // If no counter name is given, the program cannot continue.
        if (counterName.Length==0)
        {
            return;
        }

        // A category can only be created on the local computer.
        //<Snippet18>
        if (!objectExists)
            //</Snippet18>
        {
            if (machineName.Length>0)
                //<Snippet19>
            {
                return;
                //</Snippet19>
            }
            else
            {
                createCategory = true;
            }
            //<Snippet20>
            //<Snippet21>
        }
        else
        {
            //</Snippet21>
            // Check whether the specified counter exists.
            if (machineName.Length==0)
            {
                objectExists = PerformanceCounterCategory.CounterExists(counterName, categoryName);
            }
            else
            {
                objectExists = PerformanceCounterCategory.CounterExists(counterName, categoryName, machineName);
            }

            // Tell the user whether the counter exists.
            Console.WriteLine("Counter \"{0}\" "+(objectExists? "exists": "does not exist")+
                " in category \"{1}\" on "+(machineName.Length>0? "computer \"{2}\".": "this computer."), 
                counterName, categoryName, machineName);
            //</Snippet20>

            // If the counter does not exist, consider creating it.
            if (!objectExists)

                // If this is a remote computer, 
                // exit because the category cannot be created.
            {
                if (machineName.Length>0)
                {
                    return;
                }
                else
                {
                    // Ask whether the user wants to recreate the category.
                    Console.Write("Do you want to delete and recreate " +
                        "category \"{0}\" with your new counter? [Y/N]: ", categoryName);
                    string userReply = Console.ReadLine();

                    // If yes, delete the category so it can be recreated later.
                    if (userReply.Trim().ToUpper()=="Y")
                        //<Snippet22>
                    {
                        PerformanceCounterCategory.Delete(categoryName);
                        //</Snippet22>
                        createCategory = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        // Create the category if it was deleted or it never existed.
        if (createCategory)
            //<Snippet23>
        {
            pcc = PerformanceCounterCategory.Create(categoryName, categoryHelp, counterName, counterHelp);

            Console.WriteLine("Category \"{0}\" with counter \"{1}\" created.", pcc.CategoryName, counterName);
            //</Snippet23>

        }
        else if(instanceName.Length>0)
        {
            if (machineName.Length==0)
            {
                objectExists = PerformanceCounterCategory.InstanceExists(instanceName, categoryName);
            }
            else
            {
                objectExists = PerformanceCounterCategory.InstanceExists(instanceName, categoryName, machineName);
            }

            // Tell the user whether the instance exists.
            Console.WriteLine("Instance \"{0}\" "+(objectExists? "exists": "does not exist")+
                " in category \"{1}\" on " + (machineName.Length>0? "computer \"{2}\".": "this computer."), 
                instanceName, categoryName, machineName);
            //<Snippet25>
        }
        //<Snippet26>
    }
    //</Snippet26>
    //</Snippet25>
}
//</snippet27>




