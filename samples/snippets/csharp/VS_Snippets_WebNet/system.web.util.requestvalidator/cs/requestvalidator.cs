//<Snippet1>
using System;
using System.Web;
using System.Web.Util;


public class CustomRequestValidation : RequestValidator
{
    public CustomRequestValidation() { }

    protected override bool IsValidRequestString(
        HttpContext context, string value,
        RequestValidationSource requestValidationSource, string collectionKey,
        out int validationFailureIndex)
      {
        validationFailureIndex = -1;  //Set a default value for the out parameter.

        //This application does not use RawUrl directly so you can ignore the check.
        if (requestValidationSource == RequestValidationSource.RawUrl)
            return true;

        //Allow the query-string key data to have a value that is formatted like XML.
        if ((requestValidationSource == RequestValidationSource.QueryString) &&
            (collectionKey == "data"))
        {
            //The querystring value "<example>1234</example>" is allowed.
            if (value == "<example>1234</example>")
            {
                validationFailureIndex = -1;
                return true;
            }
            else
                //Leave any further checks to ASP.NET.
                return base.IsValidRequestString(context, value,
                requestValidationSource,
                collectionKey, out validationFailureIndex);
        }
        //All other HTTP input checks are left to the base ASP.NET implementation.
        else
        {
            return base.IsValidRequestString(context, value, requestValidationSource,
                                             collectionKey, out validationFailureIndex);
        }
    }
}
//</Snippet1>
