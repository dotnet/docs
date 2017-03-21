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