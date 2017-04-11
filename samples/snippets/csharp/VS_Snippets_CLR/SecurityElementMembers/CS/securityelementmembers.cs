// This sample demonstrates how to use  members of the SecurityElement class.
// The sample creates a SecurityElement for the root of the XML tree and 
// demonstrates how to add attributes and child elements.
//<Snippet1>
using System;
using System.Security;
using System.Collections;

class SecurityElementMembers
{
    [STAThread]
    static void Main(string[] args)
    {
        //<Snippet3>
        SecurityElement xmlRootElement = 
            new SecurityElement("RootTag", "XML security tree");
        //</Snippet3>

        AddAttribute(xmlRootElement,"creationdate",DateTime.Now.ToString());
        AddChildElement(xmlRootElement,"destroytime",
            DateTime.Now.AddSeconds(1.0).ToString());

        //<Snippet2>
        SecurityElement windowsRoleElement = 
            new SecurityElement("WindowsMembership.WindowsRole");
        //</Snippet2>
        
        //<Snippet4>
        windowsRoleElement.AddAttribute("version","1.00");
        //</Snippet4>

        // Add a child element and a creationdate attribute.
        AddChildElement(windowsRoleElement,"BabyElement",
            "This is a child element");
        AddAttribute(windowsRoleElement,"creationdate",
            DateTime.Now.ToString());

        //<Snippet5>
        xmlRootElement.AddChild(windowsRoleElement);
        //</Snippet5>

        CompareAttributes(xmlRootElement, "creationdate");
        ConvertToHashTable(xmlRootElement);

        DisplaySummary(xmlRootElement);

        // Determine if the security element is too old to keep.
        xmlRootElement = DestroyTree(xmlRootElement);
        if (xmlRootElement != null)
        {
            //<Snippet23>
            string elementInXml = xmlRootElement.ToString();
            //</Snippet23>
            Console.WriteLine(elementInXml);
        }
        
        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Add an attribute to the specified security element.
    private static SecurityElement AddAttribute(
        SecurityElement xmlElement,
        string attributeName,
        string attributeValue)
    {
        if (xmlElement != null)
        {
            // Verify that the attribute name and value are valid XML formats.
            //<Snippet6>
            //<Snippet7>
            if (SecurityElement.IsValidAttributeName(attributeName) &&
                SecurityElement.IsValidAttributeValue(attributeValue))
                //</Snippet7>
                //</Snippet6>
            {
                // Add the attribute to the security element.
                //<Snippet8>
                xmlElement.AddAttribute(attributeName, attributeValue);
                //</Snippet8>
            }
        }
        return xmlElement;
    }

    // Add a child element to the specified security element.
    private static SecurityElement AddChildElement(
        SecurityElement parentElement,
        string tagName,
        string tagText)
    {
        if (parentElement != null)
        {
            // Ensure that the tag text is in valid XML format.
            //<Snippet9>
            if (!SecurityElement.IsValidText(tagText))
                //</Snippet9>
            {
                // Replace invalid text with valid XML text 
                // to enforce proper XML formatting.
                //<Snippet19>
                tagText = SecurityElement.Escape(tagText);
                //</Snippet19>
            }

            // Determine whether the tag is in valid XML format.
            //<Snippet10>
            if (SecurityElement.IsValidTag(tagName))
                //</Snippet10>
            {
                //<Snippet24>
                SecurityElement childElement;
                childElement = parentElement.SearchForChildByTag(tagName);
                //</Snippet24>

                if (childElement != null)
                {
                    //<Snippet25>
                    String elementText;
                    elementText = parentElement.SearchForTextOfTag(tagName);
                    //</Snippet25>

                    if (!elementText.Equals(tagText))
                    {
                        // Add child element to the parent security element.
                        parentElement.AddChild(
                            new SecurityElement(tagName, tagText));
                    }
                }
                else 
                {
                    // Add child element to the parent security element.
                    parentElement.AddChild(
                        new SecurityElement(tagName, tagText));
                }
            }
        }
        return parentElement;
    }

    // Create and display a summary sentence 
    // about the specified security element.
    private static void DisplaySummary(SecurityElement xmlElement)
    {
        // Retrieve tag name for the security element.
        //<Snippet11>
        string xmlTreeName = xmlElement.Tag.ToString();
        //</Snippet11>

        // Retrieve tag text for the security element.
        //<Snippet12>
        string xmlTreeDescription = xmlElement.Text;
        //</Snippet12>
        
        // Retrieve value of the creationdate attribute.
        //<Snippet13>
        string xmlCreationDate = xmlElement.Attribute("creationdate");
        //</Snippet13>
        
        // Retrieve the number of children under the security element.
        //<Snippet14>
        string childrenCount = xmlElement.Children.Count.ToString();
        //</Snippet14>

        string outputMessage = "The security XML tree named " + xmlTreeName;
        outputMessage += "(" + xmlTreeDescription + ")";
        outputMessage += " was created on " + xmlCreationDate + " and ";
        outputMessage += "contains " + childrenCount + " child elements.";

        Console.WriteLine(outputMessage);
    }

    // Compare the first two occurrences of an attribute 
    // in the specified security element.
    private static void CompareAttributes(
        SecurityElement xmlElement, string attributeName)
    {
        // Create a hash table containing the security element's attributes.
        //<Snippet15>
        Hashtable attributeKeys = xmlElement.Attributes;
        string attributeValue = attributeKeys[attributeName].ToString();
        //</Snippet15>

        foreach(SecurityElement xmlChild in xmlElement.Children)
        {
            if (attributeValue.Equals(xmlChild.Attribute(attributeName)))
            {
                // The security elements were created at the exact same time.
            }
        }
    }

    // Convert the contents of the specified security element 
    // to hash codes stored in a hash table.
    private static void ConvertToHashTable(SecurityElement xmlElement)
    {
        // Create a hash table to hold hash codes of the security elements.
        //<Snippet16>
        Hashtable xmlAsHash = new Hashtable();
        int rootIndex = xmlElement.GetHashCode();
        xmlAsHash.Add(rootIndex, "root");
        //</Snippet16>

        int parentNum = 0;

        foreach(SecurityElement xmlParent in xmlElement.Children)
        {
            parentNum++;
            xmlAsHash.Add(xmlParent.GetHashCode(), "parent" + parentNum);
            if ((xmlParent.Children != null) && 
                (xmlParent.Children.Count > 0))
            {
                int childNum = 0;
                foreach(SecurityElement xmlChild in xmlParent.Children)
                {
                    childNum++;
                    xmlAsHash.Add(xmlChild.GetHashCode(), "child" + childNum);
                }
            }
        }
    }

    // Delete the specified security element if the current time is past
    // the time stored in the destroytime tag.
    private static SecurityElement DestroyTree(SecurityElement xmlElement)
    {
        SecurityElement localXmlElement = xmlElement;
        SecurityElement destroyElement = 
            localXmlElement.SearchForChildByTag("destroytime");

        // Verify that a destroytime tag exists.
        //<Snippet17>
        if (localXmlElement.SearchForChildByTag("destroytime") != null)
            //</Snippet17>
        {
            // Retrieve the destroytime text to get the time 
            // the tree can be destroyed.
            //<Snippet18>
            string storedDestroyTime =
                localXmlElement.SearchForTextOfTag("destroytime");
            //</Snippet18>

            DateTime destroyTime = DateTime.Parse(storedDestroyTime);
            if (DateTime.Now > destroyTime)
            {
                localXmlElement = null;
                Console.WriteLine("The XML security tree has been deleted.");
            }
        }

        // Verify that xmlElement is of type SecurityElement.
        //<Snippet21>
        if (xmlElement.GetType().Equals(
            typeof(System.Security.SecurityElement)))
            //</Snippet21>
        {
            // Determine whether the localXmlElement object 
            // differs from xmlElement.
            //<Snippet20>
            if (xmlElement.Equals(localXmlElement))
                //</Snippet20>
            {
                // Verify that the tags, attributes and children of the
                // two security elements are identical.
                //<Snippet22>
                if (xmlElement.Equal(localXmlElement))
                    //</Snippet22>
                {
                    // Return the original security element.
                    return xmlElement;
                }
            }
        }

        // Return the modified security element.
        return localXmlElement;
    }
}
//
// This sample produces the following output:
// 
// The security XML tree named RootTag(XML security tree) 
// was created on 2/23/2004 1:23:00 PM and contains 2 child elements.
//<RootTag creationdate="2/23/2004 1:23:00 PM">XML security tree
//   <destroytime>2/23/2004 1:23:01 PM</destroytime>
//   <WindowsMembership.WindowsRole version="1.00"
//                                  creationdate="2/23/2004 1:23:00 PM">
//      <BabyElement>This is a child element.</BabyElement>
//   </WindowsMembership.WindowsRole>
//</RootTag>
//
//This sample completed successfully; press Exit to continue.
//</Snippet1>