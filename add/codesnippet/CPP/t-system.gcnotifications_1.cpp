    public:
        static void WaitForFullGCProc()
        {
            while (true)
            {
                // CheckForNotify is set to true and false in Main.
                while (checkForNotify)
                {
                    // Check for a notification of an approaching collection.
                    GCNotificationStatus s = GC::WaitForFullGCApproach();
                    if (s == GCNotificationStatus::Succeeded)
                    {
                        Console::WriteLine("GC Notifiction raised.");
                        OnFullGCApproachNotify();
                    }
                    else if (s == GCNotificationStatus::Canceled)
                    {
                        Console::WriteLine("GC Notification cancelled.");
                        break;
                    }
                    else
                    {
                        // This can occur if a timeout period
                        // is specified for WaitForFullGCApproach(Timeout)
                        // or WaitForFullGCComplete(Timeout)
                        // and the time out period has elapsed.
                        Console::WriteLine("GC Notification not applicable.");
                        break;
                    }

                    // Check for a notification of a completed collection.
                    s = GC::WaitForFullGCComplete();
                    if (s == GCNotificationStatus::Succeeded)
                    {
                        Console::WriteLine("GC Notification raised.");
                        OnFullGCCompleteEndNotify();
                    }
                    else if (s == GCNotificationStatus::Canceled)
                    {
                        Console::WriteLine("GC Notification cancelled.");
                        break;
                    }
                    else
                    {
                        // Could be a time out.
                        Console::WriteLine("GC Notification not applicable.");
                        break;
                    }
                }


                Thread::Sleep(500);
                // FinalExit is set to true right before
                // the main thread cancelled notification.
                if (finalExit)
                {
                    break;
                }
            }
        }