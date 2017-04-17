// <Snippet1>                    

using System;
using System.Reflection;
class MyClass1
{         
    private int [,] myArray = {{1,2},{3,4}}; 
    // Declare an indexer.
    public int this [int i,int j]   
    {
        get 
        {
            return myArray[i,j];
        }
        set 
        {
            myArray[i,j] = value;
        }
    }
}
public class MyTypeClass
{
    public static void Main(string[] args)
    {
        try
        { 
            // Get the Type object.
            Type myType=typeof(MyClass1);       
            Type[] myTypeArr = new Type[2];
            // Create an instance of a Type array.
            myTypeArr.SetValue(typeof(int),0);            
            myTypeArr.SetValue(typeof(int),1);
            // Get the PropertyInfo object for the indexed property Item, which has two integer parameters. 
            PropertyInfo myPropInfo = myType.GetProperty("Item", myTypeArr);
            // Display the property.
            Console.WriteLine("The {0} property exists in MyClass1.", myPropInfo.ToString());
        }           
        catch(NullReferenceException e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Source : {0}" , e.Source);
            Console.WriteLine("Message : {0}" , e.Message);
        }
    }
}
// </Snippet1>

