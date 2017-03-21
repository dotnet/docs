        Try
            ' Attempt to call a static DoSomething method defined in the App class.
            ' However, because the App class does not define this method, 
            ' a MissingMethodException is thrown.
            GetType(App).InvokeMember("DoSomething", BindingFlags.Static Or BindingFlags.InvokeMethod, _
                                       Nothing, Nothing, Nothing)
        Catch e As MissingMethodException
            ' Show the user that the DoSomething method cannot be called.
            Console.WriteLine("Unable to call the DoSomething method: {0}", e.Message)
        End Try