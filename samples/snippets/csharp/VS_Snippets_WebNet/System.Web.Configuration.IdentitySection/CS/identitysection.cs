using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
// Accesses the System.Web.Configuration.IdentitySection
// members selected by the user.
public class UsingIdentitySection
{

public UsingIdentitySection()
{

// Process the selection.
try
{

// <Snippet1>
// Get the Web application configuration.
System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

// Get the section.
System.Web.Configuration.IdentitySection identitySection = (System.Web.Configuration.IdentitySection)configuration.GetSection("system.web/identity");
// </Snippet1>


// <Snippet2>
// Create a new IdentitySection object.
System.Web.Configuration.IdentitySection newidentitySection = new System.Web.Configuration.IdentitySection();
// </Snippet2>


// <Snippet3>
// Get the Password property value.
string currentPassword = identitySection.Password;

// Set the Password property value.
identitySection.Password = "userPassword";
// </Snippet3>


// <Snippet4>
// Get the UserName property value.
string currentUserName = identitySection.UserName;

// Set the UserName property value.
identitySection.UserName = "userName";
// </Snippet4>


// <Snippet5>
// Get the Impersonate property value.
bool currentImpersonate = identitySection.Impersonate;

// Set the Impersonate property to true.
identitySection.Impersonate = true;
// </Snippet5> 

}
catch (Exception e)
{
// Unknown error.
Console.WriteLine("Error" + e.ToString());
}
}
} // UsingIdentitySection class end.

} // Samples.Aspnet.SystemWebConfiguration namespace end.

