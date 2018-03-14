using System;

public class SByteRangeExample
{
   public static void Main()
   {
      // <Snippet1>
      long longValue = -130;
      sbyte byteValue; 
      
      if (longValue <= sbyte.MaxValue && 
          longValue >= sbyte.MinValue)
      {    
         byteValue = (sbyte) longValue;
         Console.WriteLine("Converted long integer value to {0}.", byteValue);
      }   
      else
      {
         sbyte rangeLimit;
         string relationship;
         
         if (longValue > sbyte.MaxValue)
         {
            rangeLimit = sbyte.MaxValue;
            relationship = "greater";
         }   
         else
         {
            rangeLimit = sbyte.MinValue;
            relationship = "less";
         }       

         Console.WriteLine("Conversion failure: {0:n0} is {1} than {2}.",  
                           longValue, 
                           relationship, 
                           rangeLimit);
      }       
      // </Snippet1>
   }
}
