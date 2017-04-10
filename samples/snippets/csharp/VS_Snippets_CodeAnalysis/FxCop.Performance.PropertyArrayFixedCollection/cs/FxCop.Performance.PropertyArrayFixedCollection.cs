//<Snippet1>
using System;
using System.Collections.ObjectModel; 

namespace PerformanceLibrary
{    
    public class Book    
    {        
        private ReadOnlyCollection<string> _Pages;         
        public Book(string[] pages)        
        {            
            _Pages = new ReadOnlyCollection<string>(pages);        
        }         
        
        public ReadOnlyCollection<string> Pages        
        {            
            get { return _Pages; }        
        }    
    }
}
//</Snippet1>