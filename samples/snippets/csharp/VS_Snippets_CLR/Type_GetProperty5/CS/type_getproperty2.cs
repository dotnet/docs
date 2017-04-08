// <Snippet1>
using System;
using System.Reflection;
public class MyPropertyClass
{
    private int [,] myPropertyArray = new int[10,10]; 
    // Declare an indexer.
    public int this [int i,int j]
    {
        get 
        {
            return myPropertyArray[i,j];
        }
        set 
        {
            myPropertyArray[i,j] = value;
        }
    }
}
public class MyTypeClass
{
    public static void Main()
    {
        try
        {
            Type myType=typeof(MyPropertyClass);
            Type[] myTypeArray = new Type[2];
            // Create an instance of the Type array representing the number, order 
            // and type of the parameters for the property.
            myTypeArray.SetValue(typeof(int),0);
            myTypeArray.SetValue(typeof(int),1);
            // Search for the indexed property whose parameters match the
            // specified argument types and modifiers.
            PropertyInfo myPropertyInfo = myType.GetProperty("Item",
                typeof(int),myTypeArray,null);
            Console.WriteLine(myType.FullName + "." + myPropertyInfo.Name + 
                " has a property type of " + myPropertyInfo.PropertyType);
         }
        catch(Exception ex)
        {
            Console.WriteLine("An exception occurred " + ex.Message);
        }
    }
}
// </Snippet1>

