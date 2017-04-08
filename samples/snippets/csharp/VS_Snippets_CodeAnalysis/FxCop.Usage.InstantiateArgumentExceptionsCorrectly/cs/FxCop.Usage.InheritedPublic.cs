//<Snippet1>
using System;
 
namespace Samples1
{    
    public class Book    
    {        
        private readonly string _Title;
 
        public Book(string title)        
        {            
            // Violates this rule (constructor arguments are switched)            
            if (title == null)                
                throw new ArgumentNullException("title cannot be a null reference (Nothing in Visual Basic)", "title");
 
            _Title = title;        
        }
 
        public string Title        
        {            
            get { return _Title; }        
        }
    }
}
//</Snippet1>

//<Snippet2>
namespace Samples2
{    
    public class Book    
    {        
        private readonly string _Title;
 
        public Book(string title)        
        {            
            if (title == null)                
                throw new ArgumentNullException("title", "title cannot be a null reference (Nothing in Visual Basic)");
 
            _Title = title;        }
 
        public string Title        
        {            
            get { return _Title; }        
        }
    }
}
//</Snippet2>
