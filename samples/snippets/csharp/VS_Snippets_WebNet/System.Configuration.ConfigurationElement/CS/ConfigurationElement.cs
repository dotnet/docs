// Contains the Main function to allow the
// example to be run as a console application.

// <Snippet151>
// Set Assembly name to ConfigurationElement
using System;
using System.Configuration;
using System.Collections;

namespace Samples.AspNet
{
    // Entry point for console application that reads the 
    // app.config file and writes to the console the 
    // URLs in the custom section.  
    class TestConfigurationElement
    {
        static void Main(string[] args)
        {
            // Get current configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Get the MyUrls section.
            UrlsSection myUrlsSection =
                config.GetSection("MyUrls") as UrlsSection;

            if (myUrlsSection == null)
                Console.WriteLine("Failed to load UrlsSection.");
            else
            {
                Console.WriteLine("The 'simple' element of app.config:");
                Console.WriteLine("  Name={0} URL={1} Port={2}",
                    myUrlsSection.Simple.Name,
                    myUrlsSection.Simple.Url,
                    myUrlsSection.Simple.Port);

                Console.WriteLine("The urls collection of app.config:");
                for (int i = 0; i < myUrlsSection.Urls.Count; i++)
                {
                    Console.WriteLine("  Name={0} URL={1} Port={2}",
                        myUrlsSection.Urls[i].Name,
                        myUrlsSection.Urls[i].Url,
                        myUrlsSection.Urls[i].Port);
                }
            }
            Console.ReadLine();
        }
    }
}
// </Snippet151>

namespace Samples.AspNet
{
    // Putting remaining methods into a separate class so that the
    // above snippet can be complete.
    // To test one of these methods, uncomment the appropriate 
    // line(s) and move it or them into the Main method above.
    //GetProperties();
    //LockItem();
    //LockAllAttributesExcept();
    //LockAttributes();
    //LockElements();
    //LockAllElementsExcept();
    //ModifyElement();
    //ReadOnlyElements();
    //AddClearRemoveElementName();
    //UsingElementInformation.GetElementValidator();
    //UsingSectionInformation.UnProtectSection();
    class TestConfigurationElement2
    {
        // <Snippet1>
        // Create a section whose name is 
        // MyUrls that contains a nested collection as 
        // defined by the UrlsSection class.
        static void CreateSection()
        {
            string sectionName = "MyUrls";

            try
            {

                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                UrlsSection urlsSection;

                // Create the section whose name attribute 
                // is MyUrls in <configSections>.
                // Also, create the related target section 
                // MyUrls in <configuration>.
                if (config.Sections[sectionName] == null)
                {
                    urlsSection = new UrlsSection();

                    // Change the default values of 
                    // the simple element.
                    urlsSection.Simple.Name = "Contoso";
                    urlsSection.Simple.Url = "http://www.contoso.com";
                    urlsSection.Simple.Port = 8080;

                    config.Sections.Add(sectionName, urlsSection);
                    urlsSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[CreateSection: {0}]",
                    e.ToString());
            }


        }
        // </Snippet1>


        static void AddClearRemoveElementName()
        {

            try
            {

                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                // Get the configuration section MyUrls.
                UrlsSection myUrlsSection =
                   config.Sections["MyUrls"] as UrlsSection;

                // Get the configuration element collection.
                UrlsCollection elements =
                    myUrlsSection.Urls;

                Console.WriteLine("Default Add name: {0}",
                    elements.AddElementName);
                Console.WriteLine("Default Remove name: {0}",
                    elements.RemoveElementName);
                Console.WriteLine("Default Clear name: {0}",
                    elements.ClearElementName);

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[AddElementName: {0}]",
                    e.ToString());
            }


        }

