//<Snippet1>
using System;
using System.Threading;
using System.Security.AccessControl;

internal class Example
{
    internal static void Main()
    {
        //<Snippet2>
        const string semaphoreName = "SemaphoreExample5";

        Semaphore sem = null;
        bool doesNotExist = false;
        bool unauthorized = false;

        // Attempt to open the named semaphore.
        try
        {
            // Open the semaphore with (SemaphoreRights.Synchronize
            // | SemaphoreRights.Modify), to enter and release the
            // named semaphore.
            //
            sem = Semaphore.OpenExisting(semaphoreName);
        }
        catch(WaitHandleCannotBeOpenedException)
        {
            Console.WriteLine("Semaphore does not exist.");
            doesNotExist = true;
        }
        catch(UnauthorizedAccessException ex)
        {
            Console.WriteLine("Unauthorized access: {0}", ex.Message);
            unauthorized = true;
        }
        //</Snippet2>

        // There are three cases: (1) The semaphore does not exist.
        // (2) The semaphore exists, but the current user doesn't 
        // have access. (3) The semaphore exists and the user has
        // access.
        //
        if (doesNotExist)
        {
            //<Snippet4>
            // The semaphore does not exist, so create it.
            //
            // The value of this variable is set by the semaphore
            // constructor. It is true if the named system semaphore was
            // created, and false if the named semaphore already existed.
            //
            bool semaphoreWasCreated;

            // Create an access control list (ACL) that denies the
            // current user the right to enter or release the 
            // semaphore, but allows the right to read and change
            // security information for the semaphore.
            //
            string user = Environment.UserDomainName + "\\" 
                + Environment.UserName;
            SemaphoreSecurity semSec = new SemaphoreSecurity();

            SemaphoreAccessRule rule = new SemaphoreAccessRule(
                user, 
                SemaphoreRights.Synchronize | SemaphoreRights.Modify, 
                AccessControlType.Deny);
            semSec.AddAccessRule(rule);

            rule = new SemaphoreAccessRule(
                user, 
                SemaphoreRights.ReadPermissions | SemaphoreRights.ChangePermissions,
                AccessControlType.Allow);
            semSec.AddAccessRule(rule);

            // Create a Semaphore object that represents the system
            // semaphore named by the constant 'semaphoreName', with
            // maximum count three, initial count three, and the
            // specified security access. The Boolean value that 
            // indicates creation of the underlying system object is
            // placed in semaphoreWasCreated.
            //
            sem = new Semaphore(3, 3, semaphoreName, 
                out semaphoreWasCreated, semSec);

            // If the named system semaphore was created, it can be
            // used by the current instance of this program, even 
            // though the current user is denied access. The current
            // program enters the semaphore. Otherwise, exit the
            // program.
            // 
            if (semaphoreWasCreated)
            {
                Console.WriteLine("Created the semaphore.");
            }
            else
            {
                Console.WriteLine("Unable to create the semaphore.");
                return;
            }
            //</Snippet4>

        }
        else if (unauthorized)
        {
            //<Snippet3>
            // Open the semaphore to read and change the access
            // control security. The access control security defined
            // above allows the current user to do this.
            //
            try
            {
                sem = Semaphore.OpenExisting(
                    semaphoreName, 
                    SemaphoreRights.ReadPermissions 
                        | SemaphoreRights.ChangePermissions);

                // Get the current ACL. This requires 
                // SemaphoreRights.ReadPermissions.
                SemaphoreSecurity semSec = sem.GetAccessControl();
                
                string user = Environment.UserDomainName + "\\" 
                    + Environment.UserName;

                // First, the rule that denied the current user 
                // the right to enter and release the semaphore must
                // be removed.
                SemaphoreAccessRule rule = new SemaphoreAccessRule(
                    user, 
                    SemaphoreRights.Synchronize | SemaphoreRights.Modify, 
                    AccessControlType.Deny);
                semSec.RemoveAccessRule(rule);

                // Now grant the user the correct rights.
                // 
                rule = new SemaphoreAccessRule(user, 
                     SemaphoreRights.Synchronize | SemaphoreRights.Modify, 
                     AccessControlType.Allow);
                semSec.AddAccessRule(rule);

                // Update the ACL. This requires
                // SemaphoreRights.ChangePermissions.
                sem.SetAccessControl(semSec);

                Console.WriteLine("Updated semaphore security.");

                // Open the semaphore with (SemaphoreRights.Synchronize 
                // | SemaphoreRights.Modify), the rights required to
                // enter and release the semaphore.
                //
                sem = Semaphore.OpenExisting(semaphoreName);
                //</Snippet3>

            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine("Unable to change permissions: {0}", ex.Message);
                return;
            }
        }

        // Enter the semaphore, and hold it until the program
        // exits.
        //
        try
        {
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore.");
            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();
            sem.Release();
        }
        catch(UnauthorizedAccessException ex)
        {
            Console.WriteLine("Unauthorized access: {0}", ex.Message);
        }
    }
}
//</Snippet1>


