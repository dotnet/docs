//<Snippet1>
using System; 

namespace DesignLibrary
{    
    [AttributeUsage(AttributeTargets.All)]        
    public sealed class GoodCustomAttribute : Attribute    
    {        
        string mandatory;        
        string optional;         
        
        public GoodCustomAttribute(string mandatoryData)        
        {            
            mandatory = mandatoryData;        
        }         
        
        public string MandatoryData        
        {            
            get { return mandatory; }        
        }         
        
        public string OptionalData        
        {            
            get { return optional; }            
            set { optional = value; }        
        }    
    }
}
//</Snippet1>