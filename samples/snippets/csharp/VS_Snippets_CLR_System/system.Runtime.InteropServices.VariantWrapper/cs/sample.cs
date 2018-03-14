using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // <snippet1>
        // Create an instance of an unmanged COM object.
        UnmanagedComClass UnmanagedComClassInstance = new UnmanagedComClass();

        // Create a string to pass to the COM object.
        string helloString = "Hello World!";

        // Wrap the string with the VariantWrapper class.
        object var = new System.Runtime.InteropServices.VariantWrapper(helloString);

        // Pass the wrapped object.
        UnmanagedComClassInstance.MethodWithStringRefParam(ref var);
        // </snippet1>

    }

}

class UnmanagedComClass
{
    public UnmanagedComClass() { }
    public void MethodWithStringRefParam(ref object var){}
}