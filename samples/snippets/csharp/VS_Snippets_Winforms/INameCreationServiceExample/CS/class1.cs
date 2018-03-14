//<Snippet1>
using System;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace NameCreationServiceExample
{
    public class NameCreationService : System.ComponentModel.Design.Serialization.INameCreationService
    {
        public NameCreationService()
        {
        }

//<Snippet2>
        // Creates an identifier for a particular data type that does not conflict 
        // with the identifiers of any components in the specified collection.
        public string CreateName(System.ComponentModel.IContainer container, System.Type dataType)
        {
            // Create a basic type name string.
            string baseName = dataType.Name;
            int uniqueID = 1;

            bool unique = false;            
            // Continue to increment uniqueID numeral until a 
            // unique ID is located.
            while( !unique )
            {
                unique = true;
                // Check each component in the container for a matching 
                // base type name and unique ID.
                for(int i=0; i<container.Components.Count; i++)
                {
                    // Check component name for match with unique ID string.
                    if( container.Components[i].Site.Name.StartsWith(baseName+uniqueID.ToString()) )
                    {
                        // If a match is encountered, set flag to recycle 
                        // collection, increment ID numeral, and restart.
                        unique = false;
                        uniqueID++;
                        break;
                    }
                }
            }
            
            return baseName+uniqueID.ToString();
        }
//</Snippet2>

//<Snippet3>
        // Returns whether the specified name contains 
        // all valid character types.
        public bool IsValidName(string name)
        {            
            for(int i = 0; i < name.Length; i++)
            {
                char ch = name[i];
                UnicodeCategory uc = Char.GetUnicodeCategory(ch);
                switch (uc) 
                {
                    case UnicodeCategory.UppercaseLetter:       
                    case UnicodeCategory.LowercaseLetter:     
                    case UnicodeCategory.TitlecaseLetter:                                                  
                    case UnicodeCategory.DecimalDigitNumber:                         
                        break;
                    default:
                        return false;                
                }
            }
            return true;        
         }
//</Snippet3>

//<Snippet4>
        // Throws an exception if the specified name does not contain 
        // all valid character types.
        public void ValidateName(string name)
        {
            for(int i = 0; i < name.Length; i++)
            {
                char ch = name[i];
                UnicodeCategory uc = Char.GetUnicodeCategory(ch);
                switch (uc) 
                {
                    case UnicodeCategory.UppercaseLetter:       
                    case UnicodeCategory.LowercaseLetter:     
                    case UnicodeCategory.TitlecaseLetter:                                                  
                    case UnicodeCategory.DecimalDigitNumber:                         
                        break;
                    default:
                        throw new Exception("The name '"+name+"' is not a valid identifier.");                
                }
            }
        }
//</Snippet4>
     }
}
//</Snippet1>