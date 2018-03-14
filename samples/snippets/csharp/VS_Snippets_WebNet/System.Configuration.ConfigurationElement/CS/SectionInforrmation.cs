// File name: SectionInformation.cs
// Allowed snippet tags range: [91 - 120].

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Samples.AspNet
{
    class UsingSectionInformation
    {

        // <Snippet91>
        static public SectionInformation 
            GetSectionInformation()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            
            SectionInformation sInfo = 
                section.SectionInformation;

            return sInfo;

        }
        // </Snippet91>

        // <Snippet92>
        static public void GetParentSection()
        {
            SectionInformation sInfo = 
                GetSectionInformation();

            ConfigurationSection parentSection =
                sInfo.GetParentSection();

            Console.WriteLine("Parent section : {0}",
                parentSection.SectionInformation.Name);

        }
        // </Snippet92>

        // <Snippet93>
        static public void GetSectionXml()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionXml =
                sInfo.GetRawXml();

            Console.WriteLine("Section xml:");
            Console.WriteLine(sectionXml);

        }
        // </Snippet93>

        // <Snippet94>
        static public void ProtectSection()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");


            // Protect (encrypt)the section.
            section.SectionInformation.ProtectSection(
                "RsaProtectedConfigurationProvider");

            // Save the encrypted section.
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);

            // Display decrypted configuration 
            // section. Note, the system
            // uses the Rsa provider to decrypt
            // the section transparently.
            string sectionXml =
                section.SectionInformation.GetRawXml();

            Console.WriteLine("Decrypted section:");
            Console.WriteLine(sectionXml);

        }
        // </Snippet94>

        static public void GetAllowProperties()
        {

            // <Snippet95>
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");


            SectionInformation sInfo =
                section.SectionInformation;
            // </Snippet95>

            // <Snippet96>  
            ConfigurationAllowDefinition allowDefinition =
                sInfo.AllowDefinition;
            Console.WriteLine("Allow definition: {0}", 
                allowDefinition.ToString() );
            // </Snippet96>  

            // <Snippet97>  
            ConfigurationAllowExeDefinition allowExeDefinition =
                            sInfo.AllowExeDefinition;
            Console.WriteLine("Allow exe definition: {0}",
               allowExeDefinition.ToString());
            // </Snippet97>  

            // <Snippet98>  
            bool allowLocation =
                sInfo.AllowLocation;
            Console.WriteLine("Allow location: {0}",
                           allowLocation.ToString());
            // </Snippet98>  

            // <Snippet99>  
            bool allowOverride =
                sInfo.AllowOverride;
            Console.WriteLine("Allow override: {0}",
                           allowOverride.ToString());
            // </Snippet99>  
           
        }

        // <Snippet100>  
        static public void GetInheritInChildApps()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            bool inheritInChildApps =
                sInfo.InheritInChildApplications;
            Console.WriteLine("Inherit in child apps: {0}",
                inheritInChildApps.ToString());

        }
        // </Snippet100>  
       
        static public void GetIsProperties()
        {
            // <Snippet102>
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");


            SectionInformation sInfo =
                section.SectionInformation;
            // </Snippet102>

            // <Snippet103>
            bool declRequired = 
                sInfo.IsDeclarationRequired;
            Console.WriteLine("Declaration required?: {0}",
                declRequired.ToString());
            // </Snippet103>

            // <Snippet104>
            bool declared =
                sInfo.IsDeclared;
            Console.WriteLine("Section declared?: {0}",
                declared.ToString());
            // </Snippet104>

            // <Snippet105>
            bool locked =
               sInfo.IsLocked;
            Console.WriteLine("Section locked?: {0}",
                locked.ToString());
            // </Snippet105>

            // <Snippet106>
            bool protect =
                sInfo.IsProtected;
            Console.WriteLine("Section protected?: {0}",
                protect.ToString());
            // </Snippet106>
           
        }

        // <Snippet107>
        static public void GetSectionNameProperty()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionNameProperty = sInfo.Name;
            Console.WriteLine("Section name: {0}", 
                sectionNameProperty);

        }
        // </Snippet107>


        // <Snippet108>
        static public void GetProtectionProvider()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            ProtectedConfigurationProvider pp = 
                sInfo.ProtectionProvider;
            if (pp == null)
                Console.WriteLine("Protection provider is null");
            else
                Console.WriteLine("Protection provider: {0}", 
                    pp.ToString());

        }
        // </Snippet108>


        // <Snippet109>
        static public void RestartOnExternalChanges()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            bool restartOnChange = 
                sInfo.RestartOnExternalChanges;
            Console.WriteLine("Section type: {0}", 
                restartOnChange.ToString());

        }
        // </Snippet109>

        // <Snippet110>
        static public void GetSectionName()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionName = sInfo.SectionName;
            Console.WriteLine("Section type: {0}", sectionName);

        }
        // </Snippet110>


        // <Snippet111>
        static public void GetSectionType()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionType = sInfo.Type;
            Console.WriteLine("Section type: {0}", sectionType);

        }
        // </Snippet111>


        // <Snippet112>
        static public void UnProtectSection()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");


            // Unprotect (decrypt)the section.
            section.SectionInformation.UnprotectSection();

            // <Snippet113>
            // Force the section information to be written to
            // the configuration file.
            section.SectionInformation.ForceDeclaration(true);
            // </Snippet113>

            // Save the decrypted section.
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);

            // Display the decrypted configuration 
            // section. 
            string sectionXml =
                section.SectionInformation.GetRawXml();

            Console.WriteLine("Decrypted section:");
            Console.WriteLine(sectionXml);

        }
        // </Snippet112>
           
    }
}
