namespace SomeNameSpace
{
    public class MyClass 
    {
        static void Main() 
        {
            Nested.NestedNameSpaceClass.SayHello();
        }
    }

    // a nested namespace
    namespace Nested   
    {
        public class NestedNameSpaceClass 
        {
            public static void SayHello() 
            {
                Console.WriteLine("Hello");
            }
        }
    }
}
// Output: Hello