// <Snippet1>
using System;
using System.Reflection;
 
class paramatt
{
    public static void mymethod (string str1, out string str2, ref string str3)
    {
        str2 = "string";
    }
    
    public static int Main(string[] args)
    {
        Console.WriteLine("\nReflection.ParameterAttributes");
  
        // Get the Type and the method.
  
        Type Mytype = Type.GetType("paramatt");
        MethodBase Mymethodbase = Mytype.GetMethod("mymethod");
  
        // Display the method.
        Console.Write("\nMymethodbase = " + Mymethodbase);
  
        // Get the ParameterInfo array.
        ParameterInfo[] Myarray = Mymethodbase.GetParameters();
  
        // Get and display the attributes for the second parameter.
        ParameterAttributes Myparamattributes = Myarray[1].Attributes;
  
        Console.Write("\nFor the second parameter:\nMyparamattributes = " 
            + (int) Myparamattributes
            + ", which is an "
            + Myparamattributes.ToString());
  
        return 0;
    }
}
// </Snippet1>

