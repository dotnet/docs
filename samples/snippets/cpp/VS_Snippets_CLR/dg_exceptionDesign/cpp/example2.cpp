//<snippet14>
using namespace System;

public ref class EmployeeListNotFoundException : Exception
{
public:
    EmployeeListNotFoundException()
    {
    }

    EmployeeListNotFoundException(String^ message)
        : Exception(message)
    {
    }

    EmployeeListNotFoundException(String^ message, Exception^ inner)
        : Exception(message, inner)
    {
    }
};
//</snippet14>

public ref class TestExample
{
public:
    static void Main()
    {
        EmployeeListNotFoundException ^e1, ^e2, ^e3;
        Exception^ ex = gcnew Exception();

        e1 = gcnew EmployeeListNotFoundException();
        e2 = gcnew EmployeeListNotFoundException("Hi!");
        e3 = gcnew EmployeeListNotFoundException("Hi!", ex);
    }
};

int main()
{
    TestExample::Main();
}