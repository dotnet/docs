//<Snippet1>
using System; 

namespace PerformanceLibrary
{    
    public class Book    
    {        
        private string[] _Pages;      
           
        public Book(string[] pages)        
        {            
            _Pages = pages;        
        }         
        
        public string[] Pages        
        {            
            get { return _Pages; }        
        }    
    }
}
//</Snippet1>