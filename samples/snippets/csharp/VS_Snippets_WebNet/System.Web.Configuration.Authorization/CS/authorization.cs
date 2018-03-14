using System;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
// Accesses the System.Web.Configuration.AuthorizationSection
// members selected by the user.
    class UsingAuthorizationSection
    {

        public static void Main()
        {

            // <Snippet1>
            // Get the Web application configuration.
            System.Configuration.Configuration configuration = 
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");
            // </Snippet1>

            // <Snippet2>
            // Get the section.
            AuthorizationSection authorizationSection = 
                (AuthorizationSection)configuration.GetSection(
                "system.web/authorization");
            // </Snippet2>

            // <Snippet3>
            // Get the authorization rule collection.
            AuthorizationRuleCollection authorizationRuleCollection = 
                authorizationSection.Rules;
            // </Snippet3>

            // <Snippet4>
            // Create an authorization rule object.
            AuthorizationRuleAction action =
                AuthorizationRuleAction.Deny;
            AuthorizationRule authorizationRule = 
                new System.Web.Configuration.AuthorizationRule(action);
            // </Snippet4>


            // <Snippet5>
            // Create a new 'AuthorizationSection' object.
           AuthorizationSection newauthorizationSection = 
               new System.Web.Configuration.AuthorizationSection();

            // </Snippet5>


            // <Snippet6>
            // Using the AuthorizationRuleCollection Add method.
           
            // Set the action property.
            authorizationRule.Action = 
               AuthorizationRuleAction.Allow;
            // Define the new rule to add to the collection.
            authorizationRule.Users.Add("userName");
            authorizationRule.Roles.Add("admin");
            authorizationRule.Verbs.Add("POST");

            // Add the new rule to the collection.
            authorizationSection.Rules.Add(authorizationRule);
            // </Snippet6>

            // <Snippet7>
            // Using the AuthorizationRuleCollection Clear method.
            authorizationSection.Rules.Clear();
            // </Snippet7>

            // <Snippet8>
            // Using the AuthorizationRuleCollection RemoveAt method.
            authorizationRuleCollection.RemoveAt(0);
            // </Snippet8>

            // <Snippet9>
            // Get the rule collection index.
            System.Int32 ruleIndex = 
                authorizationSection.Rules.IndexOf(authorizationRule);
            // </Snippet9>

            // <Snippet10>
            // Remove the rule from the collection.
            authorizationSection.Rules.Remove(authorizationRule);

            // </Snippet10>

            // <Snippet11>
            // Using the AuthorizationRuleCollection Set method.

            // Define the rule to add to the collection.

            // Define the collection index.
            System.Int32 rIndex = 0;

            // Set the rule in the collection.
            authorizationRuleCollection.Set(rIndex, 
                authorizationRule);
            // </Snippet11>


            // <Snippet12>
            // Show how to access the Rules elements.
            StringBuilder rules = new StringBuilder();
            for (System.Int32 i = 0; 
                i < authorizationSection.Rules.Count - 1; i++)
            {
                rules.Append("Action: " + 
                    authorizationSection.Rules[i].Action.ToString());

                // Get the Verbs.
                System.Int32 verbsCount = 
                    authorizationSection.Rules[i].Verbs.Count;
                for (System.Int32 v = 0; v < verbsCount; v++)
                    rules.AppendLine(
                        authorizationSection.Rules[i].Verbs[v]);

                // Get the Roles.
                System.Int32 rolesCount = 
                    authorizationSection.Rules[i].Roles.Count;
                for (System.Int32 r = 0; r < rolesCount; r++)
                    rules.AppendLine(authorizationSection.Rules[i].Roles[r]);

                // Get the Users.
                System.Int32 usersCount = 
                    authorizationSection.Rules[i].Users.Count;
                for (System.Int32 u = 0; u < usersCount; u++)
                    rules.AppendLine(authorizationSection.Rules[i].Users[u]);
            }

            // </Snippet12>

            // <Snippet13>
            // Using the AuthorizationRuleCollection Get method.
            AuthorizationRule authRule = 
                authorizationRuleCollection.Get(0);
            // </Snippet13>


        }

    }


} 

