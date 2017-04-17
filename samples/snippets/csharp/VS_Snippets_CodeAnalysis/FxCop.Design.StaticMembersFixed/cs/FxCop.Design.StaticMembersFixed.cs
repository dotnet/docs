//<Snippet1>
using System; 

namespace DesignLibrary
{    
    public static class StaticMembers    
    {        
        private static int someField;     
            
        public static int SomeProperty        
        {            
            get { return someField; }            
            set { someField = value; }        
        }                
        
        public static void SomeMethod()         
        {        
        }         
        
        public static event SomeDelegate SomeEvent;    
    }     
    
    public delegate void SomeDelegate();
}
//</Snippet1>