        // <Snippet2> 
        // Show the use of Properties.
        // It displays the ConfigurationElement 
        // properties.
        static void GetProperties()
        {

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the configuration section MyUrls.
                UrlsSection myUrlsSection =
                   config.Sections["MyUrls"] as UrlsSection;

                // Get the configuration element collection.
                UrlsCollection elements =
                    myUrlsSection.Urls;

                IEnumerator elemEnum =
                    elements.GetEnumerator();

                int i = 0;
                while (elemEnum.MoveNext())
                {
                    // Get the current element configuration
                    // property collection.
                    PropertyInformationCollection properties =
                        elements[i].ElementInformation.Properties;

                    // Display the current configuration 
                    // element properties.
                    foreach (PropertyInformation property in properties)
                    {
                        Console.WriteLine("Name: {0}\tDefault: {1}\tRequired: {2}",
                         property.Name, property.DefaultValue,
                         property.IsRequired.ToString());
                    }
                }

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[GetProperties: {0}]",
                    e.ToString());
            }

        }
        // </Snippet2> 

        // <Snippet3> 
        // Show how to set LockItem
        // It adds a new UrlConfigElement to 
        // the collection.
        static void LockItem()
        {
            string name = "Contoso";
            string url = "http://www.contoso.com/";
            int port = 8080;

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrls =
                   config.Sections["MyUrls"] as UrlsSection;


                // Create the new  element.
                UrlConfigElement newElement =
                    new UrlConfigElement(name, url, port);

                // Set its lock.
                newElement.LockItem = true;

                // Save the new element to the 
                // configuration file.
                if (!myUrls.ElementInformation.IsLocked)
                {

                    myUrls.Urls.Add(newElement);

                    config.Save(ConfigurationSaveMode.Full);

                    // This is used to obsolete the cached 
                    // section and read the updated 
                    // bersion from the configuration file.
                    ConfigurationManager.RefreshSection("MyUrls");
                }
                else
                    Console.WriteLine(
                        "Section was locked, could not update.");

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[LockItem: {0}]",
                    e.ToString());
            }

        }
        // </Snippet3> 


        // <Snippet4> 
        // Show how to use LockElements
        // It locks and unlocks the urls element.
        static void LockElements()
        {

            try
            {
                // Get the configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;

                if (myUrlsSection == null)
                    Console.WriteLine("Failed to load UrlsSection.");
                else
                {
                    // Get MyUrls section LockElements collection.
                    ConfigurationLockCollection lockElements =
                        myUrlsSection.LockElements;

                    // Get MyUrls section LockElements collection 
                    // enumerator.
                    IEnumerator lockElementEnum =
                         lockElements.GetEnumerator();

                    // Position the collection index.
                    lockElementEnum.MoveNext();

                    if (lockElements.Contains("urls"))
                        // Remove the lock on the urls element.
                        lockElements.Remove("urls");
                    else
                        // Add the lock on the urls element.
                        lockElements.Add("urls");

                    // Save the change.
                    config.Save(ConfigurationSaveMode.Full);

                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[LockElements: {0}]",
                    err.ToString());
            }
        }

        // </Snippet4> 

        // <Snippet5> 
        // Show how to use LockAllElementsExcept.
        // It locks and unlocks all the MyUrls elements 
        // except urls.
        static void LockAllElementsExcept()
        {

            try
            {
                // Get the configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;

                if (myUrlsSection == null)
                    Console.WriteLine("Failed to load UrlsSection.");
                else
                {

                    // Get MyUrls section LockElements collection.
                    ConfigurationLockCollection lockElementsExcept =
                        myUrlsSection.LockAllElementsExcept;

                    // Get MyUrls section LockElements collection 
                    // enumerator.
                    IEnumerator lockElementEnum =
                         lockElementsExcept.GetEnumerator();

                    // Position the collection index.
                    lockElementEnum.MoveNext();

                    if (lockElementsExcept.Contains("urls"))
                        // Remove the lock on all the ther elements.
                        lockElementsExcept.Remove("urls");
                    else
                        // Add the lock on all the other elements 
                        // but urls element.
                        lockElementsExcept.Add("urls");


                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[LockAllElementsExcept: {0}]",
                    err.ToString());
            }
        }
        // </Snippet5> 


        // <Snippet6>
        // Show how to use IsModified.
        // This method modifies the port property
        // of the url element named Microsoft and
        // saves the modification to the configuration
        // file. This in turn will cause the overriden
        // UrlConfigElement.IsModified() mathod to be called. 
        static void ModifyElement()
        {
            try
            {
                // Get the configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;


                UrlsCollection elements = myUrlsSection.Urls;


                IEnumerator elemEnum =
                    elements.GetEnumerator();

                int i = 0;
                while (elemEnum.MoveNext())
                {
                    if (elements[i].Name == "Microsoft")
                    {
                        elements[i].Port = 1010;
                        bool readOnly = elements[i].IsReadOnly();
                        break;
                    }
                    i += 1;
                }

                if (!myUrlsSection.ElementInformation.IsLocked)
                {

                    config.Save(ConfigurationSaveMode.Full);

                    // This to obsolete the MyUrls cached 
                    // section and read the updated version
                    // from the configuration file.
                    ConfigurationManager.RefreshSection("MyUrls");
                }
                else
                    Console.WriteLine(
                        "Section was locked, could not update.");
            }

            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[ModifyElement: {0}]",
                    err.ToString());
            }

        }

        // </Snippet6>

        // <Snippet7>
        // Show how to use IsReadOnly.
        // It loops to see if the elements are read only. 
        static void ReadOnlyElements()
        {
            try
            {
                // Get the configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;


                UrlsCollection elements = myUrlsSection.Urls;


                IEnumerator elemEnum =
                    elements.GetEnumerator();

                int i = 0;
                Console.WriteLine(elements.Count.ToString());

                while (elemEnum.MoveNext())
                {
                    Console.WriteLine("The element {0} is read only: {1}",
                     elements[i].Name,
                     elements[i].IsReadOnly().ToString());
                    i += 1;
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[ReadOnlyElements: {0}]",
                    err.ToString());
            }

        }
        // </Snippet7>

        // Remove a UrlConfigElement from the collection.
        static void RemoveElement(string name, string url, int port)
        {
            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Get the MyUrls section.
            UrlsSection myUrlsSection =
                config.GetSection("MyUrls") as UrlsSection;

            UrlsCollection urls = myUrlsSection.Urls;

            UrlConfigElement element =
                new UrlConfigElement(name, url, port);

            if (!myUrlsSection.ElementInformation.IsLocked)
            {

                myUrlsSection.Urls.Remove(element);

                config.Save(ConfigurationSaveMode.Minimal);

                // This to obsolete the cached section and
                // read the new updated one.
                ConfigurationManager.RefreshSection("MyUrls");
            }
            else
                Console.WriteLine(
                    "Section was locked, could not update.");
        }

        // <Snippet8> 
        // Show how to use LockAttributes.
        // It locks and unlocks all the urls elements.
        static void LockAttributes()
        {

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;

                if (myUrlsSection == null)
                    Console.WriteLine("Failed to load UrlsSection.");
                else
                {

                    IEnumerator elemEnum =
                         myUrlsSection.Urls.GetEnumerator();

                    int i = 0;
                    while (elemEnum.MoveNext())
                    {

                        // Get the current element.
                        ConfigurationElement element =
                            myUrlsSection.Urls[i];

                        // Get the lock attributes collection of 
                        // the current element.
                        ConfigurationLockCollection lockAttributes =
                            element.LockAttributes;

                        // Add or remove the lock on the attributes.
                        if (lockAttributes.Contains("name"))
                            lockAttributes.Remove("name");
                        else
                            lockAttributes.Add("name");

                        if (lockAttributes.Contains("url"))
                            lockAttributes.Remove("url");
                        else
                            lockAttributes.Add("url");

                        if (lockAttributes.Contains("port"))
                            lockAttributes.Remove("port");
                        else
                            lockAttributes.Add("port");


                        // Get the locket attributes.
                        string lockedAttributes =
                            lockAttributes.AttributeList;

                        Console.WriteLine(
                            "Element {0} Locked attributes list: {1}",
                            i.ToString(), lockedAttributes);

                        i += 1;

                        config.Save(ConfigurationSaveMode.Full);

                    }

                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[LockAttributes: {0}]",
                    e.ToString());
            }

        }
        // </Snippet8> 


        // <Snippet9> 
        // Show how to use LockAllAttributesExcept.
        // It locks and unlocks all urls elements 
        // except the port.
        static void LockAllAttributesExcept()
        {

            try
            {
                // Get current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;

                if (myUrlsSection == null)
                    Console.WriteLine(
                        "Failed to load UrlsSection.");
                else
                {

                    IEnumerator elemEnum =
                         myUrlsSection.Urls.GetEnumerator();

                    int i = 0;
                    while (elemEnum.MoveNext())
                    {

                        // Get current element.
                        ConfigurationElement element =
                            myUrlsSection.Urls[i];

                        // Get current element lock all attributes.
                        ConfigurationLockCollection lockAllAttributesExcept =
                            element.LockAllAttributesExcept;

                        // Add or remove the lock on all attributes 
                        // except port.
                        if (lockAllAttributesExcept.Contains("port"))
                            lockAllAttributesExcept.Remove("port");
                        else
                            lockAllAttributesExcept.Add("port");


                        string lockedAttributes =
                            lockAllAttributesExcept.AttributeList;

                        Console.WriteLine(
                            "Element {0} Locked attributes list: {1}",
                            i.ToString(), lockedAttributes);


                        i += 1;

                        config.Save(ConfigurationSaveMode.Full);

                    }


                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(
                    "[LockAllAttributesExcept: {0}]",
                    e.ToString());
            }

        }
        // </Snippet9> 

    }
}
