using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.AspNet.Configuration
{
  // Accesses the System.Web.Configuration.CustomErrorsSection
  // members selected by the user.
    class UsingCustomErrorsSection
    {


        public static void Main()
        {

            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the section.
            CustomErrorsSection customErrorsSection =
              (CustomErrorsSection)configuration.GetSection(
              "system.web/customErrors");

            // Get the collection
            CustomErrorCollection customErrorsCollection = 
                customErrorsSection.Errors;

            // </Snippet1>


            // <Snippet2>
            // Create a new CustomErrorCollection object.
            CustomErrorCollection newcustomErrorCollection = 
                new System.Web.Configuration.CustomErrorCollection();

            // </Snippet2>


            // <Snippet3>
            // Get the currentDefaultRedirect
            string currentDefaultRedirect = 
                customErrorsSection.DefaultRedirect;

            // </Snippet3>

            // <Snippet4>
            // Using the Set method.
            CustomError newCustomError =
            new CustomError(404, "customerror404.htm");

            // Update the configuration file.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Add the new custom error to the collection.
                customErrorsCollection.Set(newCustomError);
                configuration.Save();
            }

            // </Snippet4>

            // <Snippet5>
            // Using the Add method.
            CustomError newCustomError2 =
            new CustomError(404, "customerror404.htm");

            // Update the configuration file.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Add the new custom error to the collection.
                customErrorsCollection.Add(newCustomError2);
                configuration.Save();
            }

            // </Snippet5>


            // <Snippet6>
            // Using the Clear method.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Execute the Clear method.
                customErrorsCollection.Clear();
                configuration.Save();
            }

            // </Snippet6>

            // <Snippet7>
            // Using the Remove method.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Remove the error with statuscode 404.
                customErrorsCollection.Remove("404");
                configuration.Save();
            }

            // </Snippet7>


            // <Snippet8>
            // Using method RemoveAt.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Remove the error at 0 index
                customErrorsCollection.RemoveAt(0);
                configuration.Save();
            }

            // </Snippet8>


            // <Snippet9>
            // Get the current Mode.
            CustomErrorsMode currentMode = 
                customErrorsSection.Mode;

            // Set the current Mode.
            customErrorsSection.Mode = 
                CustomErrorsMode.RemoteOnly;

            // </Snippet9>

            // <Snippet10>
            // Get the error with collection index 0.
            CustomError customError = 
                customErrorsCollection[0];

            // </Snippet10>

            // <Snippet11>
            // Get the error with status code 404.
            CustomError customError1 = 
                customErrorsCollection["404"];

            // </Snippet11>

            // <Snippet12>
            // Create a new CustomErrorsSection object.
            CustomErrorsSection newcustomErrorsSection =
                new CustomErrorsSection();

            // </Snippet12>


        }
    }

} 

