// System.Reflection.ParameterInfo.Attributes

/*
   The following example displays the attributes associated with the
   parameters of the method called 'MyMethod' of class 'ParameterInfo_Example'.
 */


// <Snippet1>
using System;
using System.Reflection;
public class MyClass1
{
   public int MyMethod( int i, out short j, ref long k)
   {
      j = 2;
      return 0;
   }  
}

public class ParameterInfo_Attributes
{   
   public static void Main()
   {
      // Get the type. 
      Type myType = typeof(MyClass1);
      // Get the method named 'MyMethod' from the type.
      MethodBase myMethodBase = myType.GetMethod("MyMethod");
      // Get the parameters associated with the method.
      ParameterInfo[] myParameters = myMethodBase.GetParameters();
      Console.WriteLine("\nThe method {0} has the {1} parameters :", 
                          "ParameterInfo_Example.MyMethod", myParameters.Length);
      // Print the attributes associated with each of the parameters.
      for(int i = 0; i < myParameters.Length; i++)
         Console.WriteLine("\tThe {0} parameter has the attribute : {1}", 
                                             i + 1, myParameters[i].Attributes);
   }
}
// </Snippet1>