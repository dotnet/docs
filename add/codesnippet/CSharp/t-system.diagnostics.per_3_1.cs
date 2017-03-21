using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatCreateExistMod
{

    public static void Main(string[] args)
    {
        string categoryName = "";
        string counterName = "";
        string instanceName = "";
        string machineName = "";
        string categoryHelp = "";
        string counterHelp = "";
        bool objectExists = false;
        PerformanceCounterCategory pcc;
        bool createCategory = false;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            instanceName = args[2];
            machineName = args[3]=="."? "": args[3];
            categoryHelp = args[4];
            counterHelp = args[5];
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

        // Check whether the specified category exists.
        if (machineName.Length==0)
        {
            objectExists = PerformanceCounterCategory.Exists(categoryName);

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

        // Tell the user whether the specified category exists.
        Console.WriteLine("Category \"{0}\" "+ (objectExists? "exists on ": "does not exist on ")+
            (machineName.Length>0? "computer \"{1}\".": "this computer."), categoryName, machineName);

        // If no counter name is given, the program cannot continue.
        if (counterName.Length==0)
        {
            return;
        }

        // A category can only be created on the local computer.
        if (!objectExists)
        {
            if (machineName.Length>0)
            {
                return;
            }
            else
            {
                createCategory = true;
            }
        }
        else
        {
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
                    {
                        PerformanceCounterCategory.Delete(categoryName);
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
        {
            pcc = PerformanceCounterCategory.Create(categoryName, categoryHelp, counterName, counterHelp);

            Console.WriteLine("Category \"{0}\" with counter \"{1}\" created.", pcc.CategoryName, counterName);

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
        }
    }
}