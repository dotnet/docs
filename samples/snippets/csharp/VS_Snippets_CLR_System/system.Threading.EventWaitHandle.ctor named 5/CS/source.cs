//<Snippet1>
using System;
using System.Threading;
using System.Security.AccessControl;

internal class Example
{
    internal static void Main()
    {
        //<Snippet2>
        const string ewhName = "EventWaitHandleExample5";

        EventWaitHandle ewh = null;
        bool doesNotExist = false;
        bool unauthorized = false;

        // The value of this variable is set by the event
        // constructor. It is true if the named system event was
        // created, and false if the named event already existed.
        //
        bool wasCreated;

        // Attempt to open the named event.
        try
        {
            // Open the event with (EventWaitHandleRights.Synchronize
            // | EventWaitHandleRights.Modify), to wait on and 
            // signal the named event.
            //
            ewh = EventWaitHandle.OpenExisting(ewhName);
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            Console.WriteLine("Named event does not exist.");
            doesNotExist = true;
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Unauthorized access: {0}", ex.Message);
            unauthorized = true;
        }
        //</Snippet2>

        // There are three cases: (1) The event does not exist.
        // (2) The event exists, but the current user doesn't 
        // have access. (3) The event exists and the user has
        // access.
        //
        if (doesNotExist)
        {
            //<Snippet4>
            // The event does not exist, so create it.

            // Create an access control list (ACL) that denies the
            // current user the right to wait on or signal the 
            // event, but allows the right to read and change
            // security information for the event.
            //
            string user = Environment.UserDomainName + "\\"
                + Environment.UserName;
            EventWaitHandleSecurity ewhSec = 
                new EventWaitHandleSecurity();

            EventWaitHandleAccessRule rule = 
                new EventWaitHandleAccessRule(user, 
                    EventWaitHandleRights.Synchronize | 
                    EventWaitHandleRights.Modify, 
                    AccessControlType.Deny);
            ewhSec.AddAccessRule(rule);

            rule = new EventWaitHandleAccessRule(user, 
                EventWaitHandleRights.ReadPermissions | 
                EventWaitHandleRights.ChangePermissions, 
                AccessControlType.Allow);
            ewhSec.AddAccessRule(rule);

            // Create an EventWaitHandle object that represents
            // the system event named by the constant 'ewhName', 
            // initially signaled, with automatic reset, and with
            // the specified security access. The Boolean value that 
            // indicates creation of the underlying system object
            // is placed in wasCreated.
            //
            ewh = new EventWaitHandle(true, 
                EventResetMode.AutoReset, 
                ewhName, 
                out wasCreated, 
                ewhSec);

            // If the named system event was created, it can be
            // used by the current instance of this program, even 
            // though the current user is denied access. The current
            // program owns the event. Otherwise, exit the program.
            // 
            if (wasCreated)
            {
                Console.WriteLine("Created the named event.");
            }
            else
            {
                Console.WriteLine("Unable to create the event.");
                return;
            }
            //</Snippet4>
        }
        else if (unauthorized)
        {
            //<Snippet3>
            // Open the event to read and change the access control
            // security. The access control security defined above
            // allows the current user to do this.
            //
            try
            {
                ewh = EventWaitHandle.OpenExisting(ewhName, 
                    EventWaitHandleRights.ReadPermissions | 
                    EventWaitHandleRights.ChangePermissions);

                // Get the current ACL. This requires 
                // EventWaitHandleRights.ReadPermissions.
                EventWaitHandleSecurity ewhSec = ewh.GetAccessControl();
                
                string user = Environment.UserDomainName + "\\"
                    + Environment.UserName;

                // First, the rule that denied the current user 
                // the right to enter and release the event must
                // be removed.
                EventWaitHandleAccessRule rule = 
                    new EventWaitHandleAccessRule(user, 
                        EventWaitHandleRights.Synchronize | 
                        EventWaitHandleRights.Modify, 
                        AccessControlType.Deny);
                ewhSec.RemoveAccessRule(rule);

                // Now grant the user the correct rights.
                // 
                rule = new EventWaitHandleAccessRule(user, 
                    EventWaitHandleRights.Synchronize | 
                    EventWaitHandleRights.Modify, 
                    AccessControlType.Allow);
                ewhSec.AddAccessRule(rule);

                // Update the ACL. This requires
                // EventWaitHandleRights.ChangePermissions.
                ewh.SetAccessControl(ewhSec);

                Console.WriteLine("Updated event security.");

                // Open the event with (EventWaitHandleRights.Synchronize 
                // | EventWaitHandleRights.Modify), the rights required
                // to wait on and signal the event.
                //
                ewh = EventWaitHandle.OpenExisting(ewhName);
                //</Snippet3>

            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Unable to change permissions: {0}",
                    ex.Message);
                return;
            }

        }

        // Wait on the event, and hold it until the program
        // exits.
        //
        try
        {
            Console.WriteLine("Wait on the event.");
            ewh.WaitOne();
            Console.WriteLine("Event was signaled.");
            Console.WriteLine("Press the Enter key to signal the event and exit.");
            Console.ReadLine();
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Unauthorized access: {0}", ex.Message);
        }
        finally
        {
            ewh.Set();
        }
    }
}
//</Snippet1>


