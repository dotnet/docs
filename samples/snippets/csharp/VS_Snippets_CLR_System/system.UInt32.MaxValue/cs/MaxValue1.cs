using System;

public class ULongRangeExample
{
   public static void Main()
   {
      // <Snippet1>
      long longValue = long.MaxValue / 2;
      uint integerValue; 
      
      if (longValue <= uint.MaxValue && 
          longValue >= uint.MinValue)
      {    
         integerValue = (uint) longValue;
         Console.WriteLine("Converted long integer value to {0:n0}.", 
                           integerValue);
      }   
      else
      {
         uint rangeLimit;
         string relationship;
         
         if (longValue > uint.MaxValue)
         {
            rangeLimit = uint.MaxValue;
            relationship = "greater";
         }   
         else
         {
            rangeLimit = uint.MinValue;
            relationship = "less";
         }       

         Console.WriteLine("Conversion failure: {0:n0} is {1} than {2:n0}",  
                           longValue, 
                           relationship, 
                           rangeLimit);
      }       
      // </Snippet1>
   }
}
