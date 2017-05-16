//<Snippet1>
using System;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;

public class Example
{
    public static void Main()
    {
        // Create a string representing the current user.
        string user = Environment.UserDomainName + "\\" + 
            Environment.UserName;

        // Create a security object that grants no access.
        SemaphoreSecurity mSec = new SemaphoreSecurity();

        // Add a rule that grants the current user the 
        // right to enter or release the semaphore.
        SemaphoreAccessRule rule = new SemaphoreAccessRule(user, 
            SemaphoreRights.Synchronize | SemaphoreRights.Modify, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Add a rule that denies the current user the 
        // right to change permissions on the semaphore.
        rule = new SemaphoreAccessRule(user, 
            SemaphoreRights.ChangePermissions, 
            AccessControlType.Deny);
        mSec.AddAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Add a rule that allows the current user the 
        // right to read permissions on the semaphore. This rule
        // is merged with the existing Allow rule.
        rule = new SemaphoreAccessRule(user, 
            SemaphoreRights.ReadPermissions, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        ShowSecurity(mSec);

        // Create a rule that allows the current user to
        // change the owner of the semaphore, and use that rule 
        // to remove the existing allow access rule from 
        // the SemaphoreSecurity object, showing that the user
        // and access type must match, while the rights are
        // ignored.
        Console.WriteLine("Use RemoveAccessRuleAll to remove the Allow rule.");
        rule = new SemaphoreAccessRule(user, 
            SemaphoreRights.TakeOwnership, 
            AccessControlType.Allow);
        mSec.RemoveAccessRuleAll(rule);

        ShowSecurity(mSec);
    }

    private static void ShowSecurity(SemaphoreSecurity security)
    {
        Console.WriteLine("\r\nCurrent access rules:\r\n");

        foreach(SemaphoreAccessRule ar in 
            security.GetAccessRules(true, true, typeof(NTAccount)))
        {
            Console.WriteLine("        User: {0}", ar.IdentityReference);
            Console.WriteLine("        Type: {0}", ar.AccessControlType);
            Console.WriteLine("      Rights: {0}", ar.SemaphoreRights);
            Console.WriteLine();
        }
    }
}

/*This code example produces output similar to following:

Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions

        User: TestDomain\TestUser
        Type: Allow
      Rights: Modify, Synchronize


Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions

        User: TestDomain\TestUser
        Type: Allow
      Rights: Modify, ReadPermissions, Synchronize

Use RemoveAccessRuleAll to remove the Allow rule.

Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions
 */
//</Snippet1>
