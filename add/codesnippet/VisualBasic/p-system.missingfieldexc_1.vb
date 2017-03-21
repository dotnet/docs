        Try
            ' Attempt to access a static AField field defined in the App class.
            ' However, because the App class does not define this field, 
            ' a MissingFieldException is thrown.
            GetType(App).InvokeMember("AField", BindingFlags.Static Or BindingFlags.SetField, _
                                       Nothing, Nothing, New [Object]() {5})
        Catch e As MissingFieldException
            ' Show the user that the AField field cannot be accessed.
            Console.WriteLine("Unable to access the AField field: {0}", e.Message)
        End Try