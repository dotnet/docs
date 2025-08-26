//<snippet1>
namespace Example1
{
    class BaseClass
    {
        protected int myValue = 123;
    }

    class DerivedClass : BaseClass
    {
        static void Main()
        {
            var baseObject = new BaseClass();
            var derivedObject = new DerivedClass();

            // Error CS1540, because myValue can only be accessed through
            // the derived class type, not through the base class type.
            // baseObject.myValue = 10;

            // OK, because this class derives from BaseClass.
            derivedObject.myValue = 10;
        }
    }
}
//</snippet1>