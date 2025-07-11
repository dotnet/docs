//<snippet1>
// Assembly2.cs
// Compile with: /reference:Assembly1.dll
namespace Assembly2
{
    using Assembly1;
    
    class DerivedClass : BaseClass
    {
        void Access()
        {
            // OK, because protected members are accessible from
            // derived classes in any assembly
            myValue = 10;
        }
    }
}
//</snippet1>