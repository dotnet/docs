//<Snippet1>
using System;

namespace Samples
{    
    [FlagsAttribute]    
    public enum Days    
    {        
        None        = 0,        
        Monday      = 1,        
        Tuesday     = 2,        
        Wednesday   = 4,        
        Thursday    = 8,        
        Friday      = 16,        
        All         = Monday| Tuesday | Wednesday | Thursday | Friday    
    }
}

//</Snippet1>

