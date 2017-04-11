//<Snippet1>
using System; 

namespace Samples
{    
    public static class Calculator    
    {        
        public static int Decrement(int input)        
        {             
            // Violates this rule            
            input--;             
            return input;        
        }    
    }
}
//</Snippet1>
