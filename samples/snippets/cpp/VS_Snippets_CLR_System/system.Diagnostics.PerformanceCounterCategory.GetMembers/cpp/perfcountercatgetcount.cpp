//<snippet3>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

ref class PerfCounterCatGetCountMod
{
    //<snippet4>
public:
    static void Main(array<String^>^ args)
    {
        String^ categoryName = "";
        String^ machineName = "";
        String^ instanceName = "";
        PerformanceCounterCategory^ pcc;
        array<PerformanceCounter^>^ counters;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[1];
            machineName = args[2]=="."? "": args[2];
            instanceName = args[3];
        }
        catch (...)
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Create the appropriate PerformanceCounterCategory object.
            if (machineName->Length>0)
            {
                pcc = gcnew PerformanceCounterCategory(categoryName, machineName);
            }
            else
            {
                pcc = gcnew PerformanceCounterCategory(categoryName);
            }

            // Get the counters for this instance or a single instance
            // of the selected category.
            if (instanceName->Length > 0)
            {
                counters = pcc->GetCounters(instanceName);
            }
            else
            {
                counters = pcc->GetCounters();
            }

        }
        catch (Exception^ ex)
        {
            Console::WriteLine("Unable to get counter information for " +
                (instanceName->Length>0? "instance \"{2}\" in ": "single-instance ") +
                "category \"{0}\" on " + (machineName->Length>0? "computer \"{1}\":": "this computer:"),
                categoryName, machineName, instanceName);
            Console::WriteLine(ex->Message);
            return;
        }

        // Display the counter names if GetCounters was successful.
        if (counters != nullptr)
        {
            Console::WriteLine("These counters exist in " +
                (instanceName->Length > 0 ? "instance \"{1}\" of" : "single instance") +
                " category {0} on " + (machineName->Length > 0 ? "computer \"{2}\":": "this computer:"),
                categoryName, instanceName, machineName);

            // Display a numbered list of the counter names.
            int objX;
            for(objX = 0; objX < counters->Length; objX++)
            {
                Console::WriteLine("{0,4} - {1}", objX + 1, counters[objX]->CounterName);
            }
        }
    }
    //</snippet4>
};

int main()
{
    PerfCounterCatGetCountMod::Main(Environment::GetCommandLineArgs());
}
//</snippet3>



