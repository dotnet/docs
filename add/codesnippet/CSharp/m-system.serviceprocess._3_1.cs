                    sc.Pause();
                    while (sc.Status != ServiceControllerStatus.Paused)
                    {
                        Thread.Sleep(1000);
                        sc.Refresh();
                    }
                    Console.WriteLine("Status = " + sc.Status);