//<Snippet1>
using System;

namespace NDP_UE_CS
{
    // Derive an exception; the constructor sets the HelpLink and
    // Source properties.
    class LogTableOverflowException : Exception
    {
        const string overflowMessage = "The log table has overflowed.";

        public LogTableOverflowException(
            string auxMessage, Exception inner) :
                base(String.Format("{0} - {1}",
                    overflowMessage, auxMessage), inner)
        {
            this.HelpLink = "https://learn.microsoft.com";
            this.Source = "Exception_Class_Samples";
        }
    }

    class LogTable
    {
        public LogTable(int numElements)
        {
            logArea = new string[numElements];
            elemInUse = 0;
        }

        protected string[] logArea;
        protected int elemInUse;

        // The AddRecord method throws a derived exception if
        // the array bounds exception is caught.
        public int AddRecord(string newRecord)
        {
            try
            {
                logArea[elemInUse] = newRecord;
                return elemInUse++;
            }
            catch (Exception e)
            {
                throw new LogTableOverflowException(
                    String.Format("Record \"{0}\" was not logged.",
                        newRecord), e);
            }
        }
    }

    class OverflowDemo
    {
        // Create a log table and force an overflow.
        public static void Main()
        {
            LogTable log = new LogTable(4);

            Console.WriteLine(
                "This example of \n   Exception.Message, \n" +
                "   Exception.HelpLink, \n   Exception.Source, \n" +
                "   Exception.StackTrace, and \n   Exception." +
                "TargetSite \ngenerates the following output.");

            try
            {
                for (int count = 1; ; count++)
                {
                    log.AddRecord(
                        String.Format(
                            "Log record number {0}", count));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nMessage ---\n{ex.Message}");
                Console.WriteLine($"\nHelpLink ---\n{ex.HelpLink}");
                Console.WriteLine($"\nSource ---\n{ex.Source}");
                Console.WriteLine($"\nStackTrace ---\n{ex.StackTrace}");
                Console.WriteLine($"\nTargetSite ---\n{ex.TargetSite}");
            }
        }
    }
}

/*
This example of
   Exception.Message,
   Exception.HelpLink,
   Exception.Source,
   Exception.StackTrace, and
   Exception.TargetSite
generates the following output.

Message ---
The log table has overflowed. - Record "Log record number 5" was not logged.

HelpLink ---
https://learn.microsoft.com

Source ---
Exception_Class_Samples

StackTrace ---
   at NDP_UE_CS.LogTable.AddRecord(String newRecord)
   at NDP_UE_CS.OverflowDemo.Main()

TargetSite ---
Int32 AddRecord(System.String)
*/
//</Snippet1>
