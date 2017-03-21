        public void ImportPolicy(MetadataImporter importer, 
            PolicyConversionContext context)
        {
            Console.WriteLine("The custom policy importer has been called.");
            foreach (XmlElement assertion in context.GetBindingAssertions())
            {
                Console.WriteLine(assertion.NamespaceURI + " : " + assertion.Name);
                // locate a particular assertion by Name and NamespaceURI
                XmlElement customAssertion = context.GetBindingAssertions().Find(name1, ns1);
                if (customAssertion != null)
                {
                  // Found assertion; remove from collection.
                  context.GetBindingAssertions().Remove(customAssertion);
                  Console.WriteLine(
                    "Removed our custom assertion from the imported "
                    + "assertions collection and inserting our custom binding element."
                  );
                    // Here if you find the custom policy assertion that you are looking for,
                    // add the custom binding element that handles the functionality that the policy indicates.
                    // Attach it to the PolicyConversionContext.BindingElements collection.
                    // For example, if the custom policy had a "speed" attribute value:
                    /*
                      string speed 
                        = customAssertion.GetAttribute(SpeedBindingElement.name2, SpeedBindingElement.ns2);
                      SpeedBindingElement e = new SpeedBindingElement(speed);
                      context.BindingElements.Add(e);
                    */
                }

                // write assertion name in red.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(assertion.NamespaceURI + " : " + assertion.Name);

                //write contents in gray.
                Console.WriteLine(assertion.OuterXml);
                Console.ForegroundColor = ConsoleColor.Gray; 
            }
        }