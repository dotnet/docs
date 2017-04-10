//<Snippet1>
using namespace System;

namespace Samples
{    
    public ref class Book    
    {    
    private:        
        initonly String^ _Title;
 
    public:
        Book(String^ title)        
        {               
            if (title != nullptr)            
            {                        
                title = title->Trim();            
            }
 
            _Title = title;        
        }
 
        property String^ Title        
        {            
            String^ get() { return _Title; }        
        }    
    };
}
//</Snippet1>