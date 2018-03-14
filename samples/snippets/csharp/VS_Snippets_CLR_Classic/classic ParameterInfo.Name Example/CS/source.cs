// <Snippet1>
using System;
using System.Reflection;
 
class parminfo
{
    public static void mymethod (
       int int1m, out string str2m, ref string str3m)
    {
       str2m = "in mymethod";
    }
  
    public static int Main(string[] args)
    {   
       Console.WriteLine("\nReflection.Parameterinfo");
       
       //Get the ParameterInfo parameter of a function.
  
       //Get the type.
       Type Mytype = Type.GetType("parminfo");
  
       //Get and display the method.
       MethodBase Mymethodbase = Mytype.GetMethod("mymethod");
       Console.Write("\nMymethodbase = " + Mymethodbase);
  
       //Get the ParameterInfo array.
       ParameterInfo[] Myarray = Mymethodbase.GetParameters();
       
       //Get and display the name of each parameter.
       foreach (ParameterInfo Myparam in Myarray)
       {
          Console.Write ("\nFor parameter # "   + Myparam.Position 
             + ", the Name is - " +  Myparam.Name);
       }
       return 0;
    }
 }
 /*
 This code produces the following output:

 Reflection.ParameterInfo
  
 Mymethodbase
 = Void mymethod (Int32, System.String ByRef, System.String ByRef)
 For parameter # 0, the Name is - int1m
 For parameter # 1, the Name is - str2m
 For parameter # 2, the Name is - str3m
 */
// </Snippet1>

