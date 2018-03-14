using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;


class UsingPassportAuthentication
{

public UsingPassportAuthentication()
{
// <Snippet1>

// Get the configuration.
// Get the Web application configuration.
System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

// Get the section.
System.Web.Configuration.AuthenticationSection authenticationSection = (System.Web.Configuration.AuthenticationSection)configuration.GetSection("system.web/authentication");

// Get the authentication passport element.
PassportAuthentication passport = authenticationSection.Passport;

// </Snippet1>


// <Snippet2>

// Create a new passport object.
PassportAuthentication newPassport = new PassportAuthentication();

// </Snippet2>

// <Snippet3>

// Get the passport redirect URL
string redirectUrl = passport.RedirectUrl;

// Set passport redirect Url.
passport.RedirectUrl = "passportLogin.aspx";

if (!authenticationSection.SectionInformation.IsLocked)
  configuration.Save();

// </Snippet3>

}

}

