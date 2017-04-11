using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
  // Accesses the System.Web.Configuration.CustomError members selected by the user.
    class UsingCustomError
    {

        public static void Main()
        {

            // <Snippet1>

            // Get the Web application configuration.
            Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the section.
            CustomErrorsSection customErrors =
                (CustomErrorsSection)configuration.GetSection(
              "system.web/customErrors");

            // Get the collection.
            CustomErrorCollection customErrorsCollection =
                customErrors.Errors;

            // </Snippet1>


            // <Snippet2>
            // Create a new error object.
            // Does not exist anymore.
            // CustomError newcustomError = new CustomError();

            // </Snippet2>


            // <Snippet3>
            // Create a new error object.
            CustomError newcustomError2 =
                new CustomError(404, "customerror404.htm");
            // </Snippet3>


            // <Snippet4>
            // Get first errorr Redirect.
            CustomError currentError0 =
                customErrorsCollection[0];
            string currentRedirect =
                currentError0.Redirect;

            // Set first error Redirect.
            currentError0.Redirect =
                "customError404.htm";

            // </Snippet4>

            // <Snippet5>
            // Get second error StatusCode.
            CustomError currentError1 =
                customErrorsCollection[1];
            int currentStatusCode =
                currentError1.StatusCode;

            // Set the second error StatusCode.
            currentError1.StatusCode = 404;

            // </Snippet5>

        }

    }

} 

