#include "stdafx.h"
//<Snippet1>
using namespace System;
 
namespace Samples1 
{    
	public ref class Book    
	{
     private: initonly String^ _Title;
 
    public:
        Book(String^ title)        
		{            
			// Violates this rule (constructor arguments are switched)            
			if (title == nullptr)                
				throw gcnew ArgumentNullException("title cannot be a null reference (Nothing in Visual Basic)", "title");
 
            _Title = title;        
		}
 
        property String^ Title        
		{            
			String^ get()            
			{                
				return _Title;            
			}        
		}    
	};
}
//</Snippet1>

//<Snippet2>
using namespace System;
 
namespace Samples2 
{    
	public ref class Book    
	{
     private: initonly String^ _Title;
 
    public:
        Book(String^ title)        
		{            
			if (title == nullptr)                
				throw gcnew ArgumentNullException(("title", "title cannot be a null reference (Nothing in Visual Basic)"));
 
            _Title = title;        
		}
 
        property String^ Title        
		{            
			String^ get()            
			{                
				return _Title;            
			}        
		}    
	};
}
//</Snippet2>
