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