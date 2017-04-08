// <Snippet1>
using System;
using System.Reflection;

class MyClass
{
    private string myField;
    public string[] myArray = new string[] {"New York", "New Jersey"};
    MyClass()
    {
        myField = "Microsoft";
    }
    string GetField
    {
        get
        {
            return myField;
        }
    }
}

class FieldInfo_IsPrivate
{
    public static void Main()
    {
        try
        {
            // Gets the type of MyClass.
            Type myType = typeof(MyClass);

            // Gets the field information of MyClass.
            FieldInfo[] myFields = myType.GetFields(BindingFlags.NonPublic
                |BindingFlags.Public
                |BindingFlags.Instance);
      
            Console.WriteLine("\nDisplaying whether the fields of {0} are private or not:\n", myType);
            for(int i = 0; i < myFields.Length; i++)
            {
                // Check whether the field is private or not. 
                if(myFields[i].IsPrivate)
                    Console.WriteLine("{0} is a private field.", myFields[i].Name);
                else
                    Console.WriteLine("{0} is not a private field.", myFields[i].Name);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception : {0} " , e.Message);
        }
    }
}
// </Snippet1>

