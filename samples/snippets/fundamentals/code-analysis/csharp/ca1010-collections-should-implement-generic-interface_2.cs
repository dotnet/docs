using System;
using System.Collections.ObjectModel; 

namespace Samples
{    
    public class Book        
    {               
        public Book()                
        {                
        }        
    }    
    
    public class BookCollection : Collection<Book>    
    {        
        public BookCollection()        
        {        
        }    
    }
}