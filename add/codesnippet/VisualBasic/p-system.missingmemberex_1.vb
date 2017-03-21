        Try
            ' Attempt to access a static AnotherField field defined in the App class.
            ' However, because the App class does not define this field, 
            ' a MissingFieldException is thrown.
            GetType(App).InvokeMember("AnotherField", BindingFlags.Static Or BindingFlags.GetField, _
                                       Nothing, Nothing, Nothing)
        Catch e As MissingMemberException
            ' Notice that this code is catching MissingMemberException which is the  
            ' base class of MissingMethodException and MissingFieldException.
            ' Show the user that the AnotherField field cannot be accessed.
            Console.WriteLine("Unable to access the AnotherField field: {0}", e.Message)
        End Try
    End Sub 