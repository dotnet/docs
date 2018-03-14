// File name: ElementInformation.cs
// Allowed snippet tags range: [80 - 90].

using System;
// using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.Configuration;

namespace Samples.AspNet
{
    class UsingElementInformation
    {

        // <Snippet80>
        static public ElementInformation
            GetElementInformation()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            ElementInformation eInfo =
                url.ElementInformation;

            return eInfo;

        }
        // </Snippet80>

       // <Snippet81>
        static public void IsElementCollection()
        {
            
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
            
            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            // Get the collection element.
            UrlsCollection urls = section.Urls;

            bool isCollection =
                url.ElementInformation.IsCollection;
            Console.WriteLine("Url element is a collection? {0}",
                isCollection.ToString());

            isCollection =
               urls.ElementInformation.IsCollection;
            Console.WriteLine("Urls element is a collection? {0}",
                isCollection.ToString());
          
        }
        // </Snippet81>

        // <Snippet82>
        static public void IsElementLocked()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
            
            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            bool isLocked =
                url.ElementInformation.IsLocked;
            Console.WriteLine("Url element is locked? {0}",
                isLocked.ToString());

        }
        // </Snippet82>

        // <Snippet83>
        static public void IsElementPresent()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            bool isPresent =
                url.ElementInformation.IsPresent;
            Console.WriteLine("Url element is present? {0}",
                isPresent.ToString());


        }
        // </Snippet83>

        // <Snippet84>
        static public void GetElementLineNumber()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section = 
                (UrlsSection)config.GetSection("MyUrls");

            // Get the collection element.
            UrlsCollection urls = section.Urls;

            int ln =
                urls.ElementInformation.LineNumber;
            Console.WriteLine("Urls element line number: {0}",
                ln.ToString());

        }
        // </Snippet84>

        // <Snippet85>
        static public void GetElementProperties()
        {
 
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            // Get the element properties.
            PropertyInformationCollection properties =
                url.ElementInformation.Properties;

            foreach (PropertyInformation prop in properties)
            {
                Console.WriteLine(
                    "Name: {0} Type: {1}", prop.Name,
                    prop.Type.ToString());
            }
           
        }
        // </Snippet85>

        // <Snippet86>
        static public void GetElementSource()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            // Get the element source file.
            string sourceFile =
                url.ElementInformation.Source;

            Console.WriteLine("Url element source file: {0}",
                            sourceFile);
            
        }
        // </Snippet86>

        // <Snippet87>
        static public void GetElementType()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            // Get the element type.
            Type elType =
                url.ElementInformation.Type;

            Console.WriteLine("Url element type: {0}",
                            elType.ToString());

        }
        // </Snippet87>

        // <Snippet88>
        static public void GetElementValidator()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            // Get the element source file.
            ConfigurationValidatorBase elValidator =
                url.ElementInformation.Validator;

            Console.WriteLine("Url element validator: {0}",
                            elValidator.ToString());

        }
        // </Snippet88>

        // <Snippet89>
        static public void GetElementErrors()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            // Get the errors.
            ICollection errors = 
                url.ElementInformation.Errors;
            Console.WriteLine("Number of errors: {0)",
                errors.Count.ToString());
            
        }
        // </Snippet89>
    }
}
