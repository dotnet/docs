//<Snippet1>
using System;
using System.Collections.ObjectModel; 

namespace PerformanceLibrary
{    
    public class Book    
    {        
        private Collection<string> _Pages;         
        
        public Book(string[] pages)        
        {            
            _Pages = new Collection<string>(pages);        
        }         
        
        public Collection<string> Pages        
        {            
            get { return _Pages; }        
        }    
    }
}
//</Snippet1>