// <snippet3>
using namespace System;
using namespace System::Collections;

public ref class ExampleClass
{
public:
    ref class Path sealed
    {
    private:
        Path(){}

        static array<char>^ badChars = {'\"', '<', '>'};

    public:
        static array<char>^ GetInvalidPathChars()
        {
            return badChars;
        }
    };

    static void Main()
    {
        // The following code displays the elements of the
        // array as expected.
        for each(char c in Path::GetInvalidPathChars())
        {
            Console::Write(c);
        }
        Console::WriteLine();

        // The following code sets all the values to A.
        Path::GetInvalidPathChars()[0] = 'A';
        Path::GetInvalidPathChars()[1] = 'A';
        Path::GetInvalidPathChars()[2] = 'A';

        // The following code displays the elements of the array to the
        // console. Note that the values have changed.
        for each(char c in Path::GetInvalidPathChars())
        {
            Console::Write(c);
        }
    }
};
// </snippet3>

public ref class DummyColl
{
public:
    ArrayList^ myObj;

    DummyColl()
    {
        myObj = gcnew ArrayList(0);
    }
};

public ref class Path2
{
private:
    static array<char>^ badChars = {'\"', '<', '>'};

// <snippet4>
public:
    static array<char>^ GetInvalidPathChars()
    {
        return (array<char>^)badChars->Clone();
    }
// </snippet4>

    static void DoSomething(Object^ objItem)
    {
    }

    static void Dummy(DummyColl^ obj)
    {
        // <snippet5>
        for (int i = 0; i < obj->myObj->Count; i++)
        {
            DoSomething(obj->myObj[i]);
        }
        // </snippet5>
    }
};

public ref class ExampleClass2
{
    // <snippet6>
public:
    ref class Path sealed
    {
    private:
        Path(){}
    public:
        static const array<char>^ InvalidPathChars = {'\"', '<', '>','|'};
    };
    // </snippet6>

    ref class PathTester
    {
    public:
        void Dummy()
        {
            // <snippet7>
            //The following code can be used to change the values in the array.
            Path::InvalidPathChars[0] = 'A';
            // </snippet7>
        }

        String^ SomeOtherFunc()
        {
            return gcnew String('A', 128);
        }

        // <snippet8>
        void DoSomething()
        {
            String^ s = SomeOtherFunc();
            if (s->Length > 0)
            {
                // Do something else.
            }
        }
        // </snippet8>
    };
};

int main()
{
    ExampleClass::Main();
}