using namespace System;
using namespace System::Threading;

public ref class ClassA
{
};

// <snippet2>
public ref class ClassB
{
    // The private field that stores the value for the
    // ClassA property is intialized to null. It is set
    // once, from any of several threads. The field must
    // be of type Object, so that CompareExchange can be
    // used to assign the value. If the field is used
    // within the body of class Test, it must be cast to
    // type ClassA.
private:
    static Object^ classAValue = nullptr;

    // This property can be set once to an instance of
    // ClassA. Attempts to set it again cause an
    // exception to be thrown.
public:
    property ClassA^ classA
    {
        ClassA^ get()
        {
            return (ClassA^) classAValue;
        }

        void set(ClassA^ value)
        {
            // CompareExchange compares the value in classAValue
            // to null. The new value assigned to the ClassA
            // property, which is in the special variable 'value',
            // is placed in classAValue only if classAValue is
            // equal to null.
            if (nullptr != Interlocked::CompareExchange(classAValue,
                (Object^) value, nullptr))
            {
                // CompareExchange returns the original value of
                // classAValue; if it is not null, then a value
                // was already assigned, and CompareExchange did not
                // replace the original value. Throw an exception to
                // indicate that an error occurred.
                throw gcnew ApplicationException("ClassA was already set.");
            }
        }
    }
};
// </snippet2>
