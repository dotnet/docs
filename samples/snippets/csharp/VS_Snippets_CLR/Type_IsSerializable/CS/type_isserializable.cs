// <Snippet1>   
using System;
namespace SystemType
{
    public class MyClass
    {
        // Declare a public class with the [Serializable] attribute.
        [Serializable] public class MyTestClass 
        {
        }
        public static void Main(string []args)
        {
            try
            {
                bool myBool = false;
                MyTestClass myTestClassInstance = new MyTestClass();
                // Get the type of myTestClassInstance.
                Type myType = myTestClassInstance.GetType();
                // Get the IsSerializable property of myTestClassInstance.
                myBool = myType.IsSerializable;
                Console.WriteLine("\nIs {0} serializable? {1}.", myType.FullName, myBool.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn exception occurred: {0}", e.Message);
            }
        }
    }
}
// </Snippet1>