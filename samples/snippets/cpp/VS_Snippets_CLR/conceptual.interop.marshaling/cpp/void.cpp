//<snippet45>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet46>
private ref class NativeMethods
{
public:
    enum class DataType
    {
        DT_I2 = 1,
        DT_I4,
        DT_R4,
        DT_R8,
        DT_STR
    };

    // Uses AsAny when void* is expected.
    [DllImport("..\\LIB\\PInvokeLib.dll")]
    static void SetData(DataType t,
        [MarshalAs(UnmanagedType::AsAny)] Object^ o);

    // Uses overloading when void* is expected.
    [DllImport("..\\LIB\\PInvokeLib.dll", EntryPoint = "SetData")]
    static void SetData2(DataType t, double% i);

    [DllImport("..\\LIB\\PInvokeLib.dll", EntryPoint = "SetData")]
    static void SetData2(DataType t, String^ s);
};
//</snippet46>

//<snippet47>
public class App
{
public:
    static void Main()
    {
        Console::WriteLine("Calling SetData using AsAny... \n");
        NativeMethods::SetData(NativeMethods::DataType::DT_I2, (short)12);
        NativeMethods::SetData(NativeMethods::DataType::DT_I4, (long)12);
        NativeMethods::SetData(NativeMethods::DataType::DT_R4, (float)12);
        NativeMethods::SetData(NativeMethods::DataType::DT_R8, (double)12);
        NativeMethods::SetData(NativeMethods::DataType::DT_STR, "abcd");

        Console::WriteLine("\nCalling SetData using overloading... \n");
        double d = 12;
        NativeMethods::SetData2(NativeMethods::DataType::DT_R8, d);
        NativeMethods::SetData2(NativeMethods::DataType::DT_STR, "abcd");
    }
};
//</snippet47>
int main()
{
    App::Main();
}
//</snippet45>
