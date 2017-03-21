                sc.Continue()
                While sc.Status = ServiceControllerStatus.Paused
                    Thread.Sleep(1000)
                    sc.Refresh()
                End While
                Console.WriteLine("Status = " + sc.Status.ToString())