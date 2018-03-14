// <Snippet1>
using System;

public class NumericValue
{
   private int value = 0;
       
   public NumericValue(int value)
   {
      this.value = value;
   }     
   
   public ref int IncrementValue()
   {
      value++;
      return ref value;
   }
   
   public int GetValue()
   {
      return value;
   }
}
// </Snippet1>

