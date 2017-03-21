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