//<Snippet1>
using System; 

namespace Samples
{    
    public static class Calculator    
    {        
        public static int Decrement(int input)        
        {            
            if (input == int.MinValue)                
                throw new ArgumentOutOfRangeException("input", "input must be greater than Int32.MinValue");
                             
            input--;             
            return input;        
        }    
    }
}
//</Snippet1>
