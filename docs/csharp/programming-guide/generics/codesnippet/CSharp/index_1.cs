    // Declare the generic class.
    public class GenericList<T>
    {
        void Add(T input) { }
    }
    class TestGenericList
    {
        private class ExampleClass { }
        static void Main()
        {
            // Declare a list of type int.
            GenericList<int> list1 = new GenericList<int>();

            // Declare a list of type string.
            GenericList<string> list2 = new GenericList<string>();

            // Declare a list of type ExampleClass.
            GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
        }
    }