// <Snippet1>
using System;
using System.Collections.Generic;
using System.Threading;

namespace GCNotify
{
    class Program
    {
        // Variable for continual checking in the
        // While loop in the WaitForFullGCProc method.
        static bool checkForNotify = false;

        // Variable for suspending work
        // (such servicing allocated server requests)
        // after a notification is received and then
        // resuming allocation after inducing a garbage collection.
        static bool bAllocate = false;

        // Variable for ending the example.
        static bool finalExit = false;

        // Collection for objects that
        // simulate the server request workload.
        static List<byte[]> load = new List<byte[]>();

        // <Snippet2>
        public static void Main(string[] args)
        {
            try
            {
                // Register for a notification.
                GC.RegisterForFullGCNotification(10, 10);
                Console.WriteLine("Registered for GC notification.");

                checkForNotify = true;
                bAllocate = true;

                // Start a thread using WaitForFullGCProc.
                Thread thWaitForFullGC = new Thread(new ThreadStart(WaitForFullGCProc));
                thWaitForFullGC.Start();

                // While the thread is checking for notifications in
                // WaitForFullGCProc, create objects to simulate a server workload.
                try
                {

                    int lastCollCount = 0;
                    int newCollCount = 0;

                    while (true)
                    {
                        if (bAllocate)
                        {
                            load.Add(new byte[1000]);
                            newCollCount = GC.CollectionCount(2);
                            if (newCollCount != lastCollCount)
                            {
                                // Show collection count when it increases:
                                Console.WriteLine($"Gen 2 collection count: {GC.CollectionCount(2).ToString()}");
                                lastCollCount = newCollCount;
                            }

                            // For ending the example (arbitrary).
                            if (newCollCount == 500)
                            {
                                finalExit = true;
                                checkForNotify = false;
                                break;
                            }
                        }
                    }
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Out of memory.");
                }

                // <Snippet7>
                finalExit = true;
                checkForNotify = false;
                GC.CancelFullGCNotification();
                // </Snippet7>
            }
            catch (InvalidOperationException invalidOp)
            {

                Console.WriteLine("GC Notifications are not supported while concurrent GC is enabled.\n"
                    + invalidOp.Message);
            }
        }
        // </Snippet2>

        // <Snippet5>
        public static void OnFullGCApproachNotify()
        {

            Console.WriteLine("Redirecting requests.");

            // Method that tells the request queuing
            // server to not direct requests to this server.
            RedirectRequests();

            // Method that provides time to
            // finish processing pending requests.
            FinishExistingRequests();

            // This is a good time to induce a GC collection
            // because the runtime will induce a full GC soon.
            // To be very careful, you can check precede with a
            // check of the GC.GCCollectionCount to make sure
            // a full GC did not already occur since last notified.
            GC.Collect();
            Console.WriteLine("Induced a collection.");
        }
        // </Snippet5>

        // <Snippet6>
        public static void OnFullGCCompleteEndNotify()
        {
            // Method that informs the request queuing server
            // that this server is ready to accept requests again.
            AcceptRequests();
            Console.WriteLine("Accepting requests again.");
        }
        // </Snippet6>

        // <Snippet8>
        public static void WaitForFullGCProc()
        {
            while (true)
            {
                // CheckForNotify is set to true and false in Main.
                while (checkForNotify)
                {
                    // <Snippet3>
                    // Check for a notification of an approaching collection.
                    GCNotificationStatus s = GC.WaitForFullGCApproach();
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        Console.WriteLine("GC Notification raised.");
                        OnFullGCApproachNotify();
                    }
                    else if (s == GCNotificationStatus.Canceled)
                    {
                        Console.WriteLine("GC Notification cancelled.");
                        break;
                    }
                    else
                    {
                        // This can occur if a timeout period
                        // is specified for WaitForFullGCApproach(Timeout)
                        // or WaitForFullGCComplete(Timeout)
                        // and the time out period has elapsed.
                        Console.WriteLine("GC Notification not applicable.");
                        break;
                    }
                    // </Snippet3>

                    // <Snippet4>
                    // Check for a notification of a completed collection.
                    GCNotificationStatus status = GC.WaitForFullGCComplete();
                    if (status == GCNotificationStatus.Succeeded)
                    {
                        Console.WriteLine("GC Notification raised.");
                        OnFullGCCompleteEndNotify();
                    }
                    else if (status == GCNotificationStatus.Canceled)
                    {
                        Console.WriteLine("GC Notification cancelled.");
                        break;
                    }
                    else
                    {
                        // Could be a time out.
                        Console.WriteLine("GC Notification not applicable.");
                        break;
                    }
                    // </Snippet4>
                }

                Thread.Sleep(500);
                // FinalExit is set to true right before
                // the main thread cancelled notification.
                if (finalExit)
                {
                    break;
                }
            }
        }
        // </Snippet8>

        // <Snippet9>
        private static void RedirectRequests()
        {
            // Code that sends requests
            // to other servers.

            // Suspend work.
            bAllocate = false;
        }

        private static void FinishExistingRequests()
        {
            // Code that waits a period of time
            // for pending requests to finish.

            // Clear the simulated workload.
            load.Clear();
        }

        private static void AcceptRequests()
        {
            // Code that resumes processing
            // requests on this server.

            // Resume work.
            bAllocate = true;
        }
        // </Snippet9>
    }
}
// </Snippet1>
