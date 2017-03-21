Application.Lock()
Application("MyCode") = 21
Application("MyCount") = Convert.ToInt32(Application("MyCount")) + 1
Application.UnLock()