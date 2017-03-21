            // Gets the attributes for the property.
             AttributeCollection attributes = 
                TypeDescriptor.GetProperties(this)["GetLanguage"].Attributes;

             /* Prints whether the property is marked as DesignOnly 
              * by retrieving the DesignOnlyAttribute from the AttributeCollection. */
             DesignOnlyAttribute myAttribute = 
                (DesignOnlyAttribute)attributes[typeof(DesignOnlyAttribute)];
             Console.WriteLine("This property is design only :" +
                myAttribute.IsDesignOnly.ToString());