// System.ArrayTypeMismatchException.ArrayTypeMismatchException

/*
   The following example demonstrates the 'ArrayTypeMismatchException(string)' 
   constructor of class ArrayTypeMismatchException class.A function has been 
   created which takes two arrays as arguments. It checks whether the two arrays
   are of same type or not. If two arrays are of not same type then a new 
   'ArrayTypeMismatchException' object is created and thrown. That exception is 
   caught in the calling method.
 */
// <Snippet1>

using System;

public class ArrayTypeMisMatchConst
{
   public void CopyArray(Array myArray,Array myArray1)
   {
      string typeArray1 = myArray.GetType().ToString();
      string typeArray2 = myArray1.GetType().ToString();
      // Check whether the two arrays are of same type or not.
      if(typeArray1==typeArray2)
      {
         // Copies the values from one array to another.
         myArray.SetValue("Name: "+myArray1.GetValue(0),0);
         myArray.SetValue("Name: "+myArray1.GetValue(1),1);
      }
      else
      {
          // Throw an exception of type 'ArrayTypeMismatchException' with a message string as parameter.
         throw new ArrayTypeMismatchException("The Source and destination arrays are not of same type.");
      }
   }

   static void Main()
   {
      try
      {
         string[] myStringArray = new string[2];
         myStringArray.SetValue("Jones",0);
         myStringArray.SetValue("John",1);
         int[] myIntArray = new int[2];
         ArrayTypeMisMatchConst myArrayType = new ArrayTypeMisMatchConst();
         myArrayType.CopyArray(myStringArray,myIntArray);
      }
      catch(ArrayTypeMismatchException e)
      {
         Console.WriteLine("The Exception Message is : " + e.Message);
      }
   }
}
// </Snippet1>        
