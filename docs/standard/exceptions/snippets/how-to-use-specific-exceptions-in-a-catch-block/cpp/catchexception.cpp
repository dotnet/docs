//<Snippet2>
using namespace System;

public ref class Employee
{
public:
    Employee()
    {
        emlevel = 0;
    }

    //Create employee level property.
    property int Emlevel
    {
        int get()
        {
            return emlevel;
        }
        void set(int value)
        {
            emlevel = value;
        }
    }

private:
    int emlevel;
};

public ref class Ex13
{
public:
    static void PromoteEmployee(Object^ emp)
    {
        //Cast object to Employee.
        Employee^ e = (Employee^) emp;
        // Increment employee level.
        e->Emlevel++;
    }

    static void Main()
    {
        try
        {
            Object^ o = gcnew Employee();
            DateTime^ newyears = gcnew DateTime(2001, 1, 1);
            //Promote the new employee.
            PromoteEmployee(o);
            //Promote DateTime; results in InvalidCastException as newyears is not an employee instance.
            PromoteEmployee(newyears);
        }
        catch (InvalidCastException^ e)
        {
            Console::WriteLine("Error passing data to PromoteEmployee method. " + e->Message);
        }
    }
};

int main()
{
    Ex13::Main();
}
//</Snippet2>
