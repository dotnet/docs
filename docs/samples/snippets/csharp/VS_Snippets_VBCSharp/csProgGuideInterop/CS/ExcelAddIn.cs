//<Snippet1>
using System.Runtime.InteropServices;

namespace TaxTables
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class TaxTables
    {
        public static double Tax(double income)
        {
            if (income >      0 && income <=   7000) {return            (.10 * income);}
            if (income >   7000 && income <=  28400) {return   700.00 + (.15 * (income - 7000));}
            if (income >  28400 && income <=  68800) {return  3910.00 + (.25 * (income - 28400));}
            if (income >  68800 && income <= 143500) {return 14010.00 + (.28 * (income - 68800));}
            if (income > 143500 && income <= 311950) {return 34926.00 + (.33 * (income - 143500));}
            if (income > 311950)                     {return 90514.50 + (.35 * (income - 311950));}
            return 0;
        }

        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(System.Type t)
        {
            Microsoft.Win32.Registry.ClassesRoot.CreateSubKey
                ("CLSID\\{" + t.GUID.ToString().ToUpper() + "}\\Programmable");
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(System.Type t)
        {
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKey
                ("CLSID\\{" + t.GUID.ToString().ToUpper() + "}\\Programmable");
        }
    }
}
//</Snippet1>
