//<Snippet1>
using namespace System;

namespace Samples
{    
    public ref class Book    
    {
    public:
        Book()        
        {        
        }
 
        static Book^ CreateBook()        
        {
            // Violates this rule            
            gcnew Book();            
            return gcnew Book();        
        }    
    };
}
//</Snippet1>