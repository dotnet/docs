//<Snippet1>
using namespace System;

private ref class InternalOnly 
{
public:
    ref class Nested {};
};

public ref class Example 
{
public:
    ref class Nested {};
}; 


// Entry point of example
int main()
{
    Type^ classType = InternalOnly::Nested::typeid;
    Console::WriteLine(
        "Is the {0} class visible outside the assembly? {1}",
        classType->FullName, classType->IsVisible);

    classType = Example::Nested::typeid;
    Console::WriteLine(
        "Is the {0} class visible outside the assembly? {1}", 
        classType->FullName, classType->IsVisible);
}

/* This example produces the following output:

Is the InternalOnly+Nested class visible outside the assembly? False
Is the Example+Nested class visible outside the assembly? True
*/
//</Snippet1>
