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
        
        public string[] GetPages()        
        {            
            // Need to return a clone of the array so that consumers            
            // of this library cannot change its contents            
            return (string[])_Pages.Clone();        
        }    
    }
}
//</Snippet1>