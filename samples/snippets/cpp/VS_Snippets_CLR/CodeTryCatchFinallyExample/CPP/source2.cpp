//<snippet3>
using namespace System;

ref class ArgumentOutOfRangeExample
{
public:
    static void Main()
    {
        array<int>^ array1 = {0, 0};
        array<int>^ array2 = {0, 0};

        try
        {
            Array::Copy(array1, array2, -1);
        }
        catch (ArgumentOutOfRangeException^ e)
        {
            Console::WriteLine("Error: {0}", e);
        }
        finally
        {
            Console::WriteLine("This statement is always executed.");
        }
    }
};

int main()
{
    ArgumentOutOfRangeExample::Main();
}
//</snippet3>
