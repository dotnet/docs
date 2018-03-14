//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

ref class PerfCounterCatGetCatMod
{
    //<snippet2>
public:
    static void Main(array<String^>^ args)
    {
        String^ machineName = "";
        array<PerformanceCounterCategory^>^ categories;

        // Copy the machine name argument into the local variable.
        try
        {
            machineName = args[1]=="."? "": args[1];
        }
        catch (...)
        {
        }

        // Generate a list of categories registered on the specified computer.
        try
        {
            if (machineName->Length > 0)
            {
                categories = PerformanceCounterCategory::GetCategories(machineName);
            }
            else
            {
                categories = PerformanceCounterCategory::GetCategories();
            }
        }
        catch(Exception^ ex)
        {
            Console::WriteLine("Unable to get categories on " +
                (machineName->Length > 0 ? "computer \"{0}\":": "this computer:"), machineName);
            Console::WriteLine(ex->Message);
            return;
        }

        Console::WriteLine("These categories are registered on " +
            (machineName->Length > 0 ? "computer \"{0}\":": "this computer:"), machineName);

        // Create and sort an array of category names.
        array<String^>^ categoryNames = gcnew array<String^>(categories->Length);
        int objX;
        for (objX = 0; objX < categories->Length; objX++)
        {
            categoryNames[objX] = categories[objX]->CategoryName;
        }
        Array::Sort(categoryNames);

        for (objX = 0; objX < categories->Length; objX++)
        {
            Console::WriteLine("{0,4} - {1}", objX + 1, categoryNames[objX]);
        }
    }
    //</snippet2>
};

int main()
{
    PerfCounterCatGetCatMod::Main(Environment::GetCommandLineArgs());
}
//</snippet1>



